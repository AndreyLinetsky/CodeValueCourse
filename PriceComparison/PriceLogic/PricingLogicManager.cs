using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingData;
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
        public int MaxCartsToShow { get; } = 3;
        public string User { get; set; }
        public string UserMessage
        {
            get
            {
                return $"Welcome {User}";
            }
        }
        public void LoadData()
        {
            // Check if full load needed
            // Full load needed
            Database.SetInitializer<PricingContext>(new DropCreateDatabaseIfModelChanges<PricingContext>());
            //StoreLoad str = new StoreLoad();
            //  ItemLoad it = new ItemLoad();

            //   str.DataLoad();
            //  it.DataLoad();
            //else partial load 

        }
        public string Register(string user, string password)
        {
            if (AccQuery.AccountExists(user))
            {
                return $"Account {user} already exists";
            }
            else
            {
                AccQuery.AddAccount(user, password);
                return $"Account {user} was created successfully";
            }
        }
        public bool Login(string user, string password)
        {
            if (AccQuery.Login(user, password))
            {
                User = user;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Logout()
        {
            User = "";
            Cart = new Cart();
        }
        public List<ItemGeneral> GetItems(string input)
        {
            List<Item> items = ItemQuery.FilterItems(input);
            return ConvertToGeneralItems(items);
        }
        public List<ItemGeneral> ConvertToGeneralItems(List<Item> items)
        {
            var generalItems = items.OrderBy(i => i.ItemCode).Select(i => new ItemGeneral()
            {
                ItemCode = i.ItemCode,
                ItemDesc = i.ItemDesc,
                Amount = 0,
                ItemType = i.ItemType,
                ChainId = i.ChainID,
                Quantity = i.Quantity,
                UnitQuantity = i.UnitQuantity,
                Price = 0
            });
            List<ItemGeneral> retList = generalItems.ToList<ItemGeneral>();
            return retList;
        }


        public decimal GetMinPrice(ItemGeneral currItem)
        {
            if (currItem.ItemType == 1)
            {
                return ItemQuery.GetMinPrice(currItem.ItemCode);
            }
            else
            {
                return ItemQuery.GetMinPrice(currItem.ItemCode, currItem.ItemType, currItem.ChainId);
            }
        }

        public bool AddItemToCart(ItemGeneral currItem, int amount)
        {
            return Cart.Add(currItem, amount);
        }
        public List<ItemGeneral> GetCartItems()
        {
            return Cart.Items;
        }
        public List<ItemGeneral> RemoveItemFromCart(ItemGeneral currItem)
        {
            Cart.Remove(currItem);
            return Cart.Items;
        }
        public List<ItemGeneral> UpdateCart(ItemGeneral currItem, int amount)
        {
            Cart.UpdateAmount(currItem, amount);
            return Cart.Items;
        }
        public List<String> GetChains()
        {
            return StoreQuery.GetAllChains();
        }
        public List<string> GetLocations(List<string> chains)
        {
            return StoreQuery.GetLocations(chains);
        }
        public List<string> GetStores(List<string> chains, string location)
        {
            List<KeyValuePair<string, string>> stores = StoreQuery.GetAllStores(chains, location);
            var result = stores.Select(s => $"{s.Key}-{s.Value}");
            return result.ToList<string>();
        }
        public List<string> GetStores(List<string> chains)
        {
            List<KeyValuePair<string, string>> stores = StoreQuery.GetAllStores(chains);
            var result = stores.Select(s => $"{s.Key}-{s.Value}");
            return result.ToList<string>();
        }
        public List<UpdatedCart> CalculateTotal(List<string> stores)
        {
            UpdatedCarts = new List<UpdatedCart>();
            foreach (var item in stores)
            {
                List<string> storeData = item.Split('-').ToList();
                KeyValuePair<long, int> idInfo = StoreQuery.ConvertNameToID(storeData[0], storeData[1]);
                UpdatedCart currCart = new UpdatedCart(idInfo.Value, idInfo.Key, storeData[1], storeData[0]);
                UpdateCart(currCart);
            }
            return UpdatedCarts;
        }
        public List<UpdatedCart> CalculateTotal(List<string> chains, string location, int productsToFetch)
        {
            UpdatedCarts = new List<UpdatedCart>();
            List<IdValuePair> itemsToCheck = FetchCheckItems();
            List<IdValuePair> markedStores = new List<IdValuePair>();
            for (int i = 0; i < chains.Count; i++)
            {
                long chainId = StoreQuery.GetChainId(chains[i]);
                IdValuePair idsData = ItemQuery.GetCheapestStore(new List<long>() { chainId }, itemsToCheck, location, markedStores);
                if (idsData != null)
                {
                    string storeName = StoreQuery.GetStoreName(chainId, idsData.Value);
                    UpdatedCart newCart = new UpdatedCart(idsData.Value, chainId, storeName, chains[i]);
                    UpdateCart(newCart);
                    markedStores.Add(idsData);
                }
            }
            List<long> chainIds = chains.Select(c => StoreQuery.GetChainId(c)).Distinct().ToList();
            while (UpdatedCarts.Count < productsToFetch)
            {
                IdValuePair idsData = ItemQuery.GetCheapestStore(chainIds, itemsToCheck, location, markedStores);
                if (idsData != null)
                {
                    string storeName = StoreQuery.GetStoreName(idsData.Key, idsData.Value);
                    string chainName = StoreQuery.GetChainName(idsData.Key);
                    UpdatedCart currCart = new UpdatedCart(idsData.Value, idsData.Key, storeName, chainName);
                    UpdateCart(currCart);
                    markedStores.Add(idsData);
                }
                else
                {
                    break;
                }
            }
            return UpdatedCarts;
        }

        public void UpdateCart(UpdatedCart currCart)
        {
            currCart.Items = (Cart.Items.Select(i => i.c);
            foreach (ItemGeneral item in currCart.Items)
            {
                item.Price = ItemQuery.GetPrice(currCart.ChainID, currCart.StoreID, item.ItemCode, item.ItemType);
            }
            UpdatedCarts.Add(currCart);
        }
        public List<IdValuePair> FetchCheckItems()
        {
            var result = Cart.Items.Select(i => new
            {
                ItemCode = i.ItemCode,
                ItemType = i.ItemType
            }).Distinct();
            return result.AsEnumerable().Select(p => new IdValuePair(p.ItemCode, p.ItemType)).ToList();
        }
        public void SaveCart(string path)
        {
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Cart");
                foreach (ItemGeneral currItem in Cart.Items)
                {
                    writer.WriteStartElement("Item");
                    writer.WriteElementString("Code", currItem.ItemCode.ToString());
                    writer.WriteElementString("Type", currItem.ItemType.ToString());
                    writer.WriteElementString("Desc", currItem.ItemDesc);
                    writer.WriteElementString("Quantity", currItem.Quantity);
                    writer.WriteElementString("UnitQuantity", currItem.UnitQuantity);
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
            List<ItemGeneral> newItems = new List<ItemGeneral>();
            foreach (XmlNode node in dataNodes)
            {
                int itemType = Convert.ToInt32(node.SelectSingleNode("Type").InnerText);
                long itemCode = Convert.ToInt64(node.SelectSingleNode("Code").InnerText);
                string itemDesc = node.SelectSingleNode("Desc").InnerText;
                string unitQuantity = node.SelectSingleNode("UnitQuantity").InnerText;
                string quantity = node.SelectSingleNode("Quantity").InnerText;
                decimal price = Convert.ToDecimal(node.SelectSingleNode("Price").InnerText);
                int amount = Convert.ToInt32(node.SelectSingleNode("Amount").InnerText);
                long chainId = Convert.ToInt64(node.SelectSingleNode("ChainId").InnerText);
                ItemGeneral currItem = new ItemGeneral(itemCode, itemDesc, amount, itemType, chainId, unitQuantity, quantity, price);
                newItems.Add(currItem);
            }
            Cart.Items.Clear();
            Cart.Items.AddRange(newItems);
        }
    }
}
