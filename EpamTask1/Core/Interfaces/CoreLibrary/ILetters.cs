using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask1.Core.Interfaces.CoreLibrary
{
    public interface ILetters : ILibraryObject
    {
        string PubCity { get; set; }
        string PubName { get; set; }
    }
}
