using HotelsAndUsers.Core;
using HotelsAndUsers.Core.Model;
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
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Guest Guest { get; set; }

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_repo.CheckGuest(textBoxEmail.Text, passwordBoxPassword.Password) == 1)
            {
                Guest = _repo.Authorize(textBoxEmail.Text, passwordBoxPassword.Password);
                ///////////////////////открытие профиля отеля или гостя
                var searchWindow = new SearchWindow(Guest);
                searchWindow.Show();
                this.Close();
                Close();
            }
            else if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Email cannot be empty", "Error");
                textBoxEmail.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(passwordBoxPassword.Password))
            {
                MessageBox.Show("Password cannot be empty", "Error");
                passwordBoxPassword.Focus();
                return;
            }
            else if (_repo.CheckGuest(textBoxEmail.Text, passwordBoxPassword.Password) == 0)
            {
                MessageBox.Show("Incorrect login/password");
            }
            else
            {
                MessageBox.Show("There is no users in database:(", "Error");
                return;
            }
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegistrationWindow();
            registerWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
