﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class B
    {
        public string Hello(string inputString)
        {
            string outputString = string.Concat("Bonjour ", inputString);
            return outputString;
        }
    }
}
