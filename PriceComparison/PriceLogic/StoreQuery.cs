using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceData;

namespace PriceLogic
{
    public class StoreQuery
    {
        public List<KeyValuePair<long, string>> GetAllChains()
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Select(s => new { s.ChainID, s.ChainName }).Distinct().AsEnumerable().
                               Select(s => new KeyValuePair<long, string>(s.ChainID, s.ChainName)).ToList();
            }
        }

        public List<string> GetLocations(List<long> chains)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => chains.Contains(s.ChainID) && !string.Equals(s.Location, string.Empty)).Select(s => s.Location).Distinct().ToList();
            }
        }
        public List<StoreHeader> GetStores(List<long> chains, string location)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => chains.Contains(s.ChainID) && (s.Location == location || location == null)).Select(s => new
                { s.ChainID, s.StoreID, s.ChainName, s.StoreName }).AsEnumerable().Select(s => new StoreHeader(s.ChainID, s.StoreID, s.ChainName, s.StoreName)).Distinct().ToList();
            }
        }
        public StoreHeader GetStoreHeader(long chainId, int storeId)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => s.ChainID == chainId && s.StoreID == storeId).Select(s => new
                { s.ChainID, s.StoreID, s.ChainName, s.StoreName }).AsEnumerable().Select(s => new StoreHeader(s.ChainID, s.StoreID, s.ChainName, s.StoreName)).FirstOrDefault();
            }
        }

    }
}