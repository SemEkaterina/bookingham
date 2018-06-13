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
            CheckInCalendar.DisplayDateStart = DateTime.Today;
            CheckOutCalendar.DisplayDateStart = DateTime.Today;
            CheckInCalendar.SelectedDate = DateTime.Today;
            CheckOutCalendar.SelectedDate = DateTime.Today.AddDays(1);
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("Name cannot be empty", "Error");
                textBoxFirstName.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxLasNname.Text))
            {
                MessageBox.Show("Surname cannot be empty", "Error");
                textBoxLasNname.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Email cannot be empty", "Error");
                textBoxEmail.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxPassportSeries.Text))
            {
                MessageBox.Show("PassportId cannot be empty", "Error");
                textBoxPassportSeries.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxPassportNumber.Text))
            {
                MessageBox.Show("PassportNumber cannot be empty", "Error");
                textBoxPassportNumber.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBoxNumberOfPeople.Text))
            {
                MessageBox.Show("Number of people cannot be empty", "Error");
                textBoxNumberOfPeople.Focus();
                return;
            }

            else
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

                int k = 0;
                _repo.AddReservation(Room, newReservation, CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value, out k);
                if (k == 1)
                {
                    MessageBox.Show("Success", "Success");                    
                    var adminguestslistWindow = new AdminGuestsListWindow(Room, Hotel);
                    adminguestslistWindow.Show();
                    this.Close();
                }
                else
                {
                    //_repo.RemoveGuest(guest);
                    MessageBox.Show("This room has been already booked for this timespan", "Error");
                    return;
                }
            }                       
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var adminguestslistWindow = new AdminGuestsListWindow(Room, Hotel);
            adminguestslistWindow.Show();
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonConfirm_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
