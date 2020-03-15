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
        public List<MethodInfo> beforeClassMethods { get; private set; }

        /// <summary>
        /// Methods that run before each method in testing class.
        /// </summary>
        public List<MethodInfo> beforeMethods { get; private set; }

        /// <summary>
        /// Methods of testing class.
        /// </summary>
        public List<MethodInfo> testMethods { get; private set; }

        /// <summary>
        /// Methods that run after each method in testing class.
        /// </summary>
        public List<MethodInfo> afterMethods { get; private set; }

        /// <summary>
        /// Methods that run after testing class.
        /// </summary>
        public List<MethodInfo> afterClassMethods { get; private set; }

        public ListsOfMethods()
        {
            beforeClassMethods = new List<MethodInfo>();
            beforeMethods = new List<MethodInfo>();
            testMethods = new List<MethodInfo>();
            afterMethods = new List<MethodInfo>();
            afterClassMethods = new List<MethodInfo>();
        }
    }
}
