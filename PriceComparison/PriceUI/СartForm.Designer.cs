namespace PriceUI
{
    partial class СartForm
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.chainsTab = new System.Windows.Forms.TabPage();
            this.locTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.locComboBox = new System.Windows.Forms.ComboBox();
            this.locSelRadio = new System.Windows.Forms.RadioButton();
            this.locAllRadio = new System.Windows.Forms.RadioButton();
            this.storeTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.storeRadio = new System.Windows.Forms.RadioButton();
            this.storeAllRadio = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.chainsTab.SuspendLayout();
            this.locTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.storeTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(87, 72);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(32, 22);
            this.numericUpDown1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(137, 45);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(313, 239);
            this.dataGridView1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cartToolStripMenuItem
            // 
            this.cartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCartToolStripMenuItem,
            this.loadCartToolStripMenuItem,
            this.exitCartToolStripMenuItem});
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.cartToolStripMenuItem.Text = "Cart";
            // 
            // saveCartToolStripMenuItem
            // 
            this.saveCartToolStripMenuItem.Name = "saveCartToolStripMenuItem";
            this.saveCartToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.saveCartToolStripMenuItem.Text = "Save Cart";
            // 
            // loadCartToolStripMenuItem
            // 
            this.loadCartToolStripMenuItem.Name = "loadCartToolStripMenuItem";
            this.loadCartToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.loadCartToolStripMenuItem.Text = "Load Cart";
            // 
            // exitCartToolStripMenuItem
            // 
            this.exitCartToolStripMenuItem.Name = "exitCartToolStripMenuItem";
            this.exitCartToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.exitCartToolStripMenuItem.Text = "Exit Cart";
            this.exitCartToolStripMenuItem.Click += new System.EventHandler(this.exitCartToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(275, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(280, 44);
            this.button3.TabIndex = 12;
            this.button3.Text = "Compare Items";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(482, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 239);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comparison Options";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.chainsTab);
            this.tabControl1.Controls.Add(this.locTab);
            this.tabControl1.Controls.Add(this.storeTab);
            this.tabControl1.Location = new System.Drawing.Point(6, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(266, 218);
            this.tabControl1.TabIndex = 0;
            // 
            // chainsTab
            // 
            this.chainsTab.Controls.Add(this.listBox1);
            this.chainsTab.Location = new System.Drawing.Point(4, 25);
            this.chainsTab.Name = "chainsTab";
            this.chainsTab.Padding = new System.Windows.Forms.Padding(3);
            this.chainsTab.Size = new System.Drawing.Size(258, 189);
            this.chainsTab.TabIndex = 0;
            this.chainsTab.Text = "Chains";
            this.chainsTab.UseVisualStyleBackColor = true;
            // 
            // locTab
            // 
            this.locTab.Controls.Add(this.panel2);
            this.locTab.Location = new System.Drawing.Point(4, 25);
            this.locTab.Name = "locTab";
            this.locTab.Padding = new System.Windows.Forms.Padding(3);
            this.locTab.Size = new System.Drawing.Size(258, 189);
            this.locTab.TabIndex = 1;
            this.locTab.Text = "Location";
            this.locTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.locComboBox);
            this.panel2.Controls.Add(this.locSelRadio);
            this.panel2.Controls.Add(this.locAllRadio);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 183);
            this.panel2.TabIndex = 1;
            // 
            // locComboBox
            // 
            this.locComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locComboBox.Enabled = false;
            this.locComboBox.FormattingEnabled = true;
            this.locComboBox.Location = new System.Drawing.Point(0, 78);
            this.locComboBox.Name = "locComboBox";
            this.locComboBox.Size = new System.Drawing.Size(245, 24);
            this.locComboBox.TabIndex = 2;
            this.locComboBox.SelectedIndexChanged += new System.EventHandler(this.locComboBox_SelectedIndexChanged);
            // 
            // locSelRadio
            // 
            this.locSelRadio.AutoSize = true;
            this.locSelRadio.Location = new System.Drawing.Point(3, 39);
            this.locSelRadio.Name = "locSelRadio";
            this.locSelRadio.Size = new System.Drawing.Size(126, 21);
            this.locSelRadio.TabIndex = 1;
            this.locSelRadio.Text = "Select Location";
            this.locSelRadio.UseVisualStyleBackColor = true;
            this.locSelRadio.CheckedChanged += new System.EventHandler(this.locSelRadio_CheckedChanged);
            // 
            // locAllRadio
            // 
            this.locAllRadio.AutoSize = true;
            this.locAllRadio.Checked = true;
            this.locAllRadio.Location = new System.Drawing.Point(3, 12);
            this.locAllRadio.Name = "locAllRadio";
            this.locAllRadio.Size = new System.Drawing.Size(44, 21);
            this.locAllRadio.TabIndex = 0;
            this.locAllRadio.TabStop = true;
            this.locAllRadio.Text = "All";
            this.locAllRadio.UseVisualStyleBackColor = true;
            this.locAllRadio.CheckedChanged += new System.EventHandler(this.locAllRadio_CheckedChanged);
            // 
            // storeTab
            // 
            this.storeTab.Controls.Add(this.panel1);
            this.storeTab.Location = new System.Drawing.Point(4, 25);
            this.storeTab.Name = "storeTab";
            this.storeTab.Padding = new System.Windows.Forms.Padding(3);
            this.storeTab.Size = new System.Drawing.Size(258, 189);
            this.storeTab.TabIndex = 2;
            this.storeTab.Text = "Stores";
            this.storeTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.storeRadio);
            this.panel1.Controls.Add(this.storeAllRadio);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 183);
            this.panel1.TabIndex = 0;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(0, 138);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(246, 24);
            this.comboBox3.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(0, 108);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(245, 24);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // storeRadio
            // 
            this.storeRadio.AutoSize = true;
            this.storeRadio.Location = new System.Drawing.Point(3, 39);
            this.storeRadio.Name = "storeRadio";
            this.storeRadio.Size = new System.Drawing.Size(113, 21);
            this.storeRadio.TabIndex = 1;
            this.storeRadio.Text = "Select Stores";
            this.storeRadio.UseVisualStyleBackColor = true;
            this.storeRadio.CheckedChanged += new System.EventHandler(this.storeRadio_CheckedChanged);
            // 
            // storeAllRadio
            // 
            this.storeAllRadio.AutoSize = true;
            this.storeAllRadio.Checked = true;
            this.storeAllRadio.Location = new System.Drawing.Point(3, 12);
            this.storeAllRadio.Name = "storeAllRadio";
            this.storeAllRadio.Size = new System.Drawing.Size(89, 21);
            this.storeAllRadio.TabIndex = 0;
            this.storeAllRadio.TabStop = true;
            this.storeAllRadio.Text = "All Stores";
            this.storeAllRadio.UseVisualStyleBackColor = true;
            this.storeAllRadio.CheckedChanged += new System.EventHandler(this.storeAllRadio_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(3, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(249, 180);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // СartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "СartForm";
            this.Text = "Сart";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.chainsTab.ResumeLayout(false);
            this.locTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.storeTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCartToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage chainsTab;
        private System.Windows.Forms.TabPage locTab;
        private System.Windows.Forms.TabPage storeTab;
        private System.Windows.Forms.ToolStripMenuItem loadCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitCartToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton storeRadio;
        private System.Windows.Forms.RadioButton storeAllRadio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox locComboBox;
        private System.Windows.Forms.RadioButton locSelRadio;
        private System.Windows.Forms.RadioButton locAllRadio;
        private System.Windows.Forms.ListBox listBox1;
    }
}