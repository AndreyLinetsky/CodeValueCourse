using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class Store
    {
        public int StoreID { get; set; }
        public int ChainID { get; set; }
        public virtual Chain Chain { get; set; }
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
