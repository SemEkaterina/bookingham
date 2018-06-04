﻿using HotelsAndUsers.Core.Model;
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
    /// Логика взаимодействия для HotelWindow.xaml
    /// </summary>
    public partial class HotelWindow : Window
    {
        public Hotel Hotel { get; set; }

        public HotelWindow(Hotel Hotel)
        {
            InitializeComponent();
            this.Hotel = Hotel;
            HotelNameText.Text = Hotel.Name;
            HotelAddressText.Text = Hotel.Address;
            HotelStarsCount.Text = Hotel.Stars.ToString();
            CheckInTextblock.Text = Hotel.CheckInTime.ToString();
            CheckOutTextblock.Text = Hotel.CheckOutTime.ToString();
            EmailTextBlock.Text = Hotel.Email;
            PhoneTextBlock.Text = Hotel.PhoneNumber;

        }

        private void ButtonShowRomms_Click(object sender, RoutedEventArgs e)
        {
            var ert = new RoomsListWindow();
            ert.ShowDialog();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            ////////////вернуться к списку отелей
        }
    }
}
