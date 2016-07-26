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
                if (i % 3 != 0)
                {
                    Console.WriteLine($"Adding line {i}");
                    ThreadPool.QueueUserWorkItem(q => testingQueue.Enque(i));
                }
                else
                {
                    Console.WriteLine($"Removing line {i}");
                    ThreadPool.QueueUserWorkItem(q => testingQueue.Deque());
                }
                Thread.Sleep(3000);
            }
        }
    }
}
