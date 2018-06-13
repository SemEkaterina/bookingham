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
using System.Windows.Shapes;

namespace BookinghamNew.UI
{
    /// <summary>
    /// Логика взаимодействия для SaveChangesWindow.xaml
    /// </summary>
    public partial class SaveChangesWindow : Window
    {
        public SaveChangesWindow()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonOK_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                ButtonCancel_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
