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
        public void AmountOfThreads()
        {
            Assert.IsTrue(new MyThreadPool(7).NumberOfThreads >= 7);
            Assert.IsTrue(new MyThreadPool(10).NumberOfThreads >= 10);
        }

        [Test]
        public void ContinueWithTest()
        {
            var pool = new MyThreadPool(5);
            var task = pool.AddNewTask(() => 1000 + 1000);

            var newTask1 = task.ContinueWith((result) => result * 5);
            var newTask2 = newTask1.ContinueWith((result) => result / 10000);

            Assert.AreEqual(2000, task.Result);
            Assert.IsTrue(task.IsCompleted);

            Assert.AreEqual(10000, newTask1.Result);
            Assert.IsTrue(newTask1.IsCompleted);

            Assert.AreEqual(1, newTask2.Result);
            Assert.IsTrue(newTask2.IsCompleted);
        }

        private MyThreadPool threadPool;
    }
}