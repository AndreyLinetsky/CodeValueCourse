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
            // Database.SetInitializer<PricingContext>(new DropCreateDatabaseAlways<PricingContext>());
            //StoreLoad str = new StoreLoad(true);
            //ItemLoad it = new ItemLoad();

            //str.DataLoad();
            //   it.DataLoad();
        }
        public AccountQuery AccQuery { get; set; }
        public ItemQuery ItemQuery { get; set; }
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
        }
        public List<ItemGeneral> GetItems(string input)
        {
            List<Item> items = ItemQuery.FilterItems(input);
            return ConvertToGeneralItems(items);
        }
        public List<ItemGeneral> ConvertToGeneralItems(List<Item> items)
        {
            var generalItems = items.OrderBy(i => i.ItemCode).Select(i => new ItemGeneral() { ItemCode = i.ItemCode, ItemDesc = i.ItemDesc, Amount = 0, ItemType = i.ItemType, ChainId = i.ChainID });
            List<ItemGeneral> retList = generalItems.ToList<ItemGeneral>();
            return retList;
        }
    }
}
