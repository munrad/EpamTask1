using System;
using System.Collections.Generic;
using System.IO;
using EpamTask1.Core;
using EpamTask1.Core.Extensions;
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

        public IList<ICatalogObject> SearchByName(string name)
        {
            return catalog.SearchByName(name);
        }

        public IList<ICatalogObject> SortByYear(bool isReverse)
        {
            return catalog.SortByYear(isReverse);
        }

        public IList<IBook> SearchBooksByAuthors(string name)
        {
            return catalog.SearchBooksByAuthors(name);
        }

        public IDictionary<string, IList<IBook>> GetSortBooks(string symb)
        {
            return catalog.GetSortBooks(symb);
        }

        public IDictionary<int, IList<ICatalogObject>> GroupByYear()
        {
            return catalog.GroupByYear();
        }

        public void Save()
        {
            //TODO 
        }

        public void Load()
        {
            //TODO 
        }
    }
}
