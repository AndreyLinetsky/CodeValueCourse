using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    public class AccountQuery
    {
        public bool AccountExists(string user)
        {
            using (var db = new PricingContext())
            {
                return db.Accounts.Any(a => a.Name == user);
            }
        }
        public void AddAccount(string user,string password)
        {
            using (var db = new PricingContext())
            {
                Account newAccount = new Account(user, password);
                db.Accounts.Add(newAccount);
                db.SaveChanges();
            }
        }
        public bool Login(string user, string password)
        {
            using (var db = new PricingContext())
            {
                return db.Accounts.Any(a => a.Name == user && a.Password == password);
            }
        }
    }
}
