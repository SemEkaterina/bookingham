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
    /// Логика взаимодействия для AdminConfirmationWindow.xaml
    /// </summary>
    public partial class AdminConfirmationWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }

        public AdminConfirmationWindow(Room room, Hotel hotel)
        {
            InitializeComponent();
            Room = room;
            Hotel = hotel;
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            Guest guest = new Guest()
            {
                Name = textBoxFirstName.Text,
                Surname = textBoxLasNname.Text,
                Country = textBoxCountry.Text,
                PassportId = textBoxPassportSeries.Text,
                PassportNumber = textBoxPassportNumber.Text,
                Email = textBoxEmail.Text
            };
            _repo.RegisterGuest(guest);

            Reservation newReservation = new Reservation()
            {
                GuestId = guest.GuestId,
                RoomId = Room.RoomId,
                CheckInDate = CheckInCalendar.SelectedDate.Value,
                CheckOutDate = CheckOutCalendar.SelectedDate.Value                
            };

            _repo.AddReservation(Room, newReservation);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var adminguestslistWindow = new AdminGuestsListWindow(Room, Hotel);
            adminguestslistWindow.Show();
            this.Close();
        }
    }
}
