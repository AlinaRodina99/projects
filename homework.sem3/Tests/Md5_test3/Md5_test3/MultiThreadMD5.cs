using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Md5_test3
{
    public class MultiThreadMD5
    {
        private string directory;
        private MD5 hash;
        private AutoResetEvent readyResult = new AutoResetEvent(false);
        private AutoResetEvent setResult = new AutoResetEvent(false);
        private object locker = new object();

        public MultiThreadMD5(string directory)
        {
            this.directory = directory;
        }

        public string GetMD5Hash()
        {
            hash = MD5.Create();
            var data = hash.ComputeHash(Encoding.UTF8.GetBytes(directory));
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; ++i)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public string GetMD5HashForDirectory()
        {
            readyResult.WaitOne();
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException();
            }

            hash = MD5.Create();
            var nameOfDirectory = new DirectoryInfo(directory);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(nameOfDirectory);
            var files = Directory.GetFiles(directory);
            Array.Sort(files);
            lock (locker)
            {
                foreach (var file in files)
                {
                    stringBuilder.Append(GetMD5Hash());
                }
            }

            var dirs = Directory.GetDirectories(directory);
            Array.Sort(dirs);
            lock (locker)
            {
                foreach (var dir in dirs)
                {
                    stringBuilder.Append(GetMD5Hash());
                }
            }

            setResult.Set();
            return stringBuilder.ToString();
        }
    }
}
