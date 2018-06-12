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
    /// Логика взаимодействия для AdminHotelWindow.xaml
    /// </summary>
    public partial class AdminHotelWindow : Window
    {
        public Hotel Hotel { get; set; }
        public AdminHotelWindow(Hotel hotel)
        {
            InitializeComponent();
            Hotel = hotel;
            HotelClassText.Text = Hotel.Type;
            HotelAddressText.Text = Hotel.Address;
            HotelNameText.Text = Hotel.Name;
            HotelPhoneText.Text = Hotel.PhoneNumber;
            HotelCheckInText.Text = Hotel.CheckInTime;
            HotelCheckOutText.Text = Hotel.CheckOutTime;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonShowRooms_Click(object sender, RoutedEventArgs e)
        {
            var adminRoomsListWindow = new AdminRoomsListWindow(Hotel);
            adminRoomsListWindow.Show();
            this.Close();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
