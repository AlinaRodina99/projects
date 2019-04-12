namespace PriorityQueueNameSpace
{
    /// <summary>
    /// Class for queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        public class ElementOfQueue<W>
        {
            public W Value { get; set; }

            public ElementOfQueue<W> Next { get; set; } = null;

            public int Priority { get; set; }

            public ElementOfQueue(W value, int priority)
            {
                Value = value;
                Priority = priority;
            }
        }

        public ElementOfQueue<T> head;

        public ElementOfQueue<T> tail;

        public int sizeOfQueue { get; set; }

        public PriorityQueue()
        {
            head = null;
            tail = null;
            sizeOfQueue = 0;
        }

        public void Enqueue(T value, int priority)
        {
            if (head == null)
            {
                head = new ElementOfQueue<T>(value, priority);
                tail = head;
            }
            else
            {
                tail.Next = new ElementOfQueue<T>(value, priority);
                tail = tail.Next;
            }
            ++sizeOfQueue;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new EmptyQueueException("Queue is empty!");
            }

            var highestPriority = head.Priority;
            int index = 0;
            var temp = head.Next;
            for (int i = 0; i < sizeOfQueue; ++i)
            {
                if (temp.Priority > highestPriority)
                {
                    highestPriority = temp.Priority;
                    index = i;
                }
                temp = temp.Next;
            }

            temp = head;
            if (index == 0)
            {
                head = temp.Next;
                --sizeOfQueue;
                return head.Value;
            }
            
            temp = head.Next;
            var previousElement = head;
            for (int i = 0; i < index; ++i)
            {
                temp = temp.Next;
                previousElement = previousElement.Next;
            }
            previousElement.Next = temp.Next;
            --sizeOfQueue;
            return temp.Value;
        }
    }
}
