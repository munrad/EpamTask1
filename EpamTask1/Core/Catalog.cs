using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Extensions;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core
{
    public sealed class Catalog
    {       
        private static List<ICatalogObject> catalogObjects;

        public delegate T CustomSortDel<out T>(ICatalogObject obj);

        public delegate bool CustomSearchDel(ICatalogObject obj);

        public Catalog()
        {           
            catalogObjects = new List<ICatalogObject>();
        }

        public void Add(ICatalogObject obj, bool isForce = true)
        {
            Validator.ValidateProp(obj, isForce);
            catalogObjects.Add(obj);
        }

        public void Remove(ICatalogObject obj)
        {
            catalogObjects.RemoveAll(m => m.Equals(obj));
        }

        public static IList<ICatalogObject> GetAllObjects()
        {
            return catalogObjects;
        }

        public IList<ICatalogObject> SearchByName(string name)
        {
            var result = new List<ICatalogObject>();

            foreach (var t in catalogObjects)
            {
                if (!(t is Book book)) continue;
                if (book.Name != name) continue;
                result.Add(t);

                if (!(t is Paper paper)) continue;
                if (paper.Name != name) continue;
                result.Add(t);

                if (!(t is Patent patent)) continue;
                if (patent.Name != name) continue;
                result.Add(t);
            }
            return result;
        }

        public IList<ICatalogObject> CustomSort<T>(CustomSortDel<T> func) where T : IComparable
        {
            for (var i = 0; i < catalogObjects.Count; i++)
            {
                for (var j = i; j < catalogObjects.Count; j++)
                {
                    if (func(catalogObjects[j]).CompareTo(func(catalogObjects[i])) >= 0) continue;
                    var tmp = catalogObjects[i];
                    catalogObjects[i] = catalogObjects[j];
                    catalogObjects[j] = tmp;
                }
            }

            return catalogObjects;
        }

        public IList<ICatalogObject> CustomSearch(CustomSearchDel func)
        {
            var result = new List<ICatalogObject>();
            foreach (var catalogObject in catalogObjects)
            {
                if (func(catalogObject))
                {
                    result.Add(catalogObject);
                }
            }
            return result;
        }

        public IList<ICatalogObject> SortByYear(bool isReverse = false)
        {
            catalogObjects.Sort(new Comparers.SortByYear { IsReverse = isReverse });
            return catalogObjects;
        }

        public List<Book> SearchBooksByAuthors(string name)
        {
            var arrResult = new List<Book>();
            foreach (var m in catalogObjects)
            {              
                if (!(m is Book book)) break;
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

        public Dictionary<string, List<Book>> GetSortBooks(string symb)
        {
            var arr = new List<Book>();
            var books = new Dictionary<string, List<Book>>();
            foreach (var m in catalogObjects)
            {
                if (!(m is Book book)) continue;
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

        public Dictionary<int, List<ICatalogObject>> GroupByYear()
        {
            var arr = new List<ICatalogObject>();
            var objects = new Dictionary<int, List<ICatalogObject>>();
            foreach (var m in catalogObjects)
            {
                if (m is Patent) continue;
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
