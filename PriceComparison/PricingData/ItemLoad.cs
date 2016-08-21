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
            foreach (var file in files)
            {
                WriteData($"items/{file.Name}");
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
                int itemId = Convert.ToInt32(node.SelectSingleNode("ItemId").InnerText);
                int itemType = Convert.ToInt32(node.SelectSingleNode("ItemType").InnerText);
                long itemCode = Convert.ToInt64(node.SelectSingleNode("ItemCode").InnerText);
                string itemDesc = node.SelectSingleNode("ManufacturerItemDescription").InnerText;
                string unitQuantity = node.SelectSingleNode("UnitQty").InnerText;
                string quantity = node.SelectSingleNode("Quantity").InnerText;
                decimal price = Convert.ToDecimal(node.SelectSingleNode("ItemPrice").InnerText);
                string date = node.SelectSingleNode("PriceUpdateDate").InnerText;
                Item currItem = new Item(storeId,chainId,itemId,itemCode,itemType,itemDesc,unitQuantity,quantity,price,date);
                Items.Add(currItem);
            }
        }
        public void WriteToDb()
        {
            using (var db = new PricingContex())
            {
                var dbItems = db.Set<Item>();
                db.Items.RemoveRange(dbItems);
                db.SaveChanges();
                dbItems.AddRange(Items);
                var bb = Items.Select(i => i.StoreID).Distinct();

                db.SaveChanges();
                db.Dispose();
            }
        }
    }
}

