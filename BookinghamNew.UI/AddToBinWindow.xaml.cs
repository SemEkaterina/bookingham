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
            if (_repo.BinRooms == null)
            {
                _repo.BinRooms = new List<Room>();
            }
            _repo.BinRooms.Add(Room);
            Hotel.SuitableRooms.Remove(Room);
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
