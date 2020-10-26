using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new ViewModel();

            DataContext = viewModel;
        }
        private void boxForFirstNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            (DataContext as ViewModel).ChangedFirstNumber();
        }

        private void boxForSecondNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            (DataContext as ViewModel).ChangedSecondNumber();
        }
    }
}
