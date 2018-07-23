using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask1.Core.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        int NumTicket { get; set; }
        DateTime DateReg { get; set; }
        int PhoneNum { get; set; }
        bool IsBlock { get; set; }
        string City { get; set; }
        List<IBook> Book { get; set; }
        List<IPaper> Paper { get; set; }
        List<IPatent> Patent { get; set; }
    }
}
