using Attributes;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MyNUnit
{
    /// <summary>
    /// Class for running of tests.
    /// </summary>
    public class TestRunner
    {
        public ConcurrentBag<TestInfo> TestInformation { get; private set; } = new ConcurrentBag<TestInfo>();

        /// <summary>
        /// Method for reporting of test results.
        /// </summary>
        public void PrintResult()
        {
            foreach (var test in TestInformation)
            {
                if (test.IsIgnored)
                {
                    Console.WriteLine($"Test was ignored because {test.IgnoreReason}");
                }

                if (test.IsPassed)
                {
                    Console.WriteLine($"Test passed, time of running {test.RunningTime}");
                }
                else
                {
                    Console.WriteLine($"Test failed, time of running {test.RunningTime}");
                }
            }
        }

        /// <summary>
        /// Method that loads all assemblies.
        /// </summary>
        /// <param name="path">Path where assemblies are located.</param>
        public void Execute(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new TestRunException("This directory does not exist!");
            }

            var assemblies = new List<Assembly>();
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories)
                .Where(x => x.Substring(x.LastIndexOf('\\') + 1) != "Attributes.dll").ToList();
            var listOfTypes = new List<Type>();

            Parallel.ForEach(files, f => assemblies.Add(Assembly.LoadFrom(f)));

            var distinctAssemblies = assemblies.Distinct();

            foreach (var assembly in distinctAssemblies)
            {
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    listOfTypes.Add(type);
                }
            }

            Parallel.ForEach(listOfTypes, t => RunTests(t));
        }

        /// <summary>
        /// Method to run tests for current type.
        /// </summary>
        /// <param name="type">Current type.</param>
        private void RunTests(Type type)
        {
            var methods = type.GetMethods();
            var lists = FillLists(methods);
            var beforeClassList = lists.BeforeClassMethods;
            var constructor = type.GetConstructor(new Type[] { });

            try
            {
                Parallel.ForEach(beforeClassList, m => m?.Invoke(null, null));
            }
            catch (AggregateException exception)
            {
                throw new TestRunException(exception.Message, exception);
            }

            if (constructor == null)
            {
                throw new TestRunException("Type must have constructor without parameters!");
            }

            var beforeList = lists.BeforeMethods;
            var testsList = lists.TestMethods;
            var afterList = lists.AfterMethods;
            var afterClassList = lists.AfterClassMethods;

            try
            {
                Parallel.ForEach(testsList, (m) =>
                {
                    var instance = Activator.CreateInstance(type);
                    var test = new TestInfo(type, instance, m, beforeList, afterList);
                    test.Run();
                    TestInformation.Add(test);
                });
            }
            catch (AggregateException exception)
            {
                throw new TestRunException(exception.Message, exception);
            }

            try
            {
                Parallel.ForEach(afterClassList, m => m?.Invoke(null, null));
            }
            catch (AggregateException exception)
            {
                throw new TestRunException(exception.Message, exception);
            }
        }

        /// <summary>
        /// Method to fill lists of necessary methods.
        /// </summary>
        /// <param name="methods">Methods that are defined in current type.
        /// </param>
        /// <returns></returns>
        private ListsOfMethods FillLists(MethodInfo[] methods)
        {
            var lists = new ListsOfMethods();
            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes();
                foreach (var attribute in attributes)
                {
                    var typeOfAttribute = attribute.GetType();

                    if (!method.IsStatic && (typeOfAttribute == typeof(BeforeClassAttribute) || typeOfAttribute == typeof(AfterClassAttribute)))
                    {
                        throw new TestRunException("Methods with BeforeClassAttribute or AfterClassAttribute must be static!");
                    }

                    if (typeOfAttribute == typeof(BeforeClassAttribute))
                    {
                        lists.BeforeClassMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(BeforeAttribute))
                    {
                        lists.BeforeMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(TestAttribute))
                    {
                        lists.TestMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(AfterAttribute))
                    {
                        lists.AfterMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(AfterClassAttribute))
                    {
                        lists.AfterClassMethods.Add(method);
                    }
                }
            }

            return lists;
        }
    }
}
