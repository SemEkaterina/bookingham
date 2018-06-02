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

        int CheckGuest(string login, string password);
        Guest Authorize(string login, string password);
        void RegisterGuest(Guest guest);
    }
}
