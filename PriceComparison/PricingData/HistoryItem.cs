using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceData
{
    public class HistoryItem
    {
        public HistoryItem()
        {
        }
        public HistoryItem(int storeId, long chainID, long itemСode, int itemType,
                           decimal price, DateTime lastUpdateDate)
        {
            StoreID = storeId;
            ChainID = chainID;
            ItemCode = itemСode;
            ItemType = itemType;
            Price = price;
            LastUpdateDate = lastUpdateDate;
        }
        public int StoreID { get; set; }
        public long ChainID { get; set; }
        public long ItemCode { get; set; }
        public int ItemType { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
