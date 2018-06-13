using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Model
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Type { get; set; }
        public string HotelImagePath { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public decimal MinPrice { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Room> SuitableRooms { get; set; }
        public List<Room> BinRooms { get; set; }
    }
}
