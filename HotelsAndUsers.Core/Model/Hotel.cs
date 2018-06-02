using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int Stars { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Room> SuitableRooms { get; set; }
    }
}
