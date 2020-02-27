using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerNameSpace
{
    public class ClientObject
    {
        public async Task List(string path, StreamWriter writer)
        {
            if (!Directory.Exists(path))
            {
                await writer.WriteLineAsync("-1");
            }

            var files = Directory.GetFiles(path);
            var dirs = Directory.GetDirectories(path);

            await writer.WriteLineAsync($"{files.Length + dirs.Length}");

            foreach (var file in files)
            {
                await writer.WriteLineAsync(file);
                await writer.WriteLineAsync("false");
            }

            foreach (var dir in dirs)
            {
                await writer.WriteLineAsync(dir);
                await writer.WriteLineAsync("true");
            }
        }

        public async Task Get(string path, StreamWriter writer)
        {
            if (!File.Exists(path))
            {
                await writer.WriteLineAsync("-1");
            }

            await writer.WriteLineAsync($"{new FileInfo(path).Length}");

        }
    }
}
