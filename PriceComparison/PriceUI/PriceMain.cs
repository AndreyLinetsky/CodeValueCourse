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
            ResetForm();
            Login();
        }
        public PricingLogicManager Manager { get; set; }
        public void ResetForm()
        {
            label1.Text = "Please login or register";
            button1.Enabled = false;
            ResetItemData();
            searchText.Text = string.Empty;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            viewCartToolStripMenuItem.Enabled = false;
            loadToolStripMenuItem.Enabled = false;
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // comp with guest?
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
                button1.Enabled = true;
                loadToolStripMenuItem.Enabled = true;
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
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.Visible = false;
                }
                dataGridView1.Columns["ItemCode"].Visible = true;
                dataGridView1.Columns["ItemDesc"].Visible = true;
                viewCartToolStripMenuItem.Enabled = true;
                dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateItemDetails();
        }
        public void UpdateItemDetails()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ItemGeneral currItem = dataGridView1.CurrentRow.DataBoundItem as ItemGeneral;
                if (currItem != null)
                {
                    priceText.Text = Manager.GetMinPrice(currItem).ToString();
                    codeText.Text = currItem.ItemCode.ToString();
                    nameText.Text = currItem.ItemDesc.ToString();
                    quanText.Text = currItem.Quantity.ToString();
                    unitText.Text = currItem.UnitQuantity.ToString();
                    button2.Enabled = true;
                }
                else
                {
                    ResetItemData();
                }
            }
            else
            {
                ResetItemData();
            }
        }
        public void ResetItemData()
        {
            foreach (Control control in panel1.Controls)
            {
                if (control.Name.Contains("Text"))
                {
                    control.Text = "";
                }
            }
            numericUpDown1.Value = 0;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1 ||
                numericUpDown1.Value > 100)
            {
                MessageBox.Show("Please enter valid amount");
            }
            else
            {
                ItemGeneral currItem = dataGridView1.CurrentRow.DataBoundItem as ItemGeneral;
                if (!Manager.AddItemToCart(currItem, Convert.ToInt32(numericUpDown1.Value)))
                {
                    MessageBox.Show("The product is already in cart");
                }
                else
                {
                    MessageBox.Show("The product was added successfully");
                }
            }
        }

        private void viewCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            СartForm cartForm = new СartForm(Manager,false);
            cartForm.ShowDialog();

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            СartForm cartForm = new СartForm(Manager, true);
            cartForm.ShowDialog();
        }


    }
}
