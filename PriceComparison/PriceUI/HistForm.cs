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
    public partial class HistForm : Form
    {
        public HistForm(PricingLogicManager manager, List<KeyValuePair<string, string>> stores, CartItem currItem)
        {
            InitializeComponent();
            Manager = manager;
            Stores = stores;
            CurrentItem = currItem;
            InitUI();
        }
        public void InitUI()
        {
            nameText.Text = CurrentItem.ItemName;
            codeText.Text = CurrentItem.ItemCode.ToString();
            storeComboBox.DataSource = Stores;
            storeComboBox.SelectedItem = null;
            storeComboBox.DisplayMember = "Value";
            storeComboBox.ValueMember = "Key";
        }
        public PricingLogicManager Manager { get; set; }
        public List<KeyValuePair<string, string>> Stores { get; set; }
        public CartItem CurrentItem { get; set; }
        private void histBut_Click(object sender, EventArgs e)
        {
            if (storeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select store");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Title = "Save Item History";
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "XLSX-File | *.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;
                    Manager.SaveItemHistory(storeComboBox.SelectedValue.ToString(), CurrentItem, path);
                    MessageBox.Show("Item History was saved");
                }
            }
        }
    }
}
