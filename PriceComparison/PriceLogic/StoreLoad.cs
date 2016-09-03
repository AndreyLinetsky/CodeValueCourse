using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Reflection;
using GoogleMaps.LocationServices;
using System.Threading;
using PriceData;
namespace PriceLogic
{
    public class StoreLoad : ILoad
    {
        public StoreLoad()
        {
            Stores = new List<Store>();
        }

        private void PartialDataload()
        {
            throw new NotImplementedException();
        }

        public List<Store> Stores { get; set; }
        public void DataLoad()
        {
            DirectoryInfo storeDir = new DirectoryInfo("stores");
            List<FileInfo> files = storeDir.GetFiles("*.xml").ToList<FileInfo>();
            foreach (var file in files)
            {
                WriteData($"stores/{file.Name}");
                //WriteData(String.Format("stores/{0}",file.Name));
            }
            WriteToDb();
        }
        public void WriteData(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList dataNodes = xmlDoc.GetElementsByTagName("ChainName");
            string chainName = "";
            foreach (XmlNode node in dataNodes)
            {
                chainName = node.InnerText;
            }
            dataNodes = xmlDoc.GetElementsByTagName("ChainId");
            long chainId = 0;
            foreach (XmlNode node in dataNodes)
            {
                chainId = Convert.ToInt64(node.InnerText);
            }
            dataNodes = xmlDoc.GetElementsByTagName("LastUpdateDate");
            string date = "";
            foreach (XmlNode node in dataNodes)
            {
                date = node.InnerText;
            }
            dataNodes = xmlDoc.SelectNodes("/Root/SubChains/SubChain/Stores/Store");
            foreach (XmlNode node in dataNodes)
            {
                int storeId = Convert.ToInt32(node.SelectSingleNode("StoreId").InnerText);
                int storeType = Convert.ToInt32(node.SelectSingleNode("StoreType").InnerText);
                string storeName = node.SelectSingleNode("StoreName").InnerText;
                string city = node.SelectSingleNode("City").InnerText;
                string location = GetStoreLocation(city);
                Store currStore = new Store(storeId, chainId, storeType, chainName, storeName, city, date, location);
                //Prevent duplicates
                if (!Stores.Any(s => s.StoreID == currStore.StoreID && s.ChainID == currStore.ChainID))
                {
                    Stores.Add(currStore);
                }
            }
        }
        public string GetStoreLocation(string address)
        {
            if (!string.Equals(address, "unknown", StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(address))
            {
                Thread.Sleep(200);
                GoogleLocationService locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(address);
                if (point == null)
                {
                    return string.Empty;
                }
                if (point.Longitude < 35.0)

                {
                    if (point.Latitude < 32)
                    {
                        return "South";
                    }

                    if (point.Latitude < 32.5)
                    {
                        return "Merkaz";
                    }
                    return "North";
                }
                else
                {
                    if (point.Latitude < 31.4)
                    {
                        return "South";
                    }

                    if (point.Latitude < 32.4)
                    {
                        return "Jerusalem";
                    }
                    return "North";
                }
            }
            else
            {
                return string.Empty;
            }
        }
        public void WriteToDb()
        {
            using (var db = new PricingContext())
            {
                var dbStores = db.Set<Store>();
                db.Stores.RemoveRange(dbStores);
                db.SaveChanges();
                dbStores.AddRange(Stores);
                db.SaveChanges();
                db.Dispose();
            }
        }
    }
}

