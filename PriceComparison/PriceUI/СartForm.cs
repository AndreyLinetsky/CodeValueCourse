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
using System.IO;

namespace PriceUI
{
    public partial class СartForm : Form
    {
        public СartForm(PricingLogicManager manager, bool isLoad)
        {
            InitializeComponent();
            Manager = manager;
            if (isLoad)
            {
                LoadCart();
            }
            else
            {
                ResetUI();
            }
        }
        public PricingLogicManager Manager { get; set; }
        public int ProductsToFetch { get; } = 3;
        public void ResetUI()
        {
            PopulateCart();
            List<string> chains = Manager.GetChains();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(chains.ToArray());
            ResetCompOutput();
        }
        private void PopulateCart()
        {
            dataGridView1.DataSource = Manager.GetCartItems();
            InitCart();
        }
        public void ResetCompOutput()
        {
            foreach (var panel in Controls.OfType<Panel>())
            {
                foreach (var label in panel.Controls.OfType<Label>())
                {
                    if (label.Name.Contains("comp"))
                    {
                        label.Text = string.Empty;
                    }
                }
                foreach (Control control in panel.Controls)
                {
                    control.Visible = false;
                }
            }
        }
        public void EnableCompare()
        {
            foreach (var panel in Controls.OfType<Panel>())
            {
                foreach (Control control in panel.Controls)
                {
                    control.Visible = true;
                }
            }
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
                        if (currItem.Amount == Convert.ToInt32(numericUpDown1.Value))
                        {
                            MessageBox.Show("Amount was not changed");
                        }
                        else
                        {
                            List<ItemGeneral> newItems = Manager.UpdateCart(currItem, Convert.ToInt32(numericUpDown1.Value));
                            RefreshCart(newItems);
                            MessageBox.Show("Product was updated successfully");
                        }
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
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
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

            if (ValidateFilters())
            {
                if (!storeAllRadio.Checked)
                {
                    List<string> stores = new List<string>();
                    foreach (var comboBox in panel1.Controls.OfType<ComboBox>())
                    {
                        if (comboBox.SelectedItem != null)
                        {
                            stores.Add(comboBox.SelectedValue.ToString());
                        }
                    }
                    updatedItems = Manager.CalculateTotal(stores);
                }
                else if (locAllRadio.Checked)
                {
                    updatedItems = Manager.CalculateTotal(listBox1.SelectedItems.OfType<string>().ToList(), null, ProductsToFetch);
                }
                else
                {
                    updatedItems = Manager.CalculateTotal(listBox1.SelectedItems.OfType<string>().ToList(), locComboBox.SelectedValue.ToString(), ProductsToFetch);
                }
                //ShowUpdatedCart(updatedItems);
            }
        }
        public bool ValidateFilters()
        {
            if (listBox1.SelectedItems.OfType<string>().ToList().Count < 1)
            {
                MessageBox.Show("Please select at least one chain");
                return false;
            }
            if (!storeAllRadio.Checked)
            {
                if (comboBox1.SelectedItem == null &&
                        comboBox2.SelectedItem == null &&
                        comboBox3.SelectedItem == null)
                {
                    MessageBox.Show("Please select at least one store");
                    return false;
                }
                if (string.Equals(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString()) ||
                    string.Equals(comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString()) ||
                    string.Equals(comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString()))
                {
                    MessageBox.Show("Duplicated stores were selected");
                    return false;
                }
            }
            if (!locAllRadio.Checked &&
                locComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select location");
                return false;
            }
            return true;
        }

        private void saveCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.Title = "Save Cart";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML-File | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                Manager.SaveCart(path);
                MessageBox.Show("Cart was saved");
            }
        }

        private void loadCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCart();
        }
        public void LoadCart()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Title = "Load Cart";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML-File | *.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                Manager.LoadCart(path);
                ResetUI();
            }
        }

        private void exportHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ItemHistForm histForm = new histForm(Manager);
            //histForm.ShowDialog();
        }

        
    }
}

