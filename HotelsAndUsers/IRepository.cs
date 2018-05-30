using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers
{
    interface IRepository
    {
        IEnumerable<Guest> guests { get; }
        IEnumerable<Hotel> hotels { get; }

        int CheckGuest(string login, string password);
        Guest Authorize(string login, string password);
        void RegisterGuest(Guest guest);
    }
}
