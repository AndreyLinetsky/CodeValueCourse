using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Reflection;
using PriceData;
namespace PriceLogic
{
    public class ItemLoad : ILoad
    {
        public ItemLoad()
        {
            Items = new List<Item>();
        }
        public List<Item> Items;

        public void DataLoad()
        {
            DirectoryInfo storeDir = new DirectoryInfo("items");
            List<FileInfo> files = storeDir.GetFiles("*.xml").ToList<FileInfo>();
            ResetDb();
            foreach (var file in files)
            {
                WriteData($"items/{file.Name}");
                //WriteData(string.Format("items/{0}",file.Name));
               
            }
            WriteToDb();
        }
        public void WriteData(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList dataNodes = xmlDoc.GetElementsByTagName("StoreId");
            int storeId = 0;
            foreach (XmlNode node in dataNodes)
            {
                storeId = Convert.ToInt32(node.InnerText);
            }
            dataNodes = xmlDoc.GetElementsByTagName("ChainId");
            long chainId = 0;
            foreach (XmlNode node in dataNodes)
            {
                chainId = Convert.ToInt64(node.InnerText);
            }
            dataNodes = xmlDoc.SelectNodes("/Root/Items/Item");
            foreach (XmlNode node in dataNodes)
            {
                int itemType = Convert.ToInt32(node.SelectSingleNode("ItemType").InnerText);
                long itemCode = Convert.ToInt64(node.SelectSingleNode("ItemCode").InnerText);
                string itemDesc = node.SelectSingleNode("ItemName").InnerText;
                string unitQuantity = node.SelectSingleNode("UnitQty").InnerText;
                string quantity = node.SelectSingleNode("Quantity").InnerText;
                decimal price = Convert.ToDecimal(node.SelectSingleNode("ItemPrice").InnerText);
                string date = node.SelectSingleNode("PriceUpdateDate").InnerText;
                Item currItem = new Item(storeId, chainId, itemCode, itemType, itemDesc, unitQuantity, quantity, price, date);
                //Prevent duplicates
                if (currItem.Price > 0 &&
                    !Items.Any(i => i.ItemCode == currItem.ItemCode && i.ItemType == currItem.ItemType && i.ChainID == currItem.ChainID && i.StoreID == currItem.StoreID))
                {
                    Items.Add(currItem);
                }
            }
        }
        public void ResetDb()
        {
            using (var db = new PricingContext())
            {
                var dbItems = db.Set<Item>();
                if (db.Set<Item>().Any())
                {
                    db.Items.RemoveRange(dbItems);
                    db.SaveChanges();
                }
            }
        }
        public void WriteToDb()
        {
            using (var db = new PricingContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                var dbItems = db.Set<Item>();
                dbItems.AddRange(Items);
                db.SaveChanges();
            }
        }
    }
}

