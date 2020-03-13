using NUnit.Framework;
using System.IO;
using System.Reflection;
using System;
using MyNUnit;
using MyNUnit_task4;

namespace MyNUnit.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            TestRunner.testInformation = new System.Collections.Concurrent.ConcurrentBag<TestInfo>();
            foreach (var result in TestRunner.testInformation)
            {
                Assert.IsTrue(result.IsPassed);
                Assert.IsFalse(result.IsIgnored);
            }
        }

        private string path = $"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\Tests\\SuccesfulTests";
    }
}