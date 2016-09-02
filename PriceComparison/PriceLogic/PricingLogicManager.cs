using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceData;
using System.IO;
using System.Xml;

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
            Cart = new Cart();
            //    LoadData();
            //  Database.SetInitializer<PricingContext>(new DropCreateDatabaseAlways<PricingContext>());
            //   StoreLoad str = new StoreLoad(true);
            //   ItemLoad it = new ItemLoad();


            //     it.DataLoad();
        }

        public AccountQuery AccQuery { get; set; }
        public ItemQuery ItemQuery { get; set; }
        public StoreQuery StoreQuery { get; set; }
        public Cart Cart { get; set; }
        public List<UpdatedCart> UpdatedCarts { get; set; }
        public string User { get; set; }
        public void LoadData()
        {
            // Check if full load needed
            // Full load needed
            Database.SetInitializer<PricingContext>(new DropCreateDatabaseIfModelChanges<PricingContext>());
            StoreLoad str = new StoreLoad();
            ItemLoad it = new ItemLoad();

            // str.DataLoad();
            //it.DataLoad();
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
                ItemName = i.ItemDesc,
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
                if (item.ItemType == 1 ||
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
                    writer.WriteElementString("Item Code", currItem.ItemCode.ToString());
                    writer.WriteElementString("Item Type", currItem.ItemType.ToString());
                    writer.WriteElementString("Item Name", currItem.ItemName);
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
                int itemType = Convert.ToInt32(node.SelectSingleNode("Item Type").InnerText);
                long itemCode = Convert.ToInt64(node.SelectSingleNode("Item Code").InnerText);
                string itemName = node.SelectSingleNode("Item Name").InnerText;
                decimal price = Convert.ToDecimal(node.SelectSingleNode("Price").InnerText);
                int amount = Convert.ToInt32(node.SelectSingleNode("Amount").InnerText);
                long chainId = Convert.ToInt64(node.SelectSingleNode("ChainId").InnerText);
                ItemHeader currItem = new ItemHeader(itemCode, itemType, itemName, chainId, amount, price);
                newItems.Add(currItem);
            }
            Cart.Items.Clear();
            Cart.Items.AddRange(newItems);
        }
    }
}
