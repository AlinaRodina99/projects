namespace LinkedList
{
    class ElementOfList
    {
        public string Data { get; set; }
        public ElementOfList Next { get; set; }
        public ElementOfList Previous { get; set; }
        public int Key { get; set; }
        public ElementOfList(string data, int key)
        {
            Data = data;
            Key = key;
        }
    }
}
