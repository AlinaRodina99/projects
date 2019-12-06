using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPool_task2
{
    public class MyTask<TResult> : IMyTask<TResult>
    {
        private Func<TResult> function;
        private AutoResetEvent readyResult = new AutoResetEvent(false);
        private MyThreadPool threadPool;
        private TResult result;
        private AggregateException aggregateException;

        public TResult Result
        {
            get
            {
                readyResult.WaitOne();
                if (aggregateException != null)
                {
                    throw aggregateException;
                }

                return result;
            }
            private set => result = value;
        }

        public MyTask(Func<TResult> function, MyThreadPool threadPool)
        {
            this.function = function;
            this.threadPool = threadPool; 
        }

        public bool IsCompletedTask { get; private set; } = false;

        public void Execute()
        {
            try
            {
                result = function();
            }
            catch(Exception exception)
            {
                aggregateException = new AggregateException(exception);
            }

            IsCompletedTask = true;
            function = null;
            readyResult.Set();
        }

        public MyTask ContinueWith(Func<>)
    }
}
