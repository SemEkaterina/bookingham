using HotelsAndUsers.Core.Helpers;
using HotelsAndUsers.Core.Interfaces;
using HotelsAndUsers.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core
{
    internal class DBRepository : IRepository
    {
        public List<Guest> Guests { get; set; }
        public List<Hotel> Hotels { get; set; }
        public Context Context { get; set; }

        public IEnumerable<Guest> _guests => Guests;
        public IEnumerable<Hotel> _hotels => Hotels;

        public Guest Authorize(string login, string password)
        {
            var user = Guests.FirstOrDefault(u => u.Email == login && Hash.GetHash(u.Password) == Hash.GetHash(password));
            return user;
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
                    context.Guests.Add(guest);
                }
                context.SaveChanges();
            }
        }

        public int CheckGuest(string login, string password)
        {
            if (Context.Guests != null)
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
