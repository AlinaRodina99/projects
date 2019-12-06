﻿using System;

namespace ThreadPool_task2
{
    public interface IMyTask<TResult>
    {
        bool IsCompletedTask { get; set; }

        TResult Result { get; set; }

        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
