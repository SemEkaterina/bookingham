using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public string Class { get; set; }
        public int BedNumber { get; set; }
        public decimal PriceForNight { get; set; }
        public string Description { get; set; }      
        public List<Reservation> Reservations { get; set; }
    }
}
