using Attributes;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;
using MyNUnit;
using System;
using System.Threading.Tasks;

namespace MyNUnit_task4
{
    public static class TestRunner
    {
        public static ConcurrentBag<TestInfo> testInformation = new ConcurrentBag<TestInfo>();

        public static void PrintResult()
        {
            foreach (var test in testInformation)
            {
                if (test.IsIgnored)
                {
                    Console.WriteLine($"Test was ignored because {test.IgnoreReason}");
                }

                if (test.IsPassed)
                {
                    Console.WriteLine($"Test passed, time of running {test.runningTime}");
                }
                else
                {
                    Console.WriteLine($"Test failed, time of running {test.runningTime}");
                }
            }
        }

        public static void Run(string path)
        {
            var assemblies = new List<Assembly>();
            var files = Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories);
            var listOfTypes = new List<Type>();

            foreach (var file in files)
            {
                assemblies.Add(Assembly.LoadFrom(file));
            }

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    listOfTypes.Add(type);
                }
            }

            Parallel.ForEach(listOfTypes, t => RunTests(t));
        }


        private static void RunTests(Type type)
        {
            var constructor = type.GetConstructor(new Type[] { });
            
            if (constructor == null)
            {
                throw new ArgumentException("Type must have constructor without parameters!");
            }

            type = constructor.Invoke(null) as Type;
            var methods = type.GetMethods();
            var lists = FillLists(methods);
            var beforeClassList = lists.beforeClassMethods;
            var beforeList = lists.beforeMethods;
            var testsList = lists.testMethods;
            var afterList = lists.afterMethods;
            var afterClassList = lists.afterClassMethods;

            Parallel.ForEach(beforeClassList, m => m?.Invoke(null, null));
            Parallel.ForEach(testsList, (m) =>
            {
                var test = new TestInfo(type, m, beforeList, afterList);
                testInformation.Add(test);
            });
            Parallel.ForEach(afterClassList, m => m?.Invoke(null, null));
        }

        private static ListsOfMethods FillLists(MethodInfo[] methods)
        {
            var lists = new ListsOfMethods();
            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes();
                foreach (var attribute in attributes)
                {
                    var typeOfAttribute = attribute.GetType();

                    if (typeOfAttribute != typeof(MyNUnitAttribute))
                    {
                        throw new TestRunException("Attribute must be type of MyNUnitAttribute!");
                    }

                    if (typeOfAttribute == typeof(BeforeClassAttribute))
                    {
                        lists.beforeClassMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(BeforeAttribute))
                    {
                        lists.beforeMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(TestAttribute))
                    {
                        lists.testMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(AfterAttribute))
                    {
                        lists.afterMethods.Add(method);
                    }

                    if (typeOfAttribute == typeof(AfterClassAttribute))
                    {
                        lists.afterClassMethods.Add(method);
                    }
                }
            }

            return lists;
        }
    }
}
