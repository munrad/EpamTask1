using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask1.Core.Interfaces
{
    interface IArchive
    {
        IUser User { get; set; }
        IBook Book { get; set; }
        IPaper Paper { get; set; }
        string[] Journal { get; set; }
        DateTime DateGet { get; set; }
        DateTime DateReturn { get; set; }
        int DateLimit { get; set; }
    }
}
