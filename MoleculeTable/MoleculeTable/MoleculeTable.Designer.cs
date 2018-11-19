using System;
using System.Windows.Forms;

namespace MoleculeTable
{
    partial class MoleculeTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Element = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Mass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Radius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkIndex = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LinkConnectionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Add = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Generate = new System.Windows.Forms.Button();
            this.compoundName = new System.Windows.Forms.TextBox();
            this.compoundLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Preview = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.compoundElements = new System.Windows.Forms.TextBox();
            this.minus = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.percantage = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pickColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Element,
            this.Mass,
            this.Radius,
            this.LinkIndex,
            this.LinkConnectionNumber,
            this.Order,
            this.Delete});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView.Location = new System.Drawing.Point(17, 58);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 35;
            this.dataGridView.Size = new System.Drawing.Size(1397, 498);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_CellValidating);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView1_DataError);
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_IncrementOrder);
            this.dataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.dataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragOver);
            this.dataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseDown);
            this.dataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            // 
            // Element
            // 
            this.Element.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Element.HeaderText = "Елемент";
            this.Element.MaxDropDownItems = 100;
            this.Element.Name = "Element";
            // 
            // Mass
            // 
            this.Mass.HeaderText = "Маса";
            this.Mass.Name = "Mass";
            this.Mass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Radius
            // 
            this.Radius.HeaderText = "Радиус";
            this.Radius.Name = "Radius";
            this.Radius.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LinkIndex
            // 
            this.LinkIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LinkIndex.HeaderText = "Индекс на връзката";
            this.LinkIndex.Items.AddRange(new object[] {
            "-1"});
            this.LinkIndex.Name = "LinkIndex";
            this.LinkIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LinkConnectionNumber
            // 
            this.LinkConnectionNumber.HeaderText = "Брой връзки";
            this.LinkConnectionNumber.Name = "LinkConnectionNumber";
            this.LinkConnectionNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Order
            // 
            this.Order.DataPropertyName = "1";
            this.Order.HeaderText = "Подредба";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Delete
            // 
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "Изтрий";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Delete.Text = "Изтрий";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // Add
            // 
            this.Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add.Location = new System.Drawing.Point(17, 571);
            this.Add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(100, 28);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добави";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(1099, 571);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(100, 28);
            this.Save.TabIndex = 2;
            this.Save.Text = "Запази";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Safe_Click);
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate.Location = new System.Drawing.Point(1315, 571);
            this.Generate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(100, 28);
            this.Generate.TabIndex = 5;
            this.Generate.Text = "Генерирай";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // compoundName
            // 
            this.compoundName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compoundName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compoundName.Location = new System.Drawing.Point(1207, 22);
            this.compoundName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.compoundName.Multiline = true;
            this.compoundName.Name = "compoundName";
            this.compoundName.Size = new System.Drawing.Size(144, 22);
            this.compoundName.TabIndex = 6;
            this.compoundName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // compoundLabel
            // 
            this.compoundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compoundLabel.AutoSize = true;
            this.compoundLabel.Location = new System.Drawing.Point(1040, 23);
            this.compoundLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.compoundLabel.Name = "compoundLabel";
            this.compoundLabel.Size = new System.Drawing.Size(154, 17);
            this.compoundLabel.TabIndex = 7;
            this.compoundLabel.Text = "Име на съединението";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Preview
            // 
            this.Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Preview.Location = new System.Drawing.Point(1207, 571);
            this.Preview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(100, 28);
            this.Preview.TabIndex = 8;
            this.Preview.Text = "Преглед";
            this.Preview.UseVisualStyleBackColor = true;
            this.Preview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(169, 17);
            this.Create.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(195, 27);
            this.Create.TabIndex = 10;
            this.Create.Text = "Създай ново съединение";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // compoundElements
            // 
            this.compoundElements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compoundElements.Location = new System.Drawing.Point(17, 20);
            this.compoundElements.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.compoundElements.Multiline = true;
            this.compoundElements.Name = "compoundElements";
            this.compoundElements.Size = new System.Drawing.Size(144, 22);
            this.compoundElements.TabIndex = 11;
            // 
            // minus
            // 
            this.minus.Enabled = false;
            this.minus.Location = new System.Drawing.Point(372, 16);
            this.minus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(31, 28);
            this.minus.TabIndex = 13;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // plus
            // 
            this.plus.Enabled = false;
            this.plus.Location = new System.Drawing.Point(456, 16);
            this.plus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(31, 28);
            this.plus.TabIndex = 14;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // percantage
            // 
            this.percantage.AutoSize = true;
            this.percantage.Location = new System.Drawing.Point(408, 22);
            this.percantage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.percantage.Name = "percantage";
            this.percantage.Size = new System.Drawing.Size(44, 17);
            this.percantage.TabIndex = 15;
            this.percantage.Text = "100%";
            // 
            // pickColor
            // 
            this.pickColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickColor.BackgroundImage = global::MoleculeTable.Properties.Resources.flaticonmaker;
            this.pickColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pickColor.FlatAppearance.BorderSize = 0;
            this.pickColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pickColor.Location = new System.Drawing.Point(1367, 9);
            this.pickColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pickColor.Name = "pickColor";
            this.pickColor.Size = new System.Drawing.Size(48, 44);
            this.pickColor.TabIndex = 16;
            this.pickColor.UseVisualStyleBackColor = true;
            this.pickColor.Click += new System.EventHandler(this.pickColor_Click);
            // 
            // MoleculeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1445, 608);
            this.Controls.Add(this.pickColor);
            this.Controls.Add(this.percantage);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.compoundElements);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.compoundLabel);
            this.Controls.Add(this.compoundName);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1461, 645);
            this.Name = "MoleculeTableForm";
            this.Padding = new System.Windows.Forms.Padding(13, 25, 13, 12);
            this.Text = "Molecule Table";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox compoundName;
        private System.Windows.Forms.Label compoundLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private ErrorProvider errorProvider1;
        private Button Preview;
        private TextBox compoundElements;
        private Button Create;
        private Label percantage;
        private Button plus;
        private Button minus;
        private DataGridViewComboBoxColumn Element;
        private DataGridViewTextBoxColumn Mass;
        private DataGridViewTextBoxColumn Radius;
        private DataGridViewComboBoxColumn LinkIndex;
        private DataGridViewTextBoxColumn LinkConnectionNumber;
        private DataGridViewTextBoxColumn Order;
        private DataGridViewButtonColumn Delete;
        private ColorDialog colorDialog1;
        private ToolTip toolTip1;
        private Button pickColor;
    }
}

