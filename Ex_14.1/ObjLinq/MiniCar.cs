using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjLinq
{
    public class MiniCar
    {
        public MiniCar(int year, int price, int fundSaving)
        {
            Year = year;
            Price = price;
            FundSaving = fundSaving;
        }

        public int Year { get; }
        public int Price { get; set; }
        public int FundSaving { get; set; }


    }
}
