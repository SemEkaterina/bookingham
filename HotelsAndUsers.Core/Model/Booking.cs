using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int HotelId { get; set; }
        public List<Room> Room { get; set; }
        public string BookingTime { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
