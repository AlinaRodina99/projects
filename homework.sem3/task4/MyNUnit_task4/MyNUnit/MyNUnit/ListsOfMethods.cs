using System.Collections.Generic;
using System.Reflection;

namespace MyNUnit
{
    /// <summary>
    /// Class for all lists of necessary methods.
    /// </summary>
    public class ListsOfMethods
    {
        /// <summary>
        /// Methods that run before testing class.
        /// </summary>
        public List<MethodInfo> BeforeClassMethods { get; private set; }

        /// <summary>
        /// Methods that run before each method in testing class.
        /// </summary>
        public List<MethodInfo> BeforeMethods { get; private set; }

        /// <summary>
        /// Methods of testing class.
        /// </summary>
        public List<MethodInfo> TestMethods { get; private set; }

        /// <summary>
        /// Methods that run after each method in testing class.
        /// </summary>
        public List<MethodInfo> AfterMethods { get; private set; }

        /// <summary>
        /// Methods that run after testing class.
        /// </summary>
        public List<MethodInfo> AfterClassMethods { get; private set; }

        public ListsOfMethods()
        {
            BeforeClassMethods = new List<MethodInfo>();
            BeforeMethods = new List<MethodInfo>();
            TestMethods = new List<MethodInfo>();
            AfterMethods = new List<MethodInfo>();
            AfterClassMethods = new List<MethodInfo>();
        }
    }
}
