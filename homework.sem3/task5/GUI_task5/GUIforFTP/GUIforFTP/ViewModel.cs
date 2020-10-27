using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Linq;
using System.Text.RegularExpressions;

namespace GUIforFTP
{
    /// <summary>
    /// Сlass that binds the model and view.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Client client;
        private int port;
        private bool isConnected = false;
        private static string path;
        private string pathToDownload;

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
        /// Property for the folder which client wants to use for downloadings.
        /// </summary>
        public string PathToDownload
        {
            get => pathToDownload; 
            set
            {
                pathToDownload = value;
                OnPropertyChanged();
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
                FolderList.Add(new ManagerElement(RootFolder, ManagerElement.TypeOfElement.Folder));
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
        public async Task OpenFolderOrLoad(ManagerElement listElement)
        {
            if (listElement != null && listElement.Type == ManagerElement.TypeOfElement.Folder)
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
                        ClearFolderList();

                        foreach (var (name, type) in currentFolderList)
                        {
                            if (type == "File")
                            {
                                FolderList.Add(new ManagerElement(SubstringEndOfPath(name), ManagerElement.TypeOfElement.File));
                            }
                            else
                            {
                                FolderList.Add(new ManagerElement(SubstringEndOfPath(name), ManagerElement.TypeOfElement.Folder));
                            }
                        }
                    }
                }
                catch (AggregateException exception)
                {
                    MessageBox.Show($"{ exception.Message }");
                }
            }
            else
            {
                if (listElement != null)
                {
                    await DownloadOneFile(listElement.ElementName);
                }
            }
        }

        /// <summary>
        /// Method to leave the current folder.
        /// </summary>
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
                FolderList.Add(new ManagerElement(RootFolder, ManagerElement.TypeOfElement.Folder, false));
                return;
            }

            string temp = SubstringBeginOfPath(CurrentFolder);

            if (temp.LastIndexOf('\\') >= 0)
            {
                CurrentFolder = SubstringBeginOfPath(temp);
                await OpenFolderOrLoad(new ManagerElement(SubstringEndOfPath(temp), ManagerElement.TypeOfElement.Folder));
            }
            else
            {
                CurrentFolder = temp;
                await OpenFolderOrLoad(new ManagerElement(CurrentFolder, ManagerElement.TypeOfElement.Folder));
            }
        }

        /// <summary>
        /// Method to download one file in current folder.
        /// </summary>
        /// <param name="file">File that client wants to download.</param>
        public async Task DownloadOneFile(string file)
        {
            if (PathToDownload == null)
            {
                MessageBox.Show("You must write path for downloads!");
                return;
            }

            if (!Directory.Exists(PathToDownload))
            {
                MessageBox.Show("Such path does not exist or contains invalid chars!");
                PathToDownload = null;
                return;
            }

            var newFile = new ManagerElement(file, ManagerElement.TypeOfElement.File, true);
            DownloadingFolderList.Add(newFile);

            await client.Get(SubstringBeginOfPath(path) + $"\\{ CurrentFolder }" + $"\\{ file }", PathToDownload + $"\\{ file }");

            DownloadingFolderList.Remove(newFile);
            DownloadingFolderList.Add(new ManagerElement(file, ManagerElement.TypeOfElement.File, false));
            await OpenFolderOrLoad(new ManagerElement(CurrentFolder, ManagerElement.TypeOfElement.Folder));
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
                return;
            }

            if (PathToDownload == null)
            {
                MessageBox.Show("You must write path for downloads!");
                return;
            }

            for (var i = 0; i < FolderList.Count; ++i)
            {
                if (FolderList[i].Type == ManagerElement.TypeOfElement.File)
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
            /// <summary>
            /// Property for the name of file or folder.
            /// </summary>
            public string ElementName { get; set; }

            /// <summary>
            /// Property to know whether element is folder or file.
            /// </summary>
            public TypeOfElement Type { get; set; }

            /// <summary>
            /// Types of manager element.
            /// </summary>
            public enum TypeOfElement
            {
                File,
                Folder
            }

            /// <summary>
            /// Path to the icon for folder or file to draw it on window.
            /// </summary>
            public string ImagePath { get; set; }

            /// <summary>
            /// Property to know whether file is downloading or it has already been downloaded.
            /// </summary>
            public string CurrentDownloadingProcess { get; set; }

            public ManagerElement(string name, TypeOfElement type, bool isDownloading = false)
            {
                ElementName = name;
                Type = type;
                var currentPath = path.Substring(0, path.LastIndexOf('\\'));
                CurrentDownloadingProcess = isDownloading ? $"{ currentPath }\\Icons\\downloading.jpg" : $"{ currentPath }\\Icons\\downloaded.jpg";

                if (type == TypeOfElement.File)
                {
                    ImagePath = $"{ currentPath }\\Icons\\file.jpg";
                }
                else
                {
                    ImagePath = $"{ currentPath }\\Icons\\folder.jpg";
                }
            }
        }
    }
}
