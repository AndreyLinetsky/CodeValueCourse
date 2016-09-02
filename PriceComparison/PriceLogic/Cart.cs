using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<ItemHeader>();
        }
        public List<ItemHeader> Items { get; set; }
        public int getCurrentIndex(long itemCode, int itemType, long chainId)
        {
            return Items.FindIndex(i => i.ItemCode == itemCode && i.ItemType == itemType && i.ChainId == chainId);
        }
        public bool Add(ItemHeader currItem,int amount)
        {
            if (getCurrentIndex(currItem.ItemCode, currItem.ItemType, currItem.ChainId) != -1)
            {
                return false;
            }
            else
            {
                currItem.Amount = amount;
                Items.Add(currItem);
                return true;
            }
        }
        public void Remove(ItemHeader currItem)
        {
            Items.Remove(currItem);
        }
        public void UpdateAmount(ItemHeader currItem,int amount)
        {
            Items[getCurrentIndex(currItem.ItemCode, currItem.ItemType, currItem.ChainId)].Amount = amount;
        }
    }
}
