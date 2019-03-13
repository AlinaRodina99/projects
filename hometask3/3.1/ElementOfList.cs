using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
