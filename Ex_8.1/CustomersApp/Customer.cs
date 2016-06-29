using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        private string name;
        private int id;
        private string address;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
        }

        public Customer(string initName, int initId, string initAddress)
        {
            name = initName;
            id = initId;
            address = initAddress;
        }
        public int CompareTo(Customer other)
        {
            if (other == null)
            {
                return 1;
            }
            // null case
            if (this.Name == null)
            {
                if (other.Name == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(Customer other)
        {
            if (other == null)
            {
                return false;
            }
            if (string.Equals(this.Name, other.Name) &&
                this.Id == other.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Customer customerObj = obj as Customer;
            if (customerObj == null)
            {
                return false;
            }
            else
            {
                return this.Equals(customerObj);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + this.Name.GetHashCode();
        }
    }
}
