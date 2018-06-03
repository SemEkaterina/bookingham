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

        public SearchWindow()
        {
            InitializeComponent();
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var wert = new HotelWindow();
            wert.ShowDialog();
            List<Hotel> SuitableHotels = new List<Hotel>();
            foreach (var h in _repo._hotels)
            {
                int PossibleBeds = 0;
                if(h.Name == HotelNameCombobox.SelectedItem.ToString())
                {
                    ////////////////////////открыть окно отеля
                }

                else if(h.District == DistrictHotelCombobox.SelectedItem.ToString())
                {
                    foreach(var r in h.Rooms)
                    {
                        for(int i = 1; i <= r.Reservations.Count; i++)
                        {
                            if ((CheckInCalendar.SelectedDate >= r.Reservations[i-1].CheckOutDate)&&(CheckInCalendar.SelectedDate < r.Reservations[i].CheckInDate)&&(r.PriceForNight <= int.Parse(MaxPriceTextBox.Text)))
                            {
                                h.SuitableRooms.Add(r);
                                PossibleBeds += r.BedNumber;
                                break;
                            }
                        }                        
                    }

                    if ((h.SuitableRooms.Count >= int.Parse(RoomsTextBox.Text))&&(PossibleBeds >= int.Parse(PeopleTextBox.Text)))
                    {
                        SuitableHotels.Add(h);
                    }
                }
            }
        }
    }
}
