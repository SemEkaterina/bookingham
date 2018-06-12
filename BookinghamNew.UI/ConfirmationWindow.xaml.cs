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
    /// Логика взаимодействия для ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Guest Guest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public ConfirmationWindow(Guest guest, DateTime checkin, DateTime checkout)
        {
            InitializeComponent();
            Guest = guest;
            CheckInDate = checkin;
            CheckOutDate = checkout;
            textBoxFirstName.Text = Guest.Name;
            textBoxLasNname.Text = Guest.Surname;
            textBoxEmail.Text = Guest.Email;
            
        }

        private void ExitToReservationButton(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }

        private void ConfirmationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if ((textBoxFirstName.Text == Guest.Name)&&(textBoxLasNname.Text == Guest.Surname))
            {
                Guest.PassportId = textBoxPassportSeries.Text;
                Guest.PassportNumber = textBoxPassportNumber.Text;
                Guest.Country = textBoxCountry.Text;
            }

            else
            {
                Guest guest = new Guest()
                {
                    Name = textBoxFirstName.Text,
                    Surname = textBoxLasNname.Text,
                    Email = textBoxEmail.Text,
                    PassportId = textBoxPassportSeries.Text,
                    PassportNumber = textBoxPassportNumber.Text,
                    Country = textBoxCountry.Text,
                };
                _repo.RegisterGuest(guest);
                Guest = guest;
            }
            foreach (var hotel in _repo._hotels)
            {
                decimal totalPrice = 0;
                List<Room> BookedRooms = new List<Room>();
                foreach (var room in _repo.BinRooms)
                {
                    if (room.HotelId == hotel.HotelId)
                    {
                        BookedRooms.Add(room);
                        Reservation newReservation = new Reservation()
                        {
                            GuestId = Guest.GuestId,
                            RoomId = room.RoomId,
                            CheckInDate = CheckInDate,
                            CheckOutDate = CheckOutDate
                        };
                        _repo.AddReservation(room, newReservation);
                        totalPrice += _repo.TotalPrice(room, CheckInDate, CheckOutDate);
                    }
                }

                if (BookedRooms.Count != 0)
                {
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


                    _repo.AddBooking(Guest, NewBooking);

                }
                
            }
            MessageBox.Show("Success", "Success");
            return;
        }
    }
}
