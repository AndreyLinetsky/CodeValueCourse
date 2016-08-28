using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    public class StoreQuery
    {
        public List<KeyValuePair<long, string>> GetAllChains()
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Select(s => new KeyValuePair<long, string>(s.ChainID, s.ChainName)).Distinct().ToList();
            }
        }
        public long GetChainId(string chain)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => s.ChainName == chain).Select(s => s.ChainID).FirstOrDefault();
            }
        }
        public string GetChainName(long chainId)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => s.ChainID == chainId).Select(s => s.ChainName).FirstOrDefault();
            }
        }
        public List<String> GetLocations(List<string> chains)
        {
            using (var db = new PricingContext())
            {
                var result = db.Stores.Where(s => chains.Contains(s.ChainName) && !string.Equals(s.Location, string.Empty)).Select(s => s.Location).Distinct();
                return result.ToList<String>();
            }
        }
        public List<StoreHeader> GetAllStores(List<long> chains, string location)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => chains.Contains(s.ChainID) && (s.Location == location || location == null)).Select(s => new
               StoreHeader(s.ChainID, s.StoreID, s.ChainName, s.StoreName)).Distinct().ToList();
            }
        }

        public string GetStoreName(long chainId, int storeId)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => s.ChainID == chainId && s.StoreID == storeId).Select(s => s.StoreName).FirstOrDefault();
            }
        }
    }
}
