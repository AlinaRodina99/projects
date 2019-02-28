namespace LinkedList
{
    class ElementOfList
    {
        public string Data { get; set; }
        public ElementOfList Next { get; set; }
        public ElementOfList Previous { get; set; }
        public ElementOfList(string data)
        {
            Data = data;
        }
    }
}
