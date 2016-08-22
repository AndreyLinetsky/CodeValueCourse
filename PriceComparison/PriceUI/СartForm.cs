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
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = newItems;
                    InitCart();
                    dataGridView1.Update();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[0].Selected = true;
                    }
                }
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
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = newItems;
                        InitCart();
                        dataGridView1.Update();
                        if (dataGridView1.Rows.Count > 0)
                        {
                           dataGridView1.se dataGridView1.Rows[0].Selected = true;
                        }
                        MessageBox.Show("Cart was updated successfully");
                    }
                }
            }
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
    }
}
