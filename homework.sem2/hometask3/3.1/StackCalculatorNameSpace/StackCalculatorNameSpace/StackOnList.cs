namespace StackCalculatorNameSpace
{
    public class StackOnList<T> : IStack<T>
    {
        private class ElementOfList<W>
        {
            public ElementOfList(W data)
            {
                Data = data;
            }
            public W Data { get; set; }
            public ElementOfList<W> Next { get; set; }
        }

        private ElementOfList<T> head;

        public StackOnList() => Size = 0;
        
        public bool IsEmpty => Size == 0;
        
        public int Size { get; private set; }

        public void Push(T data)
        {
            var newElement = new ElementOfList<T>(data);
            newElement.Next = head;
            head = newElement;
            Size++;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            else
            {
                var temp = head;
                head = head.Next;
                Size--;
                return temp.Data;
            }
        }

        public T Peek() => IsEmpty ? default(T) : head.Data;

        public void Clear() => head = null;
    }
}

