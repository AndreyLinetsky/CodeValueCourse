using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    interface ILoad
    {
       // Task DataLoad();
        void WriteData(string path);
        void WriteToDb();
    }
}
