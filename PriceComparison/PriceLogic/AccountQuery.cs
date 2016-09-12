using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceData;

namespace PriceLogic
{
    public class AccountQuery
    {
        public bool AddAccount(string user, string password)
        {
            using (var db = new PricingContext())
            {
                if (!db.Accounts.Any(a => a.UserID == user))
                {
                    Account newAccount = new Account(user, password);
                    db.Accounts.Add(newAccount);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool Login(string user, string password)
        {
            using (var db = new PricingContext())
            {
                return db.Accounts.Any(a => a.UserID == user && a.Password == password);
            }
        }
    }
}
