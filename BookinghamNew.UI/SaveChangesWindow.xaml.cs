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
    /// Логика взаимодействия для SaveChangesWindow.xaml
    /// </summary>
    public partial class SaveChangesWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();

        public Hotel Hotel { get; set; }
        public string Address { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }
        public string HotelDistrict { get; set; }
        public SaveChangesWindow(Hotel hotel, string address, string checkin, string checkout, string hotelname, string hotelphone, string hoteldistrict)
        {
            InitializeComponent();
            Hotel = hotel;
            Address = address;
            CheckIn = checkin;
            CheckOut = checkout;
            HotelName = hotelname;
            HotelPhone = hotelphone;
            HotelDistrict = hoteldistrict;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            var adminRoomsListWindow = new AdminRoomsListWindow(Hotel);
            adminRoomsListWindow.Show();
            this.Close();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Hotel.Address = Address;
            Hotel.CheckInTime = CheckIn;
            Hotel.CheckOutTime = CheckOut;
            Hotel.Name = HotelName;
            Hotel.PhoneNumber = HotelPhone;
            Hotel.District = HotelDistrict;
            _repo.UpdateHotel(Hotel);
            var adminRoomsListWindow = new AdminRoomsListWindow(Hotel);
            adminRoomsListWindow.Show();
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonOK_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                ButtonCancel_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
