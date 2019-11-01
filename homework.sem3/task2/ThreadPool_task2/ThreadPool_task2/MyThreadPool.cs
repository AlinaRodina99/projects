using System;
using System.Threading;

namespace ThreadPool_task2
{
    public class MyThreadPool<TResult>
    {
       private class MyTask : IMyTask<TResult>
       {
           public MyTask(Func<TResult> func)
           {
               this.func = func;
           }

           private enum TaskStatus
           { 
                Created,
                WaitingForActivation,
                RanToCompletion,
                Canceled,
                Faulted
           }

            private Func<TResult> func;
            private bool IsRunned = false;
            private TaskStatus taskStatus = TaskStatus.WaitingForActivation;

            public bool IsCompletedTask
            {
                get
                {
                    switch(taskStatus)
                    {
                        case TaskStatus.RanToCompletion:
                            return true;
                        case TaskStatus.Faulted:
                            return true;
                        case TaskStatus.Canceled:
                            return true;
                        default:
                            return false;
                    }
                }
            }

            public TResult Result => func();

            public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
            {
                var newFunc = new Func<TResult>(); 
                return new MyTask(newFunc);
            }

            public void Execute()
            {
                lock (this)
                {
                    IsRunned = true;
                    func();
                }
            }
       }

       public MyThreadPool(int n)
       {
           var threads = new Thread[n];
           for (int i = 0; i < n; ++i)
           {
                threads = new Thread[i];
           }

           for (int i = 0; i < n; ++i)
           {
               threads[i].Start();
           }
       }
    }
}
