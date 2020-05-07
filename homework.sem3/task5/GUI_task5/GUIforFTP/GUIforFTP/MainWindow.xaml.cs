using System.Windows;
using System.Windows.Controls;
using System.IO;
using static GUIforFTP.ViewModel;

namespace GUIforFTP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var path = Directory.GetCurrentDirectory() + "\\TestFiles";

            var model = new ViewModel(path);


            DataContext = model;
        }

        private void Connect_Click(object sender, RoutedEventArgs e) => (DataContext as ViewModel).Connect();

        private async void ChoosenElement(object sender, SelectionChangedEventArgs e) => await (DataContext as ViewModel).OpenFolder((ManagerElement)folderList.SelectedItem);

        private async void Back_Click(object sender, RoutedEventArgs e) => await (DataContext as ViewModel).Back();

        private async void Download_Click(object sender, RoutedEventArgs e) => await (DataContext as ViewModel).DownloadOneFile(boxForEnteringFolderToDownloadFiles.Text);
    }
}
