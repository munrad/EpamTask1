using System;
using EpamTask1.Core.Extensions;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core
{
    sealed class Catalog : ICatalog
    {
        private ICatalogObject[] catalogObjects = new ICatalogObject[0];

        public int PubYear { get; set; }

        public void Add(ICatalogObject obj)
        {
            var arr = new ICatalogObject[catalogObjects.Length + 1];
            catalogObjects.CopyTo(arr, 0);
            arr[catalogObjects.Length] = obj;
            catalogObjects = arr;
        }

        public void Remove(ICatalogObject obj)
        {
            var arr = Array.FindAll(catalogObjects, m => !m.Equals(obj));
            catalogObjects = arr;
        }

        public ICatalog GetAllObjects()
        {
            return this;
        }

        public ICatalogObject[] SearchByName(string name)
        {
            var count = 0;
            var result = new ICatalogObject[count];

            foreach (var t in catalogObjects)
            {
                if (!(t is IBook book)) continue;
                if (book.Name != name) continue;
                Array.Resize(ref result, ++count);
                result[count - 1] = t;

                if (!(t is IPaper paper)) continue;
                if (paper.Name != name) continue;
                Array.Resize(ref result, ++count);
                result[count - 1] = t;

                if (!(t is IPatent patent)) continue;
                if (patent.Name != name) continue;
                Array.Resize(ref result, ++count);
                result[count - 1] = t;
            }
            return result;
        }

        public ICatalogObject[] SortByYear(bool isReverse = false)
        {
            Array.Sort(catalogObjects, new Comparers.SortByYear{ IsReverse = isReverse });
            return catalogObjects;
        }

        public IBook[] SearchBooksByAuthors(string name)
        {
            var count = 0;
            var arrResult = new IBook[count];
            foreach (var m in catalogObjects)
            {              
                if (!(m is IBook book)) break;
                var arrAuthors = book.Authors;             
                if (arrAuthors == null) break;
                foreach (var t in arrAuthors)
                {
                    if (!t.Contains(name)) continue;
                    Array.Resize(ref arrResult, ++count);
                    arrResult[count - 1] = book;
                    break;
                }
            }
            return arrResult;
        }

        public IBook[][] GetSortBooks(string symb)
        {
            var count = 0;
            var countArr = 0;
            var arrResult = new IBook[count];
            var books = new IBook[0][];
            foreach (var m in catalogObjects)
            {
                if (!(m is IBook book)) continue;
                if (book.PubName == null) continue;
                if (!book.PubName.Contains(symb)) continue;
                Array.Resize(ref arrResult, ++count);
                arrResult[count - 1] = book;
            }
            Array.Sort(arrResult, new Comparers.SortByPubName());
            for (var i = 0; i < arrResult.Length;)
            {
                var res = Array.FindAll(arrResult, n => n.PubName == arrResult[i].PubName);
                var index = Array.FindLastIndex(arrResult, t => t.PubName == arrResult[i].PubName);
                Array.Reverse(arrResult);
                Array.Resize(ref arrResult, arrResult.Length - (index + 1));
                Array.Reverse(arrResult);
                Array.Resize(ref books, ++countArr);
                books[countArr - 1] = res;
            }
            return books;
        }

        public ICatalogObject[][] GroupByYear()
        {
            var countArr = 0;
            var objects = new ICatalogObject[countArr][];
            var arrResult = SortByYear();
            for (var i = 0; i < arrResult.Length;)
            {
                if (arrResult[i] is IPatent) continue;
                var res = Array.FindAll(arrResult, n => n.PubYear == arrResult[i].PubYear);
                var index = Array.FindLastIndex(arrResult, t => t.PubYear == arrResult[i].PubYear);
                Array.Reverse(arrResult);
                Array.Resize(ref arrResult, arrResult.Length - (index + 1));
                Array.Reverse(arrResult);
                Array.Resize(ref objects, ++countArr);
                objects[countArr - 1] = res;
            }
            return objects;
        }
    }
}
