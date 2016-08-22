using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingData;

namespace PriceLogic
{
    public class UpdatedCart
    {
        public UpdatedCart(int storeId, int chainId)
        {
            Items = new List<Item>();
            StoreId = storeId;
            ChainId = chainId;
        }
        public List<Item> Items { get; set; }
        public int StoreId { get; set; }
        public int ChainId { get; set; }

        public void Add(Item item)
        {
            Items.Add(item);
        }
    }
}
