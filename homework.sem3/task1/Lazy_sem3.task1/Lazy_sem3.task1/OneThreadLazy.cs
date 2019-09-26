using System;

namespace Lazy_sem3.task1
{
    /// <summary>
    /// This class implements single-threaded thread.
    /// </summary>
    public class OneThreadLazy<T> : ILazy<T>
    {
        /// <summary>
        /// Variables for lazy computation, result of computation and check box to know if the value has already been calculated.
        /// </summary>
        private Func<T> func;
        private T result;
        private bool hasValue;

        /// <summary>
        /// Constructor of the class that initializes function and makes check box value false.
        /// </summary>
        public OneThreadLazy(Func<T> func)
        {
            this.func = func;
            hasValue = false;
        }

        /// <summary>
        /// Method to get result of the computation.
        /// </summary>
        public T Get()
        {
            if (func == null)
            {
                throw new NullReferenceException();
            }

            if (!hasValue)
            {
                result = func();
                hasValue = true;
                return result;
            }

            return result;
        }
    }
}
