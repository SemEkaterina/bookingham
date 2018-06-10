using HotelsAndUsers.Core.Helpers;
using HotelsAndUsers.Core.Interfaces;
using HotelsAndUsers.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core
{
    class FileRepository : IRepository
    {
        public List<Guest> Guests { get; set; }
        public List<Hotel> Hotels { get; set; }
        public Context Context { get; set; }
        public List<Room> BinRooms { get; set; }


        public IEnumerable<Guest> _guests => Guests;
        public IEnumerable<Hotel> _hotels => Hotels;

        public FileRepository()
        {
            try
            {
                Hotels = ReadHotels();
                Guests = ReadGuests();
            }
            catch
            {
                Guests = new List<Guest>();
                Hotels = new List<Hotel>();
            }
        }

        public List<Hotel> ReadHotels()
        {
            List<Hotel> Hotels = new List<Hotel>();
            if (File.Exists("hotels.json"))
            {
                string json = File.ReadAllText("hotels.json");
                Hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            return Hotels;
        }

        public void SerializeGuests()
        {
            string json = JsonConvert.SerializeObject(Guests);
            File.WriteAllText("users.json", json);
        }

        private List<Guest> ReadGuests()
        {
            List<Guest> Guests = new List<Guest>();
            if (File.Exists("users.json"))
            {
                string json = File.ReadAllText("users.json");
                Guests = JsonConvert.DeserializeObject<List<Guest>>(json);
            }
            return Guests;
        }

        public Guest Authorize(string login, string password)
        {
            var Guest = Guests.FirstOrDefault(u => u.Email == login && Hash.GetHash(u.Password) == Hash.GetHash(password));
            return Guest;
        }

        public void RegisterGuest(Guest guest)
        {
            if (Guests == null)
            {
                guest.GuestId = 1;
                List<Guest> guests = new List<Guest>();
                guests.Add(guest);
                Guests = guests;
            }
            else
            {
                guest.GuestId = Guests.Max(u => u.GuestId) + 1;
                Guests.Add(guest);
            }
            //user.Id = _generalData.users.Count > 0 ? _generalData.users.Max(u => u.Id) + 1 : 1;

            SerializeGuests();
        }

        public void SearchEngine(List<Room> Rooms, decimal MaxPrice, DateTime CheckInDate, DateTime CheckOutDate, out List<Room> SuitableRooms, out int PossibleBeds)
        {
            SuitableRooms = new List<Room>();
            PossibleBeds = 0;
            foreach (var r in Rooms)
            {
                if (r.Reservations == null)
                {
                    r.Reservations = new List<Reservation>();
                }
                for (int i = 1; i <= r.Reservations.Count; i++)
                {
                    if ((CheckInDate >= r.Reservations[i - 1].CheckOutDate) && (CheckInDate < r.Reservations[i].CheckInDate) && (r.PriceForNight <= MaxPrice))
                    {
                        SuitableRooms.Add(r);
                        PossibleBeds += r.BedNumber;
                        break;
                    }
                }
            }
        }

        public decimal TotalPrice(Room Room, DateTime InData, DateTime OutData)
        {
            decimal total = 0;
            var daysCount = OutData.Subtract(InData);
            total = Room.PriceForNight * daysCount.Days;

            return total;
        }

        public int CheckGuest(string login, string password)
        {
            if (Guests != null)
            {
                var user = Guests.FirstOrDefault(u => u.Email == login && Hash.GetHash(u.Password) == Hash.GetHash(password));
                if (user != null)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    
}
