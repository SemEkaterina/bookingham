﻿using HotelsAndUsers.Core;
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

        public SearchWindow()
        {
            InitializeComponent();
            DistrictHotelCombobox.ItemsSource = Districts;
            HotelNameCombobox.ItemsSource = _repo._hotels;
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var wert = new HotelWindow(_repo._hotels.First());
            wert.ShowDialog();
            List<Hotel> SuitableHotels = new List<Hotel>();
            int PossibleBeds = 0;
            if(HotelNameCombobox.SelectedIndex != -1) 
            {
                foreach (var h in _repo._hotels)
                {
                    if(h.Name == HotelNameCombobox.SelectedItem.ToString())
                    {
                        ////////////////////////открыть окно отеля
                    }
                }
            }

            else if ((DistrictHotelCombobox.SelectedIndex != -1) )
            {
                foreach (var h in _repo._hotels)
                {
                    if(h.District == DistrictHotelCombobox.SelectedItem.ToString())
                    {
                        List<Room> SuitableRooms = new List<Room>();
                        _repo.SearchEngine(h.Rooms, decimal.Parse(MaxPriceTextBox.Text), CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value, out SuitableRooms, out PossibleBeds);

                        if ((h.SuitableRooms.Count >= int.Parse(RoomsTextBox.Text)) && (PossibleBeds >= int.Parse(PeopleTextBox.Text)))
                        {
                            SuitableHotels.Add(h);
                        }
                    }
                }
            }

            else
            {
                foreach (var h in _repo._hotels)
                {
                    List<Room> SuitableRooms = new List<Room>();
                    _repo.SearchEngine(h.Rooms, decimal.Parse(MaxPriceTextBox.Text), CheckInCalendar.SelectedDate.Value, CheckOutCalendar.SelectedDate.Value, out SuitableRooms, out PossibleBeds);


                    if ((h.SuitableRooms.Count >= int.Parse(RoomsTextBox.Text)) && (PossibleBeds >= int.Parse(PeopleTextBox.Text)))
                    {
                        SuitableHotels.Add(h);
                    }
                }
            }
        }
    }
}
