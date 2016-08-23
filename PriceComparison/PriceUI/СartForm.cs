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
    public partial class СartForm : Form
    {
        public СartForm(PricingLogicManager manager)
        {
            InitializeComponent();
            Manager = manager;
            PopulateCart();
            List<string> chains = Manager.GetChains();
            listBox1.Items.AddRange(chains.ToArray());
        }
        public PricingLogicManager Manager { get; set; }
        private void PopulateCart()
        {
            dataGridView1.DataSource = Manager.GetCartItems();
            InitCart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ItemGeneral currItem = dataGridView1.CurrentRow.DataBoundItem as ItemGeneral;
                if (currItem != null)
                {
                    List<ItemGeneral> newItems = Manager.RemoveItemFromCart(currItem);
                    RefreshCart(newItems);
                    MessageBox.Show("Product  was removed successfully");
                }
            }
            else
            {
                MessageBox.Show("Please select Product");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (numericUpDown1.Value < 1 ||
                numericUpDown1.Value > 100)
                {
                    MessageBox.Show("Please enter valid amount");
                }
                else
                {
                    ItemGeneral currItem = dataGridView1.CurrentRow.DataBoundItem as ItemGeneral;
                    if (currItem != null)
                    {
                        List<ItemGeneral> newItems = Manager.UpdateCart(currItem, Convert.ToInt32(numericUpDown1.Value));
                        RefreshCart(newItems);
                        MessageBox.Show("Product was updated successfully");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select Product");
            }
        }
        public void RefreshCart(List<ItemGeneral> newItems)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = newItems;
            InitCart();
            dataGridView1.Update();
            dataGridView1.ClearSelection();
        }
        public void InitCart()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Visible = false;
            }
            dataGridView1.Columns["ItemCode"].Visible = true;
            dataGridView1.Columns["ItemDesc"].Visible = true;
            dataGridView1.Columns["Amount"].Visible = true;
        }

        private void exitCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void locAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            locComboBox.Enabled = false;
            locComboBox.SelectedItem = null;
            List<string> stores = Manager.GetStores(listBox1.SelectedItems.OfType<string>().ToList());
            ResetStores(stores);
        }

        private void storeRadio_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
        }

        private void storeAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
        }

        private void locSelRadio_CheckedChanged(object sender, EventArgs e)
        {
            locComboBox.Enabled = true;

        }
        public void ResetStores(List<string> stores)
        {
            comboBox1.DataSource = stores;
            List<string> stores2 = new List<string>(stores);
            List<string> stores3 = new List<string>(stores);
            comboBox2.DataSource = stores2;
            comboBox3.DataSource = stores3;
            storeAllRadio.Checked = true;
        }
        private void locComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locComboBox.SelectedItem != null &&
                locComboBox.Enabled == true)
            {
                List<string> stores = Manager.GetStores(listBox1.SelectedItems.OfType<string>().ToList(), locComboBox.SelectedValue.ToString());
                ResetStores(stores);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> locations = Manager.GetLocations(listBox1.SelectedItems.OfType<string>().ToList());
            locComboBox.DataSource = locations;
            locAllRadio.Checked = true;
            locComboBox.SelectedItem = null;
            List<string> stores = Manager.GetStores(listBox1.SelectedItems.OfType<string>().ToList());
            ResetStores(stores);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<UpdatedCart> updatedItems = new List<UpdatedCart>(); 
            if (!storeAllRadio.Checked)
            {
                updatedItems = Manager.CalculateTotal(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString();
            }
            else if (locAllRadio.Checked)
            {
                updatedItems = Manager.CalculateTotal(listBox1.SelectedItems.OfType<string>().ToList());
            }
            else
            {
                updatedItems =  Manager.CalculateTotal(listBox1.SelectedItems.OfType<string>().ToList(), locComboBox.SelectedValue.ToString());
            }
        }

    }
}
}
