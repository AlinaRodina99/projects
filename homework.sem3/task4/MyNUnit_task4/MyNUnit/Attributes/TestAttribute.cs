using System;

namespace Attributes
{
    public class TestAttribute : MyNUnitAttribute
    {
        public Type ExpectedException { get; set; }

        public string Ignore { get; set; }
    }
}
