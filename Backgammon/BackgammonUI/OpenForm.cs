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
            if (Human.Enabled)
            {
                Backgammon backgammon = new Backgammon("Human");
                backgammon.ShowDialog();
            }
            else
            {
                Backgammon backgammon = new Backgammon("AI");
                backgammon.ShowDialog();
            }
            this.Close();
        }
    }
}
