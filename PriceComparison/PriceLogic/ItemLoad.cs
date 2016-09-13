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
        public List<Item> Items;

        public void DataLoad()
        {
            Items = new List<Item>();
            DirectoryInfo storeDir = new DirectoryInfo("FullItems");
            if (storeDir.Exists)
            {
                List<FileInfo> files = storeDir.GetFiles("*.xml").ToList<FileInfo>();
                foreach (var file in files)
                {
                    WriteData($"{storeDir.Name}/{file.Name}");
                }
                WriteToDb();
            }
        }
        public void PartialDataLoad()
        {
            Items = new List<Item>();
            DirectoryInfo storeDir = new DirectoryInfo("PartialItems");
            if (storeDir.Exists)
            {
                List<FileInfo> files = storeDir.GetFiles("*.xml").ToList<FileInfo>();
                foreach (var file in files)
                {
                    WriteData($"{storeDir.Name}/{file.Name}");
                }
                WriteToDbPartial();
            }
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
                .Select(ItemCode => ItemCode.Parent)
                .Select(item => new Item() //fix xml chk
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
                }).OrderBy(i => i.LastUpdateDate);
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

        public void WriteToDbPartial()
        {
            using (var db = new PricingContext())
            {
                foreach (var item in Items)
                {
                    Item currItem = db.Items.Find(item.StoreID, item.ChainID, item.ItemCode, item.ItemType);
                    if (currItem != null)
                    {
                        HistoryItem histItem = db.HistoryItems.Find(currItem.StoreID, currItem.ChainID, currItem.ItemCode, currItem.ItemType, currItem.LastUpdateDate);
                        if (histItem == null)
                        {
                            db.HistoryItems.Add(new HistoryItem(currItem.StoreID, currItem.ChainID, currItem.ItemCode, currItem.ItemType, currItem.Price, currItem.LastUpdateDate));
                        }
                        db.Entry(currItem).CurrentValues.SetValues(item);
                    }
                    else
                    {
                        db.Items.Add(item);
                    }
                }
                db.SaveChanges();
            }
        }
        public void WriteToDb()
        {
            using (var db = new PricingContext())
            {
                var distinctItems = Items.GroupBy(i => new { i.ChainID, i.StoreID, i.ItemCode, i.ItemType }).Select(g => g.FirstOrDefault());
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Items.AddRange(distinctItems);
                db.SaveChanges();
            }
        }
    }
}

