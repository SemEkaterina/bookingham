using HotelsAndUsers.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Interfaces
{
    interface IRepository
    {
        IEnumerable<Guest> Guests { get; }
        IEnumerable<Hotel> Hotels { get; }

        int CheckGuest(string login, string password);
        Guest Authorize(string login, string password);
        void RegisterGuest(Guest guest);
    }
}
