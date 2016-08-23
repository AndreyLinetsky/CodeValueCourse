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
            Items = new List<ItemGeneral>();
            StoreId = storeId;
            ChainId = chainId;
        }
        public List<ItemGeneral> Items { get; set; }
        public int StoreName { get; set; }
        public int ChainName { get; set; }

        public void Add(Item item)
        {
            Items.Add(item);
        }
    }
}
