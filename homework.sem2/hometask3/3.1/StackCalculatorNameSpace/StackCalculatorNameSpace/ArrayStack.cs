namespace StackCalculatorNameSpace
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] items;
        private const int arraySizeByDefault = 10;

        public ArrayStack(int length) => items = new T[length];

        public ArrayStack() => items = new T[arraySizeByDefault];
        
        public bool IsEmpty => Size == 0;
       
        public int Size { get; private set; }

        public void Push(T data)
        {
            if (Size == items.Length)
            {
                Resize(items.Length * 2);
            }
            items[Size] = data;
            ++Size;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            else
            {
                --Size;
                T data = items[Size];
                items[Size] = default(T);
                if (Size > 0 && Size < items.Length / 2)
                {
                    Resize(items.Length / 2);
                }
                return data;
            }
        }

        public T Peek() => IsEmpty ? default(T) : items[Size - 1];
       
        public void Resize(int max)
        {
            var tempItems = new T[max];
            for (int i = 0; i < Size; i++)
            {
                tempItems[i] = items[i];
            }
            items = tempItems;
        }

        public void Clear()
        {
            for (int i = 0; i < Size; ++i)
            {
                items[i] = default(T);
            }
        }
    }
}

