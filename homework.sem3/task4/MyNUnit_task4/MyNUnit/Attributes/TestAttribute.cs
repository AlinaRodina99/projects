using System;

namespace Attributes
{
    /// <summary>
    /// Class for attribute of test methods.
    /// </summary>
    public class TestAttribute : MyNUnitAttribute
    {
        /// <summary>
        /// Exception that test must throw.
        /// </summary>
        public Type ExpectedException { get; set; }

        /// <summary>
        /// Property for the reason why test was ignored.
        /// </summary>
        public string Ignore { get; set; }
    }
}
