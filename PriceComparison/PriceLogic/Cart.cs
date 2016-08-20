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
            Items = new List<ItemGeneral>();
        }
        public List<ItemGeneral> Items { get; set; }
        public int getCurrentIndex(int itemCode, int itemType, int chainId)
        {
            return Items.FindIndex(i => i.ItemСode == itemCode && i.ItemType == itemType && i.ChainId == chainId);
        }
        public void Add(int itemCode, string itemDesc, int amount, int itemType, int chainId)
        {
            ItemGeneral currItem = new ItemGeneral(itemCode, itemDesc, amount, itemType, chainId);
            Items.Add(currItem);
        }
        public void Remove(int itemCode, int itemType, int chainId)
        {
            Items.RemoveAt(getCurrentIndex(itemCode, itemType, chainId));
        }
        public void UpdateAmount(int itemCode, int itemType, int chainId, int newAmount)
        {
            Items[getCurrentIndex(itemCode, itemType, chainId)].Amount = newAmount;
        }
    }
}
