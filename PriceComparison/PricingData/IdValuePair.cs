using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    public class IdValuePair
    {
        public IdValuePair(long key, int value)
        {
            Key = key;
            Value = value;
        }
        public IdValuePair()
        {

        }
        public long Key { get; set; }
        public int Value { get; set; }
    }
}
