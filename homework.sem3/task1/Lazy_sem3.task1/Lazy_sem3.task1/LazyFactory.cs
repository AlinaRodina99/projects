using System;

namespace Lazy_sem3.task1
{
    /// <summary>
    /// This class for creation of two different implementaions of lazy interface.
    /// First for one the single-threaded lazy; second for multithreaded lazy.
    /// </summary>
    public static class LazyFactory<T>
    {
        /// <summary>
        /// Method to create single-threaded lazy.
        /// </summary>
        /// <param name="supplier">The delegate represented by the lambda expression</param>
        /// <returns>Single-threaded lazy</returns>
        public static OneThreadLazy<T> CreateOneThreadLazy(Func<T> supplier)
        {
            return new OneThreadLazy<T>(supplier);
        }

        /// <summary>
        /// Method to create multithreaded lazy.
        /// </summary>
        /// <param name="supplier">The delegate represented by the lambda expression</param>
        /// <returns>Multithreaded lazy.</returns>
        public static MultiThreadLazy<T> CreateMultiThreadLazy(Func<T> supplier)
        {
            return new MultiThreadLazy<T>(supplier);
        }
    }
}
