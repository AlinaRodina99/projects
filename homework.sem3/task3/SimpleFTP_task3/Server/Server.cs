using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Server
{
    public class Server
    {
        private class ListOfDirsAndFiles<T> : List<T>
        {
            public ListOfDirsAndFiles(string[] dirs)
            {

            }

            public string Name { get; set; }
        }

        private TcpListener tcpListener;

        public Server(TcpListener tcpListener)
        {
            this.tcpListener = tcpListener;
        }

        public async void Task(string fileDirectory)
        {
            int size = 0;
            if (Directory.Exists(fileDirectory))
            {
                var dirs = Directory.GetDirectories(fileDirectory);
                var files = Directory.GetFiles(fileDirectory);
                var names = new string[dirs.Length + files.Length];
                for (var i = 0; i < names.Length + files.Length; ++i)
                {
                    var directoryInfo = new DirectoryInfo(dirs[i]);
                    names[i] = awdirectoryInfo.Name;
                    ++size;
                }
            }
        }

        #region MyRegion
        public async Task List(string dirName)
        {
            int size = 0;
            string name;
            bool isDir;
            if (Directory.Exists(dirName))
            {
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (var path in dirs)
                {
                    ++size;
                }
            }
        }


        #endregion
    }
}
