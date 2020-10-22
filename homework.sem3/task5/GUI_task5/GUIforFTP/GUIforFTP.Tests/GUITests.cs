using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerApp;

namespace GUIforFTP.Tests
{
    [TestClass]
    public class GUITests
    {
        private int port = 8888;
        private Server server;
        private ViewModel viewModel;
        private readonly string path = Directory.GetCurrentDirectory() + "\\TestFiles";

        [TestInitialize]
        public void Initialize()
        {
            server = new Server(port);
            viewModel = new ViewModel(path);
            viewModel.ClearFolderList();
            viewModel.ClearDownloadingList();
            Task.Run(async () => await server.ServerWork());
            viewModel.Connect();
        }

        [TestMethod]
        public void CheckThatRootFolderAppearedAfterConnectionTest()
        {
            Assert.AreEqual("TestFiles", viewModel.FolderList[0].ElementName);
            Assert.IsTrue(viewModel.FolderList[0].Type);
        }

        [TestMethod]
        public void TryOpenRootFolderTest()
        {
            viewModel.OpenFolder(new ViewModel.ManagerElement("TestFiles", true, false)).Wait();
            Assert.AreEqual("Directory", viewModel.FolderList[4].ElementName);
            Assert.AreEqual("CLR_via_CSharp_3rd_Edition_Jeffrey_Richter.pdf", viewModel.FolderList[0].ElementName);
            Assert.AreEqual("demidovich_sbornik.pdf", viewModel.FolderList[1].ElementName);
            Assert.AreEqual("group_theory.pdf", viewModel.FolderList[2].ElementName);
            Assert.AreEqual("test.txt", viewModel.FolderList[3].ElementName);
            Assert.IsTrue(viewModel.FolderList[4].Type);
            Assert.IsFalse(viewModel.FolderList[0].Type);
            Assert.IsFalse(viewModel.FolderList[1].Type);
            Assert.IsFalse(viewModel.FolderList[2].Type);
            Assert.IsFalse(viewModel.FolderList[3].Type);
        }

        [TestMethod]
        public void GoOutOfTheRootFolderTest()
        {
            viewModel.OpenFolder(new ViewModel.ManagerElement("TestFiles", true, false)).Wait();
            viewModel.Back().Wait();
            Assert.AreEqual("TestFiles", viewModel.FolderList[0].ElementName);
        }

        [TestMethod]
        public void OpenFolderInRootFolderTest()
        {
            viewModel.OpenFolder(new ViewModel.ManagerElement("TestFiles", true, false)).Wait();
            viewModel.OpenFolder(new ViewModel.ManagerElement("Directory", true, false)).Wait();
            Assert.AreEqual("test2.txt", viewModel.FolderList[0].ElementName);
            Assert.AreEqual("NewDirectory", viewModel.FolderList[1].ElementName);
            Assert.IsTrue(viewModel.FolderList[1].Type);
            Assert.IsFalse(viewModel.FolderList[0].Type);
        }

        [TestMethod]
        public void BackToRootFolderTest()
        {
            viewModel.OpenFolder(new ViewModel.ManagerElement("TestFiles", true, false)).Wait();
            viewModel.OpenFolder(new ViewModel.ManagerElement("Directory", true, false)).Wait();
            viewModel.Back().Wait();
            Assert.AreEqual("Directory", viewModel.FolderList[4].ElementName);
            Assert.AreEqual("CLR_via_CSharp_3rd_Edition_Jeffrey_Richter.pdf", viewModel.FolderList[0].ElementName);
            Assert.AreEqual("demidovich_sbornik.pdf", viewModel.FolderList[1].ElementName);
            Assert.AreEqual("group_theory.pdf", viewModel.FolderList[2].ElementName);
            Assert.AreEqual("test.txt", viewModel.FolderList[3].ElementName);
            Assert.IsTrue(viewModel.FolderList[4].Type);
            Assert.IsFalse(viewModel.FolderList[0].Type);
            Assert.IsFalse(viewModel.FolderList[1].Type);
            Assert.IsFalse(viewModel.FolderList[2].Type);
            Assert.IsFalse(viewModel.FolderList[3].Type);
        }

        [TestMethod]
        public void DownloadOneFileTest()
        {
            viewModel.OpenFolder(new ViewModel.ManagerElement("TestFiles", true, false)).Wait();
            viewModel.FolderForDownloading = "Downloaded_file";
            viewModel.FileForDownloading = "test.txt";
            viewModel.DownloadOneFile("test.txt").Wait();
            Assert.AreEqual("Downloaded_file", viewModel.FolderList[5].ElementName);
            Assert.IsTrue(viewModel.FolderList[5].Type);
            viewModel.OpenFolder(new ViewModel.ManagerElement("Downloaded_file", true, false)).Wait();
            Assert.AreEqual("test.txt", viewModel.FolderList[0].ElementName);
        }

        [TestMethod]
        public void DownloadAllFilesTest()
        {
            viewModel.OpenFolder(new ViewModel.ManagerElement("TestFiles", true, false)).Wait();
            viewModel.FolderForDownloading = "My_downloads";
            viewModel.DownloadAllFilesInFolder().Wait();
            Assert.AreEqual("My_downloads", viewModel.FolderList[5].ElementName);
            Assert.IsTrue(viewModel.FolderList[5].Type);
            viewModel.OpenFolder(new ViewModel.ManagerElement("My_downloads", true, false)).Wait();
            Assert.AreEqual("CLR_via_CSharp_3rd_Edition_Jeffrey_Richter.pdf", viewModel.FolderList[0].ElementName);
            Assert.AreEqual("demidovich_sbornik.pdf", viewModel.FolderList[1].ElementName);
            Assert.AreEqual("group_theory.pdf", viewModel.FolderList[2].ElementName);
            Assert.AreEqual("test.txt", viewModel.FolderList[3].ElementName);
        }
    }
}
