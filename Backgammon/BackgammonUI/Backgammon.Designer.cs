namespace BackgammonUI
{
    partial class Backgammon
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
            this.board = new System.Windows.Forms.PictureBox();
            this.roll = new System.Windows.Forms.Button();
            this.turn = new System.Windows.Forms.Label();
            this.BlackLab = new System.Windows.Forms.Label();
            this.GreenLab = new System.Windows.Forms.Label();
            this.Message = new System.Windows.Forms.Label();
            this.Dice1 = new System.Windows.Forms.PictureBox();
            this.Dice2 = new System.Windows.Forms.PictureBox();
            this.Point0 = new System.Windows.Forms.PictureBox();
            this.Point1 = new System.Windows.Forms.PictureBox();
            this.Point2 = new System.Windows.Forms.PictureBox();
            this.Point3 = new System.Windows.Forms.PictureBox();
            this.Point4 = new System.Windows.Forms.PictureBox();
            this.Point5 = new System.Windows.Forms.PictureBox();
            this.Point7 = new System.Windows.Forms.PictureBox();
            this.Point8 = new System.Windows.Forms.PictureBox();
            this.Point9 = new System.Windows.Forms.PictureBox();
            this.Point10 = new System.Windows.Forms.PictureBox();
            this.Point11 = new System.Windows.Forms.PictureBox();
            this.Point12 = new System.Windows.Forms.PictureBox();
            this.Point23 = new System.Windows.Forms.PictureBox();
            this.Point22 = new System.Windows.Forms.PictureBox();
            this.Point21 = new System.Windows.Forms.PictureBox();
            this.Point20 = new System.Windows.Forms.PictureBox();
            this.Point19 = new System.Windows.Forms.PictureBox();
            this.Point18 = new System.Windows.Forms.PictureBox();
            this.Point17 = new System.Windows.Forms.PictureBox();
            this.Point16 = new System.Windows.Forms.PictureBox();
            this.Point15 = new System.Windows.Forms.PictureBox();
            this.Point14 = new System.Windows.Forms.PictureBox();
            this.Point13 = new System.Windows.Forms.PictureBox();
            this.Point24 = new System.Windows.Forms.PictureBox();
            this.Point6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point6)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.Image = global::BackgammonUI.Properties.Resources.Optimized_Game_Board_BackgammonFull_Red_White_3;
            this.board.Location = new System.Drawing.Point(12, 2);
            this.board.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(601, 432);
            this.board.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.board.TabIndex = 0;
            this.board.TabStop = false;
            // 
            // roll
            // 
            this.roll.Enabled = false;
            this.roll.Location = new System.Drawing.Point(693, 89);
            this.roll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roll.Name = "roll";
            this.roll.Size = new System.Drawing.Size(81, 31);
            this.roll.TabIndex = 1;
            this.roll.Text = "Roll";
            this.roll.UseVisualStyleBackColor = true;
            this.roll.Click += new System.EventHandler(this.roll_Click);
            // 
            // turn
            // 
            this.turn.AutoSize = true;
            this.turn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.turn.Location = new System.Drawing.Point(691, 50);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(38, 17);
            this.turn.TabIndex = 2;
            this.turn.Text = "Turn";
            // 
            // BlackLab
            // 
            this.BlackLab.AutoSize = true;
            this.BlackLab.Location = new System.Drawing.Point(663, 153);
            this.BlackLab.Name = "BlackLab";
            this.BlackLab.Size = new System.Drawing.Size(42, 17);
            this.BlackLab.TabIndex = 3;
            this.BlackLab.Text = "Black";
            // 
            // GreenLab
            // 
            this.GreenLab.AutoSize = true;
            this.GreenLab.Location = new System.Drawing.Point(749, 153);
            this.GreenLab.Name = "GreenLab";
            this.GreenLab.Size = new System.Drawing.Size(48, 17);
            this.GreenLab.TabIndex = 4;
            this.GreenLab.Text = "Green";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(652, 302);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 17);
            this.Message.TabIndex = 5;
            // 
            // Dice1
            // 
            this.Dice1.Location = new System.Drawing.Point(655, 193);
            this.Dice1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dice1.Name = "Dice1";
            this.Dice1.Size = new System.Drawing.Size(73, 73);
            this.Dice1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Dice1.TabIndex = 6;
            this.Dice1.TabStop = false;
            this.Dice1.Click += new System.EventHandler(this.Dice1_Click);
            // 
            // Dice2
            // 
            this.Dice2.Location = new System.Drawing.Point(741, 193);
            this.Dice2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dice2.Name = "Dice2";
            this.Dice2.Size = new System.Drawing.Size(73, 73);
            this.Dice2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Dice2.TabIndex = 7;
            this.Dice2.TabStop = false;
            this.Dice2.Click += new System.EventHandler(this.Dice2_Click);
            // 
            // Point0
            // 
            this.Point0.Location = new System.Drawing.Point(549, 252);
            this.Point0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point0.Name = "Point0";
            this.Point0.Size = new System.Drawing.Size(29, 156);
            this.Point0.TabIndex = 8;
            this.Point0.TabStop = false;
            // 
            // Point1
            // 
            this.Point1.Location = new System.Drawing.Point(501, 252);
            this.Point1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point1.Name = "Point1";
            this.Point1.Size = new System.Drawing.Size(29, 156);
            this.Point1.TabIndex = 9;
            this.Point1.TabStop = false;
            // 
            // Point2
            // 
            this.Point2.Location = new System.Drawing.Point(456, 252);
            this.Point2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point2.Name = "Point2";
            this.Point2.Size = new System.Drawing.Size(29, 156);
            this.Point2.TabIndex = 10;
            this.Point2.TabStop = false;
            // 
            // Point3
            // 
            this.Point3.Location = new System.Drawing.Point(411, 252);
            this.Point3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point3.Name = "Point3";
            this.Point3.Size = new System.Drawing.Size(29, 156);
            this.Point3.TabIndex = 11;
            this.Point3.TabStop = false;
            // 
            // Point4
            // 
            this.Point4.Location = new System.Drawing.Point(365, 252);
            this.Point4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point4.Name = "Point4";
            this.Point4.Size = new System.Drawing.Size(29, 156);
            this.Point4.TabIndex = 12;
            this.Point4.TabStop = false;
            // 
            // Point5
            // 
            this.Point5.Location = new System.Drawing.Point(327, 252);
            this.Point5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point5.Name = "Point5";
            this.Point5.Size = new System.Drawing.Size(29, 156);
            this.Point5.TabIndex = 13;
            this.Point5.TabStop = false;
            // 
            // Point7
            // 
            this.Point7.Location = new System.Drawing.Point(208, 252);
            this.Point7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point7.Name = "Point7";
            this.Point7.Size = new System.Drawing.Size(29, 156);
            this.Point7.TabIndex = 14;
            this.Point7.TabStop = false;
            // 
            // Point8
            // 
            this.Point8.Location = new System.Drawing.Point(155, 252);
            this.Point8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point8.Name = "Point8";
            this.Point8.Size = new System.Drawing.Size(29, 156);
            this.Point8.TabIndex = 15;
            this.Point8.TabStop = false;
            // 
            // Point9
            // 
            this.Point9.Location = new System.Drawing.Point(109, 252);
            this.Point9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point9.Name = "Point9";
            this.Point9.Size = new System.Drawing.Size(29, 156);
            this.Point9.TabIndex = 16;
            this.Point9.TabStop = false;
            // 
            // Point10
            // 
            this.Point10.Location = new System.Drawing.Point(64, 252);
            this.Point10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point10.Name = "Point10";
            this.Point10.Size = new System.Drawing.Size(29, 156);
            this.Point10.TabIndex = 17;
            this.Point10.TabStop = false;
            // 
            // Point11
            // 
            this.Point11.Location = new System.Drawing.Point(28, 252);
            this.Point11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point11.Name = "Point11";
            this.Point11.Size = new System.Drawing.Size(29, 156);
            this.Point11.TabIndex = 18;
            this.Point11.TabStop = false;
            // 
            // Point12
            // 
            this.Point12.Location = new System.Drawing.Point(28, 14);
            this.Point12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point12.Name = "Point12";
            this.Point12.Size = new System.Drawing.Size(29, 156);
            this.Point12.TabIndex = 19;
            this.Point12.TabStop = false;
            // 
            // Point23
            // 
            this.Point23.Location = new System.Drawing.Point(549, 14);
            this.Point23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point23.Name = "Point23";
            this.Point23.Size = new System.Drawing.Size(29, 156);
            this.Point23.TabIndex = 21;
            this.Point23.TabStop = false;
            // 
            // Point22
            // 
            this.Point22.Location = new System.Drawing.Point(501, 14);
            this.Point22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point22.Name = "Point22";
            this.Point22.Size = new System.Drawing.Size(29, 156);
            this.Point22.TabIndex = 22;
            this.Point22.TabStop = false;
            // 
            // Point21
            // 
            this.Point21.Location = new System.Drawing.Point(456, 14);
            this.Point21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point21.Name = "Point21";
            this.Point21.Size = new System.Drawing.Size(29, 156);
            this.Point21.TabIndex = 23;
            this.Point21.TabStop = false;
            // 
            // Point20
            // 
            this.Point20.Location = new System.Drawing.Point(411, 14);
            this.Point20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point20.Name = "Point20";
            this.Point20.Size = new System.Drawing.Size(29, 156);
            this.Point20.TabIndex = 24;
            this.Point20.TabStop = false;
            // 
            // Point19
            // 
            this.Point19.Location = new System.Drawing.Point(365, 14);
            this.Point19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point19.Name = "Point19";
            this.Point19.Size = new System.Drawing.Size(29, 156);
            this.Point19.TabIndex = 25;
            this.Point19.TabStop = false;
            // 
            // Point18
            // 
            this.Point18.BackColor = System.Drawing.SystemColors.Control;
            this.Point18.Location = new System.Drawing.Point(327, 14);
            this.Point18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point18.Name = "Point18";
            this.Point18.Size = new System.Drawing.Size(29, 156);
            this.Point18.TabIndex = 26;
            this.Point18.TabStop = false;
            // 
            // Point17
            // 
            this.Point17.Location = new System.Drawing.Point(253, 14);
            this.Point17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point17.Name = "Point17";
            this.Point17.Size = new System.Drawing.Size(29, 156);
            this.Point17.TabIndex = 27;
            this.Point17.TabStop = false;
            // 
            // Point16
            // 
            this.Point16.Location = new System.Drawing.Point(208, 14);
            this.Point16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point16.Name = "Point16";
            this.Point16.Size = new System.Drawing.Size(29, 156);
            this.Point16.TabIndex = 28;
            this.Point16.TabStop = false;
            // 
            // Point15
            // 
            this.Point15.Location = new System.Drawing.Point(155, 14);
            this.Point15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point15.Name = "Point15";
            this.Point15.Size = new System.Drawing.Size(29, 156);
            this.Point15.TabIndex = 29;
            this.Point15.TabStop = false;
            // 
            // Point14
            // 
            this.Point14.Location = new System.Drawing.Point(109, 14);
            this.Point14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point14.Name = "Point14";
            this.Point14.Size = new System.Drawing.Size(29, 156);
            this.Point14.TabIndex = 30;
            this.Point14.TabStop = false;
            // 
            // Point13
            // 
            this.Point13.Location = new System.Drawing.Point(64, 12);
            this.Point13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point13.Name = "Point13";
            this.Point13.Size = new System.Drawing.Size(29, 156);
            this.Point13.TabIndex = 31;
            this.Point13.TabStop = false;
            // 
            // Point24
            // 
            this.Point24.Location = new System.Drawing.Point(289, 14);
            this.Point24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point24.Name = "Point24";
            this.Point24.Size = new System.Drawing.Size(25, 154);
            this.Point24.TabIndex = 32;
            this.Point24.TabStop = false;
            // 
            // Point6
            // 
            this.Point6.Location = new System.Drawing.Point(253, 252);
            this.Point6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Point6.Name = "Point6";
            this.Point6.Size = new System.Drawing.Size(29, 156);
            this.Point6.TabIndex = 34;
            this.Point6.TabStop = false;
            // 
            // Backgammon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 448);
            this.Controls.Add(this.Point6);
            this.Controls.Add(this.Point24);
            this.Controls.Add(this.Point13);
            this.Controls.Add(this.Point14);
            this.Controls.Add(this.Point15);
            this.Controls.Add(this.Point16);
            this.Controls.Add(this.Point17);
            this.Controls.Add(this.Point18);
            this.Controls.Add(this.Point19);
            this.Controls.Add(this.Point20);
            this.Controls.Add(this.Point21);
            this.Controls.Add(this.Point22);
            this.Controls.Add(this.Point23);
            this.Controls.Add(this.Point12);
            this.Controls.Add(this.Point11);
            this.Controls.Add(this.Point10);
            this.Controls.Add(this.Point9);
            this.Controls.Add(this.Point8);
            this.Controls.Add(this.Point7);
            this.Controls.Add(this.Point5);
            this.Controls.Add(this.Point4);
            this.Controls.Add(this.Point3);
            this.Controls.Add(this.Point2);
            this.Controls.Add(this.Point1);
            this.Controls.Add(this.Point0);
            this.Controls.Add(this.Dice2);
            this.Controls.Add(this.Dice1);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.GreenLab);
            this.Controls.Add(this.BlackLab);
            this.Controls.Add(this.turn);
            this.Controls.Add(this.roll);
            this.Controls.Add(this.board);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Backgammon";
            this.Text = "Backgammon";
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Point6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.Button roll;
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.Label BlackLab;
        private System.Windows.Forms.Label GreenLab;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.PictureBox Dice1;
        private System.Windows.Forms.PictureBox Dice2;
        private System.Windows.Forms.PictureBox Point0;
        private System.Windows.Forms.PictureBox Point1;
        private System.Windows.Forms.PictureBox Point2;
        private System.Windows.Forms.PictureBox Point3;
        private System.Windows.Forms.PictureBox Point4;
        private System.Windows.Forms.PictureBox Point5;
        private System.Windows.Forms.PictureBox Point7;
        private System.Windows.Forms.PictureBox Point8;
        private System.Windows.Forms.PictureBox Point9;
        private System.Windows.Forms.PictureBox Point10;
        private System.Windows.Forms.PictureBox Point11;
        private System.Windows.Forms.PictureBox Point12;
        private System.Windows.Forms.PictureBox Point23;
        private System.Windows.Forms.PictureBox Point22;
        private System.Windows.Forms.PictureBox Point21;
        private System.Windows.Forms.PictureBox Point20;
        private System.Windows.Forms.PictureBox Point19;
        private System.Windows.Forms.PictureBox Point18;
        private System.Windows.Forms.PictureBox Point17;
        private System.Windows.Forms.PictureBox Point16;
        private System.Windows.Forms.PictureBox Point15;
        private System.Windows.Forms.PictureBox Point14;
        private System.Windows.Forms.PictureBox Point13;
        private System.Windows.Forms.PictureBox Point24;
        private System.Windows.Forms.PictureBox Point6;
    }
}