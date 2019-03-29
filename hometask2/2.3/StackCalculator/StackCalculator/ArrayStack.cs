namespace StackCalculator
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] items;
        private int size;
        const int n = 10;
        public ArrayStack(int length)
        {
            items = new T[length];
        }

        public ArrayStack()
        {
            items = new T[n];
        }

        public bool IsEmpty
        {
            get
            {
                return size == 0;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
        }

        public void Push(T data)
        {
            if (size == items.Length)
            {
                Resize(items.Length + 10);
            }
            items[size] = data;
            ++size;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            else
            {
                --size;
                T data = items[size];
                items[size] = default(T);
                if (size > 0 && size < items.Length - 10)
                {
                    Resize(items.Length - 10);
                }
                return data;
            }
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            else
            {
                return items[size - 1];
            }
        }

        public void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < size; i++)
            {
                tempItems[i] = items[i];
            }
            items = tempItems;
        }
    }
}

