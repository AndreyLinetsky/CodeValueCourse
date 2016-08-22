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
    }
}
