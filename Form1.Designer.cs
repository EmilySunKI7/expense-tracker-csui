namespace ExpenseTrackerWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            filesToolStripMenuItem = new ToolStripMenuItem();
            webAPIToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            dataGridView1 = new DataGridView();
            listBox1 = new ListBox();
            buttonAddExpense = new Button();
            label1 = new Label();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonSearch = new Button();
            buttonClearSearch = new Button();
            buttonEditCats = new Button();
            monthlyStmntButton = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1385, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(62, 34);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(182, 40);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filesToolStripMenuItem, webAPIToolStripMenuItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(182, 40);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // filesToolStripMenuItem
            // 
            filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            filesToolStripMenuItem.Size = new Size(211, 40);
            filesToolStripMenuItem.Text = "Files";
            filesToolStripMenuItem.Click += filesToolStripMenuItem_Click;
            // 
            // webAPIToolStripMenuItem
            // 
            webAPIToolStripMenuItem.Name = "webAPIToolStripMenuItem";
            webAPIToolStripMenuItem.Size = new Size(211, 40);
            webAPIToolStripMenuItem.Text = "Web API";
            webAPIToolStripMenuItem.Click += webAPIToolStripMenuItem_ClickAsync;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(183, 171);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(680, 418);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Location = new Point(1041, 153);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(223, 244);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // buttonAddExpense
            // 
            buttonAddExpense.Location = new Point(1040, 539);
            buttonAddExpense.Margin = new Padding(4);
            buttonAddExpense.Name = "buttonAddExpense";
            buttonAddExpense.Size = new Size(224, 50);
            buttonAddExpense.TabIndex = 3;
            buttonAddExpense.Text = "Add Expense";
            buttonAddExpense.UseVisualStyleBackColor = true;
            buttonAddExpense.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1041, 99);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 30);
            label1.TabIndex = 4;
            label1.Text = "Sort By";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1040, 713);
            buttonSave.Margin = new Padding(4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(224, 45);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += button2_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(1040, 456);
            buttonEdit.Margin = new Padding(4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(224, 48);
            buttonEdit.TabIndex = 6;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(183, 652);
            buttonSearch.Margin = new Padding(4);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(261, 46);
            buttonSearch.TabIndex = 7;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonClearSearch
            // 
            buttonClearSearch.Location = new Point(543, 652);
            buttonClearSearch.Margin = new Padding(4);
            buttonClearSearch.Name = "buttonClearSearch";
            buttonClearSearch.Size = new Size(234, 46);
            buttonClearSearch.TabIndex = 8;
            buttonClearSearch.Text = "Clear Search";
            buttonClearSearch.UseVisualStyleBackColor = true;
            buttonClearSearch.Click += buttonClearSearch_Click;
            // 
            // buttonEditCats
            // 
            buttonEditCats.Location = new Point(1040, 634);
            buttonEditCats.Margin = new Padding(4);
            buttonEditCats.Name = "buttonEditCats";
            buttonEditCats.Size = new Size(224, 45);
            buttonEditCats.TabIndex = 9;
            buttonEditCats.Text = "Edit Categories";
            buttonEditCats.UseVisualStyleBackColor = true;
            buttonEditCats.Click += buttonEditCats_Click;
            // 
            // monthlyStmntButton
            // 
            monthlyStmntButton.Location = new Point(358, 747);
            monthlyStmntButton.Name = "monthlyStmntButton";
            monthlyStmntButton.Size = new Size(271, 51);
            monthlyStmntButton.TabIndex = 10;
            monthlyStmntButton.Text = "View Monthly Statements";
            monthlyStmntButton.UseVisualStyleBackColor = true;
            monthlyStmntButton.Click += monthlyStmntButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1385, 833);
            Controls.Add(monthlyStmntButton);
            Controls.Add(buttonEditCats);
            Controls.Add(buttonClearSearch);
            Controls.Add(buttonSearch);
            Controls.Add(buttonEdit);
            Controls.Add(buttonSave);
            Controls.Add(label1);
            Controls.Add(buttonAddExpense);
            Controls.Add(listBox1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private ListBox listBox1;
        private Button buttonAddExpense;
        private Label label1;
        private Button buttonSave;
        private Button buttonEdit;
        private Button buttonSearch;
        private Button buttonClearSearch;
        private ToolStripMenuItem filesToolStripMenuItem;
        private ToolStripMenuItem webAPIToolStripMenuItem;
        private Button buttonEditCats;
        private Button monthlyStmntButton;
    }
}
