using System;

namespace Lazy_sem3.task1
{
    /// <summary>
    /// This class implements multithreaded lazy.
    /// </summary>
    public class MultiThreadLazy<T> : ILazy<T>
    {
        /// <summary>
        /// Variable for stab object.
        /// </summary>
        private object locker = new object();

        /// <summary>
        /// Variable for lazy computation.
        /// </summary>
        private Func<T> func;

        /// <summary>
        /// Variavle for result of computation.
        /// </summary>
        private T result;

        /// <summary>
        /// Variable for check box to know if the value has already been calculated.
        /// </summary>
        private volatile bool hasValue;

        /// <summary>
        /// Constructor of the class that initializes function and makes check box value false.
        /// </summary>
        public MultiThreadLazy(Func<T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException();
            }
            this.func = func;
            hasValue = false;
        }

        /// <summary>
        /// Method to get result of the computation.
        /// </summary>
        public T Get()
        {
            if (!hasValue)
            {
                lock(locker)
                {
                    if (!hasValue)
                    {
                        result = func();
                        hasValue = true;
                        func = null;
                    }
                }
            }

            return result;
        }
    }
}
