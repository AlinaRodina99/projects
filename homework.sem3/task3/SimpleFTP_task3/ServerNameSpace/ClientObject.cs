using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerNameSpace
{
    public class ClientObject
    {
        private readonly TcpClient tcpClient;

        public ClientObject(TcpClient tcpClient)                                
        {
            this.tcpClient = tcpClient;
        }

        private byte[] GetMessage(string pathToDirectory)
        {
            var stringBuilder = new StringBuilder();
            string message;
            if (Directory.Exists(pathToDirectory))
            {
                var directories = Directory.GetDirectories(pathToDirectory);
                var files = Directory.GetFiles(pathToDirectory);
                var dirsAndFiles = new string[directories.Length + files.Length];
                directories.CopyTo(dirsAndFiles, 0);
                files.CopyTo(dirsAndFiles, directories.Length);
                stringBuilder.Append(directories.Length + files.Length);
                foreach (var dirOrFile in dirsAndFiles)
                {
                    var attributes = File.GetAttributes(dirOrFile);
                    if (attributes.HasFlag(FileAttributes.Directory))
                    {
                        var dirInfo = new DirectoryInfo(dirOrFile);
                        var dirName = dirInfo.Name;
                        stringBuilder.Append(" " + dirName + " true");
                    }

                    var fileInfo = new FileInfo(dirOrFile);
                    var fileName = fileInfo.Name;
                    stringBuilder.Append(" " + fileName + " false");
                }

                message = stringBuilder.ToString();
                var data = Encoding.Unicode.GetBytes(message);
                return data;
            }

            message = "-1";
            var currData = Encoding.Unicode.GetBytes(message);
            return currData;
        }

        public async Task List(string pathToCurrentDirectory)
        {
            NetworkStream stream = null;
            try
            {
                stream = tcpClient.GetStream();
                var data = GetMessage(pathToCurrentDirectory);
                await stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                stream?.Close();
                tcpClient?.Close();
            }
        }

        public async Task Get(byte[] pathToFile)
        {
            NetworkStream stream = null;
            var stringBuilder = new StringBuilder();
            var data = new byte[256];
            int bytes = 0;
            bytes = stream.Read()
            try
            {
                string message;
                if (File.Exists(pathToFile))
                {
                    var fileInfo = new FileInfo(pathToFile);
                    stringBuilder.Append(fileInfo.Length);
                    stream = tcpClient.GetStream();
                    using (var streamReader = new StreamReader(pathToFile))
                    {
                        stringBuilder.Append(streamReader.ReadToEnd());
                    }

                    message = stringBuilder.ToString();
                    var data = Encoding.Unicode.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                }

                message = "-1";
                var currData = Encoding.Unicode.GetBytes(message);
                await stream.WriteAsync(currData, 0, currData.Length);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                stream?.Close();
                tcpClient?.Close();
            }
        }

        public async Task Process(string path)
        {
            if (path.Remove(0, 1) == "1")
            {
                await List(path);
            }

            await Get(path);
        }
    }
}
