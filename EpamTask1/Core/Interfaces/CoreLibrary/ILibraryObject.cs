using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Interfaces.CoreLibrary
{
    public interface ILibraryObject : ICatalogObject
    {
        string Name { get; set; }       
        string Note { get; set; }
        int CountPages { get; set; }
    }
}
