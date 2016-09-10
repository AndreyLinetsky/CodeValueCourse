using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceData;
namespace PriceLogic
{
    public class ItemQuery
    {
        public List<Item> FilterItems(string input)
        {
            using (var db = new PricingContext())
            {
                return db.Items.Where(i => i.ItemName.Contains(input)).GroupBy(i => i.ItemCode).Select(g => g.FirstOrDefault()).ToList();
            }
        }

        public ItemInfo GetInfo(ItemHeader header)
        {
            using (var db = new PricingContext())
            {
                return db.Items.Where(i => i.ItemCode == header.ItemCode && i.ItemType == header.ItemType && i.ChainID == header.ChainId)
                     .Select(i => new { i.ItemCode, i.ItemName, i.ItemType, i.Quantity, i.UnitQuantity }).AsEnumerable()
                     .Select(i => new ItemInfo(i.ItemCode, i.ItemName, i.ItemType, null, i.UnitQuantity, i.Quantity)).FirstOrDefault();
            }
        }
        public decimal GetPrice(long chainId, int storeId, long itemCode, int itemType)
        {
            using (var db = new PricingContext())
            {
                return db.Items.Where(i => i.ItemCode == itemCode && i.ItemType == itemType && i.StoreID == storeId && i.ChainID == chainId).Select(i => i.Price).FirstOrDefault();
            }
        }

        public KeyValuePair<long, int> GetCheapestStore(List<long> chainIds, List<ItemHeader> itemsToCheck, string location, List<StoreHeader> markedStores)
        {
            using (var db = new PricingContext())
            {
                var filteredStores = db.Items.Where(i => (i.Store.Location == location || location == null) && chainIds.Contains(i.ChainID)).ToList();
                var filteredItems = filteredStores.Where(i => !markedStores.Any(s => s.ChainId == i.ChainID && s.StoreId == i.StoreID) && itemsToCheck.Any(s => s.ItemCode == i.ItemCode && s.ItemType == i.ItemType && (i.ItemType != 0 || i.ChainID == s.ChainId))).Select(i => new
                {
                    ChainID = i.ChainID,
                    StoreID = i.StoreID,
                    Price = i.Price * itemsToCheck.Where(s => s.ItemCode == i.ItemCode && s.ItemType == i.ItemType).Select(s => s.Amount).FirstOrDefault()
                }).ToList();
                var bestStore = filteredItems.GroupBy(i => new { i.ChainID, i.StoreID }).Select(g => new { ChainID = g.Key.ChainID, StoreID = g.Key.StoreID, Count = g.Count(), TotalPrice = g.Sum(g1 => g1.Price) }).OrderByDescending(i => i.Count).ThenBy(i => i.TotalPrice).FirstOrDefault();
                if (bestStore != null)
                {
                    return new KeyValuePair<long, int>(bestStore.ChainID, bestStore.StoreID);
                }
                else
                {
                    return new KeyValuePair<long, int>(0, 0);
                }
            }
        }
    }
}
