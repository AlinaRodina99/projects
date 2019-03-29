namespace StackCalculator
{
    public class StackOnList<T> : IStack<T>
    {
        ElementOfList<T> head;
        int size;
        public StackOnList()
        {
            size = 0;
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
            ElementOfList<T> newElement = new ElementOfList<T>(data);
            newElement.Next = head;
            head = newElement;
            size++;
        }

        public T Pop()
        {
            if (IsEmpty == true)
            {
                return default(T);
            }
            else
            {
                ElementOfList<T> temp = head;
                head = head.Next;
                size--;
                return temp.Data;
            }
        }

        public T Peek()
        {
            if (IsEmpty == true)
            {
                return default(T);
            }
            else
            {
                return head.Data;
            }
        }
    }
}

