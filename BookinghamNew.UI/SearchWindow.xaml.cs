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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        List<string> Districts = new List<string>() { "Center", "North", "South", "West", "East","North-West", "North-East", "South-West", "South-East" };
        public Guest Guest { get; set; }

        public SearchWindow(Guest Guest)
        {
            InitializeComponent();
            DistrictHotelCombobox.ItemsSource = Districts;
            HotelNameCombobox.ItemsSource = _repo._hotels;
            this.Guest = Guest;
            CheckInCalendar.DisplayDateStart = DateTime.Today;
            CheckOutCalendar.DisplayDateStart = DateTime.Today;
            CheckInCalendar.SelectedDate = DateTime.Today;
            CheckOutCalendar.SelectedDate = DateTime.Today.AddDays(1);
        }

        //private void ExitButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var mainWindow = new MainWindow();
        //    mainWindow.Show();
        //    this.Close();
        //}

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {            
            List<Hotel> SuitableHotels = new List<Hotel>();
            int PossibleBeds = 0;
            if(HotelNameCombobox.SelectedIndex != -1) 
            {
                foreach (var h in _repo._hotels)
                {
                    if(h == HotelNameCombobox.SelectedItem)
                    {
                        ////////////////////////открыть окно отеля
                        List<Room> SuitableRooms = new List<Room>();
                        _repo.SearchEngine(h.Rooms, decimal.Parse(MaxPriceTextBox.Text), CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value, out SuitableRooms, out PossibleBeds);
                        h.SuitableRooms = SuitableRooms;
                        var hotelWindow = new HotelWindow(h, Guest, CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value);
                        hotelWindow.Show();
                    }
                }
            }

            else if ((DistrictHotelCombobox.SelectedIndex != -1) )
            {
                foreach (var h in _repo._hotels)
                {
                    h.SuitableRooms = null;
                    if(h.District == DistrictHotelCombobox.SelectedItem.ToString())
                    {
                        List<Room> SuitableRooms = new List<Room>();
                        _repo.SearchEngine(h.Rooms, decimal.Parse(MaxPriceTextBox.Text), CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value, out SuitableRooms, out PossibleBeds);
                        h.SuitableRooms = SuitableRooms;
                        if ((h.SuitableRooms.Count >= int.Parse(RoomsTextBox.Text)) && (PossibleBeds >= int.Parse(PeopleTextBox.Text)))
                        {
                            SuitableHotels.Add(h);
                        }
                    }
                }
                /////////////////////Вывод списка отелей
                var hotelslistWindow = new HotelsListWindow(SuitableHotels, Guest, CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value);
                hotelslistWindow.Show();
                this.Close();
            }

            //else if((HotelNameCombobox.SelectedIndex == -1)&&(DistrictHotelCombobox.SelectedIndex == -1))
            //{
            //    foreach (var item in _repo._hotels)
            //    {
            //        SuitableHotels.Add(item);
            //    }
                

            //    var hotelslistWindow = new HotelsListWindow(SuitableHotels);
            //    hotelslistWindow.Show();
            //    this.Close();
            //}

            else
            {
                foreach (var h in _repo._hotels)
                {
                    h.SuitableRooms = null;
                    List<Room> SuitableRooms = new List<Room>();
                    _repo.SearchEngine(h.Rooms, decimal.Parse(MaxPriceTextBox.Text), CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value, out SuitableRooms, out PossibleBeds);


                    if ((SuitableRooms.Count >= int.Parse(RoomsTextBox.Text)) && (PossibleBeds >= int.Parse(PeopleTextBox.Text)))
                    {
                        SuitableHotels.Add(h);
                        h.SuitableRooms = SuitableRooms;
                    }
                }
                /////////////////////Вывод списка отелей
                var hotelslistWindow = new HotelsListWindow(SuitableHotels, Guest, CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value);
                hotelslistWindow.Show();
                this.Close();
            }            
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LogInWindow();
            loginWindow.Show();
            this.Close();
        }

        private void DistrictHotelCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DistrictHotelCombobox.Focus();
            if (DistrictHotelCombobox.SelectedItem != null)
            {
                var selecteddistrict = DistrictHotelCombobox.SelectedItem.ToString();
                List<Hotel> somehotels = new List<Hotel>();
                foreach (var h in _repo._hotels)
                {
                    if (h.District == selecteddistrict)
                    {
                        somehotels.Add(h);
                    }
                    
                }
                HotelNameCombobox.ItemsSource = somehotels;
            }
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonPreviousBookings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
