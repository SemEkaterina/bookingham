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

        public AddToBinWindow(Room room)
        {
            InitializeComponent();
            this.Room = room;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _repo.BinRooms.Add(Room);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
