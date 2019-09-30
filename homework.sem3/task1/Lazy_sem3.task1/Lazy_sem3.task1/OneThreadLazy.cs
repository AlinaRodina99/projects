using System;

namespace Lazy_sem3.task1
{
    /// <summary>
    /// This class implements single-threaded thread.
    /// </summary>
    public class OneThreadLazy<T> : ILazy<T>
    {
        /// <summary>
        /// Variable for lazy computation.
        /// </summary>
        private Func<T> func;

        /// <summary>
        /// Variable for result of computation.
        /// </summary>
        private T result;

        /// <summary>
        /// Variable check box to know if the value has already been calculated.
        /// </summary>
        private bool hasValue;

        /// <summary>
        /// Constructor of the class that initializes function and makes check box value false.
        /// </summary>
        public OneThreadLazy(Func<T> func)
        {
            if (func != null)
            {
                this.func = func;
            }
            hasValue = false;
        }

        /// <summary>
        /// Method to get result of the computation.
        /// </summary>
        public T Get()
        {
            if (!hasValue)
            {
                result = func();
                hasValue = true;
                func = null;
                return result;
            }

            return result;
        }
    }
}
