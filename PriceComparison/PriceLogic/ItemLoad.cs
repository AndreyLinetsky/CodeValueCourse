using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Reflection;
using PriceData;
using System.Xml.Linq;

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
            foreach (var file in files)
            {
                WriteData($"items/{file.Name}");
                //WriteData(string.Format("items/{0}",file.Name));

            }
            WriteToDb();
        }
        public void WriteData(string path)
        {
            var doc = XDocument.Load(path);

            long chainId = long.Parse(doc.Root.Element("ChainId").Value);
            int storeId = int.Parse(doc.Root.Element("StoreId").Value);
            // Write data only if the store exists
            if (CheckStore(chainId, storeId))
            {
                var currItems = doc.Descendants("ItemCode")
                .Select(price => price.Parent)
                .Select(item => new Item()
                {
                    StoreID = storeId,
                    ChainID = chainId,
                    ItemCode = long.Parse(item.Element("ItemCode").Value),
                    ItemType = int.Parse(item.Element("ItemType").Value),
                    ItemName = item.Element("ItemName").Value,
                    UnitQuantity = item.Element("UnitQty").Value,
                    Quantity = item.Element("Quantity").Value,
                    Price = decimal.Parse(item.Element("ItemPrice").Value),
                    LastUpdateDate = DateTime.Parse(item.Element("PriceUpdateDate").Value)
                });
                Items.AddRange(currItems);
            }
        }
        public bool CheckStore(long chainId, int storeId)
        {
            using (var db = new PricingContext())
            {
                return db.Stores.Any(s => s.ChainID == chainId && s.StoreID == storeId);
            }
        }

        public void WriteToDb()
        {
            using (var db = new PricingContext())
            {
                var distinctItems = Items.GroupBy(i => new { i.ChainID, i.StoreID, i.ItemCode }).Select(g => g.FirstOrDefault());
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Items.AddRange(distinctItems);
                db.SaveChanges();
            }
        }
    }
}

