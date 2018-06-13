using HotelsAndUsers.Core;
using HotelsAndUsers.Core.Helpers;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Guest Guest { get; set; }

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Password cannot be empty", "Error");
                textBoxLogin.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Name cannot be empty", "Error");
                textBoxName.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Surname cannot be empty", "Error");
                textBoxSurname.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxPassword.Password))
            {
                MessageBox.Show("Password cannot be empty", "Error");
                textBoxPassword.Focus();
                return;
            }

            Guest guest;
            Hotel hotel;
             _repo.Authorize(textBoxLogin.Text, Hash.GetHash(textBoxPassword.Password), out guest, out hotel);
            if (guest != null)
            {
                MessageBox.Show("This user has been already created", "Error");
                return;
            }               
                if (Guest == null)
                {
                    Guest = new Guest
                    {
                        Name = textBoxName.Text,
                        Surname = textBoxSurname.Text,
                        Email = textBoxLogin.Text,
                        Password = textBoxPassword.Password,
                    };
                    _repo.RegisterGuest(Guest);
                    LogInWindow logInWindow = new LogInWindow();
                    logInWindow.Show();
                    Close();
                }           
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
