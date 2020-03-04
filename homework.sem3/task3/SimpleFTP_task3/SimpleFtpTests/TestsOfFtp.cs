using NUnit.Framework;
using ClientNameSpace;
using ServerNameSpace;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Threading;

namespace SimpleFtpTests
{
    [TestFixture]
    public class TestsOfFtp
    {
        [SetUp]
        public void Setup()
        {
            Thread.Sleep(1000);
            server = new Server(8888);
            server.ServerWork();
            Thread.Sleep(1000);
            client = new Client(8888);
        }


        [Test]
        public void GetContentTest()
        {
            var responce = client.Get($"{path}/test.txt").Result;
            var text = File.ReadAllText($"{path}/test.txt");
            Assert.AreEqual(text, Encoding.Default.GetString(responce.Item2));
            Assert.AreEqual(Encoding.Default.GetBytes(text), responce.Item2);
            server.Stop();
        }

        [Test]
        public void GetSizeTest()
        {
            var content = client.Get($"{path}/test.txt").Result;
            Assert.AreEqual(1357, content.Item1);
            server.Stop();
        }

        [Test]
        public void ListFromWrongPath()
        {
            var responce = client.List("path").Result;
            Assert.AreEqual("-1", responce);
            server.Stop();
        }

        [Test]
        public void TaskGetFromWrongPath()
        {
            var responce = client.Get("path").Result;
            Assert.AreEqual(-1, responce.Item1);
            Assert.IsNull(responce.Item2);
            server.Stop();
        }

        [Test]
        public void ListTest()
        {
            var list = client.List(path).Result;
            var splittedResponce = list.Split();
            Assert.AreEqual(11, splittedResponce.Length);
            Assert.AreEqual("5", splittedResponce[0]);
            Assert.AreEqual($"{path}\\CLR_via_CSharp_3rd_Edition_Jeffrey_Richter.pdf", splittedResponce[1]); 
            Assert.AreEqual("false", splittedResponce[2]);
            Assert.AreEqual($"{path}\\demidovich_sbornik.pdf", splittedResponce[3]);
            Assert.AreEqual("false", splittedResponce[4]);
            Assert.AreEqual($"{path}\\group_theory.pdf", splittedResponce[5]);
            Assert.AreEqual("false", splittedResponce[6]);
            Assert.AreEqual($"{path}\\test.txt", splittedResponce[7]);
            Assert.AreEqual("false", splittedResponce[8]);
            Assert.AreEqual($"{path}\\Directory", splittedResponce[9]);
            Assert.AreEqual("true", splittedResponce[10]);
            server.Stop();

        }

        private Client client;
        private Server server;
        private static string path = "../../../../SimpleFtpTests/TestFiles";
    }
}