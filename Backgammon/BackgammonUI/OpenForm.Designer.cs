namespace BackgammonUI
{
    partial class OpenForm
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
            this.Human = new System.Windows.Forms.RadioButton();
            this.AI = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose game style";
            // 
            // Human
            // 
            this.Human.AutoSize = true;
            this.Human.Checked = true;
            this.Human.Location = new System.Drawing.Point(118, 81);
            this.Human.Name = "Human";
            this.Human.Size = new System.Drawing.Size(139, 21);
            this.Human.TabIndex = 1;
            this.Human.TabStop = true;
            this.Human.Text = "Human vs human";
            this.Human.UseVisualStyleBackColor = true;
            // 
            // AI
            // 
            this.AI.AutoSize = true;
            this.AI.Location = new System.Drawing.Point(118, 117);
            this.AI.Name = "AI";
            this.AI.Size = new System.Drawing.Size(108, 21);
            this.AI.TabIndex = 2;
            this.AI.Text = "Human vs AI";
            this.AI.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // OpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 253);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AI);
            this.Controls.Add(this.Human);
            this.Controls.Add(this.label1);
            this.Name = "OpenForm";
            this.Text = "Backgammon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Human;
        private System.Windows.Forms.RadioButton AI;
        private System.Windows.Forms.Button button1;
    }
}

