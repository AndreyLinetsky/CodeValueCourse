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
            ResetUI();
        }
        public PricingLogicManager Manager { get; set; }
        public int ProductsToFetch { get; } = 3;
        public void ResetUI()
        {
            InitCart();
            var chains = Manager.GetChains();
            chainsListBox.SelectedIndexChanged -= chainsListBox_SelectedIndexChanged;
            chainsListBox.DataSource = chains;
            chainsListBox.DisplayMember = "Value";
            chainsListBox.ValueMember = "Key";
            chainsListBox.SelectedItem = null;
            chainsListBox.SelectedIndexChanged += chainsListBox_SelectedIndexChanged;
            ResetCompOutput();
        }

        public void ResetCompOutput()
        {
            foreach (var panel in Controls.OfType<Panel>().Where(p => p.Name.Contains("compPanel")))
            {
                panel.Controls.OfType<TextBox>().ToList().ForEach(t => t.Text = string.Empty);
                panel.Controls.OfType<ComboBox>().ToList().ForEach(t => t.Items.Clear());
                panel.Controls.OfType<Control>().ToList().ForEach(c => c.Visible = false);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                CartItem currItem = dataGridView1.CurrentRow.DataBoundItem as CartItem;
                if (currItem != null)
                {
                    Manager.RemoveItemFromCart(currItem);
                    InitCart();
                    MessageBox.Show("Product  was removed successfully");
                }
                else
                {
                    ResetUI();
                    MessageBox.Show("Error! Please reselect item");
                }
            }
            else
            {
                MessageBox.Show("Please select Product");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
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
                    CartItem currItem = dataGridView1.CurrentRow.DataBoundItem as CartItem;
                    if (currItem != null)
                    {
                        if (currItem.Amount == Convert.ToInt32(numericUpDown1.Value))
                        {
                            MessageBox.Show("Amount was not changed");
                        }
                        else
                        {
                            Manager.UpdateCart(currItem, Convert.ToInt32(numericUpDown1.Value));
                            InitCart();
                            MessageBox.Show("Product was updated successfully");
                        }
                    }
                    else
                    {
                        ResetUI();
                        MessageBox.Show("Error! Please reselect item");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select Product");
            }
        }

        public void InitCart()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Manager.GetCartItems();
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
            dataGridView1.Columns["Amount"].Visible = true;
            dataGridView1.Columns["Amount"].Width = 60;
            dataGridView1.Columns["Amount"].HeaderText = "Amount";
            dataGridView1.ClearSelection();
        }

        private void exitCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<long> GetSelectedChains()
        {
            return chainsListBox.SelectedItems.OfType<KeyValuePair<long, string>>().Select(i => i.Key).ToList();
        }
        private void chainsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var locations = Manager.GetLocations(GetSelectedChains());
            locComboBox.DataSource = locations;
            locAllRadio.Checked = true;
            locComboBox.SelectedItem = null;
            ResetStores(false);
        }
        private void locAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            locComboBox.Enabled = false;
            locComboBox.SelectedItem = null;
            ResetStores(false);
        }
        private void locSelRadio_CheckedChanged(object sender, EventArgs e)
        {
            locComboBox.Enabled = true;
        }
        private void locComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locComboBox.SelectedItem != null &&
                locComboBox.Enabled == true)
            {
                ResetStores(true);
            }
        }
        public void ResetStores(bool isLocationNeeded)
        {
            List<KeyValuePair<string, string>> stores;
            if (isLocationNeeded)
            {
                stores = Manager.GetStores(GetSelectedChains(), locComboBox.SelectedValue.ToString());
            }
            else
            {
                stores = Manager.GetStores(GetSelectedChains(), null);
            }
            foreach (var comboBox in storePanel.Controls.OfType<ComboBox>())
            {
                List<KeyValuePair<string, string>> currStores = new List<KeyValuePair<string, string>>(stores);
                comboBox.DataSource = currStores;
                comboBox.SelectedItem = null;
                comboBox.DisplayMember = "Value";
                comboBox.ValueMember = "Key";
            }
            storeAllRadio.Checked = true;
        }

        private void storeAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            InitStores(false);
        }
        private void storeSelRadio_CheckedChanged(object sender, EventArgs e)
        {
            InitStores(true);
        }

        public void InitStores(bool isStoresEnabled)
        {
            storePanel.Controls.OfType<ComboBox>().ToList().ForEach(c => c.Enabled = isStoresEnabled);
        }
        private void compareButton_Click(object sender, EventArgs e)
        {
            List<UpdatedCart> updatedItems = new List<UpdatedCart>();

            if (ValidateFilters())
            {
                ResetCompOutput();
                if (storeSelRadio.Checked)
                {
                    List<string> stores = new List<string>();
                    foreach (var comboBox in storePanel.Controls.OfType<ComboBox>())
                    {
                        if (comboBox.SelectedItem != null &&
                            !stores.Contains(comboBox.SelectedValue.ToString()))
                        {
                            stores.Add(comboBox.SelectedValue.ToString());
                        }
                    }
                    updatedItems = Manager.CalculateTotal(stores);
                }
                else if (locAllRadio.Checked)
                {
                    updatedItems = Manager.CalculateTotal(GetSelectedChains(), null, ProductsToFetch);
                }
                else
                {
                    updatedItems = Manager.CalculateTotal(GetSelectedChains(), locComboBox.SelectedValue.ToString(), ProductsToFetch);
                }

                if (updatedItems.Count > 0)
                {
                    ShowUpdatedCart(updatedItems);
                }
                else
                {
                    MessageBox.Show("No results were found");
                }
            }
        }
        public bool ValidateFilters()
        {
            if (chainsListBox.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select at least one chain");
                return false;
            }
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("The cart is empty");
                return false;
            }
            if (storeSelRadio.Checked &&
                comboStore1.SelectedItem == null &&
                comboStore2.SelectedItem == null &&
                comboStore3.SelectedItem == null)
            {
                MessageBox.Show("Please select at least one store");
                return false;
            }

            if (locSelRadio.Checked &&
                locComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select location");
                return false;
            }
            return true;
        }

        public void ShowUpdatedCart(List<UpdatedCart> updatedItems)
        {
            for (int i = 1; i <= updatedItems.Count; i++)
            {
                EnablePanel(i);
                WriteToPanel(updatedItems[i - 1], i);
            }
        }

        public void EnablePanel(int currNum)
        {
            Panel currPanel = (Panel)Controls.Find($"compPanel{currNum}", true).FirstOrDefault();
            currPanel.Controls.OfType<Control>().ToList().ForEach(c => c.Visible = true);
        }

        public void WriteToPanel(UpdatedCart currCart, int currNum)
        {
            TextBox txtChain = (TextBox)Controls.Find($"compChain{currNum}", true).FirstOrDefault();
            txtChain.Text = currCart.ChainName;
            TextBox txtStore = (TextBox)Controls.Find($"compStore{currNum}", true).FirstOrDefault();
            txtStore.Text = currCart.StoreName;
            TextBox txtTotal = (TextBox)Controls.Find($"compTotal{currNum}", true).FirstOrDefault();
            txtTotal.Text = currCart.TotalPrice.ToString();
            for (int i = 1; i <= currCart.CheapItems.Count; i++)
            {
                TextBox txtItem = (TextBox)Controls.Find($"compItem{i}Ch{currNum}", true).FirstOrDefault();
                txtItem.Text = currCart.CheapItems[i - 1].ItemName;
                TextBox txtPrice = (TextBox)Controls.Find($"compPrice{i}Ch{currNum}", true).FirstOrDefault();
                txtPrice.Text = currCart.CheapItems[i - 1].Price.ToString();
            }
            for (int i = 1; i <= currCart.ExpensiveItems.Count; i++)
            {
                TextBox txtItem = (TextBox)Controls.Find($"compItem{i}Ex{currNum}", true).FirstOrDefault();
                txtItem.Text = currCart.ExpensiveItems[i - 1].ItemName;
                TextBox txtPrice = (TextBox)Controls.Find($"compPrice{i}Ex{currNum}", true).FirstOrDefault();
                txtPrice.Text = currCart.ExpensiveItems[i - 1].Price.ToString();
            }
            string[] missingItems = currCart.Items.Where(i => i.Price == 0).Select(i => i.ItemName).ToArray();
            ComboBox comMissing = (ComboBox)Controls.Find($"compCombo{currNum}", true).FirstOrDefault();
            comMissing.Items.AddRange(missingItems);
        }

        private void saveCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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
            ResetUI();
        }
        public void LoadCart()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Load Cart";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML-File | *.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                try
                {
                    Manager.LoadCart(path);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (compChain1.Text == string.Empty)
            {
                MessageBox.Show("No stores were compared");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Title = "Save Comparison";
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "XLSX-File | *.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;
                    Manager.SaveComparison(path);
                    MessageBox.Show("Comparison was saved");
                }
            }
        }

        private void histButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                CartItem currItem = dataGridView1.CurrentRow.DataBoundItem as CartItem;
                if (currItem != null)
                {
                    var itemStores = Manager.GetItemStores(currItem);
                    if (itemStores.Count > 0)
                    {
                        using (HistForm histForm = new HistForm(Manager, itemStores, currItem))
                        {
                            histForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No history exists for this product");
                    }
                }
                else
                {
                    ResetUI();
                    MessageBox.Show("Error! Please reselect item");
                }
            }
            else
            {
                MessageBox.Show("Please select product");
            }
        }
    }
}

