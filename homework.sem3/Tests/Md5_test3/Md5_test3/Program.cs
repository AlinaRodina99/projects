using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace Md5_test3
{
    class Program
    {
        private static AutoResetEvent readyResult = new AutoResetEvent(false);
        private static AutoResetEvent setResult = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            Console.WriteLine("Enter path to directory: ");
            var directory = Environment.GetCommandLineArgs();
            var oneThreadMD5 = new OneThreadMD5(directory.ToString());
            stopWatch.Start();
            oneThreadMD5.GetMD5HashForDirectory();
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            stopWatch.Start();
            var multiThread = new MultiThreadMD5(directory.ToString());
            var thread = new Thread(() => multiThread.GetMD5HashForDirectory());
            thread.Start();
            readyResult.Set();
            setResult.WaitOne();
            Thread.Sleep(10);
            stopWatch.Stop();
        }
    }
}
