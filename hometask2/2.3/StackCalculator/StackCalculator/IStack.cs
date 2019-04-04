namespace StackCalculatorNameSpace
{
    public interface IStack<T>
    {
        void Push(T data);
        T Pop();
        bool IsEmpty { get; }
        int Size { get; }
        T Peek();
    }
}
