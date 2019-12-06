using System;
using System.Threading;
using System.Collections.Generic;

namespace ThreadPool_task2
{
    public class MyThreadPool
    {
        private readonly LinkedList<Thread> threads;
        private readonly Queue<MyTask<TResult>> tasks;  

        private 
       public MyThreadPool(int count)
       {
            threads = new LinkedList<Thread>();
            for (var i = 0; i < count; ++i)
            {
                var thread = new Thread(this.MemberwiseClone)
            }
       }
    }
}
