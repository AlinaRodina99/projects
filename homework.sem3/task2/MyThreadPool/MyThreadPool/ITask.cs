using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThreadPool
{
    public interface ITask<TResult>
    {
        bool IsCompleted { get; }

        TResult Result { get; }

        ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function);

    }
}
