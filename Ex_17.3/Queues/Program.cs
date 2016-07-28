using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Queues
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LimitedQueue<int> testingQueue = new LimitedQueue<int>(5);
            for (int i = 0; i <= 21; i++)
            {
                Console.WriteLine($"Queue size is {testingQueue.Count}");
                Random rand = new Random();
                int currRand = rand.Next(1, 101);
                if (currRand % 3 != 0)
                {
                    Console.WriteLine("Start adding process");
                    ThreadPool.QueueUserWorkItem(q => testingQueue.Enque(i));
                }
                else
                {
                    Console.WriteLine("Start removing process");
                    ThreadPool.QueueUserWorkItem(q => testingQueue.Deque());
                }
                Thread.Sleep(1000);
            }
        }
    }
}
