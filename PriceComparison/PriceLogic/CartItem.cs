using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class CartItem
    {
        public CartItem(long itemCode, int itemType, string itemName, long chainId, int amount, decimal price)
        {
            ItemCode = itemCode;
            ItemType = itemType;
            ItemName = itemName;
            ChainId = chainId;
            Amount = amount;
            Price = price;
        }

        public CartItem()
        {
        }

        public long ItemCode { get; set; }
        public int ItemType { get; set; }
        public string ItemName { get; set; }
        public long ChainId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
