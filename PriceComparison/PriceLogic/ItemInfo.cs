using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class ItemInfo
    {
        public ItemInfo(long itemCode, string itemName, int itemType, string chainName, string unitQuantity, string quantity)
        {
            ItemCode = itemCode;
            ItemName = itemName;
            ItemType = itemType;
            ChainName = chainName;
            Quantity = quantity;
            UnitQuantity = unitQuantity;
        }

        public long ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ItemType { get; set; }
        public string ChainName { get; set; }
        public string UnitQuantity { get; set; }
        public string Quantity { get; set; }

    }
}
