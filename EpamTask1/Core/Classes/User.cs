using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Classes
{
    public class User
    {
        public string Name { get; set; }
        public string NumTicket { get; set; }
        public DateTime DateReg { get; set; }
        public string PhoneNum { get; set; }
        public bool IsBlock { get; set; }
        public string City { get; set; }
        public List<Book> Books { get; set; }
        public List<Paper> Papers { get; set; }
        public List<Patent> Patents { get; set; }
    }
}
