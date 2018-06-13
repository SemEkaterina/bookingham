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
    /// Логика взаимодействия для PreviousBookings.xaml
    /// </summary>
    public partial class PreviousBookings : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Guest Guest { get; set; }

        public PreviousBookings(Guest guest)
        {
            InitializeComponent();
            Guest = guest;
            bookingsList.ItemsSource = guest.GuestBookings;
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            if (bookingsList.SelectedItem == null)
            {
                MessageBox.Show("Select booking please", "Error");
                return;
            }
            else
            {
                this.Close();
            }
            
        }

        private void MyBookingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExitToHotelButton(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow(Guest);
            searchWindow.Show();
            this.Close();
        }

        //private void BinButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (_repo.BinRooms == null)
        //    {
        //        MessageBox.Show("Bin is empty", "Error");
        //        return;
        //    }
        //    else
        //    {
        //        var binWindow = new BinWindow(Guest, CheckIn, CheckOut);
        //        binWindow.Show();
        //    }
        //}
    }
}
