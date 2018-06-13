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
    /// Логика взаимодействия для RoomsListWindow.xaml
    /// </summary>
    public partial class RoomsListWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();

        public Hotel Hotel { get; set; }
        public Guest Guest { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public RoomsListWindow(Hotel hotel, Guest guest, DateTime checkin, DateTime checkout)
        {
            InitializeComponent();
            Hotel = hotel;
            Guest = guest;
            CheckIn = checkin;
            CheckOut = checkout;
            HotelHeader.Text = Hotel.Name;
            //roomsList.ItemsSource = null;
            //roomsList.ItemsSource = Hotel.SuitableRooms;
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            if (roomsList.SelectedItem == null)
            {
                MessageBox.Show("Please select the room first", "Error");
                return;
            }

            else
            {
                var addtobinWindow = new AddToBinWindow(roomsList.SelectedItem as Room, Hotel);
                if (addtobinWindow.ShowDialog() == false)
                {
                    roomsList.ItemsSource = null;
                    roomsList.ItemsSource = Hotel.SuitableRooms;
                }
            }                     
        }

        private void RoomsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BinButton_Click(object sender, RoutedEventArgs e)
        {

            if (_repo.BinHotels == null)
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

        private void ExitToHotelButton_Click(object sender, RoutedEventArgs e)
        {
            var hotelWindow = new HotelWindow(Hotel, Guest, CheckIn, CheckOut);
            hotelWindow.Show();
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonSelect_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
