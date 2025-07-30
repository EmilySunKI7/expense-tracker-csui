namespace ExpenseTrackerWinForms
{
    partial class FormSearch
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
            comboBoxCategory = new ComboBox();
            comboBoxSearchType = new ComboBox();
            textBoxLower = new TextBox();
            textBoxUpper = new TextBox();
            buttonGo = new Button();
            buttonCancel = new Button();
            buttonAdd = new Button();
            listboxSearchParams = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(381, 302);
            comboBoxCategory.Margin = new Padding(4);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(430, 38);
            comboBoxCategory.TabIndex = 1;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // comboBoxSearchType
            // 
            comboBoxSearchType.FormattingEnabled = true;
            comboBoxSearchType.Location = new Point(381, 440);
            comboBoxSearchType.Margin = new Padding(4);
            comboBoxSearchType.Name = "comboBoxSearchType";
            comboBoxSearchType.Size = new Size(430, 38);
            comboBoxSearchType.TabIndex = 2;
            comboBoxSearchType.SelectedIndexChanged += comboBoxSearchType_SelectedIndexChanged;
            // 
            // textBoxLower
            // 
            textBoxLower.Location = new Point(485, 590);
            textBoxLower.Margin = new Padding(4);
            textBoxLower.Name = "textBoxLower";
            textBoxLower.Size = new Size(214, 35);
            textBoxLower.TabIndex = 3;
            // 
            // textBoxUpper
            // 
            textBoxUpper.Location = new Point(485, 735);
            textBoxUpper.Margin = new Padding(4);
            textBoxUpper.Name = "textBoxUpper";
            textBoxUpper.Size = new Size(214, 35);
            textBoxUpper.TabIndex = 4;
            // 
            // buttonGo
            // 
            buttonGo.Location = new Point(1099, 709);
            buttonGo.Margin = new Padding(4);
            buttonGo.Name = "buttonGo";
            buttonGo.Size = new Size(154, 46);
            buttonGo.TabIndex = 5;
            buttonGo.Text = "Go";
            buttonGo.UseVisualStyleBackColor = true;
            buttonGo.Click += buttonGo_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(1099, 793);
            buttonCancel.Margin = new Padding(4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(154, 46);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(1099, 617);
            buttonAdd.Margin = new Padding(4);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(154, 44);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Add Search Parameter";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // listboxSearchParams
            // 
            listboxSearchParams.FormattingEnabled = true;
            listboxSearchParams.ItemHeight = 30;
            listboxSearchParams.Location = new Point(192, 48);
            listboxSearchParams.Margin = new Padding(4);
            listboxSearchParams.Name = "listboxSearchParams";
            listboxSearchParams.Size = new Size(800, 154);
            listboxSearchParams.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(571, 667);
            label1.Name = "label1";
            label1.Size = new Size(32, 30);
            label1.TabIndex = 9;
            label1.Text = "to";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(383, 250);
            label2.Name = "label2";
            label2.Size = new Size(103, 30);
            label2.TabIndex = 10;
            label2.Text = "Search by";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(383, 389);
            label3.Name = "label3";
            label3.Size = new Size(140, 30);
            label3.TabIndex = 11;
            label3.Text = "Specifications";
            // 
            // FormSearch
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 912);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listboxSearchParams);
            Controls.Add(buttonAdd);
            Controls.Add(buttonCancel);
            Controls.Add(buttonGo);
            Controls.Add(textBoxUpper);
            Controls.Add(textBoxLower);
            Controls.Add(comboBoxSearchType);
            Controls.Add(comboBoxCategory);
            Margin = new Padding(4);
            Name = "FormSearch";
            Text = "FormSearch";
            Load += FormSearch_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCategory;
        private ComboBox comboBoxSearchType;
        private TextBox textBoxLower;
        private TextBox textBoxUpper;
        private Button buttonGo;
        private Button buttonCancel;
        private Button buttonAdd;
        private ListBox listboxSearchParams;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}