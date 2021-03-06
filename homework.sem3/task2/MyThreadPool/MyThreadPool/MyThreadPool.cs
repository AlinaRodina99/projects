﻿using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyThreadPool
{
    /// <summary>
    /// Class that implements thread pool.
    /// </summary>
    public class MyThreadPool
    {
        private Thread[] threads;
        private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();
        private readonly ConcurrentQueue<Action> tasksQueue = new ConcurrentQueue<Action>();
        private readonly AutoResetEvent taskSignal = new AutoResetEvent(false);
        private readonly AutoResetEvent shutDownSignal = new AutoResetEvent(false);
        private readonly object locker = new object();
        private int countOfThreads;

        public MyThreadPool(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid argument!");
            }

            NumberOfThreads = count;
            CreateThreads(count);
        }
        
        /// <summary>
        /// Property to know amount of threads.
        /// </summary>
        public int NumberOfThreads { get => countOfThreads; private set { countOfThreads = value; } }

        /// <summary>
        /// Property to know if thread pool is working.
        /// </summary>
        public bool IsWorking { get => !tokenSource.IsCancellationRequested; }

        /// <summary>
        /// Method to start pool.
        /// </summary>
        /// <param name="count"></param>
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
                            Interlocked.Decrement(ref countOfThreads);
                            shutDownSignal.Set();
                            break;
                        }

                        if (tasksQueue.TryDequeue(out Action task))
                        {
                            taskSignal.Set();
                            task();
                        }
                        else
                        {
                            taskSignal.WaitOne();
                        }
                    }
                });
                threads[i].Start();
            }
        }

        /// <summary>
        /// Method to add new task to the queue of the tasks.
        /// </summary>
        /// <typeparam name="TResult">Result of the function.</typeparam>
        /// <param name="function">Input function.</param>
        /// <returns>New task.</returns>
        public ITask<TResult> AddNewTask<TResult>(Func<TResult> function)
        {
            var newTask = new Task<TResult>(this, function);
            AddTaskToQueue(newTask);
            return newTask;
        }

        /// <summary>
        /// Method to add new task to the queue of the tasks.
        /// </summary>
        /// <typeparam name="TResult">Outcoming result.</typeparam>
        private void AddTaskToQueue<TResult>(Task<TResult> task)
        {
            if (tokenSource.IsCancellationRequested)
            {
                throw new ThreadPoolException();
            }

            tasksQueue.Enqueue(task.Calculations);
            taskSignal.Set();
        }

        /// <summary>
        /// Method to stop work of thread pool.
        /// </summary>
        public void Shutdown()
        {
            lock (locker)
            {
                tokenSource.Cancel();
                while (countOfThreads != 0)
                {
                    taskSignal.Set();
                    shutDownSignal.WaitOne();
                }
            }
        }

        public class Task<TResult> : ITask<TResult>
        {
            private Func<TResult> function;
            private readonly MyThreadPool myThreadPool;
            private readonly ManualResetEvent readyResult = new ManualResetEvent(false);
            private AggregateException exception;
            private readonly Queue<Action> continuationQueue = new Queue<Action>();
            private TResult result;
            private readonly object locker = new object();


            public Task(MyThreadPool myThreadPool, Func<TResult> function)
            {
                this.myThreadPool = myThreadPool;
                this.function = function;
            }

            /// <summary>
            /// Property to know if task was calculated.
            /// </summary>
            public bool IsCompleted { get; private set; }

            /// <summary>
            /// Property to know the result of the task.
            /// </summary>
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

            /// <summary>
            /// Method to calculate function of current task.
            /// </summary>
            public void Calculations()
            {
                try
                {
                    if (!myThreadPool.IsWorking)
                    {
                        throw new ThreadPoolException();
                    }

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

            /// <summary>
            /// Method to add continuation task using result of previous task.
            /// </summary>
            /// <typeparam name="TNewResult">Result of continuation task.</typeparam>
            /// <param name="function">Function of continuation task.</param>
            /// <returns>New task.</returns>
            public ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> function)
            {
                if (!myThreadPool.IsWorking)
                {
                    throw new ThreadPoolException();
                }

                var newTask = new Task<TNewResult>(myThreadPool, () => function(result));
                lock (locker)
                {
                    if (!IsCompleted)
                    {
                        continuationQueue.Enqueue(newTask.Calculations);
                        return newTask;
                    }
                    else
                    {
                        myThreadPool.AddTaskToQueue(newTask);
                        return newTask;
                    }
                }
            }
        }
    }
}
