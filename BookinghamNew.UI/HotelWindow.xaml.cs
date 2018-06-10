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
        public Hotel Hotel { get; set; }

        public HotelWindow(Hotel Hotel)
        {
            InitializeComponent();
            this.Hotel = Hotel;
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

            //ImageOfHotel.Source = Hotel.HotelImagePath.;
            //Source = "Images/novotelPaddington.jpg"
        }

        private void ButtonShowRooms_Click(object sender, RoutedEventArgs e)
        {
            var roomslistlWindow = new RoomsListWindow(Hotel);
            roomslistlWindow.Show();
        }        
    }
}
