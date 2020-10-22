using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace GUIforFTP
{
    /// <summary>
    /// Сlass that links the model and view.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Client client;
        private int port;
        private bool isConnected = false;
        private static string path;
        private string fileForDownloading;
        private string folderForDownloading;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Auxiliary function that cuts off the end of the path after the last \\.
        /// </summary>
        private string SubstringEndOfPath(string path) => path.Substring(path.LastIndexOf('\\') + 1);

        /// <summary>
        /// Auxiliary function that cuts off the end of the path before the last \\.
        /// </summary>
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

        /// <summary>
        /// Property for the port of the client.
        /// </summary>
        public string Port
        {
            get => Convert.ToString(port);
            set => port = Convert.ToInt32(value);
        }

        /// <summary>
        /// Property for the file which client wants to download.
        /// </summary>
        public string FileForDownloading
        {
            get { return fileForDownloading; }
            set
            {
                fileForDownloading = value;
                OnPropertyChanged("FileForDownloading");
            }
        }

        /// <summary>
        /// Property for the folder which client wants to use for downloadings.
        /// </summary>
        public string FolderForDownloading
        {
            get { return folderForDownloading; }
            set
            {
                folderForDownloading = value;
                OnPropertyChanged("FolderForDownloading");
            }
        }

        /// <summary>
        /// Property for IPAdress.
        /// </summary>
        public string ServerAddress { get; set; }

        /// <summary>
        /// Property for the files and folders in current folder.
        /// </summary>
        public ObservableCollection<ManagerElement> FolderList { get; set; }

        /// <summary>
        /// Property for files which are downloading or they have already been downloaded.
        /// </summary>
        public ObservableCollection<ManagerElement> DownloadingFolderList { get; set; }

        public string RootFolder { get; set; }

        public string CurrentFolder { get; set; }

        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        
        /// <summary>
        /// Method to connect with server.
        /// </summary>
        public void Connect()
        {
            if (isConnected)
            {
                MessageBox.Show("You have already connected to the server.");
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
                MessageBox.Show($"Socket exception was occured: { exception.Message }");
            }
        }

        /// <summary>
        /// Method to open folder in folder manager.
        /// </summary>
        /// <param name="listElement">Element in folder manager: file or folder</param>
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
                    MessageBox.Show($"{ exception.Message }");
                }
            }

            return;
        }

        /// <summary>
        /// Method to leave the current folder.
        /// </summary>
        /// <returns></returns>
        public async Task Back()
        {
            if (!isConnected)
            {
                MessageBox.Show("You must connect before clicking on Back button.");
            }

            if (CurrentFolder == null)
            {
                MessageBox.Show("You can not go back out of the root folder.");
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

        /// <summary>
        /// Method to download one file in current folder.
        /// </summary>
        /// <param name="file">File that client wants to download.</param>
        public async Task DownloadOneFile(string file)
        {
            if (!isConnected)
            {
                MessageBox.Show("You must connect before clicking on Download button.");
                return;
            }

            if (CurrentFolder == null)
            {
                MessageBox.Show("You must open root folder before clicking on Download button.");
                return;
            }

            if (!File.Exists(SubstringBeginOfPath(path) +  "\\" + CurrentFolder + "\\" + file))
            {
                MessageBox.Show("Such file does not exist in the current folder. Try again.");
                FileForDownloading = null;
                return;
            }

            if (file == "" || file == null)
            {
                MessageBox.Show("You must enter the file before clicking on Download button.");
                return;
            }

            var newPath = CurrentFolder + $"\\{ FolderForDownloading }\\";
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            var newFile = new ManagerElement(file, false, true);
            DownloadingFolderList.Add(newFile);

            await client.Get(SubstringBeginOfPath(path) + $"\\{ CurrentFolder }" + $"\\{ file }", newPath + $"{ file }");

            DownloadingFolderList.Remove(newFile);
            DownloadingFolderList.Add(new ManagerElement(file, false, false));
            FileForDownloading = null;
            await OpenFolder(new ManagerElement(CurrentFolder, true));
        }

        /// <summary>
        /// Method to download all files in current folder.
        /// </summary>
        public async Task DownloadAllFilesInFolder()
        {
            if (!isConnected)
            {
                MessageBox.Show("You must connect before clicking on DownloadAll button.");
                return;
            }

            if (CurrentFolder == null)
            {
                MessageBox.Show("You must open root folder before clicking on DownloadAll button.");
            }

            for (var i = 0; i < FolderList.Count; ++i)
            {
                if (!FolderList[i].Type)
                {
                    await DownloadOneFile(FolderList[i].ElementName);
                }
            }
        }

        /// <summary>
        /// Method to clear window with downloadings.
        /// </summary>
        public void ClearDownloadingList() => DownloadingFolderList.Clear();

        /// <summary>
        /// Method to clear current folder for the tests.
        /// </summary>
        public void ClearFolderList() => FolderList.Clear();

        /// <summary>
        /// Class that represents manager element: file or folder.
        /// </summary>
        public class ManagerElement 
        {
            public string ElementName { get; set;}

            /// <summary>
            /// Property to know whether element is folder or not. True-folder, false-file.
            /// </summary>
            public bool Type { get; set; }

            public string ImagePath { get; set; }

            /// <summary>
            /// Property to know whether file is downloading or it has already been downloaded.
            /// </summary>
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
