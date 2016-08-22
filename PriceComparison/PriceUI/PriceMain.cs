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
using System.Data.Entity;

namespace PriceUI
{
    public partial class PriceMain : Form
    {
        public PriceMain()
        {
            InitializeComponent();
            Manager = new PricingLogicManager();
            Login();
        }
        public PricingLogicManager Manager { get; set; }
        public void ResetForm()
        {
            label1.Text = "Please login or register";
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Manager.User != "")
            {
                MessageBox.Show("You are already logged");
            }
            else
            {
                Login();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Manager.User == "")
            {
                MessageBox.Show("You are not logged");
            }
            else
            {
                Manager.Logout();
                ResetForm();
            }
        }
        public void Login()
        {
            LoginForm logForm = new LoginForm(Manager);
            if (logForm.ShowDialog(this) == DialogResult.OK)
            {
                label1.Text = Manager.UserMessage;
            }
            else
            {
                ResetForm();
            }
            logForm.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchText.Text))
            {
                MessageBox.Show("Please submit product");
            }
            else
            {
                dataGridView1.DataSource = Manager.GetItems(searchText.Text);
                dataGridView1.Columns["Amount"].Visible = false;
                dataGridView1.Columns["ChainId"].Visible = false;
                dataGridView1.Columns["ItemType"].Visible = false;
                dataGridView1.Columns["ItemCode"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns["ItemDesc"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateItemDetails();
        }
        public void UpdateItemDetails()
        {

        }

            }
}
