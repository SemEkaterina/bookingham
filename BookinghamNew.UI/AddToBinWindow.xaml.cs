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
    /// Логика взаимодействия для AddToBinWindow.xaml
    /// </summary>
    public partial class AddToBinWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public Guest Guest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public AddToBinWindow(Room room, Hotel hotel, Guest guest, DateTime checkin, DateTime checkout)
        {
            InitializeComponent();
            Room = room;
            Hotel = hotel;
            Guest = guest;
            CheckInDate = checkin;
            CheckOutDate = checkout;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_repo.BinRooms == null)
            {
                _repo.BinRooms = new List<Room>();
            }
            _repo.BinRooms.Add(Room);
            Hotel.SuitableRooms.Remove(Room);
            var binWindow = new BinWindow(Guest, CheckInDate, CheckOutDate);
            binWindow.Show();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                ButtonAdd_Click(sender, e);
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
