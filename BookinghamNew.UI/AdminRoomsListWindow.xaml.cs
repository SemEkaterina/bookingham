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
    /// Логика взаимодействия для AdminRoomsListWindow.xaml
    /// </summary>
    public partial class AdminRoomsListWindow : Window
    {
        public Hotel Hotel { get; set; }
        public AdminRoomsListWindow(Hotel hotel)
        {
            InitializeComponent();
            Hotel = hotel;
            HotelHeader.Text = Hotel.Name;
            roomsList.ItemsSource = Hotel.Rooms;
        }

        private void ButtonShowGuests_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = roomsList.SelectedItem as Room;
            
            var adminguestslistWindow = new AdminGuestsListWindow(selectedRoom, Hotel);
            adminguestslistWindow.Show();
            this.Close();
        }

        private void RoomsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExitToHotelButton_Click(object sender, RoutedEventArgs e)
        {
            var adminhotelWindow = new AdminHotelWindow(Hotel);
            adminhotelWindow.Show();
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonShowGuests_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
