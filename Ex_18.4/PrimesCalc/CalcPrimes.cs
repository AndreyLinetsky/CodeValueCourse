using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
namespace PrimesCalculator
{
    public class CalcPrimes
    {
        public async Task<int> CountPrimesAsync(int firstNum, int secondNum, CancellationToken token)
        {
            List<int> primes = await Task.Run(() => ReturnPrimes(firstNum, secondNum, token),token);
            return primes.Count;
        }
        public List<int> ReturnPrimes(int firstNum, int secondNum, CancellationToken token)
        {
            List<int> primeList = new List<int>();
            bool isPrime;
            // Correct min and max values
            if (firstNum > secondNum)
            {
                int tempNumber = firstNum;
                firstNum = secondNum;
                secondNum = tempNumber;
            }

            for (int i = firstNum; i <= secondNum; i++)
            {
                isPrime = true;
                // Filter only possible prime values
                if (i > 1)
                {
                    for (int j = 2; j <= i / 2; j++)
                    {
                        token.ThrowIfCancellationRequested();
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primeList.Add(i);
                    }
                }
            }
            return primeList;
        }
    }
}