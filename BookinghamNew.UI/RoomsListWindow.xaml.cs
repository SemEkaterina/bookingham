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
        public Hotel Hotel { get; set; }

        public RoomsListWindow(Hotel hotel)
        {
            InitializeComponent();
            this.Hotel = hotel;
            roomsList.ItemsSource = Hotel.SuitableRooms;
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            var addtobinWindow = new AddToBinWindow(roomsList.SelectedItem as Room);
            addtobinWindow.Show();
        }

        //private void BinButton(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void ExitToHotelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RoomsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BinButton_Click(object sender, RoutedEventArgs e)
        {
            var binWindow = new BinWindow();
            binWindow.Show();
        }
    }
}
