using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Interfaces.Catalog
{
    public interface ILetters
    {
        string PubCity { get; set; }
        string PubName { get; set; }
        int CountCopies { get; set; }
        int PubYear { get; set; }
    }
}
