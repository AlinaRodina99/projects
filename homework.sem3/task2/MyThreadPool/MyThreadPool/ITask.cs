using System;

namespace MyThreadPool
{
    /// <summary>
    /// Interface for the task which is calculated in thread pool.
    /// </summary>
    /// <typeparam name="TResult">Result of the task.</typeparam>
    public interface ITask<TResult>
    {
        /// <summary>
        /// Property to know if task was calculated.
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Property for the result of the task calculation.
        /// </summary>
        TResult Result { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TNewResult"></typeparam>
        /// <param name="function"></param>
        /// <returns></returns>
        ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function);
    }
}
