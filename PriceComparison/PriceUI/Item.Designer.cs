namespace PriceUI
{
    partial class Item
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.units = new System.Windows.Forms.Label();
            this.package = new System.Windows.Forms.Label();
            this.desc = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Units";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Package Quantity:";
            // 
            // units
            // 
            this.units.AutoSize = true;
            this.units.Location = new System.Drawing.Point(155, 122);
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(0, 17);
            this.units.TabIndex = 5;
            // 
            // package
            // 
            this.package.AutoSize = true;
            this.package.Location = new System.Drawing.Point(155, 152);
            this.package.Name = "package";
            this.package.Size = new System.Drawing.Size(0, 17);
            this.package.TabIndex = 6;
            // 
            // desc
            // 
            this.desc.AutoSize = true;
            this.desc.Location = new System.Drawing.Point(155, 94);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(0, 17);
            this.desc.TabIndex = 7;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(155, 65);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(0, 17);
            this.name.TabIndex = 8;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(155, 38);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(0, 17);
            this.id.TabIndex = 9;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.id);
            this.Controls.Add(this.name);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.package);
            this.Controls.Add(this.units);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Item";
            this.Text = "Item Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label units;
        private System.Windows.Forms.Label package;
        private System.Windows.Forms.Label desc;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label id;
    }
}