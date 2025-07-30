namespace ExpenseTrackerWinForms
{
    partial class FormExpense
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            txtDate = new TextBox();
            txtItem = new TextBox();
            txtName = new TextBox();
            label4 = new Label();
            txtPrice = new TextBox();
            label5 = new Label();
            buttonOk = new Button();
            buttonCancel = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            menuStrip1 = new MenuStrip();
            toolStripMenuItemType = new ToolStripMenuItem();
            toolStripContainer1 = new ToolStripContainer();
            label3 = new Label();
            txtType = new TextBox();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(306, 30);
            label1.TabIndex = 0;
            label1.Text = "Date of purchase (YYYYMMDD)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 149);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 30);
            label2.TabIndex = 1;
            label2.Text = "Item";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(58, 89);
            txtDate.Margin = new Padding(4);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(410, 35);
            txtDate.TabIndex = 2;
            // 
            // txtItem
            // 
            txtItem.Location = new Point(58, 204);
            txtItem.Margin = new Padding(4);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(410, 35);
            txtItem.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Location = new Point(58, 348);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(410, 35);
            txtName.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 292);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(191, 30);
            label4.TabIndex = 4;
            label4.Text = "Name of purchaser";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(58, 611);
            txtPrice.Margin = new Padding(4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(410, 35);
            txtPrice.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 554);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(58, 30);
            label5.TabIndex = 8;
            label5.Text = "Price";
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(74, 913);
            buttonOk.Margin = new Padding(4);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(162, 42);
            buttonOk.TabIndex = 10;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(276, 913);
            buttonCancel.Margin = new Padding(4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(162, 42);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(28, 28);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(271, 40);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(270, 36);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(5, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(5, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(5, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(5, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(922, 74);
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemType });
            menuStrip1.Location = new Point(11, 8);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(157, 38);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemType
            // 
            toolStripMenuItemType.Name = "toolStripMenuItemType";
            toolStripMenuItemType.Size = new Size(149, 34);
            toolStripMenuItemType.Text = "Please select";
            toolStripMenuItemType.Click += toolStripMenuItemType_Click;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(menuStrip1);
            toolStripContainer1.ContentPanel.Size = new Size(478, 74);
            toolStripContainer1.Location = new Point(496, 442);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(478, 99);
            toolStripContainer1.TabIndex = 12;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 423);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 30);
            label3.TabIndex = 13;
            label3.Text = "Type";
            // 
            // txtType
            // 
            txtType.Location = new Point(58, 480);
            txtType.Margin = new Padding(4);
            txtType.Name = "txtType";
            txtType.Size = new Size(410, 35);
            txtType.TabIndex = 14;
            // 
            // FormExpense
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1479, 993);
            Controls.Add(txtType);
            Controls.Add(label3);
            Controls.Add(toolStripContainer1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(txtPrice);
            Controls.Add(label5);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(txtItem);
            Controls.Add(txtDate);
            Controls.Add(label2);
            Controls.Add(label1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "FormExpense";
            Text = "FormExpense";
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtDate;
        private TextBox txtItem;
        private TextBox txtName;
        private Label label4;
        private TextBox txtPrice;
        private Label label5;
        private Button buttonOk;
        private Button buttonCancel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItemType;
        private ToolStripContainer toolStripContainer1;
        private Label label3;
        private TextBox txtType;
    }
}