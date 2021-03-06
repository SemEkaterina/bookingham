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
    /// Логика взаимодействия для HotelsListWindow.xaml
    /// </summary>
    public partial class HotelsListWindow : Window
    {
        HotelsAndUsers.Core.Interfaces.IRepository _repo = Factory.Instance.GetRepository();
        public List<Hotel> Hotels { get; set; }
        public Guest Guest { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public HotelsListWindow(List<Hotel> SuitableHotels, Guest guest, DateTime checkin, DateTime checkout)
        {
            InitializeComponent();
            Hotels = SuitableHotels;
            Guest = guest;
            CheckIn = checkin;
            CheckOut = checkout;           
            hotelsList.ItemsSource = Hotels;
        }

        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            if (hotelsList.SelectedItem != null)
            {
                var hotelWindow = new HotelWindow(hotelsList.SelectedItem as Hotel, Guest, CheckIn, CheckOut);
                hotelWindow.Show();
            }
            else
            {
                MessageBox.Show("Select a hotel first", "Error");
                return;
            }
        }

        private void BinButton_Click(object sender, RoutedEventArgs e)
        {
            if (_repo.BinHotels == null)
            {
                MessageBox.Show("Bin is empty", "Error");
                return;
            }
            else
            {
                var binWindow = new BinWindow(Guest, CheckIn, CheckOut);
                binWindow.Show();
            }
        }

        private void ExitToSearchPageButton_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow(Guest);
            searchWindow.Show();
            this.Close();
        }

        private void HotelsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoomsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonShow_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
