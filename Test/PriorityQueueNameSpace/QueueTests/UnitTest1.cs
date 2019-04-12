using NUnit.Framework;
using PriorityQueueNameSpace;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            priorityQueue = new PriorityQueue<int>();
        }

        [Test]
        public void EnqueueTest()
        {
            priorityQueue.Enqueue(1, 1);
            Assert.AreEqual(priorityQueue.sizeOfQueue, 1);
        }

        [Test]
        public void DequeueTest()
        {
            priorityQueue.Enqueue(1, 1);
            priorityQueue.Enqueue(2, 3);
            priorityQueue.Dequeue();
            Assert.AreEqual(priorityQueue.sizeOfQueue, 1);
        }

        PriorityQueue<int> priorityQueue;
    }
}