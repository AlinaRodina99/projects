using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyThreadPool
{
    public class MyThreadPool
    {
        private Thread[] threads;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private ManualResetEvent taskSignal = new ManualResetEvent(false);
        private object locker = new object();

        public MyThreadPool(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid argument!");
            }

            NumberOfThreads = count;
            CreateThreads(count);
        }

        public int NumberOfThreads { get; private set; }

        /// <summary>
        /// Property to know if thread pool is working.
        /// </summary>
        public bool IsWorking { get => tokenSource.IsCancellationRequested; }

        private void CreateThreads(int count)
        {
            threads = new Thread[count];
            for (var i = 0; i < count; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    while (true)
                    {
                        if (tokenSource.IsCancellationRequested && tasksQueue.IsEmpty)
                        {
                            break;
                        }

                        if (tasksQueue.TryDequeue(out Action task))
                        {
                            task();
                        }
                        else
                        {
                            taskSignal.Reset();
                            taskSignal.WaitOne();
                        }
                    }
                });
                threads[i].Start();
            }
        }

        public ITask<TResult> AddNewTask<TResult>(Func<TResult> function)
        {
            var newTask = new Task<TResult>(this, function);
            AddTaskToQueue(newTask);
            return newTask;
        }

        protected internal void AddTaskToQueue<TResult>(Task<TResult> task)
        {
            if (tokenSource.IsCancellationRequested)
            {
                throw new ThreadPoolException();
            }

            tasksQueue.Enqueue(task.Calculations);
            taskSignal.Set();
        }

        public void Shutdown()
        {
            tokenSource.Cancel();
        }

        public class Task<TResult> : ITask<TResult>
        {
            private Func<TResult> function;
            private MyThreadPool myThreadPool;
            private ManualResetEvent readyResult = new ManualResetEvent(false);
            private AggregateException exception;
            private Queue<Action> continuationQueue = new Queue<Action>();
            private TResult result;
            private object locker = new object();


            public Task(MyThreadPool myThreadPool, Func<TResult> function)
            {
                this.myThreadPool = myThreadPool;
                this.function = function;
            }

            public bool IsCompleted { get; private set; }

            public TResult Result
            {
                get
                {
                    readyResult.WaitOne();
                    if (exception != null)
                    {
                        throw new AggregateException("There was an exception {0} ", exception);
                    }

                    return result;
                }
                private set
                {
                    result = value;
                }
            }

            public void Calculations()
            {
                try
                {
                    result = function();
                }
                catch (Exception exception)
                {
                    this.exception = new AggregateException(exception); 
                }
                finally
                { 
                    readyResult.Set();
                    IsCompleted = true;
                    function = null;

                    lock (locker)
                    {
                        while (continuationQueue.Count != 0)
                        {
                            continuationQueue.Dequeue().Invoke();
                        }
                    }
                }
            }

            public ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function)
            {
                var newTask = new Task<TNewResult>(myThreadPool, () => function(result));
                lock (locker)
                {
                    if (!IsCompleted)
                    {
                        continuationQueue.Enqueue(() => myThreadPool.AddTaskToQueue(newTask));
                        return newTask;
                    }
                }

                myThreadPool.AddTaskToQueue(newTask);
                return newTask;
            }
        }
    }
}
