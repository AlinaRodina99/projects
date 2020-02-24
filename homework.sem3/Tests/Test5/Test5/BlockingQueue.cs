using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test5
{
    public class BlockingQueue<T>
    {
        private class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            public int Priority { get; set; }
        }

        private Node<T> head;
        private Node<T> tail;

        private List<T> items;
        private List<int> priorities;

        public void Enqueue(T data)
        {
            if 
        }
    }
}
