using System;
using MoleculeTable.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MoleculeTable.Constants;

namespace MoleculeTable.Actions
{
    public class Utility
    {
        public List<string> LinkIndexes = new List<string> { "-1" };
        public readonly List<Atom> DataAtoms = new List<Atom>()
        {
                    new Atom("Ac", 227m, 195m, "actinide ","C78DFFFF"),
                    new Atom("Ag", 107.86822m, 160m, "transition metal ","FFCE00FF"),
                    new Atom("Al", 26.98153857m, 125m, "post-transition metal ","FFCE00FF"),
                    new Atom("Am", 243m, 175m, "actinide ","C78DFFFF"),
                    new Atom("Ar", 39.9481m, 106m, "noble gas ","1F8AFEFF"),
                    new Atom("As", 74.9215956m, 115m, "metalloid ","3CEBC7FF"),
                    new Atom("At", 210m, 150m, "metalloid ","3CEBC7FF"),
                    new Atom("Au", 196.9665695m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("B", 10.81m, 85m, "metalloid ","3CEBC7FF"),
                    new Atom("Ba", 137.3277m, 215m, "alkaline earth metal ","FF6341FF"),
                    new Atom("Be", 9.01218315m, 105m, "alkaline earth metal ","FF6341FF"),
                    new Atom("Bh", 270m, 141m, "transition metal ","FFCE00FF"),
                    new Atom("Bi", 208.980401m, 160m, "post-transition metal ","FFCE00FF"),
                    new Atom("Bk", 247m, 168m, "actinide ","C78DFFFF"),
                    new Atom("Br", 79.904m, 115m, "diatomic nonmetal ","50FF29FF"),
                    new Atom("C", 12.011m, 70m, "polyatomic nonmetal ","55E334FF"),
                    new Atom("Ca", 40.0784m, 180m, "alkaline earth metal ","FF6341FF"),
                    new Atom("Cd", 112.4144m, 155m, "transition metal ","FFCE00FF"),
                    new Atom("Ce", 140.1161m, 185m, "lanthanide ","FF9EFFFF"),
                    new Atom("Cf", 251m, 175m, "actinide ","C78DFFFF"),
                    new Atom("Cl", 35.45m, 100m, "diatomic nonmetal ","50FF29FF"),
                    new Atom("Cm", 247m, 169m, "actinide ","C78DFFFF"),
                    new Atom("Cn", 285m, 122m, "transition metal ","FFCE00FF"),
                    new Atom("Co", 58.9331944m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Cr", 51.99616m, 140m, "transition metal ","FFCE00FF"),
                    new Atom("Cs", 132.905451966m, 260m, "alkali metal ","FF6341FF"),
                    new Atom("Cu", 63.5463m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Db", 268m, 149m, "transition metal ","FFCE00FF"),
                    new Atom("Ds", 281m, 128m, "transition metal","FFCE00FF"),
                    new Atom("Dy", 162.5001m, 175m, "lanthanide ","FF9EFFFF"),
                    new Atom("Er", 167.2593m, 175m, "lanthanide ","FF9EFFFF"),
                    new Atom("Es", 252m, 165m, "actinide ","C78DFFFF"),
                    new Atom("Eu", 151.9641m, 185m, "lanthanide ","FF9EFFFF"),
                    new Atom("F", 18.9984031636m, 50m, "diatomic nonmetal ","50FF29FF"),
                    new Atom("Fe", 55.8452m, 140m, "transition metal ","FFCE00FF"),
                    new Atom("Fl", 289m, 180m, "post-transition metal ","FFCE00FF"),
                    new Atom("Fm", 257m, 167m, "actinide ","C78DFFFF"),
                    new Atom("Fr", 223m, 260m, "alkali metal ","FF6341FF"),
                    new Atom("Ga", 69.7231m, 130m, "post-transition metal ","FFCE00FF"),
                    new Atom("Gd", 157.253m, 180m, "lanthanide ","FF9EFFFF"),
                    new Atom("Ge", 72.6308m, 125m, "metalloid ","3CEBC7FF"),
                    new Atom("H", 1.008m, 25m, "diatomic nonmetal ","50FF29FF"),
                    new Atom("He", 4.0026022m, 28m, "noble gas ","1F8AFEFF"),
                    new Atom("Hf", 178.492m, 155m, "transition metal ","FFCE00FF"),
                    new Atom("Hg", 200.5923m, 150m, "transition metal ","FFCE00FF"),
                    new Atom("Ho", 164.930332m, 175m, "lanthanide ","FF9EFFFF"),
                    new Atom("Hs", 269m, 134m, "transition metal ","FFCE00FF"),
                    new Atom("I", 126.904473m, 140m, "diatomic nonmetal ","50FF29FF"),
                    new Atom("In", 114.8181m, 155m, "post-transition metal ","FFCE00FF"),
                    new Atom("Ir", 192.2173m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("K", 39.09831m, 220m, "alkali metal ","FF6341FF"),
                    new Atom("Kr", 83.7982m, 116m, "noble gas ","1F8AFEFF"),
                    new Atom("La", 138.905477m, 195m, "lanthanide ","FF9EFFFF"),
                    new Atom("Li", 6.94m, 145m, "alkali metal ","FF6341FF"),
                    new Atom("Lr", 266m, 171m, "actinide ","C78DFFFF"),
                    new Atom("Lu", 174.96681m, 175m, "lanthanide ","FF9EFFFF"),
                    new Atom("Lv", 293m, 183m, "post-transition metal","FFCE00FF"),
                    new Atom("Md", 258m, 173m, "actinide ","C78DFFFF"),
                    new Atom("Mg", 24.305m, 150m, "alkaline earth metal ","FF6341FF"),
                    new Atom("Mn", 54.9380443m, 140m, "transition metal ","FFCE00FF"),
                    new Atom("Mo", 95.951m, 145m, "transition metal ","FFCE00FF"),
                    new Atom("Mt", 278m, 129m, "transition metal ","FFCE00FF"),
                    new Atom("N", 14.007m, 65m, "diatomic nonmetal ","50FF29FF"),
                    new Atom("Na", 22.989769282m, 180m, "alkali metal ","FF6341FF"),
                    new Atom("Nb", 92.906372m, 145m, "transition metal ","FFCE00FF"),
                    new Atom("Nd", 144.2423m, 185m, "lanthanide ","FF9EFFFF"),
                    new Atom("Ne", 20.17976m, 58m, "noble gas ","1F8AFEFF"),
                    new Atom("Ni", 58.69344m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("No", 259m, 176m, "actinide ","C78DFFFF"),
                    new Atom("Np", 237m, 175m, "actinide ","C78DFFFF"),
                    new Atom("O", 15.999m, 60m, "diatomic nonmetal ","50FF29FF"),
                    new Atom("Os", 190.233m, 130m, "transition metal ","FFCE00FF"),
                    new Atom("P", 30.9737619985m, 100m, "polyatomic nonmetal ","55E334FF"),
                    new Atom("Pa", 231.035882m, 180m, "actinide ","C78DFFFF"),
                    new Atom("Pb", 207.21m, 180m, "post-transition metal ","FFCE00FF"),
                    new Atom("Pd", 106.421m, 140m, "transition metal ","FFCE00FF"),
                    new Atom("Pm", 145m, 185m, "lanthanide ","FF9EFFFF"),
                    new Atom("Po", 209m, 190m, "post-transition metal ","FFCE00FF"),
                    new Atom("Pr", 140.907662m, 185m, "lanthanide ","FF9EFFFF"),
                    new Atom("Pt", 195.0849m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Pu", 244m, 175m, "actinide ","C78DFFFF"),
                    new Atom("Ra", 226m, 215m, "alkaline earth metal ","FF6341FF"),
                    new Atom("Rb", 85.46783m, 235m, "alkali metal ","FF6341FF"),
                    new Atom("Re", 186.2071m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Rf", 267m, 150m, "transition metal ","FFCE00FF"),
                    new Atom("Rg", 282m, 121m, "transition metal","FFCE00FF"),
                    new Atom("Rh", 102.905502m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Rn", 222m, 150m, "noble gas ","1F8AFEFF"),
                    new Atom("Ru", 101.072m, 130m, "transition metal ","FFCE00FF"),
                    new Atom("S", 32.06m, 100m, "polyatomic nonmetal ","55E334FF"),
                    new Atom("Sb", 121.7601m, 145m, "metalloid ","3CEBC7FF"),
                    new Atom("Sc", 44.9559085m, 160m, "transition metal ","FFCE00FF"),
                    new Atom("Se", 78.9718m, 115m, "polyatomic nonmetal ","55E334FF"),
                    new Atom("Sg", 269m, 143m, "transition metal ","FFCE00FF"),
                    new Atom("Si", 28.085m, 110m, "metalloid ","3CEBC7FF"),
                    new Atom("Sm", 150.362m, 185m, "lanthanide ","FF9EFFFF"),
                    new Atom("Sn", 118.7107m, 145m, "post-transition metal ","FFCE00FF"),
                    new Atom("Sr", 87.621m, 200m, "alkaline earth metal ","FF6341FF"),
                    new Atom("Ta", 180.947882m, 145m, "transition metal ","FFCE00FF"),
                    new Atom("Tb", 158.925352m, 175m, "lanthanide ","FF9EFFFF"),
                    new Atom("Tc", 98m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Te", 127.603m, 140m, "metalloid ","3CEBC7FF"),
                    new Atom("Th", 232.03774m, 180m, "actinide ","C78DFFFF"),
                    new Atom("Ti", 47.8671m, 140m, "transition metal ","FFCE00FF"),
                    new Atom("Tl", 204.38m, 190m, "post-transition metal ","FFCE00FF"),
                    new Atom("Tm", 168.934222m, 175m, "lanthanide ","FF9EFFFF"),
                    new Atom("U", 238.028913m, 175m, "actinide ","C78DFFFF"),
                    new Atom("Uuo", 294m, 157m, "noble gas ","1F8AFEFF"),
                    new Atom("Uup", 289m, 157m, "post-transition metal ","FFCE00FF"),
                    new Atom("Uus", 294m, 156m, "metalloid ","3CEBC7FF"),
                    new Atom("Uut", 286m, 175m, "transition metal ","FFCE00FF"),
                    new Atom("V", 50.94151m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("W", 183.841m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Xe", 131.2936m, 145m, "noble gas ","1F8AFEFF"),
                    new Atom("Y", 88.905842m, 180m, "transition metal ","FFCE00FF"),
                    new Atom("Zn", 65.382m, 135m, "transition metal ","FFCE00FF"),
                    new Atom("Zr", 91.2242m, 155m, "transition metal ","FFCE00FF"),        };
        public void BlinkErrors(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    dataGridView.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ErrorText = null;
        }
        public void PopulateNamesComboBox(DataGridView dataGridView)
        {
            var data = dataGridView.Columns[StringValues.Element] as DataGridViewComboBoxColumn;
            List<string> names = DataAtoms.Select(atom => atom.name).ToList();
            data.DataSource = names;
        }
        public void PopulateLinkIndexesComboBox(DataGridView dataGridView)
        {
            var data = dataGridView.Columns[StringValues.LinkIndex] as DataGridViewComboBoxColumn;
            data.DataSource = this.LinkIndexes;
        }
        public void DeleteRows(DataGridView dataGridView, TextBox textBox1)
        {
            int rows = dataGridView.RowCount;
            textBox1.Text = string.Empty;
            for (var i = rows - 1; i >= 0; i--)
                dataGridView.Rows.RemoveAt(i);
            this.LinkIndexes = new List<string> { "-1" };
        }
        public void FillRow(DataGridView dataGridView, int row, string element)
        {
            Atom atom = DataAtoms.Find(a => a.name == element);
            if (atom is null)
            {
                MessageBox.Show(
                   string.Format(StringValues.ElementNotPresented, element),
                    StringValues.CreateNewCompound,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                return;
            }
            dataGridView.Rows[row].Cells[0].Value = atom.name;
            dataGridView.Rows[row].Cells[1].Value = atom.mass;
            dataGridView.Rows[row].Cells[2].Value = atom.size;
        }
        public List<Atom> GetAtoms(DataGridView dataGridView)
        {
            List<Atom> atoms = new List<Atom>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var name = row.Cells[StringValues.Element].Value.ToString();
                var order = int.Parse(row.Cells[StringValues.Order].Value.ToString());
                var mass = decimal.Parse(row.Cells[StringValues.Mass].Value.ToString());
                var size = decimal.Parse(row.Cells[StringValues.Radius].Value.ToString());
                int linkIndex = int.Parse(row.Cells[StringValues.LinkIndex].Value.ToString());
                var linkConnectionNumber = int.Parse(row.Cells[StringValues.LinkConnectionNum].Value.ToString());
                if (linkIndex != -1)
                    linkIndex -= 1;
                string category = DataAtoms.FirstOrDefault(a => a.name == name)?.category;
                string color = DataAtoms.FirstOrDefault(a => a.name == name)?.color;
                var atom = new Atom(name, mass, size, category, color)
                {
                    viewOrder = order - 1,
                    linkConnectionNum = linkConnectionNumber,
                    linkIndex = linkIndex,
                    category = category,
                    color = color
                };
                atoms.Add(atom);
            }
            return atoms;
        }
        public string GetJson(DataGridView dataGridView, string compoundName)
        {
            RootObject rootObject = new RootObject();
            Molecule molecule = new Molecule
            {
                atoms = GetAtoms(dataGridView),
                compoundName = compoundName
            };
            rootObject.molecules.Add(molecule);
            return JsonConvert.SerializeObject(rootObject);
        }
        public bool ValidateRow(DataGridView dataGridView, object currentCell, int row, int col)
        {
            if (currentCell == null || currentCell.ToString() == string.Empty)
            {
                dataGridView.Rows[row].Cells[col].ErrorText = "Моля, въведете стойност.";
                return false;
            }

            dataGridView.Rows[row].Cells[col].ErrorText = null;
            switch (col)
            {
                case 0:
                    return true;
                case 3:
                    CheckLinkIndexValidation(dataGridView, row, currentCell.ToString());
                    break;
                case 4:
                    CheckLinkConnectionNum(dataGridView, row, currentCell.ToString());
                    return true;
                case 6:
                    return true;
            }
            bool isNumber = decimal.TryParse(currentCell.ToString(), out decimal _);
            if (currentCell.ToString().Contains("."))
            {
                dataGridView.Rows[row].Cells[col].ErrorText = @"Използвайте "","" вместо ""."".";
                return false;
            }
            if (!isNumber)
            {
                dataGridView.Rows[row].Cells[col].ErrorText = "Моля, въведете валидно число.";
                return false;
            }
            dataGridView.Rows[row].Cells[col].ErrorText = null;
            return true;
        }
        public bool ValidateForm(DataGridView dataGridView, ErrorProvider errorProvider1, Button Add, bool textBoxValidated, TextBox textBox1, bool isPreview)
        {
            if (isPreview)
                errorProvider1.SetError(textBox1, null);
            if (dataGridView.RowCount == 0)
            {
                errorProvider1.SetError(Add, null);
                errorProvider1.SetError(Add, "Моля, първо добавете ред.");
                return false;
            }
            bool tableValidated = true;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!ValidateRow(dataGridView, cell.Value, cell.RowIndex, cell.ColumnIndex))
                        tableValidated = false;
                }
            }

            if (textBoxValidated || isPreview) return tableValidated;
            errorProvider1.SetError(textBox1, null);
            errorProvider1.SetError(textBox1, "Името на съединението е задължително.");
            return false;
        }
        public void CheckLinkConnectionNum(DataGridView dataGridView, int row, string currentCell)
        {
            var linkIndex = dataGridView.Rows[row].Cells[StringValues.LinkIndex];
            var linkConnectionNum = dataGridView.Rows[row].Cells[StringValues.LinkConnectionNum];

            var isInt = int.TryParse(currentCell, out int _);
            if (!isInt)
            {
                linkConnectionNum.ErrorText = "Моля, въведете валидно число.";
                return;
            }

            linkConnectionNum.ErrorText = null;

            if (int.Parse(currentCell) <= 5)
            {
                linkConnectionNum.ErrorText = null;
            }
            else
            {
                linkConnectionNum.ErrorText = "Стойноста не може да бъде по голяма от 5";
                return;
            }


            if (linkIndex.Value == null) return;
            if (linkIndex.Value.ToString() == "-1" && int.Parse(currentCell) > 0)
            {
                linkIndex.ErrorText = "Стойността не може да бъде -1, ако броят на връзки е по-голям от 0.";
            }
            else
            {
                linkConnectionNum.ErrorText = null;
                linkIndex.ErrorText = null;
            }
        }
        private void CheckLinkIndexValidation(DataGridView dataGridView, int row, string linkIndex)
        {
            var linkConnectionNum = dataGridView.Rows[row].Cells[StringValues.LinkConnectionNum];

            if (linkConnectionNum.Value == null || !int.TryParse(linkConnectionNum.Value.ToString(), out int _))
                return;

            if (linkIndex == "-1" && int.Parse(linkConnectionNum.Value.ToString()) > 0)
            {
                dataGridView.Rows[row].Cells[StringValues.LinkIndex].ErrorText = "Стойността не може да бъде -1, ако броят на връзки е по-голям от 0.";
            }
        }
    }
}