using System;

namespace Attributes
{
    /// <summary>
    /// Attribute class for test methods.
    /// </summary>
    public class TestAttribute : MyNUnitAttribute
    {
        /// <summary>
        /// Exception that method must throw.
        /// </summary>
        public Type ExpectedException { get; set; } 

        /// <summary>
        /// Reason why test was ignored.
        /// </summary>
        public string Ignore { get; set; }
    }
}
