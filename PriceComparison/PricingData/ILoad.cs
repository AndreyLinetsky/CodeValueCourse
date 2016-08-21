using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingData
{
    interface ILoad
    {
        void DataLoad();
        void WriteData(string path);
        void WriteToDb();
    }
}
