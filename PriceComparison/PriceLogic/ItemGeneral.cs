using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class ItemGeneral
    {
        public ItemGeneral(long itemCode, string itemDesc, int amount, int itemType, long chainId,string unitQuantity, string quantity)
        {
            ItemCode = itemCode;
            ItemDesc = itemDesc;
            Amount = amount;
            ItemType = itemType;
            Quantity = quantity;
            UnitQuantity = unitQuantity;
            if (ItemType == 0)
            {
                ChainId = chainId;
            }
            else
            {
                ChainId = 0;
            }

        }

        public ItemGeneral()
        {
        }

        public long ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int Amount { get; set; }
        public int ItemType { get; set; }
        public long ChainId { get; set; }
        public string UnitQuantity { get; set; }
        public string Quantity { get; set; }
    }
}
