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
    public class Catalog
    {       
        public List<ICatalogObject> CatalogObjects;

        public delegate T CustomSortDel<out T>(ICatalogObject obj);

        public delegate bool CustomSearchDel(ICatalogObject obj);

        public Catalog()
        {           
            CatalogObjects = new List<ICatalogObject>();
        }

        public void Add(ICatalogObject obj, bool isForce = true)
        {
            Validator.ValidateProp(obj, isForce);
            CatalogObjects.Add(obj);
        }

        public void Remove(ICatalogObject obj)
        {
            CatalogObjects.RemoveAll(m => m.Equals(obj));
        }

        public List<ICatalogObject> GetAllObjects()
        {
            return CatalogObjects;
        }

        public List<ICatalogObject> SearchByName(string name)
        {
            var result = new List<ICatalogObject>();

            foreach (var t in CatalogObjects)
            {
                if (t.Name.Equals(name))
                {
                    result.Add(t);
                }
            }
            return result;
        }

        public List<ICatalogObject> CustomSort<T>(CustomSortDel<T> func) where T : IComparable
        {
            for (var i = 0; i < CatalogObjects.Count; i++)
            {
                for (var j = i; j < CatalogObjects.Count; j++)
                {
                    if (func(CatalogObjects[j]).CompareTo(func(CatalogObjects[i])) >= 0) continue;
                    var tmp = CatalogObjects[i];
                    CatalogObjects[i] = CatalogObjects[j];
                    CatalogObjects[j] = tmp;
                }
            }

            return CatalogObjects;
        }

        public List<ICatalogObject> CustomSearch(CustomSearchDel func)
        {
            var result = new List<ICatalogObject>();
            foreach (var catalogObject in CatalogObjects)
            {
                if (func(catalogObject))
                {
                    result.Add(catalogObject);
                }
            }
            return result;
        }

        public List<ICatalogObject> SortByYear(bool isReverse = false)
        {
            CatalogObjects.Sort(new Comparers.SortByYear { IsReverse = isReverse });
            return CatalogObjects;
        }

        public List<Book> SearchBooksByAuthors(string name)
        {
            var arrResult = new List<Book>();
            foreach (var m in CatalogObjects)
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
            foreach (var m in CatalogObjects)
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
            foreach (var m in CatalogObjects)
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

        public Dictionary<string, List<ILetters>> GetSortCatalogByPublishers()
        {
            var list = CatalogObjects.OfType<ILetters>().ToList();
            var dic = list.GroupBy(m => m.PubName).Select(m =>
            {
                return new
                {
                     PubName = m.Key,
                     Letters = m.Select(n => n).ToList()
                };
            }).ToDictionary(m => m.PubName, m => m.Letters);
            var lastElem = dic.Last();
            var lastVal = lastElem.Value.OrderBy(m => m.PubYear).ToList();
            dic[lastElem.Key] = lastVal;
            return dic;
        }

    }
}
