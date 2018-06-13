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
    /// Логика взаимодействия для HotelWindow.xaml
    /// </summary>
    public partial class HotelWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Hotel Hotel { get; set; }
        public Guest Guest { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public HotelWindow(Hotel Hotel, Guest guest, DateTime checkin, DateTime checkout)
        {
            InitializeComponent();
            this.Hotel = Hotel;
            Guest = guest;
            CheckIn = checkin;
            CheckOut = checkout;
            HotelClassText.Text = Hotel.Type;
            HotelNameText.Text = Hotel.Name;
            HotelAddressText.Text = Hotel.Address;
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
            CheckInTextblock.Text = Hotel.CheckInTime.ToString();
            CheckOutTextblock.Text = Hotel.CheckOutTime.ToString();
            //EmailTextBlock.Text = Hotel.Email;
            PhoneTextBlock.Text = Hotel.PhoneNumber;

            Uri newUri = new Uri(Hotel.HotelImagePath, UriKind.Relative);
            ImageSource imgHotelSource = new BitmapImage(newUri);
            ImageOfHotel.Source = imgHotelSource;
        }

        private void ButtonShowRooms_Click(object sender, RoutedEventArgs e)
        {
            var roomslistlWindow = new RoomsListWindow(Hotel, Guest, CheckIn, CheckOut);
            roomslistlWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow(Guest);
            searchWindow.Show();
            this.Close();
        }

        private void BinButton_Click(object sender, RoutedEventArgs e)
        {
            if (_repo.BinRooms == null)
            {
                MessageBox.Show("Bin is empty", "Error");
                return;
            }
            else
            {
                var binWindow = new BinWindow(Guest, CheckIn, CheckOut);
                binWindow.Show();
            }
            
        }
    }
}
