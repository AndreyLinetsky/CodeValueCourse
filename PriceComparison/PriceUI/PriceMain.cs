using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PricingData;
using PriceLogic;
using System.Data.Entity;

namespace PriceUI
{
    public partial class PriceMain : Form
    {
        public PriceMain()
        {
            InitializeComponent();
           Database.SetInitializer<PricingContex>(new DropCreateDatabaseAlways<PricingContex>());
            StoreLoad str = new StoreLoad();
            ItemLoad it = new ItemLoad();

             str.DataLoad();
            it.DataLoad();

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PriceMain_Load(object sender, EventArgs e)
        {

        }
    }
}
