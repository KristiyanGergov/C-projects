using MoleculeTable.Actions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Linq;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using MoleculeTable.Constants;
using MoleculeTable.Models;

namespace MoleculeTable
{
    public partial class MoleculeTableForm : Form
    {
        readonly Utility utility = new Utility();
        readonly DragRows drag = new DragRows();
        ComboBox cbm;
        private bool textBoxValidated = false;
        public MoleculeTableForm()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");
            toolTip1.SetToolTip(pickColor, "Избери цвят");
            toolTip1.SetToolTip(Create, "Въведете съединението, което искате да визуализирате");
            this.dataGridView.RowTemplate.Height = 100;
            utility.PopulateNamesComboBox(dataGridView);
        }
        private async Task PutTaskDelay()
        {
            await Task.Delay(10);
        }
        private void CheckIfFileHasCorrectExtension(object sender, CancelEventArgs e)
        {
            if (sender is SaveFileDialog sv && Path.GetExtension(sv.FileName)?.ToLower() == ".json") return;
            e.Cancel = true;
            MessageBox.Show("Моля, пропуснете разширението или използвайте 'JSON'.");
        }
        private void dataGridView_IncrementOrder(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView.Rows[e.RowIndex].Cells[5].Value = e.RowIndex + 1;
        }

        #region Buttons

        #region Add

        private void Add_Click(object sender, EventArgs e)
        {
            plus.Enabled = true;
            minus.Enabled = true;
            errorProvider1.SetError(Add, null);
            dataGridView.Rows.Add();
            utility.LinkIndexes.Add(dataGridView.RowCount.ToString());
            utility.LinkIndexes = utility.LinkIndexes
                .OrderBy(int.Parse)
                .Select(x => x.ToString())
                .ToList();
            utility.PopulateLinkIndexesComboBox(dataGridView);
        }


        #endregion
        #region Safe

        private async void Safe_Click(object sender, EventArgs e)
        {
            utility.BlinkErrors(dataGridView);
            await PutTaskDelay();
            if (!utility.ValidateForm(dataGridView, errorProvider1, Add, textBoxValidated, compoundName, false))
                return;
            saveFileDialog1.FileOk += CheckIfFileHasCorrectExtension;
            string json = utility.GetJson(dataGridView, compoundName.Text);
            saveFileDialog1.FileName = compoundName.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, json);
        }


        #endregion
        #region Create

        private void Create_Click(object sender, EventArgs e)
        {
            string compound = compoundElements.Text;

            if (string.IsNullOrEmpty(compound))
            {
                var confirmResult = MessageBox.Show
                ("Няма ново съединение, което да се създаде. Да се изтрие старото?",
                    "Потвърди изтриване!",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (confirmResult != DialogResult.Yes) return;
                plus.Enabled = false;
                minus.Enabled = false;
                utility.DeleteRows(dataGridView, compoundName);
                return;
            }
            utility.DeleteRows(dataGridView, compoundName);


            plus.Enabled = true;
            minus.Enabled = true;
            string currentElement = string.Empty;
            var allElements = new List<string>();

            for (var i = 0; i < compound.Length; i++)
            {
                var currentLetter = compound[i];

                if (!string.IsNullOrEmpty(currentElement) && char.IsUpper(currentLetter))
                {
                    allElements.Add(currentElement);
                    currentElement = currentLetter.ToString();
                }
                else if (char.IsDigit(currentLetter))
                {
                    var number = int.Parse(currentLetter.ToString());
                    while (i + 1 < compound.Length && char.IsDigit(compound[i + 1]))
                    {
                        number = 10 * number + int.Parse(compound[i + 1].ToString());
                        i++;
                    }
                    for (int j = 1; j < number; j++)
                    {
                        allElements.Add(currentElement);
                    }
                }
                else
                {
                    currentElement += currentLetter;
                }
            }
            allElements.Add(currentElement);

            for (int i = 0; i < allElements.Count; i++)
            {
                dataGridView.Rows.Add();
                utility.LinkIndexes.Add(dataGridView.RowCount.ToString());
                utility.FillRow(dataGridView, i, allElements[i]);
            }
            utility.LinkIndexes = utility.LinkIndexes
                .OrderBy(int.Parse)
                .Select(x => x.ToString())
                .ToList();
            utility.PopulateLinkIndexesComboBox(dataGridView);
        }


        #endregion
        #region Preview
        private async void Preview_Click(object sender, EventArgs e)
        {
            utility.BlinkErrors(dataGridView);
            await PutTaskDelay();

            var path = ConfigurationManager.AppSettings.Get("path") + ConfigurationManager.AppSettings.Get("exe");
            string fileName = ConfigurationManager.AppSettings.GetValues(0)[0];
            if (!File.Exists(path))
            {
                MessageBox.Show(
                    fileName + " не беше намерено!",
                    "Преглед",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (!utility.ValidateForm(dataGridView, errorProvider1, Add, textBoxValidated, compoundName, true))
                return;
            string json = utility.GetJson(dataGridView, compoundName.Text);
            string guid = Guid.NewGuid() + ".json";
            File.WriteAllText(ConfigurationManager.AppSettings.Keys[0] + guid, json);
            Process.Start(path, ConfigurationManager.AppSettings.Keys[0] + guid);
        }



        #endregion
        #region Generate

        private void Generate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            var directory = folderBrowserDialog1.SelectedPath;
            var files = Directory.GetFiles(directory)
                .Where(item => item.EndsWith("json"))
                .ToList();
            RootObject rootObject = new RootObject();
            if (files.Count == 0)
            {
                MessageBox.Show(
                    StringValues.FilesNotFound,
                    StringValues.Generate,
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                return;
            }
            IList<string> unserializableJsons = new List<string>();
            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                try
                {
                    var currentMolecule = (JsonConvert.DeserializeObject<RootObject>(json)).molecules;
                    if (currentMolecule.Count > 1)
                        throw new Exception();
                    rootObject.molecules.Add(currentMolecule.FirstOrDefault());
                }
                catch
                {
                    int last = file.LastIndexOf(@"\") + 1;
                    string unserializableFile = file.Substring(last, file.Length - last);
                    unserializableJsons.Add(unserializableFile);
                }
            }
            if (unserializableJsons.Count > 0)
            {
                MessageBox.Show(
                  StringValues.FilesContent + string.Join(Environment.NewLine, unserializableJsons),
                  StringValues.Generate,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }
            if (rootObject.molecules.Count == 0)
                return;
            saveFileDialog1.FileName = "all.json";
            saveFileDialog1.FileOk += CheckIfFileHasCorrectExtension;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string resJson = JsonConvert.SerializeObject(rootObject);

            File.WriteAllText(saveFileDialog1.FileName, resJson);
        }


        #endregion
        #region Percentage
        private void plus_Click(object sender, EventArgs e)
        {
            string text = percantage.Text;
            text = text.Substring(0, text.Length - 1);
            text = (int.Parse(text) + 10).ToString();
            percantage.Text = text + "%";

            RadiusPercantage();
        }
        private void minus_Click(object sender, EventArgs e)
        {
            string text = percantage.Text;
            text = text.Substring(0, text.Length - 1);
            text = (int.Parse(text) - 10).ToString();
            percantage.Text = text + "%";

            RadiusPercantage();
        }
        #endregion

        #endregion
        #region Dragging rows
        private void dataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            drag.dataGridView_MouseMove(dataGridView, e);
        }
        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            drag.dataGridView_MouseDown(dataGridView, e);
        }
        private void dataGridView_DragOver(object sender, DragEventArgs e)
        {
            drag.dataGridView_DragOver(e);
        }
        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {

            dataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            drag.dataGridView_DragDrop(dataGridView, e);
            var rowIndexSender = drag.ReceiverRow.Index + 1;
            var rowIndexReceiver = drag.RowSender.Index + 1;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var currentCellValue = row.Cells[StringValues.LinkIndex].Value;
                if (currentCellValue == null)
                    continue;
                if (row.Index + 1 == rowIndexSender)
                {
                    if (currentCellValue.ToString() == rowIndexSender.ToString())
                    {
                        dataGridView.Rows[rowIndexSender - 1].Cells[StringValues.LinkIndex].Value = rowIndexReceiver.ToString();
                    }
                }
                else if (row.Index + 1 == rowIndexReceiver)
                {
                    if (currentCellValue.ToString() == rowIndexReceiver.ToString())
                    {
                        dataGridView.Rows[rowIndexReceiver - 1].Cells[StringValues.LinkIndex].Value = rowIndexSender.ToString();
                    }
                }
                else
                {
                    if (currentCellValue.ToString() == rowIndexSender.ToString())
                    {
                        dataGridView.Rows[row.Index].Cells[StringValues.LinkIndex].Value = rowIndexReceiver.ToString();
                    }
                    else if (currentCellValue.ToString() == rowIndexReceiver.ToString())
                    {
                        dataGridView.Rows[row.Index].Cells[StringValues.LinkIndex].Value = rowIndexSender.ToString();
                    }
                }
            }


        }
        #endregion
        #region Combobox properties and events
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;

                if (dataGridView.CurrentCell.ColumnIndex == 0)
                {
                    cbm = (ComboBox)e.Control;
                    cbm.DropDownStyle = ComboBoxStyle.DropDown;
                    cbm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbm.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cbm.DropDownHeight = 132;
                    if (cbm != null)
                    {
                        cbm.SelectedIndexChanged += cbm_SelectedIndexChanged;
                    }
                }
                else if (dataGridView.CurrentCell.ColumnIndex == 3)
                {
                    cbm = (ComboBox)e.Control;
                    string currentLinkIndex = (dataGridView.CurrentCell.RowIndex + 1).ToString();
                    List<string> currentList = utility
                        .LinkIndexes
                        .Where(linkIndexes => linkIndexes != currentLinkIndex)
                        .ToList();
                    cbm.DataSource = currentList;
                }
                else
                {
                    cbm.Text = null;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        private void cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(EndEdit));
        }
        private void EndEdit()
        {
            if (cbm != null)
            {
                string linkIndex = cbm.Text;
                int i = dataGridView.CurrentRow.Index;
                if (cbm.SelectedItem != null && dataGridView.CurrentCell.ColumnIndex == 0)
                {
                    string SelectedItem = cbm.SelectedItem.ToString();
                    dataGridView.Rows[i].Cells["Element"].Value = SelectedItem;
                    utility.FillRow(dataGridView, i, SelectedItem);
                    RadiusPercantage();
                    dataGridView.Rows[i].Cells[1].ErrorText = null;
                    dataGridView.Rows[i].Cells[2].ErrorText = null;
                }
                else if (!string.IsNullOrEmpty(linkIndex))
                {
                    var col = dataGridView.Columns[StringValues.LinkIndex] as DataGridViewComboBoxColumn;
                    if (!col.Items.Contains(linkIndex))
                    {
                        if (!int.TryParse(linkIndex, out int _))
                            return;
                        if (!utility.LinkIndexes.Contains(linkIndex))
                            utility.LinkIndexes.Add(linkIndex);
                        col.DataSource = utility.LinkIndexes;
                    }
                    dataGridView.Rows[i].Cells[StringValues.LinkIndex].Value = linkIndex;
                }
            }
        }
        #endregion
        #region Delete row
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 6 || e.RowIndex == -1)
                return;

            var confirmResult = MessageBox.Show
                (StringValues.RowDelete,
                 StringValues.ConfirmDelete,
                 MessageBoxButtons.YesNoCancel,
                 MessageBoxIcon.Warning);
            if (confirmResult != DialogResult.Yes) return;
            if (dataGridView.RowCount == 1)
            {
                plus.Enabled = false;
                minus.Enabled = false;
            }
            int deletedRowIndex = e.RowIndex + 1;
            utility.LinkIndexes.RemoveAt(utility.LinkIndexes.Count - 1);
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int i = row.Index;
                if (row.Index == e.RowIndex)
                    dataGridView.Rows.Remove(row);
                if (dataGridView.Rows.Count != i)
                    dataGridView.Rows[i].Cells[5].Value = i + 1;
                else
                    continue;

                var linkIndex = dataGridView.Rows[i].Cells[StringValues.LinkIndex].Value;
                if (linkIndex != null)
                {
                    if (linkIndex.ToString() == deletedRowIndex.ToString())
                        dataGridView.Rows[i].Cells[StringValues.LinkIndex].Value = "-1";
                    if (int.Parse(linkIndex.ToString()) > deletedRowIndex)
                    {
                        int current = int.Parse(linkIndex.ToString());
                        current--;
                        dataGridView.Rows[i].Cells[StringValues.LinkIndex].Value = current.ToString();
                    }
                }
            }
        }
        #endregion
        #region Validation
        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            utility.ValidateRow(dataGridView, e.FormattedValue, e.RowIndex, e.ColumnIndex);
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(compoundName.Text))
            {
                textBoxValidated = false;
            }
            else
            {
                textBoxValidated = true;
                errorProvider1.SetError(compoundName, null);
            }
        }
        #endregion
        private void RadiusPercantage()
        {
            double percent = double.Parse(this.percantage.Text.Substring(0, this.percantage.Text.Length - 1));
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value == null) continue;
                string element = row.Cells[0].Value.ToString();
                var atoms = utility.DataAtoms.Where(a => a.name == element).ToArray();
                if (atoms.Length == 0)
                    return;
                int radius = int.Parse(atoms[0].size.ToString());
                row.Cells[StringValues.Radius].Value = (radius * (percent / 100)).ToString();
            }
        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {

                    string name = row.Cells[0].Value.ToString();
                    var atoms = utility.DataAtoms.Where(n => n.name == name).ToList();
                    if (atoms.Count == 0)
                        return;
                    var colors = new Colors();
                    Color color = colors.C.Where(a => atoms[0].category.Contains(a.Key)).ElementAt(0).Value;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataGridView.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = color;
                    }
                }
            }

        }
        private void pickColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            int col = anError.ColumnIndex;
            int row = anError.RowIndex;
            MessageBox.Show($"Error happened {anError.Context} at column {col} row {row}");

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if (anError.Exception is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
                anError.ThrowException = false;
            }
        }
    }
}