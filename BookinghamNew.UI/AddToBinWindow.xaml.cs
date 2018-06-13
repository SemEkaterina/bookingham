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

        public AddToBinWindow(Room room, Hotel hotel)
        {
            InitializeComponent();
            Room = room;
            Hotel = hotel;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_repo.BinHotels == null)
            {
                _repo.BinHotels = new List<Hotel>();
            }
            if (Hotel.BinRooms == null)
            {
                Hotel.BinRooms = new List<Room>();
            }
            Hotel.BinRooms.Add(Room);
            _repo.BinHotels.Add(Hotel);
            Hotel.SuitableRooms.Remove(Room);
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
