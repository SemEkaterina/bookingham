using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
