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
        private AutoResetEvent resetEvent = new AutoResetEvent(true);
        private bool IsCompleted;
        private MyThreadPool threadPool;
        private TResult result;
        private AggregateException aggregateException;

        public TResult Result
        {
            get => result;
            private set => result = value;
        }

        public MyTask(Func<TResult> function, MyThreadPool threadPool)
        {
            this.function = function;
            this.threadPool = threadPool; 
        }

        public bool IsCompletedTask
        {
            get
            {
                

                return false;
            }
            set
            {

            }
        }

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

            IsCompleted = true;
            function = null;
            resetEvent.Set();
        }

        #region
        //private class MyTask : IMyTask<TResult>
        //{
        //    public MyTask(Func<TResult> func)
        //    {
        //        this.func = func;
        //    }

        //    private enum TaskStatus
        //    {
        //        Created,
        //        WaitingForActivation,
        //        RanToCompletion,
        //        Canceled,
        //        Faulted
        //    }

        //    private Func<TResult> func;
        //    private bool IsRunned = false;
        //    private TaskStatus taskStatus = TaskStatus.WaitingForActivation;

        //    public bool IsCompletedTask
        //    {
        //        get
        //        {
        //            switch (taskStatus)
        //            {
        //                case TaskStatus.RanToCompletion:
        //                    return true;
        //                case TaskStatus.Faulted:
        //                    return true;
        //                case TaskStatus.Canceled:
        //                    return true;
        //                default:
        //                    return false;
        //            }
        //        }
        //    }

        //    public TResult Result => func();

        //    public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
        //    {
        //        var newFunc = new Func<TResult>();
        //        return new MyTask(newFunc);
        //    }

        //    public void Execute()
        //    {
        //        lock (this)
        //        {
        //            IsRunned = true;
        //            func();
        //        }
        //    }
        //}
        #endregion
    }
}
