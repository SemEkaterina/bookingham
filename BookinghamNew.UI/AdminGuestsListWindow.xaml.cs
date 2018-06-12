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
    /// Логика взаимодействия для AdminGuestsListWindow.xaml
    /// </summary>
    public partial class AdminGuestsListWindow : Window
    {
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public AdminGuestsListWindow(Room room,Hotel hotel)
        {
            InitializeComponent();
            Hotel = hotel;
            Room = room;
        }

        private void BackToRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            var adminRoomsListWindow = new AdminRoomsListWindow(Hotel);
            adminRoomsListWindow.Show();
            this.Close();
        }

        private void GuestsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonRegisterNewGuest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
