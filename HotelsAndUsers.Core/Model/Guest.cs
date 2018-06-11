using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Model
{
    public class Guest
    {
        public int GuestId { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string PassportId { get; set; }
        public string PassportNumber { get; set; }
        public List<Booking> GuestBookings { get; set; }
    }
}
