using System;

namespace MyNUnit
{
    class Program
    {
        static void Main(string[] _)
        {
            var testRunner = new TestRunner();
            testRunner.Execute($"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\..\\Tests");
            testRunner.PrintResult();
        }
    }
}
