using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers
{
    public class Guest
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int MyProperty { get; set; }
        public int Age { get; set; }
        public string PassportId { get; set; }
        public string PassportNumber { get; set; }
        public int PreviousBookings { get; set; }
    }
}
