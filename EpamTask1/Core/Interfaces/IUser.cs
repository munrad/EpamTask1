using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask1.Core.Interfaces
{
    interface IUser
    {
        string Name { get; set; }
        int NumTicket { get; set; }
        DateTime DateReg { get; set; }
        int PhoneNum { get; set; }
        bool isBlock { get; set; }
        string City { get; set; }
        IBook Book { get; set; }
        IPaper Paper { get; set; }
        IPatent Patent { get; set; }
    }
}
