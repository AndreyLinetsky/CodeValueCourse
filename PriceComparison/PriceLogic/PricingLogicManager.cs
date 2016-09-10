using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceData;
using System.IO;
using System.Xml;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml.Drawing.Chart;

namespace PriceLogic
{
    public class PricingLogicManager
    {
        public PricingLogicManager()
        {
            User = "";
            AccQuery = new AccountQuery();
            ItemQuery = new ItemQuery();
            StoreQuery = new StoreQuery();
            HistItemQuery = new HistItemQuery();
            Cart = new Cart();
            //LoadData();
            //  Database.SetInitializer<PricingContext>(new DropCreateDatabaseAlways<PricingContext>());
            //   StoreLoad str = new StoreLoad(true);
            //   ItemLoad it = new ItemLoad();


            //     it.DataLoad();
        }

        public AccountQuery AccQuery { get; set; }
        public ItemQuery ItemQuery { get; set; }
        public StoreQuery StoreQuery { get; set; }
        public HistItemQuery HistItemQuery { get; set; }
        public Cart Cart { get; set; }
        public List<UpdatedCart> UpdatedCarts { get; set; }
        public string User { get; set; }
        public void LoadData()
        {
            // Check if full load needed
            // Full load needed
            Database.SetInitializer(new CreateDatabaseIfNotExists<PricingContext>());
            StoreLoad str = new StoreLoad();
            ItemLoad it = new ItemLoad();

            str.DataLoad();
            it.DataLoad();
            //else partial load 

        }
        public bool Register(string user, string password)
        {
            return AccQuery.AddAccount(user, password);
        }

        public bool Login(string user, string password)
        {
            if (AccQuery.Login(user, password))
            {
                User = user;
                return true;
            }
            return false;
        }
        public void Logout()
        {
            User = "";
            Cart = new Cart();
        }
        public List<ItemHeader> GetItems(string input)
        {
            List<Item> items = ItemQuery.FilterItems(input);
            return items.OrderBy(i => i.ItemCode).Select(i => new ItemHeader()
            {
                ItemCode = i.ItemCode,
                ItemType = i.ItemType,
                ItemName = i.ItemName,
                ChainId = i.ChainID,
                Amount = 0,
                Price = 0
            }).ToList();
        }
        public ItemInfo GetItemInfo(ItemHeader header)
        {
            ItemInfo itemInfo = ItemQuery.GetInfo(header);
            itemInfo.ChainName = StoreQuery.GetAllChains().Where(c => c.Key == header.ChainId).Select(c => c.Value).FirstOrDefault();
            return itemInfo;
        }
        public bool AddItemToCart(ItemHeader currItem, int amount)
        {
            return Cart.Add(currItem, amount);
        }
        public List<ItemHeader> GetCartItems()
        {
            return Cart.Items;
        }
        public List<ItemHeader> RemoveItemFromCart(ItemHeader currItem)
        {
            Cart.Remove(currItem);
            return Cart.Items;
        }
        public List<ItemHeader> UpdateCart(ItemHeader currItem, int amount)
        {
            Cart.UpdateAmount(currItem, amount);
            return Cart.Items;
        }
        public List<KeyValuePair<long, string>> GetChains()
        {
            return StoreQuery.GetAllChains();
        }
        public List<string> GetLocations(List<long> chains)
        {
            return StoreQuery.GetLocations(chains);
        }
        public List<KeyValuePair<string, string>> GetStores(List<long> chains, string location)
        {
            List<StoreHeader> storeData = StoreQuery.GetStores(chains, location);
            return storeData.Select(i => new KeyValuePair<string, string>($"{i.ChainId}-{i.StoreId}", $"{i.ChainName}-{i.StoreName}")).ToList();
            //return storeData.Select(i => new KeyValuePair<string, string>(String.Format("{0}-{1}", i.ChainId, i.StoreId), String.Format("{0}-{1}", i.ChainName, i.StoreName))).ToList();
        }

        public List<UpdatedCart> CalculateTotal(List<string> stores)
        {
            UpdatedCarts = new List<UpdatedCart>();
            foreach (var item in stores)
            {
                List<string> storeId = item.Split('-').ToList();
                StoreHeader storeData = StoreQuery.GetStoreHeader(Convert.ToInt64(storeId[0]), Convert.ToInt32(storeId[1]));
                UpdatedCart currCart = new UpdatedCart(storeData.StoreId, storeData.ChainId, storeData.StoreName, storeData.ChainName);
                UpdateCart(currCart);
            }
            return UpdatedCarts;
        }
        public List<UpdatedCart> CalculateTotal(List<long> chains, string location, int productsToFetch)
        {
            UpdatedCarts = new List<UpdatedCart>();
            List<StoreHeader> markedStores = new List<StoreHeader>();
            KeyValuePair<long, int> idData = new KeyValuePair<long, int>();
            for (int i = 0; i < productsToFetch; i++)
            {
                if (i < chains.Count)
                {
                    idData = ItemQuery.GetCheapestStore(new List<long>() { chains[i] }, Cart.Items, location, markedStores);
                }
                else
                {
                    idData = ItemQuery.GetCheapestStore(chains, Cart.Items, location, markedStores);
                }

                if (idData.Key != 0 &&
                    idData.Value != 0)
                {
                    StoreHeader storeData = StoreQuery.GetStoreHeader(idData.Key, idData.Value);
                    UpdatedCart currCart = new UpdatedCart(storeData.StoreId, storeData.ChainId, storeData.StoreName, storeData.ChainName);
                    UpdateCart(currCart);
                    markedStores.Add(storeData);
                }
            }
            return UpdatedCarts.OrderBy(c => c.TotalPrice).ToList();
        }

        public void UpdateCart(UpdatedCart currCart)
        {
            currCart.Items = Cart.Items.Select(i => new ItemHeader()
            {
                ItemCode = i.ItemCode,
                ItemType = i.ItemType,
                ItemName = i.ItemName,
                ChainId = i.ChainId,
                Amount = i.Amount,
                Price = 0
            }).ToList();
            foreach (ItemHeader item in currCart.Items)
            {
                if (item.ItemType != 0 ||
                    item.ChainId == currCart.ChainID)
                {
                    item.Price = ItemQuery.GetPrice(currCart.ChainID, currCart.StoreID, item.ItemCode, item.ItemType);
                }
            }
            UpdatedCarts.Add(currCart);
        }
        public void SaveCart(string path)
        {
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Cart");
                foreach (ItemHeader currItem in Cart.Items)
                {
                    writer.WriteStartElement("Item");
                    writer.WriteElementString("ItemCode", currItem.ItemCode.ToString());
                    writer.WriteElementString("ItemType", currItem.ItemType.ToString());
                    writer.WriteElementString("ItemName", currItem.ItemName);
                    writer.WriteElementString("ChainId", currItem.ChainId.ToString());
                    writer.WriteElementString("Price", currItem.Price.ToString());
                    writer.WriteElementString("Amount", currItem.Amount.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        public void LoadCart(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList dataNodes = xmlDoc.SelectNodes("/Cart/Item");
            List<ItemHeader> newItems = new List<ItemHeader>();
            foreach (XmlNode node in dataNodes)
            {
                int itemType = Convert.ToInt32(node.SelectSingleNode("ItemType").InnerText);
                long itemCode = Convert.ToInt64(node.SelectSingleNode("ItemCode").InnerText);
                string itemName = node.SelectSingleNode("ItemName").InnerText;
                long chainId = Convert.ToInt64(node.SelectSingleNode("ChainId").InnerText);
                decimal price = Convert.ToDecimal(node.SelectSingleNode("Price").InnerText);
                int amount = Convert.ToInt32(node.SelectSingleNode("Amount").InnerText);
                ItemHeader currItem = new ItemHeader(itemCode, itemType, itemName, chainId, amount, price);
                newItems.Add(currItem);
            }
            Cart.Items.Clear();
            Cart.Items.AddRange(newItems);
        }
        public void SaveComparison(string path)
        {
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.Add("Comparison");
                // Set row headers
                int currCol = 1;
                var chainCell = worksheet.Cells[1, currCol];
                chainCell.Value = "Chain";
                var storeCell = worksheet.Cells[2, currCol];
                storeCell.Value = "Store";
                worksheet.Cells[3, 1, 5, 1].Merge = true;
                var cheapCell = worksheet.Cells[3, currCol];
                cheapCell.Value = "Cheapest";
                worksheet.Cells[6, 1, 8, 1].Merge = true;
                var exCell = worksheet.Cells[6, currCol];
                exCell.Value = "Most Expensive";
                var totalCell = worksheet.Cells[9, currCol];
                totalCell.Value = "Total Price";
                totalCell.Merge = true;
                int maxMissingItems = UpdatedCarts.Select(c => c.Items.Where(i => i.Price == 0).Count()).Max();
                worksheet.Cells[10, currCol, 9 + maxMissingItems, currCol].Merge = true;
                var allMissingCell = worksheet.Cells[10, currCol];
                allMissingCell.Value = "Missing Items";
                worksheet.Column(currCol).Width = 14;
                worksheet.Column(currCol).Style.Font.Bold = true;
                worksheet.Column(currCol).Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                worksheet.Column(currCol).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                currCol++;
                // Fill data
                foreach (UpdatedCart currCart in UpdatedCarts)
                {
                    worksheet.Cells[1, currCol, 1, currCol + 1].Merge = true;
                    var chainNameCell = worksheet.Cells[1, currCol];
                    chainNameCell.Value = currCart.ChainName;
                    chainNameCell.Style.Font.Size++;
                    chainNameCell.Style.Font.Bold = true;
                    worksheet.Cells[2, currCol, 2, currCol + 1].Merge = true;
                    var storeNameCell = worksheet.Cells[2, currCol];
                    storeNameCell.Value = currCart.StoreName;
                    storeNameCell.Style.Font.Size++;
                    storeNameCell.Style.Font.Bold = true;
                    for (int i = 3; i < 3 + currCart.CheapItems.Count; i++)
                    {
                        var cheapNameCell = worksheet.Cells[i, currCol];
                        cheapNameCell.Value = currCart.CheapItems[i - 3].ItemName;
                        var cheapPriceCell = worksheet.Cells[i, currCol + 1];
                        cheapPriceCell.Value = currCart.CheapItems[i - 3].Price;
                    }
                    for (int i = 6; i < 6 + currCart.ExpensiveItems.Count; i++)
                    {
                        var expNameCell = worksheet.Cells[i, currCol];
                        expNameCell.Value = currCart.ExpensiveItems[i - 6].ItemName;
                        var expPriceCell = worksheet.Cells[i, currCol + 1];
                        expPriceCell.Value = currCart.ExpensiveItems[i - 6].Price;
                    }
                    worksheet.Cells[9, currCol, 9, currCol + 1].Merge = true;
                    var priceCell = worksheet.Cells[9, currCol];
                    priceCell.Value = currCart.TotalPrice;
                    List<ItemHeader> missingItems = currCart.Items.Where(i => i.Price == 0).ToList();
                    for (int i = 10; i < 10 + missingItems.Count; i++)
                    {
                        worksheet.Cells[i, currCol, i, currCol + 1].Merge = true;
                        var missingCell = worksheet.Cells[i, currCol];
                        missingCell.Value = missingItems[i - 10].ItemName;
                    }
                    worksheet.Column(currCol).Width = 20;
                    worksheet.Column(currCol + 1).Width = 7;
                    worksheet.Column(currCol + 2).Width = 4;
                    worksheet.Column(currCol + 2).Style.Fill.PatternType = ExcelFillStyle.LightGray;
                    worksheet.Column(currCol).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    worksheet.Column(currCol + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    currCol += 3;
                }
                package.SaveAs(new System.IO.FileInfo(path));
            }
        }
        public List<KeyValuePair<string, string>> GetItemStores(ItemHeader currItem)
        {
            var storeIds = HistItemQuery.GetStores(currItem);
            var storeData = storeIds.Select(s => StoreQuery.GetStoreHeader(s.Key, s.Value)).ToList();
            return storeData.Select(i => new KeyValuePair<string, string>($"{i.ChainId}-{i.StoreId}", $"{i.ChainName}-{i.StoreName}")).ToList();
        }
        public void SaveItemHistory(string currStore, ItemHeader currItem, string path)
        {
            using (var package = new ExcelPackage())
            {
                List<string> storeId = currStore.Split('-').ToList();
                StoreHeader storeData = StoreQuery.GetStoreHeader(Convert.ToInt64(storeId[0]), Convert.ToInt32(storeId[1]));
                List<KeyValuePair<DateTime, decimal>> priceHist = HistItemQuery.GetItemHistory(currItem, storeData);
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.Add("ItemHistory");
                int currRow = 1;
                var dateHeadCell = worksheet.Cells[currRow, 1];
                dateHeadCell.Value = "Date";
                var priceHeadCell = worksheet.Cells[currRow, 2];
                priceHeadCell.Value = "Price";
                foreach (var record in priceHist)
                {
                    currRow++;
                    var dateCell = worksheet.Cells[currRow, 1];
                    dateCell.Value = record.Key.Date.ToString("dd/MM/yyyy");
                    var priceCell = worksheet.Cells[currRow, 2];
                    priceCell.Value = record.Value;
                }
                var chart = worksheet.Drawings.AddChart("chart", eChartType.ColumnClustered);
                var series = chart.Series.Add($"B2:B{currRow}", $"A2:A{currRow}");
                series.Header = "Price";
                package.SaveAs(new System.IO.FileInfo(path));
            }
            //public void DownloadFiles()
            //{
            //    FileDownloader downloader = new FileDownloader();

            //}
        }
    }
}