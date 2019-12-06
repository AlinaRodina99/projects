using System;
using System.Threading;
using System.Collections.Generic;

namespace ThreadPool_task2
{
    public class MyThreadPool<TResult>
    {
        private readonly LinkedList<Thread> threads;
        private readonly Queue<MyTask<TResult>> tasks = new Queue<MyTask<TResult>>();
        private object locker = new object();

        public void Enqueue(MyTask<TResult> myTask)
        {
            lock (locker)
            {
                tasks.Enqueue(myTask);
            }
        }

        public MyThreadPool(int count)
        {
            threads = new LinkedList<Thread>();
            for (var i = 0; i < count; ++i)
            {
                var thread = new Thread(Work);
                thread.Start();
            }
        }

        public void Work()
        {
            try
            {
                lock (locker)
                {
                    if (tasks.Count > 0)
                    {

                    }
                }
            }
        }
    }
}
