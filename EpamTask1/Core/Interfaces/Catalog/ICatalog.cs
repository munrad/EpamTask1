using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask1.Core.Interfaces.Catalog
{
    public interface ICatalog : ICatalogObject
    {
        void Add(ICatalogObject obj, bool isForce);
        void Remove(ICatalogObject obj);
        IList<ICatalogObject> GetAllObjects();
        IList<ICatalogObject> SearchByName(string name);
        IList<ICatalogObject> SortByYear(bool isReverse);
        IList<IBook> SearchBooksByAuthors(string name);
        IDictionary<string, IList<IBook>> GetSortBooks(string symb);
        IDictionary<int, IList<ICatalogObject>> GroupByYear();
    }
}
