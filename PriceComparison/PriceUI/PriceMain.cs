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
            searchBut.Enabled = false;
            itemChkBox.Enabled = false;
            ResetItemData();
            searchText.Text = string.Empty;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            viewCartToolStripMenuItem.Enabled = false;
            loadCartToolStripMenuItem.Enabled = false;
            welcomeBox.Text = "Please login";
        }
        public void ResetItemData()
        {
            panel1.Controls.OfType<TextBox>().ToList().ForEach(t => t.Text = string.Empty);
            numericUpDown1.Value = 0;
            addBut.Enabled = false;
            chainLabel.Visible = false;
            chainText.Visible = false;
        }
        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Manager.User != string.Empty)
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
            if (Manager.User == string.Empty)
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
            using (LoginForm logForm = new LoginForm(Manager))
            {
                if (logForm.ShowDialog(this) == DialogResult.OK)
                {
                    searchBut.Enabled = true;
                    viewCartToolStripMenuItem.Enabled = true;
                    loadCartToolStripMenuItem.Enabled = true;
                    itemChkBox.Enabled = true;
                    welcomeBox.Text = $"Welcome {Manager.User}";
                }
            }
        }

        private void searchBut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchText.Text))
            {
                MessageBox.Show("Please submit product");
            }
            else
            {
                dataGridView1.DataSource = Manager.GetItems(searchText.Text, itemChkBox.Checked);
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.Visible = false;
                }
                dataGridView1.Columns["ItemCode"].Visible = true;
                dataGridView1.Columns["ItemCode"].Width = 120;
                dataGridView1.Columns["ItemCode"].HeaderText = "Code";
                dataGridView1.Columns["ItemName"].Visible = true;
                dataGridView1.Columns["ItemName"].Width = 150;
                dataGridView1.Columns["ItemName"].HeaderText = "Name";
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
                CartItem currItem = dataGridView1.CurrentRow.DataBoundItem as CartItem;
                ItemInfo itemInfo = Manager.GetItemInfo(currItem);
                if (itemInfo != null)
                {
                    if (itemInfo.ItemType != 0)
                    {
                        typeText.Text = "General";
                        chainLabel.Visible = false;
                        chainText.Visible = false;
                    }
                    else
                    {
                        typeText.Text = "Internal";
                        chainLabel.Visible = true;
                        chainText.Visible = true;
                        chainText.Text = itemInfo.ChainName;
                    }
                    codeText.Text = itemInfo.ItemCode.ToString();
                    nameText.Text = itemInfo.ItemName;
                    quanText.Text = itemInfo.Quantity;
                    unitText.Text = itemInfo.UnitQuantity;
                    addBut.Enabled = true;
                }
                else
                {
                    ResetItemData();
                    MessageBox.Show("Error! Please reselect item");
                }
            }
            else
            {
                ResetItemData();
            }
        }


        private void addBut_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1 ||
                numericUpDown1.Value > 100)
            {
                MessageBox.Show("Please enter valid amount");
            }
            else
            {
                CartItem currItem = dataGridView1.CurrentRow.DataBoundItem as CartItem;
                if (currItem != null)
                {
                    if (!Manager.AddItemToCart(currItem, Convert.ToInt32(numericUpDown1.Value)))
                    {
                        MessageBox.Show("The product is already in cart");
                    }
                    else
                    {
                        MessageBox.Show("The product was added successfully");
                    }
                }
                else
                {
                    ResetItemData();
                    MessageBox.Show("Error! Please reselect item");
                }
            }
        }

        private void viewCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Manager.userCart.Items.Count > 0)
            {
                using (СartForm cartForm = new СartForm(Manager, false))
                {
                    cartForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("There are no items in the cart");
            }
        }

        private void loadCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (СartForm cartForm = new СartForm(Manager, true))
            {
                cartForm.ShowDialog();
            }
        }

        private async void updateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data is loading,please wait");
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            await Task.Run(() => Manager.LoadData());
            progressBar1.Visible = false;
            MessageBox.Show("Data loading is finished");
        }
    }
}
