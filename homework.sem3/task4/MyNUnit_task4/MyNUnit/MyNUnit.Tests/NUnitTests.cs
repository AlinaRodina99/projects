using NUnit.Framework;
using System;
using SuccesfulTests;

namespace MyNUnit.Tests
{
    public class NUnitTests
    {
        [SetUp]
        public void SetUp()
        {
            runner = new TestRunner();
            path = $"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\Tests";
        }

        [Test]  
        public void SuccesfulTestingTest()
        {
            path += "\\SuccesfulTests\\bin";
            runner.Run(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }

            Assert.AreEqual(3, runner.TestInformation.Count);
            Assert.AreEqual("Testing finished", TestClass.TestString);
        }

        [Test]
        public void FailedTestingTest()
        {
            path += "\\FailedTesting\\bin";
            runner.Run(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsFalse(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }

            Assert.AreEqual(4, runner.TestInformation.Count);
        }

        [Test]
        public void IgnoreTestingTest()
        {
            path += "\\IgnoredTesting\\bin";
            runner.Run(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsIgnored);
                Assert.IsTrue(test.RunningTime == TimeSpan.Zero);
            }
        }

        [Test]
        public void ExpectedExceptionTestingTest()
        {
            path += "\\ExpectedExceptionTesting\\bin";
            runner.Run(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsFalse(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }
        }

        private string path;
        private TestRunner runner;
    }
}