using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.IO;

namespace GUIforFTP
{
    public class ViewModel 
    {
        private Client client;
        private int port;
        private bool isConnected = false;
        private static string path;

        private string SubstringEndOfPath(string path) => path.Substring(path.LastIndexOf('\\') + 1);

        private string SubstringBeginOfPath(string path) => path.Substring(0, path.LastIndexOf('\\'));

        public ViewModel(string path)
        {
            port = 8888;
            ServerAddress = "localhost";
            FolderList = new ObservableCollection<ManagerElement>();
            DownloadingFolderList = new ObservableCollection<ManagerElement>();
            RootFolder = SubstringEndOfPath(path);
            isConnected = false;
            ViewModel.path = path;
        }

        public string Port
        {
            get => Convert.ToString(port);
            set => port = Convert.ToInt32(value);
        }

        public string FileForDownloading { get; set; }

        public string FolderForDownloading { get; set; }

        public string ServerAddress { get; set; }

        public ObservableCollection<ManagerElement> FolderList { get; set; }

        public ObservableCollection<ManagerElement> DownloadingFolderList { get; set; }

        public string RootFolder { get; set; }

        public string MessageForUser { get; set; }

        public string CurrentFolder { get; set; }

        public void Connect()
        {
            if (isConnected)
            {
                MessageForUser = "You have already connected to the server.";
                return;
            }

            try
            {
                client = new Client(port, ServerAddress);
                isConnected = true;
                FolderList.Add(new ManagerElement(RootFolder, true));
            }
            catch (AggregateException exception)
            {
                MessageForUser = $"Socket exception was occured: { exception.Message }";
            }
        }

        public async Task OpenFolder(ManagerElement listElement)
        {
            if (listElement != null && listElement.Type)
            {
                if (CurrentFolder == null)
                {
                    CurrentFolder = RootFolder;
                }
                else if (RootFolder != listElement.ElementName)
                {
                    if (CurrentFolder == RootFolder)
                    {
                        CurrentFolder = RootFolder + $"\\{ listElement.ElementName }";
                    }
                    else
                    {
                        CurrentFolder += $"\\{ listElement.ElementName }";
                    }
                }
                else
                {
                    CurrentFolder = RootFolder;
                }

                try
                {
                    var currentFolderList = await client.List(Directory.GetCurrentDirectory() + $"\\{ CurrentFolder }");

                    if (currentFolderList != null)
                    {
                        FolderList.Clear();

                        foreach (var (name, type) in currentFolderList)
                        {
                            FolderList.Add(new ManagerElement(SubstringEndOfPath(name), Convert.ToBoolean(type)));
                        }
                    }
                }
                catch (AggregateException exception)
                {
                    MessageForUser = $"{ exception.Message }";
                }
            }

            return;
        }

        public async Task Back()
        {
            if (!isConnected)
            {
                MessageForUser = "You must connect before clicking on Back button.";
            }

            if (CurrentFolder == null)
            {
                MessageForUser = "You can not go back out of the root folder.";
                return;
            }

            if (CurrentFolder == RootFolder)
            {
                FolderList.Clear();
                FolderList.Add(new ManagerElement(RootFolder, true, false));
                return;
            }

            string temp = SubstringBeginOfPath(CurrentFolder);

            if (temp.LastIndexOf('\\') >= 0)
            {
                CurrentFolder = SubstringBeginOfPath(temp);
                await OpenFolder(new ManagerElement(SubstringEndOfPath(temp), true));
            }
            else
            {
                CurrentFolder = temp;
                await OpenFolder(new ManagerElement(CurrentFolder, true));
            }
        }

        public async Task DownloadOneFile(string file)
        {
            if (!isConnected)
            {
                MessageForUser = "You must connect before clicking on Download button.";
                return;
            }

            if (CurrentFolder == null)
            {
                MessageForUser = "You must open root folder before clicking on Download button.";
                return;
            }

            if (file == "" || file == null)
            {
                MessageForUser = "You must enter the file before clicking on Download button.";
                return;
            }

            var newPath = SubstringBeginOfPath(path) + $"\\{ FolderForDownloading }\\";
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            var newFile = new ManagerElement(file, false, true);
            DownloadingFolderList.Add(newFile);

            await client.Get(SubstringBeginOfPath(path) + $"\\{ CurrentFolder }" + $"\\{ file }", newPath + $"{ file }");

            DownloadingFolderList.Remove(newFile);
            DownloadingFolderList.Add(new ManagerElement(file, false, false));
        }

        public async Task DownloadAllFilesInFolder()
        {
            if (!isConnected)
            {
                MessageForUser = "You must connect before clicking on DownloadAll button.";
                return;
            }

            if (CurrentFolder == null)
            {
                MessageForUser = "You must open root folder before clicking on DownloadAll button.";
            }

            foreach (var element in FolderList)
            {
                if (!element.Type)
                {
                    await DownloadOneFile(element.ElementName);
                }
            }
        }

        public class ManagerElement 
        {
            public string ElementName { get; set;}

            public bool Type { get; set; }

            public string ImagePath { get; set; }

            public string CurrentDownloadingProcess { get; set; }

            public ManagerElement(string name, bool type, bool isDownloading = false)
            {
                ElementName = name;
                Type = type;
                var currentPath = path.Substring(0, path.LastIndexOf('\\'));
                CurrentDownloadingProcess = isDownloading ? $"{ currentPath }\\Icons\\downloading.jpg" : $"{ currentPath }\\Icons\\downloaded.jpg";
                ImagePath = type ? $"{ currentPath }\\Icons\\folder.jpg" : $"{ currentPath }\\Icons\\file.jpg";
            }
        }
    }
}
