using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class Chain
    {
        public int ChainID { get; set; }
        public int ChainName { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
