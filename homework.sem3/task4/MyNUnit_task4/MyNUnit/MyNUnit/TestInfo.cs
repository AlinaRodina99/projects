using System;
using System.Diagnostics;
using System.Reflection;
using Attributes;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyNUnit
{
    /// <summary>
    /// Class for test information.
    /// </summary>
    public class TestInfo
    {
        private List<MethodInfo> beforeMethods;
        private List<MethodInfo> afterMethods;
        private MethodInfo testMethod;
        private readonly object instance;

        /// <summary>
        /// Property for class in which method was defined.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Name of the method.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time while test was executing.
        /// </summary>
        public TimeSpan RunningTime { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Bool property tp know whether test was passed or not.
        /// </summary>
        public bool IsPassed { get; set; } = false;

        /// <summary>
        /// Reason why test was ignored.
        /// </summary>
        public string IgnoreReason { get; set; }

        /// <summary>
        /// Property to know whether test was ignored or not.
        /// </summary>
        public bool IsIgnored { get; set; } = false;

        public TestInfo(Type type, object instance, MethodInfo testMethod, List<MethodInfo> beforeMethods, List<MethodInfo> afterMethods)
        {
            if (testMethod.ReturnType != typeof(void))
            {
                throw new AggregateException("Test method must not return anything!");
            }

            if (testMethod.GetParameters().Length != 0)
            {
                throw new AggregateException("Test method can not have parameters!");
            }

            this.beforeMethods = beforeMethods;
            this.testMethod = testMethod;
            this.afterMethods = afterMethods;
            this.instance = instance;
            Name = testMethod.Name;
            ClassName = type.Name;
        }

        /// <summary>
        /// Method to run each test method.
        /// </summary>
        public void Run()
        {
            try
            {
                Parallel.ForEach(beforeMethods, m => m?.Invoke(instance, null));
            }
            catch (AggregateException exception)
            {
                throw exception;
            }

            var testAttribute = testMethod.GetCustomAttribute<TestAttribute>();

            if (testAttribute.Ignore != null)
            {
                IgnoreReason = testAttribute.Ignore;
                IsIgnored = true;
                return;
            }

            var timer = new Stopwatch();

            try
            {
                timer.Start();
                testMethod.Invoke(instance, null);
                timer.Stop();
                RunningTime = timer.Elapsed;
                IsPassed = true;
            }
            catch (Exception e)
            {
                timer.Stop();
                RunningTime = timer.Elapsed;
                var exception = e.InnerException.GetType();
                IsPassed = false;

                if (testAttribute.ExpectedException == exception)
                {
                    IsPassed = true;
                }
            }

            Parallel.ForEach(afterMethods, m => m?.Invoke(instance, null));
            testMethod = null;
            beforeMethods = null;
            afterMethods = null;
        }
    }
}
