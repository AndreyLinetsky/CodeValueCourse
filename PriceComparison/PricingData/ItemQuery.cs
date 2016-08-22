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
                if(item != null)
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
    }
}
