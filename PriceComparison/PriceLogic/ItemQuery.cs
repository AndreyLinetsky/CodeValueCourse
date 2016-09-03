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
                return db.Items.Where(i => i.ItemDesc.Contains(input)).GroupBy(i => i.ItemCode).Select(g => g.FirstOrDefault()).ToList();
            }
        }

        public ItemInfo GetInfo(ItemHeader header)
        {
            using (var db = new PricingContext())
            {
                return db.Items.Where(i => i.ItemCode == header.ItemCode && i.ItemType == header.ItemType && i.ChainID == header.ChainId)
                     .Select(i => new { i.ItemCode, i.ItemDesc, i.ItemType, i.Quantity, i.UnitQuantity }).AsEnumerable()
                     .Select(i => new ItemInfo(i.ItemCode, i.ItemDesc, i.ItemType, null, i.UnitQuantity, i.Quantity)).FirstOrDefault();
            }
        }
        public decimal GetPrice(long chainId, int storeId, long itemCode, int itemType)
        {
            using (var db = new PricingContext())
            {
                return db.Items.Where(i => i.ItemCode == itemCode && i.ItemType == itemType && i.StoreID == storeId && i.ChainID == chainId).Select(t => t.Price).FirstOrDefault();
            }
        }
        public KeyValuePair<long, int> GetCheapestStore(List<long> chainIds, List<ItemHeader> itemsToCheck, string location, List<StoreHeader> markedStores)
        {
            using (var db = new PricingContext())
            {
                var filteredStores = db.Items.Join(db.Stores, i => new { i.ChainID, i.StoreID }, s => new { s.ChainID, s.StoreID }, (i, s) => new
                {
                    ItemSource = i,
                    StoreSource = s
                }).Where(j => (j.StoreSource.Location == location || location == null) &&
                chainIds.Contains(j.StoreSource.ChainID)).ToList();
                var filteredItems = filteredStores.Where(i => !markedStores.Any(s => s.ChainId == i.StoreSource.ChainID && s.StoreId == i.StoreSource.StoreID) && itemsToCheck.Any(s => s.ItemCode == i.ItemSource.ItemCode && s.ItemType == i.ItemSource.ItemType && (i.ItemSource.ItemType != 0 || i.ItemSource.ChainID == s.ChainId))).Select(i => new
                {
                    ChainID = i.ItemSource.ChainID,
                    StoreID = i.ItemSource.StoreID,
                    Price = i.ItemSource.Price * itemsToCheck.Where(s => s.ItemCode == i.ItemSource.ItemCode && s.ItemType == i.ItemSource.ItemType).Select(s => s.Amount).FirstOrDefault()
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
