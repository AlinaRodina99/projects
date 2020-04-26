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
            var path = Directory.GetCurrentDirectory() + "\\TestFiles";

            var model = new ViewModel(path);

            DataContext = model;

            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e) => (DataContext as ViewModel).Connect();

        private async void ChoosenElement(object sender, SelectionChangedEventArgs e) => await (DataContext as ViewModel).OpenFolder((ManagerElement)folderList.SelectedItem);

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void folderList_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
