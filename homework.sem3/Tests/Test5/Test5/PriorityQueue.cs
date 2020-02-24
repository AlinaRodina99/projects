using System;
using System.Collections.Generic;
using System.Threading;

namespace Test5
{
    public class PriorityQueue<T>
    {
        private List<T> items;
        private List<int> priorities;
        private object locker = new object();

        public PriorityQueue()
        {
            items = new List<T>();
            priorities = new List<int>();
        }

        public int Size { get { return items.Count; } }

        public void Enqueue(T item, int priority)
        {
            if (item == null || priority <= 0)
            {
                throw new ArgumentNullException();
            }

            lock (locker)
            {
                for (var i = 0; i < priorities[i]; ++i)
                {
                    if (priorities[i] > priority)
                    {
                        Monitor.Wait(locker);
                        priorities.Insert(i, priority);
                        items.Insert(i, item);
                    }
                }
            }

            items.Add(item);
            priorities.Add(priority);
        }

        public T Dequeue()
        {
            while (Size >= 0)
            {
                T item = items[0];
                priorities.RemoveAt(0);
                items.RemoveAt(0);
                return item;
            }
            return default; 
        }

    }
}
