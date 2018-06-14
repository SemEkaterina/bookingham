using HotelsAndUsers.Core.Helpers;
using HotelsAndUsers.Core.Interfaces;
using HotelsAndUsers.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core
{
    internal class DBRepository : IRepository
    {
        public List<Guest> Guests { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Room> Rooms { get; set; }
        public Context Context { get; set; }
        public List<Room> BinRooms { get; set; }

        public IEnumerable<Guest> _guests => Guests;
        public IEnumerable<Hotel> _hotels => Hotels;

        public DBRepository()
        {
            try
            {
                using (Context = new Context())
                {
                    Guests = Context.Guests.Include("GuestBookings").ToList();
                    Hotels = Context.Hotels/*.Include("Rooms")*/.ToList();
                    Rooms = Context.Rooms.Include("Reservations").ToList();
                    for (int i = 0; i < Guests.Count; i++)
                    {
                        if (Guests[i].Password == null)
                        {
                            Guests.Remove(Guests[i]);
                        }
                    }
                }
            }
            catch
            {
                Guests = new List<Guest>();
                Hotels = new List<Hotel>();
            }
        }

        public void Authorize(string login, string password, out Guest guest, out Hotel hotel)
        {
            guest = Guests.FirstOrDefault(g => g.Email == login && Hash.GetHash(g.Password) == Hash.GetHash(password));
            hotel = Hotels.FirstOrDefault(h => h.Email == login && Hash.GetHash(h.Password) == Hash.GetHash(password));           
        }

        public void RegisterGuest(Guest guest)
        {
            using (var context = new Context())
            {
                if (Guests == null)
                {
                    List<Guest> Guests = new List<Guest>();
                    context.Guests.Add(guest);
                    this.Guests = Guests;
                }
                else
                {
                    context.Guests.AddOrUpdate(guest);
                    Guests.Add(guest);
                }
                context.SaveChanges();
            }
        }

        public void SearchEngine(List<Room> Rooms,decimal MaxPrice,DateTime CheckInDate, DateTime CheckOutDate, out List<Room> SuitableRooms, out int PossibleBeds)
        {
            SuitableRooms = new List<Room>();
            PossibleBeds = 0;
            foreach (var r in Rooms)
            {
                if (((r.Reservations == null)||(r.Reservations.Count == 0))&&(r.PriceForNight <= MaxPrice))
                {
                    r.Reservations = new List<Reservation>();
                    SuitableRooms.Add(r);
                    PossibleBeds += r.BedNumber;
                    //break;
                }
                else if(r.Reservations != null)
                {
                    for (int i = 1; i <= r.Reservations.Count - 1; i++)
                    {
                        if (CheckInDate >= r.Reservations[r.Reservations.Count - 1].CheckOutDate)
                        {
                            if (r.PriceForNight <= MaxPrice)
                            {
                                SuitableRooms.Add(r);
                                PossibleBeds += r.BedNumber;
                                break;
                            }
                        }

                        else if ((CheckInDate >= r.Reservations[i - 1].CheckOutDate) && (CheckInDate < r.Reservations[i].CheckInDate) && (CheckOutDate < r.Reservations[i].CheckInDate))
                        {
                            if (r.PriceForNight <= MaxPrice)
                            {
                                SuitableRooms.Add(r);
                                PossibleBeds += r.BedNumber;
                                break;
                            }
                        }
                    }
                }
                if (BinRooms != null)
                {
                    var suitableRooms = SuitableRooms.Except(BinRooms);
                    SuitableRooms = new List<Room>();
                    foreach (var item in suitableRooms)
                    {
                        SuitableRooms.Add(item);
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

        public void AddBooking(Guest guest, Booking booking)
        {
            using (var c = new Context())
            {

                if (guest.GuestBookings == null)
                {
                    guest.GuestBookings = new List<Booking>();
                }

                guest.GuestBookings.Add(booking);
                
                c.Bookings.Add(guest.GuestBookings.Last());
                c.SaveChanges();
            }
        }

        public void AddReservation(Room room, Reservation reservation, DateTime CheckInDate, DateTime CheckOutDate, out int k)
        {
            k = 0;
            using (var c = new Context())
            {
                if (room.Reservations.Count != 0)
                {
                    for (int i = 1; i <= room.Reservations.Count; i++)
                    {
                        if (CheckInDate >= room.Reservations[room.Reservations.Count - 1].CheckOutDate)
                        {
                            k = 1;
                            break;
                        }
                        else if (((CheckInDate >= room.Reservations[i - 1].CheckOutDate) && (CheckInDate < room.Reservations[i].CheckInDate) && (CheckOutDate < room.Reservations[i].CheckInDate)))
                        {
                            k = 1;
                            break;
                        }
                    }
                }
                else if ((room.Reservations == null) || (room.Reservations.Count == 0))
                {
                    room.Reservations = new List<Reservation>();
                    k = 1;
                }

                if (k == 1)
                {
                    room.Reservations.Add(reservation);
                    
                    c.Reservations.Add(room.Reservations.Last());

                    c.SaveChanges();
                }

            }
        }

        public void UpdateHotel(Hotel hotel)
        {
            using (var c = new Context())
            {
                c.Hotels.AddOrUpdate(hotel);
                c.SaveChanges();
            }
        }

        public List<Guest> RegisteredGuests(Room room)
        {
            List<Guest> guests = new List<Guest>();
            if (room.Reservations != null)
            {
                foreach (var item in room.Reservations)
                {
                    foreach (var g in _guests)
                    {
                        if (g.GuestId == item.GuestId)
                        {
                            guests.Add(g);
                        }
                    }
                }
            }
            return guests;
        }

        public void AddBookedRoomsAndReservations(Hotel hotel, Guest Guest, DateTime CheckInDate, DateTime CheckOutDate, out List<Room> BookedRooms, out decimal totalPrice)
        {
            
                totalPrice = 0;
                BookedRooms = new List<Room>();
                foreach (var room in BinRooms)
                {
                    if (room.HotelId == hotel.HotelId)
                    {
                        BookedRooms.Add(room);
                        Reservation newReservation = new Reservation()
                        {
                            GuestId = Guest.GuestId,
                            RoomId = room.RoomId,
                            CheckInDate = CheckInDate,
                            CheckOutDate = CheckOutDate
                        };
                        AddReservation(room, newReservation, CheckInDate, CheckInDate, out int k);
                        totalPrice += TotalPrice(room, CheckInDate, CheckOutDate);
                    }
                }
            
        }

        public void RemoveGuest(Guest guest)
        {
            using (var c = new Context())
            {
                Guests.Remove(guest);
                c.Guests.Remove(guest);
                c.SaveChanges();
            }
        }
    }
}
