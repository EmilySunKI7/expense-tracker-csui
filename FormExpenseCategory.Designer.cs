namespace ExpenseTrackerWinForms
{
    partial class FormExpenseCategory
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
            labelCatName = new Label();
            labelParent = new Label();
            textBoxCategory = new TextBox();
            buttonOk = new Button();
            dataGridViewCats = new DataGridView();
            buttonEditCat = new Button();
            buttonRemoveCat = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            dataGridViewToAdd = new DataGridView();
            labelToAdd = new Label();
            textBoxParent = new TextBox();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewToAdd).BeginInit();
            SuspendLayout();
            // 
            // labelCatName
            // 
            labelCatName.AutoSize = true;
            labelCatName.Location = new Point(1061, 499);
            labelCatName.Name = "labelCatName";
            labelCatName.Size = new Size(96, 30);
            labelCatName.TabIndex = 0;
            labelCatName.Text = "Category";
            // 
            // labelParent
            // 
            labelParent.AutoSize = true;
            labelParent.Location = new Point(1325, 499);
            labelParent.Name = "labelParent";
            labelParent.Size = new Size(72, 30);
            labelParent.TabIndex = 1;
            labelParent.Text = "Parent";
            // 
            // textBoxCategory
            // 
            textBoxCategory.Location = new Point(999, 555);
            textBoxCategory.Name = "textBoxCategory";
            textBoxCategory.Size = new Size(226, 35);
            textBoxCategory.TabIndex = 2;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(1147, 655);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(189, 43);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // dataGridViewCats
            // 
            dataGridViewCats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCats.Location = new Point(97, 66);
            dataGridViewCats.Name = "dataGridViewCats";
            dataGridViewCats.RowHeadersWidth = 72;
            dataGridViewCats.Size = new Size(716, 408);
            dataGridViewCats.TabIndex = 5;
            dataGridViewCats.CellClick += dataGridViewCats_CellClick;
            // 
            // buttonEditCat
            // 
            buttonEditCat.Location = new Point(313, 526);
            buttonEditCat.Name = "buttonEditCat";
            buttonEditCat.Size = new Size(221, 39);
            buttonEditCat.TabIndex = 6;
            buttonEditCat.Text = "Edit";
            buttonEditCat.UseVisualStyleBackColor = true;
            buttonEditCat.Click += buttonEditCat_Click;
            // 
            // buttonRemoveCat
            // 
            buttonRemoveCat.Location = new Point(313, 592);
            buttonRemoveCat.Name = "buttonRemoveCat";
            buttonRemoveCat.Size = new Size(221, 45);
            buttonRemoveCat.TabIndex = 7;
            buttonRemoveCat.Text = "Remove";
            buttonRemoveCat.UseVisualStyleBackColor = true;
            buttonRemoveCat.Click += buttonRemoveCat_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(245, 704);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(149, 42);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(435, 704);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(149, 42);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // dataGridViewToAdd
            // 
            dataGridViewToAdd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewToAdd.Location = new Point(999, 120);
            dataGridViewToAdd.Name = "dataGridViewToAdd";
            dataGridViewToAdd.RowHeadersWidth = 72;
            dataGridViewToAdd.Size = new Size(525, 354);
            dataGridViewToAdd.TabIndex = 11;
            // 
            // labelToAdd
            // 
            labelToAdd.AutoSize = true;
            labelToAdd.Location = new Point(998, 63);
            labelToAdd.Name = "labelToAdd";
            labelToAdd.Size = new Size(80, 30);
            labelToAdd.TabIndex = 12;
            labelToAdd.Text = "To add:";
            // 
            // textBoxParent
            // 
            textBoxParent.Location = new Point(1250, 555);
            textBoxParent.Name = "textBoxParent";
            textBoxParent.Size = new Size(226, 35);
            textBoxParent.TabIndex = 13;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(1504, 553);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(61, 40);
            buttonAdd.TabIndex = 14;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FormExpenseCategory
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1662, 794);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxParent);
            Controls.Add(labelToAdd);
            Controls.Add(dataGridViewToAdd);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonRemoveCat);
            Controls.Add(buttonEditCat);
            Controls.Add(dataGridViewCats);
            Controls.Add(buttonOk);
            Controls.Add(textBoxCategory);
            Controls.Add(labelParent);
            Controls.Add(labelCatName);
            Name = "FormExpenseCategory";
            Text = "FormExpenseCategory";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCats).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewToAdd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCatName;
        private Label labelParent;
        private TextBox textBoxCategory;
        private Button buttonOk;
        private DataGridView dataGridViewCats;
        private Button buttonEditCat;
        private Button buttonRemoveCat;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridView dataGridViewToAdd;
        private Label labelToAdd;
        private TextBox textBoxParent;
        private Button buttonAdd;
    }
}