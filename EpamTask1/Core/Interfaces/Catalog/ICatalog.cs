using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask1.Core.Interfaces.Catalog
{
    public interface ICatalog : ICatalogObject
    {
        void Add(ICatalogObject obj);
        void Remove(ICatalogObject obj);
        ICatalog GetAllObjects();
        ICatalogObject[] SearchByName(string name);
        ICatalogObject[] SortByYear(bool isReverse);
        IBook[] SearchBooksByAuthors(string name);
    }
}
