using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceData;

namespace PriceLogic
{
    public class UpdatedCart
    {
        public UpdatedCart(int storeId, long chainId, string storeName, string chainName)
        {
            Items = new List<ItemHeader>();
            StoreID = storeId;
            StoreName = storeName;
            ChainID = chainId;
            ChainName = chainName;
        }
        public List<ItemHeader> Items { get; set; }
        public string StoreName { get; set; }
        public string ChainName { get; set; }
        public int StoreID { get; set; }
        public long ChainID { get; set; }
        public int ItemsToShow { get; } = 3;

        public List<ItemHeader> CheapItems
        {
            get
            {
                if (Items.Where(i => i.Price > 0).Count() <= ItemsToShow)
                {
                    return Items.Where(i => i.Price > 0).OrderBy(i => i.Price).ToList();
                }
                else
                {
                    return Items.Where(i => i.Price > 0).OrderBy(i => i.Price).Take(ItemsToShow).ToList();
                }
            }
        }
        public List<ItemHeader> ExpensiveItems
        {
            get
            {
                if (Items.Where(i => i.Price > 0).Count() <= ItemsToShow)
                {
                    return Items.Where(i => i.Price > 0).OrderByDescending(i => i.Price).ToList();
                }
                else
                {
                    return Items.Where(i => i.Price > 0).OrderByDescending(i => i.Price).Take(ItemsToShow).ToList();
                }
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return Items.Select(i => i.Price * i.Amount).Sum();
            }
        }
        public void Add(ItemHeader item)
        {
            Items.Add(item);
        }
    }
}
