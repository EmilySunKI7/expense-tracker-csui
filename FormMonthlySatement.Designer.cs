namespace ExpenseTrackerWinForms
{
    partial class FormMonthlySatement
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
            dataGridViewExpenses = new DataGridView();
            comboBoxMonths = new ComboBox();
            buttonOk = new Button();
            labelTotal = new Label();
            textBoxTotal = new TextBox();
            textBoxYear = new TextBox();
            labelMonth = new Label();
            labelYear = new Label();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpenses).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewExpenses
            // 
            dataGridViewExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExpenses.Location = new Point(161, 191);
            dataGridViewExpenses.Name = "dataGridViewExpenses";
            dataGridViewExpenses.RowHeadersWidth = 72;
            dataGridViewExpenses.Size = new Size(792, 399);
            dataGridViewExpenses.TabIndex = 0;
            // 
            // comboBoxMonths
            // 
            comboBoxMonths.FormattingEnabled = true;
            comboBoxMonths.Location = new Point(199, 106);
            comboBoxMonths.Name = "comboBoxMonths";
            comboBoxMonths.Size = new Size(268, 38);
            comboBoxMonths.TabIndex = 1;
            comboBoxMonths.SelectedIndexChanged += comboBoxMonths_SelectedIndexChanged;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(907, 106);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(76, 42);
            buttonOk.TabIndex = 3;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(169, 638);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(62, 30);
            labelTotal.TabIndex = 4;
            labelTotal.Text = "Total:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Location = new Point(251, 638);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.Size = new Size(261, 35);
            textBoxTotal.TabIndex = 5;
            // 
            // textBoxYear
            // 
            textBoxYear.Location = new Point(536, 106);
            textBoxYear.Name = "textBoxYear";
            textBoxYear.Size = new Size(251, 35);
            textBoxYear.TabIndex = 6;
            textBoxYear.TextChanged += textBox1_TextChanged;
            // 
            // labelMonth
            // 
            labelMonth.AutoSize = true;
            labelMonth.Location = new Point(199, 54);
            labelMonth.Name = "labelMonth";
            labelMonth.Size = new Size(80, 30);
            labelMonth.TabIndex = 7;
            labelMonth.Text = "Month:";
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(536, 54);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(57, 30);
            labelYear.TabIndex = 8;
            labelYear.Text = "Year:";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(1015, 664);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(133, 36);
            buttonClose.TabIndex = 9;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormMonthlySatement
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 737);
            Controls.Add(buttonClose);
            Controls.Add(labelYear);
            Controls.Add(labelMonth);
            Controls.Add(textBoxYear);
            Controls.Add(textBoxTotal);
            Controls.Add(labelTotal);
            Controls.Add(buttonOk);
            Controls.Add(comboBoxMonths);
            Controls.Add(dataGridViewExpenses);
            Name = "FormMonthlySatement";
            Text = "FormMonthlySatement";
            Load += FormMonthlySatement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewExpenses;
        private ComboBox comboBoxMonths;
        private Button buttonOk;
        private Label labelTotal;
        private TextBox textBoxTotal;
        private TextBox textBoxYear;
        private Label labelMonth;
        private Label labelYear;
        private Button buttonClose;
    }
}