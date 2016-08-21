using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using PriceLogic;
using System.Reflection;

namespace PricingData
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
            foreach (var file in files)
            {
                WriteData($"stores/{file.Name}");
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
                string address = node.SelectSingleNode("Address").InnerText;
                string city = node.SelectSingleNode("City").InnerText;
                string zip = node.SelectSingleNode("ZipCode").InnerText;
                Store currStore = new Store(storeId, chainId, storeType, chainName, storeName, address, city, zip, date, "");
                Stores.Add(currStore);
            }
        }
        public void WriteToDb()
        {
            using (var db = new PricingContex())
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

