﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Queues
{
    public class LimitedQueue<T>
    {
        public LimitedQueue(int maxSize)
        {
            if (maxSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Max Size must be larger than 0");
            }
            LocalQueue = new Queue<T>();
            QueueLimit = new Semaphore(maxSize, maxSize);
        }
        private static Semaphore QueueLimit { get; set; }
        private Queue<T> LocalQueue { get; set; }
        public void Enque(T newVar)
        {
            QueueLimit.WaitOne();
            LocalQueue.Enqueue(newVar);
            Console.WriteLine($"Current queue size(after add {newVar}) is {LocalQueue.Count}");
        }
        public T Deque()
        {
            T returnValue = default(T);
            if (LocalQueue.Count > 0)
            {
                returnValue = LocalQueue.Dequeue();
                Console.WriteLine($"Current queue size(after remove {returnValue}) is {LocalQueue.Count}");
                QueueLimit.Release();
            }
            return returnValue;
        }
    }
}
