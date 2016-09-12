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
            Items = new List<CartItem>();
        }
        public List<CartItem> Items { get; set; }
        public int getCurrentIndex(long itemCode, int itemType, long chainId)
        {
            return Items.FindIndex(i => i.ItemCode == itemCode && i.ItemType == itemType && i.ChainId == chainId);
        }
        public bool Add(CartItem currItem,int amount)
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
        public void Reload(List<CartItem> newItems)
        {
            Reset();
            Items.AddRange(newItems);
        }
        public void Remove(CartItem currItem)
        {
            Items.Remove(currItem);
        }

        public void Reset()
        {
            Items.Clear();
        }
        public void UpdateAmount(CartItem currItem,int amount)
        {
            Items[getCurrentIndex(currItem.ItemCode, currItem.ItemType, currItem.ChainId)].Amount = amount;
        }
    }
}
