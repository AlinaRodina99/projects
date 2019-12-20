using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Md5_test3
{
    /// <summary>
    /// Class for implementing one thread MD5
    /// </summary>
    public class OneThreadMD5
    {
        private MD5 hash;
        private string directory;

        public OneThreadMD5(string directory)
        {
            this.directory = directory;
        }

        public string GetMd5Hash()
        {
            hash = MD5.Create();
            var data = hash.ComputeHash(Encoding.UTF8.GetBytes(directory));
            var stringBuilder = new StringBuilder();
            for (var i  = 0; i < data.Length; ++i)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public string GetMD5HashForDirectory()
        {
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
            foreach (var file in files)
            {
                stringBuilder.Append(GetMd5Hash());
            }

            var dirs = Directory.GetDirectories(directory);
            Array.Sort(dirs);
            foreach (var dir in dirs)
            {
                stringBuilder.Append(GetMd5Hash());
            }

            return stringBuilder.ToString();
        }
    }
}
