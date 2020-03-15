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

        public string ClassName { get; private set; }

        public string Name { get; private set; }

        public TimeSpan RunningTime { get; private set; } = TimeSpan.Zero;

        public bool IsPassed { get; private set; } = false;

        public string IgnoreReason { get; private set; }

        public bool IsIgnored { get; private set; } = false;

        public TestInfo(Type type, object instance, MethodInfo testMethod, List<MethodInfo> beforeMethods, List<MethodInfo> afterMethods)
        {
            this.beforeMethods = beforeMethods;
            this.testMethod = testMethod;
            this.afterMethods = afterMethods;
            this.instance = instance;
            Name = testMethod.Name;
            ClassName = type.Name;
            Run();
        }

        public void Run()
        {
            Parallel.ForEach(beforeMethods, m => m?.Invoke(instance, null));
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
                if (testAttribute.ExpectedException != exception)
                {
                    IsPassed = false;
                }
            }

            Parallel.ForEach(afterMethods, m => m?.Invoke(instance, null));
            testMethod = null;
            beforeMethods = null;
            afterMethods = null;
        }
    }
}
