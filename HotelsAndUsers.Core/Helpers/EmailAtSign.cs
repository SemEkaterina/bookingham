using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Helpers
{
    public class EmailAtSign
    {
        public bool SampleCheckingEmail(string email)
        {
            foreach (var letter in email)
            {
                if (letter == '@')
                {
                    if (email.Length >= 7)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
