using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsAndUsers.Core
{
    public class Factory
    {
        private static Factory _instance;
        public static Factory Instance => _instance ?? (_instance = new Factory());
        private Interfaces.IRepository _repo;
        public Interfaces.IRepository GetRepository() => _repo ?? (_repo = new FileRepository());
    }
}
