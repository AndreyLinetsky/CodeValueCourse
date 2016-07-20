using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjLinq
{
    public class Car
    {
        private int driverId;
        public Car(int year, int price, int fuelAmount, string secretName,int currDriverId)
        {
            Year = year;
            Price = price;
            FuelAmount = fuelAmount;
            SecretName = secretName;
            DriverId = currDriverId;
        }

        public int Year { get; }
        public int Price { get; set; }
        public int FuelAmount { get; set; }
        private string SecretName { get;set; }

        public int DriverId
        {
            set { driverId = value; }
        }

        public string GetName()
        {
            return SecretName;
        }
        public int GetId()
        {
            return driverId;
        }
    }
}
