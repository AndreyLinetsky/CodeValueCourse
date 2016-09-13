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
using System.Xml.Linq;

namespace PriceLogic
{
    public class StoreLoad : ILoad
    {
        public StoreLoad()
        {
            Stores = new List<Store>();
        }

        public List<Store> Stores { get; set; }
        public void DataLoad()
        {
            DirectoryInfo storeDir = new DirectoryInfo("stores");
            List<FileInfo> files = storeDir.GetFiles("*.xml").ToList<FileInfo>();
            ResetDb();
            foreach (var file in files)
            {
                WriteData($"{storeDir}/{file.Name}");
            }
            WriteToDb();
        }
        public void WriteData(string path)
        {
            var doc = XDocument.Load(path);
            //fxi chk xml
            long chainId = long.Parse(doc.Root.Element("ChainId").Value);
            string chainName = doc.Root.Element("ChainName").Value;
            var currStores = doc.Descendants("StoreId")
               .Select(s => s.Parent)
               .Select(store => new Store()
               {
                   StoreID = int.Parse(store.Element("StoreId").Value),
                   ChainID = chainId,
                   ChainName = chainName,
                   StoreName = store.Element("StoreName").Value,
                   City = store.Element("City").Value,
                   Location = GetStoreLocation(store.Element("City").Value)
               });
            Stores.AddRange(currStores);
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
                    if (point.Latitude < 31.9)
                    {
                        return "South";
                    }
                    if (point.Latitude < 32.14)
                    {
                        return "Merkaz";
                    }
                    if (point.Latitude < 32.5)
                    {
                        return "Sharon";
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
        public void ResetDb()
        {
            using (var db = new PricingContext())
            {
                if (db.Stores.Any())
                {
                    var filteredNewItems = db.Items.Where(i => !db.HistoryItems.Any(hist => hist.ChainID == i.ChainID && hist.StoreID == i.StoreID && i.ItemCode == hist.ItemCode &&
                     i.ItemType == hist.ItemType && DateTime.Compare(hist.LastUpdateDate, i.LastUpdateDate) >= 0)).Select(i => new
                     {
                         ChainID = i.ChainID,
                         StoreID = i.StoreID,
                         ItemCode = i.ItemCode,
                         ItemType = i.ItemType,
                         LastUpdateDate = i.LastUpdateDate,
                         Price = i.Price
                     }).ToList();
                    var convertedToHistItems = filteredNewItems.Select(i => new HistoryItem()
                    {
                        ChainID = i.ChainID,
                        StoreID = i.StoreID,
                        ItemCode = i.ItemCode,
                        ItemType = i.ItemType,
                        LastUpdateDate = i.LastUpdateDate,
                        Price = i.Price
                    }).ToList();
                    db.HistoryItems.AddRange(convertedToHistItems);
                    db.Stores.RemoveRange(db.Stores);
                    db.SaveChanges();
                }
            }
        }
        public void WriteToDb()
        {
            using (var db = new PricingContext())
            {
                db.Stores.AddRange(Stores);
                db.SaveChanges();
            }
        }
    }
}

