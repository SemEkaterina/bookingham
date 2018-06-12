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
    /// Логика взаимодействия для AdminHotelWindow.xaml
    /// </summary>
    public partial class AdminHotelWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();

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
            if (Hotel.Stars == 1)
            {
                Uri uri = new Uri(@"Stars/1_star.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                StarsImage.Source = imgSource;
            }
            if (Hotel.Stars == 2)
            {
                Uri uri = new Uri(@"Stars/2_stars.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                StarsImage.Source = imgSource;
            }
            if (Hotel.Stars == 3)
            {
                Uri uri = new Uri(@"Stars/3_stars.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                StarsImage.Source = imgSource;
            }
            if (Hotel.Stars == 4)
            {
                Uri uri = new Uri(@"Stars/4_stars.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                StarsImage.Source = imgSource;
            }
            if (Hotel.Stars == 5)
            {
                Uri uri = new Uri(@"Stars/5_stars.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                StarsImage.Source = imgSource;
            }

            Uri newUri = new Uri(Hotel.HotelImagePath, UriKind.Relative);
            ImageSource imgHotelSource = new BitmapImage(newUri);
            ImageOfHotel.Source = imgHotelSource;
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
            Hotel.Address = HotelAddressText.Text;
            Hotel.CheckInTime = HotelCheckInText.Text;
            Hotel.CheckOutTime = HotelCheckOutText.Text;
            Hotel.Name = HotelNameText.Text;
            Hotel.PhoneNumber = HotelPhoneText.Text;
            _repo.UpdateHotel(Hotel);
        }
    }
}
