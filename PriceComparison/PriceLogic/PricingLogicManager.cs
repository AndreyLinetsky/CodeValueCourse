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
using System.Xml.Linq;

namespace PriceLogic
{
    public class PricingLogicManager
    {
        public PricingLogicManager()
        {
            User = string.Empty;
            AccQuery = new AccountQuery();
            ItemQuery = new ItemQuery();
            StoreQuery = new StoreQuery();
            HistItemQuery = new HistItemQuery();
            userCart = new Cart();
            SetupDb();
        }

        public AccountQuery AccQuery { get; set; }
        public ItemQuery ItemQuery { get; set; }
        public StoreQuery StoreQuery { get; set; }
        public HistItemQuery HistItemQuery { get; set; }
        public Cart userCart { get; set; }
        public List<UpdatedCart> UpdatedCarts { get; set; }
        public string User { get; set; }
        public void SetupDb()
        {
            using (var db = new PricingContext())
            {
                if (!db.Database.Exists())
                {
                    Database.SetInitializer(new CreateDatabaseIfNotExists<PricingContext>());
                }
                else
                {
                    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PricingContext>());
                }
            }
        }
        public void LoadData(bool isFullUpdate)
        {
            ItemLoad it = new ItemLoad();
            if (isFullUpdate)
            {
                StoreLoad str = new StoreLoad();
                str.DataLoad();
            }
            it.DataLoad(isFullUpdate);
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
            User = string.Empty;
            userCart.Reset();
        }
        public List<CartItem> GetItems(string input, bool includeInnerItems)
        {
            List<Item> items = ItemQuery.FilterGeneralItems(input);
            if (includeInnerItems)
            {
                items.AddRange(ItemQuery.FilterInnerItems(input));
            }

            return items.OrderBy(i => i.ItemCode).Select(i => new CartItem()
            {
                ItemCode = i.ItemCode,
                ItemType = i.ItemType,
                ItemName = i.ItemName,
                ChainId = i.ChainID,
                Amount = 0,
                Price = 0
            }).ToList();
        }
        public ItemInfo GetItemInfo(CartItem currItem)
        {
            return ItemQuery.GetItemInfo(currItem);
        }
        public bool AddItemToCart(CartItem currItem, int amount)
        {
            return userCart.Add(currItem, amount);
        }
        public List<CartItem> GetCartItems()
        {
            return userCart.Items;
        }
        public void RemoveItemFromCart(CartItem currItem)
        {
            userCart.Remove(currItem);
        }
        public void UpdateCart(CartItem currItem, int amount)
        {
            userCart.UpdateAmount(currItem, amount);
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
        }

        public List<UpdatedCart> CalculateTotal(List<string> stores)
        {
            UpdatedCarts = new List<UpdatedCart>();
            foreach (var item in stores)
            {
                List<string> storeId = item.Split('-').ToList();
                StoreHeader storeData = StoreQuery.GetStoreHeader(Convert.ToInt64(storeId[0]), Convert.ToInt32(storeId[1]));
                UpdateCart(storeData);
            }
            return UpdatedCarts;
        }
        public List<UpdatedCart> CalculateTotal(List<long> chains, string location, int productsToFetch)
        {
            UpdatedCarts = new List<UpdatedCart>();
            List<StoreHeader> markedStores = new List<StoreHeader>();
            List<KeyValuePair<long, int>> idData = new List<KeyValuePair<long, int>>();
            int uniqueFetchs;
            if (chains.Count >= productsToFetch)
            {
                uniqueFetchs = productsToFetch;
            }
            else
            {
                uniqueFetchs = chains.Count;
            }
            for (int i = 0; i < uniqueFetchs; i++)
            {
                idData = ItemQuery.GetCheapestStore(new List<long>() { chains[i] }, userCart.Items, location, markedStores, 1);
                if (idData.Count > 0)
                {
                    StoreHeader storeData = StoreQuery.GetStoreHeader(idData.First().Key, idData.First().Value);
                    UpdateCart(storeData);
                    markedStores.Add(storeData);
                }
            }
            if (UpdatedCarts.Count > 0 &&
                UpdatedCarts.Count < productsToFetch)
            {
                idData = ItemQuery.GetCheapestStore(chains, userCart.Items, location, markedStores, productsToFetch - UpdatedCarts.Count);
                foreach (var id in idData)
                {
                    StoreHeader storeData = StoreQuery.GetStoreHeader(id.Key, id.Value);
                    UpdateCart(storeData);
                }
            }
            return UpdatedCarts.OrderBy(c => c.TotalPrice).ToList();
        }

        public void UpdateCart(StoreHeader storeData)
        {
            UpdatedCart currCart = new UpdatedCart(storeData.StoreId, storeData.ChainId, storeData.StoreName, storeData.ChainName);
            currCart.Items = userCart.Items.Select(i => new CartItem()
            {
                ItemCode = i.ItemCode,
                ItemType = i.ItemType,
                ItemName = i.ItemName,
                ChainId = i.ChainId,
                Amount = i.Amount,
                Price = 0
            }).ToList();
            foreach (CartItem item in currCart.Items)
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
                foreach (CartItem currItem in userCart.Items)
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
            var doc = XDocument.Load(path);
            var currItems = doc.Descendants("Item")
                .Select(item => new CartItem()
                {
                    ItemCode = long.Parse(item.Element("ItemCode").Value),
                    ItemType = int.Parse(item.Element("ItemType").Value),
                    ItemName = item.Element("ItemName").Value,
                    ChainId = long.Parse(item.Element("ChainId").Value),
                    Price = decimal.Parse(item.Element("Price").Value),
                    Amount = int.Parse(item.Element("Amount").Value),
                }).ToList();
            userCart.Reload(currItems);
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
                    List<CartItem> missingItems = currCart.Items.Where(i => i.Price == 0).ToList();
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
        public List<KeyValuePair<string, string>> GetItemStores(CartItem currItem)
        {
            var storeIds = HistItemQuery.GetStores(currItem);
            var storeData = storeIds.Select(s => StoreQuery.GetStoreHeader(s.Key, s.Value)).ToList();
            return storeData.Select(i => new KeyValuePair<string, string>($"{i.ChainId}-{i.StoreId}", $"{i.ChainName}-{i.StoreName}")).ToList();
        }
        public void SaveItemHistory(string currStore, CartItem currItem, string path)
        {
            using (var package = new ExcelPackage())
            {
                List<string> storeId = currStore.Split('-').ToList();
                StoreHeader storeData = StoreQuery.GetStoreHeader(Convert.ToInt64(storeId[0]), Convert.ToInt32(storeId[1]));
                var priceHist = HistItemQuery.GetItemHistory(currItem, storeData);
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
                var chart = worksheet.Drawings.AddChart("chart", eChartType.ColumnStacked);
                var series = chart.Series.Add($"B2:B{currRow}", $"A2:A{currRow}");
                series.Header = "Price";
                package.SaveAs(new System.IO.FileInfo(path));
            }
        }
    }
}
