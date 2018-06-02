using HotelsAndUsers.Core;
using HotelsAndUsers.Core.Interfaces;
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

namespace BookinghamNew.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow();
            searchWindow.Show();
            this.Close();
        }

        private void ButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            var logInWindow = new LogInWindow();
            logInWindow.Show();
            Close();
        }
    }
}
