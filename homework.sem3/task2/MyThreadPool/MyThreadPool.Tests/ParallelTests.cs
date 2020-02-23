using NUnit.Framework;
using System.Threading;
using System.Collections.Concurrent;
using System.Linq;

namespace MyThreadPool.Tests
{
    public class Tests
    {

        [Test]
        public void Test()
        {
            threadPool = new MyThreadPool(2);
            var task1 = threadPool.AddNewTask(() => 3 + 10);
            var task2 = threadPool.AddNewTask(() => 15 + 3);
            var task3 = threadPool.AddNewTask(() => 2 * 2);

            Assert.AreEqual(13, task1.Result);
            Assert.AreEqual(18, task2.Result);
            Assert.AreEqual(4, task3.Result);

            Assert.IsTrue(task1.IsCompleted);
            Assert.IsTrue(task2.IsCompleted);
            Assert.IsTrue(task3.IsCompleted);
        }

        [Test]
        public void AmountOfThreadsTest()
        {
            var count = 10;
            threadPool = new MyThreadPool(count);
            var bag = new ConcurrentBag<int>();

            for (var i = 0; i < count; ++i)
            {
                threadPool.AddNewTask(() =>
                {
                    bag.Add(Thread.CurrentThread.ManagedThreadId);
                    return i;
                });
            }

            threadPool.Shutdown();
            Assert.AreEqual(bag.Count(), bag.Distinct().Count());
        }


        [Test]
        public void ThreadPoolTest()
        {
            var threadPoolAmount = 3;
            var threadPool = new MyThreadPool(threadPoolAmount);
            var tasksAmount = 10;
            var tasks = new ITask<int>[tasksAmount];
            var taskExecute = new ManualResetEvent(false);

            for (var i = 0; i < tasksAmount; ++i)
            {
                var localI = i;
                tasks[localI] = threadPool.AddNewTask(() =>
                {
                    taskExecute.WaitOne();
                    Thread.Sleep(1000);
                    return localI;
                });
            }
            taskExecute.Set();
            for (var i = 0; i < tasksAmount; ++i)
            {
                Assert.AreEqual(i, tasks[i].Result);
            }
            threadPool.Shutdown();
        }

        private MyThreadPool threadPool;
    }
}