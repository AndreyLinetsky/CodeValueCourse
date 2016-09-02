﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceData
{
    public class Store
    {
        public Store()
        {
        }
        public Store(int storeId, long chainId, int storeType, string chainName, string storeName,
            string address, string city, string zip, string lastUpdateDate, string location)
        {
            StoreID = storeId;
            ChainID = chainId;
            StoreType = storeType;
            ChainName = chainName;
            StoreName = storeName;
            Address = address;
            City = city;
            Zip = zip;
            LastUpdateDate = lastUpdateDate;
            Location = location;
        }
        public int StoreID { get; set; }
        public long ChainID { get; set; }
        public int StoreType { get; set; }
        public string ChainName { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string LastUpdateDate { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Item> Items { get; set; }


    }
}