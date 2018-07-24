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
        public int NumTicket { get; set; }
        public DateTime DateReg { get; set; }
        public int PhoneNum { get; set; }
        public bool IsBlock { get; set; }
        public string City { get; set; }
        public List<Book> Book { get; set; }
        public List<Paper> Paper { get; set; }
        public List<Patent> Patent { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
