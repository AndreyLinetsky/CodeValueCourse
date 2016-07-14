using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class C
    {
        public string Hello(string inputString)
        {
            string outputString = string.Concat("Nihau ", inputString);
            return outputString;
        }
    }
}
