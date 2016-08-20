using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PriceLogic
{
    public class PricingContex : DbContext
    {
        public PricingContex() : base("PricingContext")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Chain> Chains { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }

    }
}
