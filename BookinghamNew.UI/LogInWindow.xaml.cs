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
            if (_repo.CheckGuest(textBoxLogin.Text, textBoxPassword.Text) == 1)
            {
                Guest = _repo.Authorize(textBoxLogin.Text, textBoxPassword.Text);
                ///////////////////////
                Close();
            }
            else if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Email cannot be empty", "Error");
                textBoxLogin.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Password cannot be empty", "Error");
                textBoxPassword.Focus();
                return;
            }
            else if (_repo.CheckGuest(textBoxLogin.Text, textBoxPassword.Text) == 0)
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

        }
    }
}
