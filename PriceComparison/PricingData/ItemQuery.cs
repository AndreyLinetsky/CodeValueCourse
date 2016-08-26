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
        //public KeyValuePair<long,int> GetCheapestStore(List<long> chainIds, List<KeyValuePair<long, int>> items,string location)
        //{
        //    using (var db = new PricingContext())
        //    {
        //        var cartItems = db.Items.Where(i => chainIds.Contains(i.ChainID) && (i.Store.Location == location || location == null) && items.Contains(new KeyValuePair<long, int>(i.ItemCode, i.ItemType)));
        //        var bestPrice = cartItems.GroupBy(i => new { i.ChainID, i.StoreID }).Max(g => g.Key.)
        //        var result = db.Items.Where(i => chainIds.Contains(i.ChainID) && (i.Store.Location == location || location == null)).Join(items, s => new { s.ItemCode, s.ItemType }, t => new { ItemCode = t.Key, ItemType = t.Value }, (s, t) => new { Data = s, Input = t }).Select(s => new { s.Data.StoreID, s.Data.ChainID });
        //        return result.AsEnumerable().Select(r => new KeyValuePair<long, int>(r.ChainID, r.StoreID)).FirstOrDefault();
        //        KeyValuePair<long, int> idData = new KeyValuePair<long, int>(result.)
        //    }
        //}
    }
}
