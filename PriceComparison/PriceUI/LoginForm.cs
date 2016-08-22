using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceLogic;

namespace PriceUI
{
    public partial class LoginForm : Form
    {
        public LoginForm(PricingLogicManager manager)
        {
            InitializeComponent();
            Manager = manager;
        }
        public PricingLogicManager Manager { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(regUser.Text) ||
                String.IsNullOrWhiteSpace(regPass.Text) ||
                String.IsNullOrWhiteSpace(regConf.Text))
            {
                MessageBox.Show("Please fill all the data");
            }
            else if (regPass.Text != regConf.Text)
            {
                MessageBox.Show("Wrong password confirmation");
            }
            else
            {
                MessageBox.Show(Manager.Register(regUser.Text, regPass.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(logUser.Text) ||
                String.IsNullOrWhiteSpace(logPass.Text))
            {
                MessageBox.Show("Please fill all the data");
            }
            else
            {
                if (Manager.Login(logUser.Text, logPass.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }
    }
}
