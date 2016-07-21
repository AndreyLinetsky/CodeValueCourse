using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgammonUI
{
    public partial class OpenForm : Form
    {
        public OpenForm()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            if (radioButton1.Checked)
            {
                Backgammon backgammon = new Backgammon(false,false);
                backgammon.ShowDialog();
            }
            else if(radioButton2.Checked)
            {
                Backgammon backgammon = new Backgammon(false,true);
                backgammon.ShowDialog();
            }
            else if(radioButton3.Checked)
            {
                Backgammon backgammon = new Backgammon(true,false);
                backgammon.ShowDialog();
            }
            else
            {
                Backgammon backgammon = new Backgammon(true, true);
                backgammon.ShowDialog();
            }
            this.Close();
        }
    }
}
