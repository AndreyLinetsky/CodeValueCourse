using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceData
{
    public class Account
    {
        public Account()
        {

        }
        public Account(string userId, string password)
        {
            UserID = userId;
            Password = password;
        }
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
