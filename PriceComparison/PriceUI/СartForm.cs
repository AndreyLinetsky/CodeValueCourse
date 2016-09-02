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
            List<KeyValuePair<long, string>> chains = Manager.GetChains();
            listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;
            listBox1.DataSource = chains;
            listBox1.DisplayMember = "Value";
            listBox1.ValueMember = "Key";
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            ResetCompOutput();
        }
        private void PopulateCart()
        {
            dataGridView1.DataSource = Manager.GetCartItems();
            InitCart();
        }
        public void ResetCompOutput()
        {
            foreach (var panel in Controls.OfType<Panel>().Where(p => p.Name.Contains("compPanel")))
            {
                foreach (var label in panel.Controls.OfType<Label>())
                {
                    if (label.Name.Contains("comp"))
                    {
                        label.Text = string.Empty;
                    }
                }
                foreach (var combo in panel.Controls.OfType<ComboBox>())
                {
                    combo.Items.Clear();
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
                ItemHeader currItem = dataGridView1.CurrentRow.DataBoundItem as ItemHeader;
                if (currItem != null)
                {
                    List<ItemHeader> newItems = Manager.RemoveItemFromCart(currItem);
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
                    ItemHeader currItem = dataGridView1.CurrentRow.DataBoundItem as ItemHeader;
                    if (currItem != null)
                    {
                        if (currItem.Amount == Convert.ToInt32(numericUpDown1.Value))
                        {
                            MessageBox.Show("Amount was not changed");
                        }
                        else
                        {
                            List<ItemHeader> newItems = Manager.UpdateCart(currItem, Convert.ToInt32(numericUpDown1.Value));
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
        public void RefreshCart(List<ItemHeader> newItems)
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
            dataGridView1.Columns["ItemName"].Visible = true;
            dataGridView1.Columns["Amount"].Visible = true;
        }

        private void exitCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<long> GetSelectedChains()
        {
            return listBox1.SelectedItems.OfType<KeyValuePair<long, string>>().Select(i => i.Key).ToList();
        }
        private void locAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            locComboBox.Enabled = false;
            locComboBox.SelectedItem = null;
            List<KeyValuePair<string, string>> stores = Manager.GetStores(GetSelectedChains(), null);
            ResetStores(stores);
        }

        private void storeRadio_CheckedChanged(object sender, EventArgs e)
        {
            comboStore1.Enabled = true;
            comboStore2.Enabled = true;
            comboStore3.Enabled = true;
        }

        private void storeAllRadio_CheckedChanged(object sender, EventArgs e)
        {
            comboStore1.Enabled = false;
            comboStore2.Enabled = false;
            comboStore3.Enabled = false;
        }

        private void locSelRadio_CheckedChanged(object sender, EventArgs e)
        {
            locComboBox.Enabled = true;
        }
        public void ResetStores(List<KeyValuePair<string, string>> stores)
        {
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
        private void locComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locComboBox.SelectedItem != null &&
                locComboBox.Enabled == true)
            {
                List<KeyValuePair<string, string>> stores = Manager.GetStores(GetSelectedChains(), locComboBox.SelectedValue.ToString());
                ResetStores(stores);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> locations = Manager.GetLocations(GetSelectedChains());
            locComboBox.DataSource = locations;
            locAllRadio.Checked = true;
            locComboBox.SelectedItem = null;
            List<KeyValuePair<string, string>> stores = Manager.GetStores(GetSelectedChains(), null);
            ResetStores(stores);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<UpdatedCart> updatedItems = new List<UpdatedCart>();

            if (ValidateFilters())
            {
                ResetCompOutput();
                if (!storeAllRadio.Checked)
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
                ShowUpdatedCart(updatedItems);
            }
        }
        public bool ValidateFilters()
        {
            if (listBox1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select at least one chain");
                return false;
            }
            if (!storeAllRadio.Checked)
            {
                if (comboStore1.SelectedItem == null &&
                        comboStore2.SelectedItem == null &&
                        comboStore3.SelectedItem == null)
                {
                    MessageBox.Show("Please select at least one store");
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
            foreach (Control control in currPanel.Controls)
            {
                control.Visible = true;
            }
        }

        public void WriteToPanel(UpdatedCart currCart, int currNum)
        {
            Label panChain = (Label)Controls.Find($"compChain{currNum}", true).FirstOrDefault();
            panChain.Text = currCart.ChainName;
            Label panStore = (Label)Controls.Find($"compStore{currNum}", true).FirstOrDefault();
            panStore.Text = currCart.StoreName;
            Label panTotal = (Label)Controls.Find($"compTotal{currNum}", true).FirstOrDefault();
            panTotal.Text = currCart.TotalPrice.ToString();
            for (int i = 1; i <= currCart.CheapItems.Count; i++)
            {
                Label panItem = (Label)Controls.Find($"compItem{i}Ch{currNum}", true).FirstOrDefault();
                panItem.Text = currCart.CheapItems[i - 1].ItemName;
                Label panPrice = (Label)Controls.Find($"compPrice{i}Ch{currNum}", true).FirstOrDefault();
                panPrice.Text = currCart.CheapItems[i - 1].Price.ToString();
            }
            for (int i = 1; i <= currCart.ExpensiveItems.Count; i++)
            {
                Label panItem = (Label)Controls.Find($"compItem{i}Ex{currNum}", true).FirstOrDefault();
                panItem.Text = currCart.ExpensiveItems[i - 1].ItemName;
                Label panPrice = (Label)Controls.Find($"compPrice{i}Ex{currNum}", true).FirstOrDefault();
                panPrice.Text = currCart.ExpensiveItems[i - 1].Price.ToString();
            }
            string[] missingItems = currCart.Items.Where(i => i.Price == 0).Select(i => i.ItemName).ToArray();
            ComboBox comMissing = (ComboBox)Controls.Find($"compCombo{currNum}", true).FirstOrDefault();
            comMissing.Items.AddRange(missingItems);
        }
        //public void EnablePanel(int currNum)
        //{
        //    Panel currPanel = (Panel)Controls.Find(String.Format("compPanel{0}", currNum), true).FirstOrDefault();
        //    foreach (Control control in currPanel.Controls)
        //    {
        //        control.Visible = true;
        //    }
        //}

        //public void WriteToPanel(UpdatedCart currCart, int currNum)
        //{
        //    Label panChain = (Label)Controls.Find(String.Format("compChain{0}", currNum), true).FirstOrDefault();
        //    panChain.Text = currCart.ChainName;
        //    Label panStore = (Label)Controls.Find(String.Format("compStore{0}", currNum), true).FirstOrDefault();
        //    panStore.Text = currCart.StoreName;
        //    Label panTotal = (Label)Controls.Find(String.Format("compTotal{0}", currNum), true).FirstOrDefault();
        //    panTotal.Text = currCart.TotalPrice.ToString();
        //    for (int i = 1; i <= currCart.CheapItems.Count; i++)
        //    {
        //        Label panItem = (Label)Controls.Find(String.Format("compItem{0}Ch{1}", i, currNum), true).FirstOrDefault();
        //        panItem.Text = currCart.CheapItems[i - 1].ItemDesc;
        //        Label panPrice = (Label)Controls.Find(String.Format("compPrice{0}Ch{1}", i, currNum), true).FirstOrDefault();
        //        panPrice.Text = currCart.CheapItems[i - 1].Price.ToString();
        //    }
        //    for (int i = 1; i <= currCart.ExpensiveItems.Count; i++)
        //    {
        //        Label panItem = (Label)Controls.Find(String.Format("compItem{0}Ex{1}", i, currNum), true).FirstOrDefault();
        //        panItem.Text = currCart.ExpensiveItems[i - 1].ItemDesc;
        //        Label panPrice = (Label)Controls.Find(String.Format("compPrice{0}Ex{1}", i, currNum), true).FirstOrDefault();
        //        panPrice.Text = currCart.ExpensiveItems[i - 1].Price.ToString();
        //    }
        //    string[] missingItems = currCart.Items.Where(i => i.Price == 0).Select(i => i.ItemDesc).ToArray();
        //    ComboBox comMissing = (ComboBox)Controls.Find(String.Format("compCombo{0}", currNum), true).FirstOrDefault();
        //    comMissing.Items.AddRange(missingItems);
        //}

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

