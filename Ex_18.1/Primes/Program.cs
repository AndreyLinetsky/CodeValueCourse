using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int firstNum, secondNum, thirdNum;
                Console.WriteLine("Please enter the first range number");
                string firstInput = Console.ReadLine();
                Console.WriteLine("Please enter the second range number");
                string secondInput = Console.ReadLine();
                Console.WriteLine("Please enter the max degree of parallelism ");
                string thirdInput = Console.ReadLine();
                if (int.TryParse(firstInput, out firstNum) &&
                    int.TryParse(secondInput, out secondNum) &&
                    int.TryParse(thirdInput, out thirdNum))
                {
                    List<int> primeList = CalcPrimes(firstNum, secondNum, thirdNum);
                    if (primeList.Count > 0)
                    {
                        Console.WriteLine("Prime numbers in the given range are:");
                        foreach (int number in primeList)
                        {
                            Console.WriteLine(number);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No prime numbers were found in the given range");
                    }
                }
                else
                {
                    Console.WriteLine("Error! Please enter only integer numbers");
                }
            }
        }

        public static List<int> CalcPrimes(int firstNum, int secondNum, int maxDegree)
        {
            if (maxDegree < -1 ||
                maxDegree == 0)
            {
                throw new ArgumentOutOfRangeException("Max degree is invalid");
            }
            List<int> primeList = new List<int>();
            bool isPrime;
            object sync = new object();
            // Correct min and max values
            if (firstNum > secondNum)
            {
                int tempNumber = firstNum;
                firstNum = secondNum;
                secondNum = tempNumber;
            }
            Parallel.For(firstNum, secondNum + 1, new ParallelOptions { MaxDegreeOfParallelism = maxDegree }, (i) =>
                {
                    isPrime = true;
                // Filter only possible prime values
                if (i > 1)
                    {
                        for (int j = 2; j <= i / 2; j++)
                        {
                            if (i % j == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        if (isPrime)
                        {
                            lock (sync)
                            {
                                primeList.Add(i);
                            }
                        }
                    }
                });
            return primeList;
        }
    }
}
