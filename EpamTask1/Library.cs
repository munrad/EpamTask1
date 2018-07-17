using EpamTask1.Core;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1
{
    public class Library : ICatalog
    {
        private readonly ICatalog catalog;
        public int PubYear { get; set; }

        public Library()
        {
            catalog = new Catalog();
        }

        public void Add(ICatalogObject obj)
        {
            catalog.Add(obj);
        }

        public ICatalog GetAllObjects()
        {
            return catalog.GetAllObjects();
        }

        public void Remove(ICatalogObject obj)
        {
            catalog.Remove(obj);
        }

        public ICatalogObject[] SearchByName(string name)
        {
            return catalog.SearchByName(name);
        }

        public ICatalogObject[] SortByYear(bool isReverse)
        {
            return catalog.SortByYear(isReverse);
        }

        public IBook[] SearchBooksByAuthors(string name)
        {
            return catalog.SearchBooksByAuthors(name);
        }

        public IBook[][] GetSortBooks(string symb)
        {
            return catalog.GetSortBooks(symb);
        }

        public ICatalogObject[][] GroupByYear()
        {
            return catalog.GroupByYear();
        }
    }
}
