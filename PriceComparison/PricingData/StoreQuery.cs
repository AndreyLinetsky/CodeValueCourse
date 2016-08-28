using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    public class StoreQuery
    {
        public List<String> GetAllChains()
        {
            using (var db = new PricingContext())
            {
                var result = db.Stores.Select(s => s.ChainName).Distinct();
                return result.ToList<String>();
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
        public List<KeyValuePair<string, string>> GetAllStores(List<string> chains, string location)
        {
            using (var db = new PricingContext())
            {
                var result = db.Stores.Where(s => chains.Contains(s.ChainName) && string.Equals(location, s.Location)).Select(s => new
                {
                    ChainName = s.ChainName,
                    StoreName = s.StoreName
                }).Distinct();
                var pairs = result.AsEnumerable().Select(p => new KeyValuePair<string, string>(p.ChainName, p.StoreName)).ToList();
                return pairs;
            }
        }
        public List<KeyValuePair<string, string>> GetAllStores(List<string> chains)
        {
            using (var db = new PricingContext())
            {
                var result = db.Stores.Where(s => chains.Contains(s.ChainName)).Select(s => new
                {
                    ChainName = s.ChainName,
                    StoreName = s.StoreName
                }).Distinct();
                var pairs = result.AsEnumerable().Select(p => new KeyValuePair<string, string>(p.ChainName, p.StoreName)).ToList();
                return pairs;
            }
        }
        public string GetStoreName(long chainId,int storeId)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Where(s => s.ChainID == chainId && s.StoreID == storeId).Select(s => s.StoreName).FirstOrDefault();
            }
        }
        public IdValuePair ConvertNameToID(string chainName, string storeName)
        {
            using (var db = new PricingContext())
            {
                var result = db.Stores.Where(s => string.Equals(chainName, s.ChainName) && string.Equals(storeName, s.StoreName)).Select(s => new IdValuePair
                {
                    Key = s.ChainID,
                    Value = s.StoreID
                }).FirstOrDefault();
               // var pair = result.Select(p => new IdValuePair(p.ChainID, p.StoreID )).FirstOrDefault();
                return result;
            }
        }
    }
}
