namespace StackCalculator
{
    public class ElementOfList<T>
    {
        public ElementOfList(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public ElementOfList<T> Next { get; set; }
    }
}
