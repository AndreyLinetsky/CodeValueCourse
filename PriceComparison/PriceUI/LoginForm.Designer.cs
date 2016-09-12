namespace PriceUI
{
    partial class LoginForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Login = new System.Windows.Forms.TabPage();
            this.logBut = new System.Windows.Forms.Button();
            this.logPass = new System.Windows.Forms.TextBox();
            this.logUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Register = new System.Windows.Forms.TabPage();
            this.regConf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.regBut = new System.Windows.Forms.Button();
            this.regPass = new System.Windows.Forms.TextBox();
            this.regUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Login.SuspendLayout();
            this.Register.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Login);
            this.tabControl1.Controls.Add(this.Register);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(283, 216);
            this.tabControl1.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.Controls.Add(this.logBut);
            this.Login.Controls.Add(this.logPass);
            this.Login.Controls.Add(this.logUser);
            this.Login.Controls.Add(this.label2);
            this.Login.Controls.Add(this.label1);
            this.Login.Location = new System.Drawing.Point(4, 25);
            this.Login.Name = "Login";
            this.Login.Padding = new System.Windows.Forms.Padding(3);
            this.Login.Size = new System.Drawing.Size(275, 187);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            // 
            // logBut
            // 
            this.logBut.Location = new System.Drawing.Point(125, 93);
            this.logBut.Name = "logBut";
            this.logBut.Size = new System.Drawing.Size(75, 27);
            this.logBut.TabIndex = 4;
            this.logBut.Text = "Login";
            this.logBut.UseVisualStyleBackColor = true;
            this.logBut.Click += new System.EventHandler(this.logBut_Click);
            // 
            // logPass
            // 
            this.logPass.Location = new System.Drawing.Point(113, 56);
            this.logPass.Name = "logPass";
            this.logPass.Size = new System.Drawing.Size(100, 22);
            this.logPass.TabIndex = 3;
            this.logPass.UseSystemPasswordChar = true;
            // 
            // logUser
            // 
            this.logUser.Location = new System.Drawing.Point(113, 18);
            this.logUser.Name = "logUser";
            this.logUser.Size = new System.Drawing.Size(100, 22);
            this.logUser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // Register
            // 
            this.Register.Controls.Add(this.regConf);
            this.Register.Controls.Add(this.label6);
            this.Register.Controls.Add(this.regBut);
            this.Register.Controls.Add(this.regPass);
            this.Register.Controls.Add(this.regUser);
            this.Register.Controls.Add(this.label4);
            this.Register.Controls.Add(this.label5);
            this.Register.Location = new System.Drawing.Point(4, 25);
            this.Register.Name = "Register";
            this.Register.Padding = new System.Windows.Forms.Padding(3);
            this.Register.Size = new System.Drawing.Size(275, 187);
            this.Register.TabIndex = 1;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            // 
            // regConf
            // 
            this.regConf.Location = new System.Drawing.Point(112, 87);
            this.regConf.Name = "regConf";
            this.regConf.Size = new System.Drawing.Size(100, 22);
            this.regConf.TabIndex = 13;
            this.regConf.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Confirm";
            // 
            // regBut
            // 
            this.regBut.Location = new System.Drawing.Point(125, 128);
            this.regBut.Name = "regBut";
            this.regBut.Size = new System.Drawing.Size(75, 27);
            this.regBut.TabIndex = 10;
            this.regBut.Text = "Register";
            this.regBut.UseVisualStyleBackColor = true;
            this.regBut.Click += new System.EventHandler(this.regBut_Click);
            // 
            // regPass
            // 
            this.regPass.Location = new System.Drawing.Point(112, 50);
            this.regPass.Name = "regPass";
            this.regPass.Size = new System.Drawing.Size(100, 22);
            this.regPass.TabIndex = 9;
            this.regPass.UseSystemPasswordChar = true;
            // 
            // regUser
            // 
            this.regUser.Location = new System.Drawing.Point(112, 12);
            this.regUser.Name = "regUser";
            this.regUser.Size = new System.Drawing.Size(100, 22);
            this.regUser.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Username";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 229);
            this.Controls.Add(this.tabControl1);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.tabControl1.ResumeLayout(false);
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.Register.ResumeLayout(false);
            this.Register.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Login;
        private System.Windows.Forms.TabPage Register;
        private System.Windows.Forms.Button logBut;
        private System.Windows.Forms.TextBox logPass;
        private System.Windows.Forms.TextBox logUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button regBut;
        private System.Windows.Forms.TextBox regUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox regConf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox regPass;
        private System.Windows.Forms.Label label4;
    }
}