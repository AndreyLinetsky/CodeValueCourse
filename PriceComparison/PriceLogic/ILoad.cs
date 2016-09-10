using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    interface ILoad
    {
        void DataLoad();
        void WriteData(string path);
        void WriteToDb();
    }
}
