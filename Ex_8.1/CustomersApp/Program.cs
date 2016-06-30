using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public delegate bool CustomerFilter(Customer customer);
    public class Program
    {
        public static List<Customer> GetCustomers(List<Customer> oldCustomers, CustomerFilter custFilter)
        {
            List<Customer> newCustomers = new List<Customer>();
            foreach (Customer cust in oldCustomers)
            {
                if (custFilter != null)
                {
                    if (custFilter(cust))
                    {
                        newCustomers.Add(cust);
                    }
                }
            }
            return newCustomers;
        }

        public bool FilterFirstHalf(Customer customer)
        {
            if ((customer.Name[0] >= 'A' &&
                customer.Name[0] <= 'K') ||
                (customer.Name[0] >= 'a' &&
                customer.Name[0] <= 'k'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Customer[] customerArray = new Customer[6];
            customerArray[0] = new Customer("Zill", 22, "Jerusalem");
            customerArray[1] = new Customer("Aerek", 99, "Tel aviv");
            customerArray[2] = new Customer("Yoav", 100, "Haifa");
            customerArray[3] = new Customer("Lill", 222, "Haifa");
            customerArray[4] = new Customer("2en", 3, "Eilat");
            customerArray[5] = new Customer("ken", -1, "Eilat");
            foreach (Customer cust in customerArray)
            {
                Console.WriteLine("Customer name is {0}, customer id is {1} and customer address is {2}", cust.Name, cust.Id, cust.Address);
            }
            Program prog = new Program();
            Customer[] newCustomerArray = GetCustomers(customerArray.ToList<Customer>(), new CustomerFilter(prog.FilterFirstHalf)).ToArray();
            Console.WriteLine("Filtered A-K array");
            foreach (Customer cust in newCustomerArray)
            {
                Console.WriteLine("Customer name is {0}, customer id is {1} and customer address is {2}", cust.Name, cust.Id, cust.Address);
            }
            // Anonymous
            newCustomerArray = GetCustomers(customerArray.ToList<Customer>(), delegate (Customer customer)
            {
                if ((customer.Name[0] >= 'L' &&
                customer.Name[0] <= 'Z') ||
                (customer.Name[0] >= 'l' &&
                customer.Name[0] <= 'z'))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }).ToArray();
            Console.WriteLine("Filtered L-Z array");
            foreach (Customer cust in newCustomerArray)
            {
                Console.WriteLine("Customer name is {0}, customer id is {1} and customer address is {2}", cust.Name, cust.Id, cust.Address);
            }
            // Lambda expression
            newCustomerArray = GetCustomers(customerArray.ToList<Customer>(), customer =>
            {
                if (customer.Id < 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }).ToArray();
            Console.WriteLine("Filtered ID < 100 array");
            foreach (Customer cust in newCustomerArray)
            {
                Console.WriteLine("Customer name is {0}, customer id is {1} and customer address is {2}", cust.Name, cust.Id, cust.Address);
            }
        }
    }
}