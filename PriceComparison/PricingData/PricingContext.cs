using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceData
{
    public class PricingContext : DbContext
    {
        public PricingContext() : base("PricingContext")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<HistoryItem> HistoryItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Store>().HasKey(st => new { st.ChainID, st.StoreID });
            // Turn off autogeneration in database
            modelBuilder.Entity<Store>()
                        .Property(st => st.StoreID)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Item>().HasKey(it => new { it.ChainID, it.StoreID, it.ItemCode, it.ItemType });
            modelBuilder.Entity<HistoryItem>().HasKey(it => new { it.ChainID, it.StoreID, it.ItemCode, it.ItemType, it.LastUpdateDate });
        }

    }
}
