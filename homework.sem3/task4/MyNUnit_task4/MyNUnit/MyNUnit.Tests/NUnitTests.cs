using NUnit.Framework;
using System;
using System.Linq;

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
            runner.Execute(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }

            Assert.AreEqual(4, runner.TestInformation.Count);
        }

        [Test]
        public void FailedTestingTest()
        {
            path += "\\FailedTesting\\bin";
            runner.Execute(path);

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
            runner.Execute(path);

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
            runner.Execute(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }
        }

        [Test]
        public void BeforeTestingTest()
        {
            path += "\\BeforeTesting\\bin";
            runner.Execute(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }

            Assert.AreEqual(1, runner.TestInformation.Count());
        }

        [Test]
        public void AfterTestingTest()
        {
            path += "\\AfterTesting\\bin";
            runner.Execute(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }

            Assert.AreEqual(2, runner.TestInformation.Count());
        }

        [Test]
        public void BeforeClassTestingTest()
        {
            path += "\\BeforeClassTesting\\bin";
            runner.Execute(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }

            Assert.AreEqual(1, runner.TestInformation.Count());
        }

        [Test]
        public void AfterClassTestingTest()
        {
            path += "\\AfterClassTesting\\bin";
            runner.Execute(path);

            foreach (var test in runner.TestInformation)
            {
                Assert.IsTrue(test.IsPassed);
                Assert.IsTrue(test.RunningTime > TimeSpan.Zero);
            }

            Assert.AreEqual(2, runner.TestInformation.Count());
        }

        private string path;
        private TestRunner runner;
    }
}