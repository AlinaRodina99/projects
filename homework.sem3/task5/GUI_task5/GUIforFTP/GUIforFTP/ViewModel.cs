using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Net.Sockets;
using System.IO;

namespace GUIforFTP
{
    public class ViewModel 
    {
        private Client client;
        private int port;
        private bool isConnected;

        private string SubstringPath(string path) => path.Substring(path.LastIndexOf('\\') + 1);

        public ViewModel(string path)
        {
            port = 8888;
            ServerAddress = "localhost";
            FolderList = new ObservableCollection<ManagerElement>();
            RootFolder = SubstringPath(path);
            isConnected = false;
        }

        public string Port
        {
            get => Convert.ToString(port);
            set => port = Convert.ToInt32(value);
        }

        public string ServerAddress { get; set; }

        public ObservableCollection<ManagerElement> FolderList { get; set; }

        public string RootFolder { get; set; }

        public string MessageForUser { get; set; }

        public string CurrentFolder { get; set; }

        public void Connect()
        {
            if (isConnected)
            {
                MessageForUser = "You must enter port and server address before connecting.";
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
                MessageForUser = $"{ exception.Message }";
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
                else
                {
                    CurrentFolder = RootFolder + $"\\{ listElement.ElementName }";
                }

                try
                {
                    var currentFolderList = await client.List(Directory.GetCurrentDirectory() + $"\\{CurrentFolder}");

                    if (currentFolderList != null)
                    {
                        FolderList.Clear();

                        foreach (var (name, type) in currentFolderList)
                        {
                            FolderList.Add(new ManagerElement(SubstringPath(name), Convert.ToBoolean(type)));
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

        }

        public class ManagerElement 
        {
            public string ElementName { get; set;}

            public bool Type { get; set; }

            public string ImagePath { get; }

            public ManagerElement(string name, bool type)
            {
                ElementName = name;
                Type = type;

                ImagePath = type ? $"{ Directory.GetCurrentDirectory() }\\Icons\\folder.png" : $"{ Directory.GetCurrentDirectory() }\\Icons\\file.png";
            }
        }
    }
}
