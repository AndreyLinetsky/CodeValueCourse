﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public interface ILoad
    {
        void ReadData(string path);
        void WriteToDb();
    }
}
