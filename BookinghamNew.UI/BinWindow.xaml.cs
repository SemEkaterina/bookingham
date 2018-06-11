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
    /// Логика взаимодействия для BinWindow.xaml
    /// </summary>
    public partial class BinWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Guest Guest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public BinWindow(Guest guest, DateTime checkin, DateTime checkout)
        {
            InitializeComponent();
            Guest = guest;
            CheckInDate = checkin;
            CheckOutDate = checkout;
            roomsList.ItemsSource = _repo.BinRooms;
            //TotalCost.Text=.......сумма стоимостей румов
        }

        private void ButtonProceed_Click(object sender, RoutedEventArgs e)
        {
            ////зарегать booking
            if (Guest == null)
            {
                MessageBox.Show("To book these rooms you need to sign in first", "Error");               
                return;
            }

            else
            {
                foreach (var hotel in _repo._hotels)
                {
                    decimal totalPrice = 0;
                    List<Room> BookedRooms = new List<Room>();
                    foreach (var room in _repo.BinRooms)
                    {
                        if (room.Hotel == hotel)
                        {
                            BookedRooms.Add(room);
                            totalPrice += _repo.TotalPrice(room, CheckInDate, CheckOutDate);
                        }                       
                    }

                    Booking NewBooking = new Booking
                    {
                        Hotel = hotel,
                        GuestId = Guest.GuestId,
                        Room = BookedRooms,
                        BookingTime = DateTime.Now,
                        CheckIn = CheckInDate,
                        CheckOut = CheckOutDate,
                        TotalPrice = totalPrice
                    };

                    //добавление в previous bookings
                    if (Guest.GuestBookings == null)
                    {
                        Guest.GuestBookings = new List<Booking>();
                    }
                    Guest.GuestBookings.Add(NewBooking);
                }               
            }
        }

        private void RoomsListButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
