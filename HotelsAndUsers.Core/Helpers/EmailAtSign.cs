using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core.Helpers
{
    public class EmailAtSign
    {
        public bool SampleCheckingEmail(string mail)
        {
            foreach (var letter in mail)
            {
                if (letter == '@')
                {
                    if (mail.Length >= 7)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
