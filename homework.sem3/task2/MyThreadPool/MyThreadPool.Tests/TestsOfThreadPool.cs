using NUnit.Framework;
using System;

namespace MyThreadPool.Tests
{
    public class TestsOfThreadPool
    {

        [Test]
        public void ManyTasksTest()
        {
            threadPool = new MyThreadPool(2);
            var task1 = threadPool.AddNewTask(() => 20 + 10);
            var task2 = threadPool.AddNewTask(() => 15 * 3);
            var task3 = threadPool.AddNewTask(() => 2 * 2);

            Assert.AreEqual(30, task1.Result);
            Assert.AreEqual(45, task2.Result);
            Assert.AreEqual(4, task3.Result);

            Assert.IsTrue(task1.IsCompleted);
            Assert.IsTrue(task2.IsCompleted);
            Assert.IsTrue(task3.IsCompleted);
        }

        [Test]
        public void ShutdownTest()
        {
            threadPool = new MyThreadPool(10);
            var task1 = threadPool.AddNewTask(() => Math.Max(30, 50));
            var task2 = threadPool.AddNewTask(() => Math.Abs(-10000));

            threadPool.Shutdown();

            Assert.AreEqual(50, task1.Result);
            Assert.AreEqual(10000, task2.Result);
            Assert.IsTrue(task1.IsCompleted);
            Assert.IsTrue(task2.IsCompleted);
        }

        [Test]
        public void OneTaskManyThreadsTest()
        {
            threadPool = new MyThreadPool(10);
            var task = threadPool.AddNewTask(() => 3 * 3 * 3);

            Assert.AreEqual(27, task.Result);
            Assert.IsTrue(task.IsCompleted);
        }

        [Test]
        public void AmountOfThreads()
        {
            Assert.IsTrue(new MyThreadPool(7).NumberOfThreads >= 7);
            Assert.IsTrue(new MyThreadPool(10).NumberOfThreads >= 10);
        }

        [Test]
        public void ContinueWithTest()
        {
            var pool = new MyThreadPool(5);
            var task = pool.AddNewTask(() => 5 * 2);

            var newTask1 = task.ContinueWith((result) => result * 5);
            var newTask2 = newTask1.ContinueWith((result) => result / 50);

            Assert.AreEqual(10, task.Result);
            Assert.IsTrue(task.IsCompleted);

            Assert.AreEqual(50, newTask1.Result);
            Assert.IsTrue(newTask1.IsCompleted);

            Assert.AreEqual(1, newTask2.Result);
            Assert.IsTrue(newTask2.IsCompleted);
        }

        [Test]
        public void ShutdownWhenNoTasksInThreadPoolTest()
        {
            threadPool = new MyThreadPool(20);

            threadPool.Shutdown();
            Assert.AreEqual(0, threadPool.NumberOfThreads);
        }

        [Test]
        public void TryContinueWithWhenThreadPoolWasShutdownTest()
        {
            threadPool = new MyThreadPool(10);

            var task1 = threadPool.AddNewTask(() => Math.Log2(8));
            var task2 = threadPool.AddNewTask(() => 1000 * 1000);
            var newTask1 = task2.ContinueWith((result) => Math.Sqrt(result));
            threadPool.Shutdown();

            Assert.Throws<ThreadPoolException>(() => task2.ContinueWith((result) => result / 10));
            Assert.AreEqual(task1.Result, 3);
            Assert.IsTrue(task1.IsCompleted);
            Assert.AreEqual(1000000, task2.Result);
            Assert.IsTrue(task2.IsCompleted);
            Assert.AreEqual(1000, newTask1.Result);
            Assert.IsTrue(newTask1.IsCompleted);
        }

        [Test]
        public void 

        private MyThreadPool threadPool;
    }
}