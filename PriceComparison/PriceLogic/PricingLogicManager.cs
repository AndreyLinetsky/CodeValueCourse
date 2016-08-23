using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingData;


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
                UnitQuantity = i.UnitQuantity
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
            return StoreQuery.GetChains();
        }
        public List<string> GetLocations(List<string> chains)
        {
            return StoreQuery.GetLocations(chains);
        }
        public List<string> GetStores(List<string> chains, string location)
        {
            List<KeyValuePair<string, string>> stores = StoreQuery.GetStores(chains, location);
            var result = stores.Select(s => $"{s.Key}-{s.Value}");
            return result.ToList<string>();
        }
        public List<string> GetStores(List<string> chains)
        {
            List<KeyValuePair<string, string>> stores = StoreQuery.GetStores(chains);
            var result = stores.Select(s => $"{s.Key}-{s.Value}");
            return result.ToList<string>();
        }
    }
}
