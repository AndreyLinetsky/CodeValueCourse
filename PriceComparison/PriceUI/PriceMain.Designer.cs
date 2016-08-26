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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.priceText = new System.Windows.Forms.Label();
            this.unitText = new System.Windows.Forms.Label();
            this.quanText = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.Label();
            this.codeText = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cartToolStripMenuItem,
            this.userToolStripMenuItem});
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
            this.loadToolStripMenuItem});
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.cartToolStripMenuItem.Text = "Cart";
            // 
            // viewCartToolStripMenuItem
            // 
            this.viewCartToolStripMenuItem.Enabled = false;
            this.viewCartToolStripMenuItem.Name = "viewCartToolStripMenuItem";
            this.viewCartToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.viewCartToolStripMenuItem.Text = "View Cart";
            this.viewCartToolStripMenuItem.Click += new System.EventHandler(this.viewCartToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Enabled = false;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loadToolStripMenuItem.Text = "Load Cart";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(170, 60);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(237, 287);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seach Product";
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(27, 154);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(100, 22);
            this.searchText.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.priceText);
            this.panel1.Controls.Add(this.unitText);
            this.panel1.Controls.Add(this.quanText);
            this.panel1.Controls.Add(this.nameText);
            this.panel1.Controls.Add(this.codeText);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(423, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 287);
            this.panel1.TabIndex = 13;
            
            // 
            // priceText
            // 
            this.priceText.AutoSize = true;
            this.priceText.Location = new System.Drawing.Point(103, 146);
            this.priceText.Name = "priceText";
            this.priceText.Size = new System.Drawing.Size(0, 17);
            this.priceText.TabIndex = 19;
            // 
            // unitText
            // 
            this.unitText.AutoSize = true;
            this.unitText.Location = new System.Drawing.Point(103, 119);
            this.unitText.Name = "unitText";
            this.unitText.Size = new System.Drawing.Size(0, 17);
            this.unitText.TabIndex = 18;
            // 
            // quanText
            // 
            this.quanText.AutoSize = true;
            this.quanText.Location = new System.Drawing.Point(103, 92);
            this.quanText.Name = "quanText";
            this.quanText.Size = new System.Drawing.Size(0, 17);
            this.quanText.TabIndex = 17;
            // 
            // nameText
            // 
            this.nameText.AutoSize = true;
            this.nameText.Location = new System.Drawing.Point(103, 65);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(0, 17);
            this.nameText.TabIndex = 16;
            // 
            // codeText
            // 
            this.codeText.AutoSize = true;
            this.codeText.Location = new System.Drawing.Point(103, 38);
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(0, 17);
            this.codeText.TabIndex = 15;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(135, 221);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 22);
            this.numericUpDown1.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Add To Cart";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Lowest price:";
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
            this.label3.Location = new System.Drawing.Point(67, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Item Details";
            // 
            // PriceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Formf¥ V e r s  i o n =  1  
 E v ∏n t T ày p ,= P |P G\Ãi c D ÏiVr F Çu FdÇi mQÇ1 3 æ1 4@ 0 6 8 7—0 9 9 }™CãsitìR äp r ïI dXi f ªè= ]dE 0 4 5 -E b e0 -eeA _- b a 9E f 3 2Ç9uÄ
dÄ4ÄÅAÅ6s∑Ä|ÅäÅD.Ä:ÖÑ4Çp"SÄ;g [Ä[] X. NÄÉrAÄâcT hÄtÄ,cÄuÄeêVÄl u1Ä= xÄMã+1 Uã+HÄrÄowÇe   IÄøÅUÖDÉâ*U S B \T VÇ_ÄÎ0Ä”F¨ &ÄÊÅ_Ä^0¿ J5@R@V E1]@M@¡√ÑD@Çnï¿m@6c¿i A?ıM)O@ ¿AdEï¡(kYI,1@#.¬ A5U@h6@W2¿ 0ƒ 7]@J8¿¡Y&2ÃOLı¿éc¿/l¿[«N”%√≠Õ%3¿ì¡2F¿si@∫n@cl@EGÀGÅI@¬¢s¿~a l@ e@
™ ¿Ke@eBc¿oVdBA⁄r@s¿'f◊@≈wAC¿n@Á¡ht K¿y¿√k‚A≠@±p»ß…Ï ¿o ^‘t ßJi*a cÉ+·c	P†(t \= hC :†KW Ba!oµ†s‡S`"ae‡~’·k\‡Ts`U†°¢T‡s k`8e‡^W#c·m•{D‡s†ãr•‡
pÊ= Î ¢’m,dz* †	h¢!Íu"#o t c·jw!ÑaWa4f`a cxs’‡4o‡%  o w·6´cl!Jn‡	u  ‡ve†¢!§e†a#mı`n‡f‡ 'É°!Íy†p†ob!úÒ3õ!/!  ·qb !Z’!a†Ld†"t` ·ñUaO †e†t¢eÌ‡."ë#9l ab%ıÈ™t`= q·É 5˝°F  ?????ˇ???????ˇˇˇˇ