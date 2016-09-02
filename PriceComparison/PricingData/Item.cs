using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceData
{
    public class Item
    {
        public Item()
        {
        }
        public Item(int storeId, long chainID, long itemСode, int itemType, string itemDesc,
            string unitQuantity, string quantity, decimal price, string lastUpdateDate)
        {
            StoreID = storeId;
            ChainID = chainID;
            ItemCode = itemСode;
            ItemType = itemType;
            ItemDesc = itemDesc;
            UnitQuantity = unitQuantity;
            Quantity = quantity;
            Price = price;
            LastUpdateDate = lastUpdateDate;
        }
        public int ItemID { get; set; }
        public int StoreID { get; set; }
        public virtual Store Store { get; set; }
        public long ChainID { get; set; }
        public long ItemCode { get; set; }
        public int ItemType { get; set; }
        public string ItemDesc { get; set; }
        public string UnitQuantity { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
        public string LastUpdateDate { get; set; }

    }
}
