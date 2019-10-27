using System;

namespace ThreadPool_task2
{
    public interface IMyTask<TResult>
    {
        bool IsCompletedTask { get; }

        TResult Result { get; }

        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
