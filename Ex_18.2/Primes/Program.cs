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
                Console.WriteLine("Starting calculation...");
                List<int> primeList = CalcPrimes(0, 30000000);
                Console.WriteLine($"{primeList.Count} numbers were returned before the stop");
            }
        }

        public static List<int> CalcPrimes(int firstNum, int secondNum)
        {
            List<int> primeList = new List<int>();
            bool isPrime;
            object sync = new object();
            Random rand = new Random();
            // Correct min and max values
            if (firstNum > secondNum)
            {
                int tempNumber = firstNum;
                firstNum = secondNum;
                secondNum = tempNumber;
            }
            Parallel.For(firstNum, secondNum + 1, new ParallelOptions { MaxDegreeOfParallelism = -1 }, (i, loopState) =>
            {
                int randNum = rand.Next(10000000);
                if (randNum == 0)
                {
                    loopState.Stop();
                    Console.WriteLine("Stop activated");
                    return;
                }
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
