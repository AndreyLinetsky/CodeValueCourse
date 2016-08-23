using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    public class StoreQuery
    {
        public List<String> GetChains()
        {
            using (var db = new PricingContext())
            {
                var result = db.Stores.Select(s => s.ChainName).Distinct();
                return result.ToList<String>();
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
        public List<KeyValuePair<string, string>> GetStores(List<string> chains, string location)
        {
            using (var db = new PricingContext())
            {
                var result = db.Stores.Where(s => chains.Contains(s.ChainName) && string.Equals(location,s.Location)).Select(s => new
                {
                    ChainName = s.ChainName,
                    StoreName = s.StoreName
                }).Distinct();
                var pairs = result.AsEnumerable().Select(p => new KeyValuePair<string, string>(p.ChainName, p.StoreName)).ToList();
                return pairs;
            }
        }
        public List<KeyValuePair<string, string>> GetStores(List<string> chains)
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
    }
}
