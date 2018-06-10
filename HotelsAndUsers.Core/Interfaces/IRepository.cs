using HotelsAndUsers.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Guest> _guests { get; }
        IEnumerable<Hotel> _hotels { get; }
        List<Room> BinRooms { get; set; }

        int CheckGuest(string login, string password);
        Guest Authorize(string login, string password);
        decimal TotalPrice(Room Room, DateTime InData, DateTime OutData);
        void RegisterGuest(Guest guest);
        void SearchEngine(List<Room> Rooms, decimal MaxPrice, DateTime CheckInDate, DateTime CheckOutDate, out List<Room> SuitableRooms, out int PossibleBeds);
    }
}
