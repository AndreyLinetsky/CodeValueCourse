using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class Item
    {
        public int ItemID { get; set; }
        public int StoreID { get; set; }
        public virtual Store Store { get; set; }
        public int ItemСode { get; set; }
        public int ItemType { get; set; }
        public string ItemDesc { get; set; }
        public string UnitQuantity { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
        public string LastUpdateDate { get; set; }

    }
}
