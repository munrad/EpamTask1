using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EpamTask1.Core.Extensions;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core
{
    sealed class Catalog : ICatalog
    {
        public List<ICatalogObject> CatalogObjects;
        public int PubYear { get; set; }

        public Catalog()
        {
            CatalogObjects = new List<ICatalogObject>();
        }

        public void Add(ICatalogObject obj, bool isForce = false)
        {
            Validator.ValidateProp(obj, isForce);
            CatalogObjects.Add(obj);
        }

        public void Remove(ICatalogObject obj)
        {
            CatalogObjects.RemoveAll(m => m.Equals(obj));
        }

        public IList<ICatalogObject> GetAllObjects()
        {
            return CatalogObjects;
        }

        public IList<ICatalogObject> SearchByName(string name)
        {
            var result = new List<ICatalogObject>();

            foreach (var t in CatalogObjects)
            {
                if (!(t is IBook book)) continue;
                if (book.Name != name) continue;
                result.Add(t);

                if (!(t is IPaper paper)) continue;
                if (paper.Name != name) continue;
                result.Add(t);

                if (!(t is IPatent patent)) continue;
                if (patent.Name != name) continue;
                result.Add(t);
            }
            return result;
        }

        public IList<ICatalogObject> SortByYear(bool isReverse = false)
        {
            CatalogObjects.Sort(new Comparers.SortByYear { IsReverse = isReverse });
            return CatalogObjects;
        }

        public IList<IBook> SearchBooksByAuthors(string name)
        {
            var arrResult = new List<IBook>();
            foreach (var m in CatalogObjects)
            {              
                if (!(m is IBook book)) break;
                var arrAuthors = book.Authors;             
                if (arrAuthors == null) break;
                foreach (var t in arrAuthors)
                {
                    if (!t.Contains(name)) continue;
                    arrResult.Add(book);
                    break;
                }
            }
            return arrResult;
        }

        public IDictionary<string, IList<IBook>> GetSortBooks(string symb)
        {
            var arr = new List<IBook>();
            var books = new Dictionary<string, IList<IBook>>();
            foreach (var m in CatalogObjects)
            {
                if (!(m is IBook book)) continue;
                if (book.PubName == null) continue;
                if (!book.PubName.Contains(symb)) continue;
                arr.Add(book);
            }
            foreach (var book in arr)
            {
                if (book.PubName == null) continue;
                if (!books.ContainsKey(book.PubName))
                    books.Add(book.PubName, arr.FindAll(n => n.PubName.Equals(book.PubName)));
            }
            return books;
        }

        public IDictionary<int, IList<ICatalogObject>> GroupByYear()
        {
            var arr = new List<ICatalogObject>();
            var objects = new Dictionary<int, IList<ICatalogObject>>();
            foreach (var m in CatalogObjects)
            {
                if (m is IPatent) continue;
                arr.Add(m);
            }

            foreach (var catalogObject in arr)
            {
                if (!objects.ContainsKey(catalogObject.PubYear))
                    objects.Add(catalogObject.PubYear, arr.FindAll(n => n.PubYear.Equals(catalogObject.PubYear)));
            }
            return objects;
        }
    }
}
