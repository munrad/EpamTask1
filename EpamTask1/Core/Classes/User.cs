using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Interfaces;

namespace EpamTask1.Core.Classes
{
    public class User : IUser
    {
        public string Name { get; set; }
        public int NumTicket { get; set; }
        public DateTime DateReg { get; set; }
        public int PhoneNum { get; set; }
        public bool IsBlock { get; set; }
        public string City { get; set; }
        public List<IBook> Book { get; set; }
        public List<IPaper> Paper { get; set; }
        public List<IPatent> Patent { get; set; }
    }
}
