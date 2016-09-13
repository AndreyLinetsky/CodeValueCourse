namespace PriceUI
{
    partial class PriceMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.searchBut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chainText = new System.Windows.Forms.TextBox();
            this.unitText = new System.Windows.Forms.TextBox();
            this.quanText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.codeText = new System.Windows.Forms.TextBox();
            this.typeText = new System.Windows.Forms.TextBox();
            this.chainLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.addBut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itemChkBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.welcomeBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.updatePartialDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cartToolStripMenuItem,
            this.userToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cartToolStripMenuItem
            // 
            this.cartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCartToolStripMenuItem,
            this.loadCartToolStripMenuItem});
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.cartToolStripMenuItem.Text = "Cart";
            // 
            // viewCartToolStripMenuItem
            // 
            this.viewCartToolStripMenuItem.Enabled = false;
            this.viewCartToolStripMenuItem.Name = "viewCartToolStripMenuItem";
            this.viewCartToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.viewCartToolStripMenuItem.Text = "View Cart";
            this.viewCartToolStripMenuItem.Click += new System.EventHandler(this.viewCartToolStripMenuItem_Click);
            // 
            // loadCartToolStripMenuItem
            // 
            this.loadCartToolStripMenuItem.Enabled = false;
            this.loadCartToolStripMenuItem.Name = "loadCartToolStripMenuItem";
            this.loadCartToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.loadCartToolStripMenuItem.Text = "Load Cart";
            this.loadCartToolStripMenuItem.Click += new System.EventHandler(this.loadCartToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.userToolStripMenuItem.Text = "Account";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.logInToolStripMenuItem.Text = "Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateDataToolStripMenuItem,
            this.updatePartialDataToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // updateDataToolStripMenuItem
            // 
            this.updateDataToolStripMenuItem.Name = "updateDataToolStripMenuItem";
            this.updateDataToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.updateDataToolStripMenuItem.Text = "Setup Daily Data";
            this.updateDataToolStripMenuItem.Click += new System.EventHandler(this.updateDataToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(145, 61);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(294, 287);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seach Item";
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(15, 38);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(100, 22);
            this.searchText.TabIndex = 11;
            // 
            // searchBut
            // 
            this.searchBut.Location = new System.Drawing.Point(15, 116);
            this.searchBut.Name = "searchBut";
            this.searchBut.Size = new System.Drawing.Size(98, 29);
            this.searchBut.TabIndex = 12;
            this.searchBut.Text = "Search";
            this.searchBut.UseVisualStyleBackColor = true;
            this.searchBut.Click += new System.EventHandler(this.searchBut_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chainText);
            this.panel1.Controls.Add(this.unitText);
            this.panel1.Controls.Add(this.quanText);
            this.panel1.Controls.Add(this.nameText);
            this.panel1.Controls.Add(this.codeText);
            this.panel1.Controls.Add(this.typeText);
            this.panel1.Controls.Add(this.chainLabel);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.addBut);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(445, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 287);
            this.panel1.TabIndex = 13;
            // 
            // chainText
            // 
            this.chainText.Location = new System.Drawing.Point(92, 176);
            this.chainText.Name = "chainText";
            this.chainText.ReadOnly = true;
            this.chainText.Size = new System.Drawing.Size(152, 22);
            this.chainText.TabIndex = 26;
            // 
            // unitText
            // 
            this.unitText.Location = new System.Drawing.Point(92, 120);
            this.unitText.Name = "unitText";
            this.unitText.ReadOnly = true;
            this.unitText.Size = new System.Drawing.Size(152, 22);
            this.unitText.TabIndex = 25;
            // 
            // quanText
            // 
            this.quanText.Location = new System.Drawing.Point(92, 92);
            this.quanText.Name = "quanText";
            this.quanText.ReadOnly = true;
            this.quanText.Size = new System.Drawing.Size(152, 22);
            this.quanText.TabIndex = 24;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(92, 64);
            this.nameText.Name = "nameText";
            this.nameText.ReadOnly = true;
            this.nameText.Size = new System.Drawing.Size(152, 22);
            this.nameText.TabIndex = 23;
            // 
            // codeText
            // 
            this.codeText.Location = new System.Drawing.Point(92, 38);
            this.codeText.Name = "codeText";
            this.codeText.ReadOnly = true;
            this.codeText.Size = new System.Drawing.Size(152, 22);
            this.codeText.TabIndex = 22;
            // 
            // typeText
            // 
            this.typeText.Location = new System.Drawing.Point(92, 147);
            this.typeText.Name = "typeText";
            this.typeText.ReadOnly = true;
            this.typeText.Size = new System.Drawing.Size(152, 22);
            this.typeText.TabIndex = 21;
            // 
            // chainLabel
            // 
            this.chainLabel.AutoSize = true;
            this.chainLabel.Location = new System.Drawing.Point(12, 181);
            this.chainLabel.Name = "chainLabel";
            this.chainLabel.Size = new System.Drawing.Size(48, 17);
            this.chainLabel.TabIndex = 20;
            this.chainLabel.Text = "Chain:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(135, 230);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 22);
            this.numericUpDown1.TabIndex = 14;
            // 
            // addBut
            // 
            this.addBut.Location = new System.Drawing.Point(15, 230);
            this.addBut.Name = "addBut";
            this.addBut.Size = new System.Drawing.Size(92, 23);
            this.addBut.TabIndex = 13;
            this.addBut.Text = "Add To Cart";
            this.addBut.UseVisualStyleBackColor = true;
            this.addBut.Click += new System.EventHandler(this.addBut_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Item Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Units:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Item Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Item Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Item Details";
            // 
            // itemChkBox
            // 
            this.itemChkBox.AutoSize = true;
            this.itemChkBox.Location = new System.Drawing.Point(15, 72);
            this.itemChkBox.Name = "itemChkBox";
            this.itemChkBox.Size = new System.Drawing.Size(114, 21);
            this.itemChkBox.TabIndex = 14;
            this.itemChkBox.Text = "Internal Items";
            this.itemChkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.itemChkBox);
            this.groupBox1.Controls.Add(this.searchBut);
            this.groupBox1.Controls.Add(this.searchText);
            this.groupBox1.Location = new System.Drawing.Point(0, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 156);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // welcomeBox
            // 
            this.welcomeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.welcomeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeBox.Location = new System.Drawing.Point(12, 33);
            this.welcomeBox.Name = "welcomeBox";
            this.welcomeBox.ReadOnly = true;
            this.welcomeBox.Size = new System.Drawing.Size(193, 17);
            this.welcomeBox.TabIndex = 27;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(221, 33);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(332, 23);
            this.progressBar1.TabIndex = 28;
            this.progressBar1.Visible = false;
            // 
            // updatePartialDataToolStripMenuItem
            // 
            this.updatePartialDataToolStripMenuItem.Name = "updatePartialDataToolStripMenuItem";
            this.updatePartialDataToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.updatePartialDataToolStripMenuItem.Text = "Update Partial Data";
            this.updatePartialDataToolStripMenuItem.Click += new System.EventHandler(this.updatePartialDataToolStripMenuItem_Click);
            // 
            // PriceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 393);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.welcomeBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PriceMain";
            this.Text = "PriceComparison";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Button searchBut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addBut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripMenuItem viewCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCartToolStripMenuItem;
        private System.Windows.Forms.Label chainLabel;
        private System.Windows.Forms.TextBox typeText;
        private System.Windows.Forms.TextBox quanText;
        private System.Windows.Forms.TextBox unitText;
        private System.Windows.Forms.TextBox chainText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox codeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox itemChkBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox welcomeBox;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDataToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem updatePartialDataToolStripMenuItem;
    }
}