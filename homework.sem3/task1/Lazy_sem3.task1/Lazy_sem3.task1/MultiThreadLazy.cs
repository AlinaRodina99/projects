using System;

namespace Lazy_sem3.task1
{
    /// <summary>
    /// This class implements multithreaded lazy.
    /// </summary>
    public class MultiThreadLazy<T> : ILazy<T>
    {
        /// <summary>
        /// Variables for stab object, lazy computation, result of computation and check box to know if the value has already been calculated.
        /// </summary>
        private object locker = new object();
        private Func<T> func;
        private T result;
        private bool hasValue;

        /// <summary>
        /// Constructor of the class that initializes function and makes check box value false.
        /// </summary>
        public MultiThreadLazy(Func<T> func)
        {
            this.func = func;
            hasValue = false;
        }

        /// <summary>
        /// Method to get result of the computation.
        /// </summary>
        public T Get()
        {
            if (hasValue)
            {
                return result;
            }

            lock(locker)
            {
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
}
