using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class StoreHeader
    {
        public StoreHeader(long chainId, int storeId)
        {
            ChainId = chainId;
            StoreId = storeId;
            ChainName = string.Empty;
            StoreName = string.Empty;
        }
        public StoreHeader(long chainId, int storeId, string chainName, string storeName)
        {
            ChainId = chainId;
            StoreId = storeId;
            ChainName = chainName;
            StoreName = storeName;
        }
        public StoreHeader()
        {

        }
        public long ChainId { get; set; }
        public int StoreId { get; set; }
        public string ChainName { get; set; }
        public string StoreName { get; set; }
    }
}
