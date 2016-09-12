using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceData;
namespace PriceLogic
{
    public class HistItemQuery
    {
        public List<KeyValuePair<DateTime, decimal>> GetItemHistory(CartItem currItem, StoreHeader currStore)
        {
            using (var db = new PricingContext())
            {
                return db.HistoryItems.Where(i => i.ItemCode == currItem.ItemCode && i.ItemType == currItem.ItemType && i.StoreID == currStore.StoreId && i.ChainID == currStore.ChainId).Select(i => new { Date = i.LastUpdateDate, Price = i.Price }).OrderBy(i => i.Date)
                    .AsEnumerable().Select(i => new KeyValuePair<DateTime, decimal>(i.Date, i.Price)).ToList();
            }
        }
        public List<KeyValuePair<long, int>> GetStores(CartItem currItem)
        {
            using (var db = new PricingContext())
            {
                return db.HistoryItems.Where(i => i.ItemCode == currItem.ItemCode && i.ItemType == currItem.ItemType && (currItem.ItemType != 0 || i.ChainID == currItem.ChainId)).Select(i => new { Chain = i.ChainID, Store = i.StoreID }).Distinct()
                    .AsEnumerable().Select(i => new KeyValuePair<long, int>(i.Chain, i.Store)).ToList();
            }
        }
    }
}
