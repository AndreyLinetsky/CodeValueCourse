using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    public class ItemQuery
    {
        public List<Item> FilterItems(string input)
        {
            using (var db = new PricingContext())
            {
                var result = db.Items.Where(t => t.ItemDesc.Contains(input)).GroupBy(t => t.ItemCode).Select(g => g.FirstOrDefault());
                return result.ToList<Item>();
            }
        }

        public decimal GetMinPrice(long itemCode, int itemType, long chainId)
        {
            using (var db = new PricingContext())
            {
                var result = db.Items.Where(t => t.ItemCode == itemCode && t.ItemType == itemType && t.ChainID == chainId).OrderBy(t => t.Price).FirstOrDefault();
                Item item = result as Item;
                if (item != null)
                {
                    return item.Price;
                }
                else
                {
                    return 0;
                }
            }
        }
        public decimal GetMinPrice(long itemCode)
        {
            using (var db = new PricingContext())
            {
                var result = db.Items.Where(t => t.ItemCode == itemCode).OrderBy(t => t.Price).FirstOrDefault();
                Item item = result as Item;
                if (item != null)
                {
                    return item.Price;
                }
                else
                {
                    return 0;
                }
            }
        }
        public decimal GetPrice(long chainId, int storeId, long itemCode, int itemType)
        {
            using (var db = new PricingContext())
            {
                var result = db.Items.Where(t => t.ItemCode == itemCode && t.ItemType == itemType && t.StoreID == storeId && t.ChainID == chainId).Select(t => t.Price).FirstOrDefault();
                return result;
            }
        }
        public IdValuePair GetCheapestStore(List<long> chainIds, List<IdValuePair> items, string location, List<IdValuePair> markedStores)
        {
            using (var db = new PricingContext())
            {
                var filtItems = db.Items.Where(i => chainIds.Contains(i.ChainID) && (i.Store.Location == location || location == null)).ToList();
                var updItems = filtItems.Where(i => !markedStores.Any(s => s.Key == i.ChainID && s.Value == i.StoreID) && items.Any(s => s.Key == i.ItemCode && s.Value == i.ItemType)).ToList();
                var bestStore = updItems.GroupBy(i => new { i.ChainID, i.StoreID }).Select(g => new { ChainID = g.Key.ChainID, StoreID = g.Key.StoreID, Count = g.Count(), TotalPrice = g.Sum(g1 => g1.Price) }).OrderByDescending(i => i.Count).ThenBy(i => i.TotalPrice).FirstOrDefault();
                if(bestStore != null)
                {
                    return new IdValuePair(bestStore.ChainID, bestStore.StoreID);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
