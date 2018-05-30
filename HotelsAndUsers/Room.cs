using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers
{
    class Room
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public int RoomNumber { get; set; }
        public decimal PriceForNight { get; set; }
        public string Class { get; set; }
        public int BedNumber { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
