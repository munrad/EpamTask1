using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public ICatalogObject[] SortByYear(bool isReverse)
        {
            Array.Sort(catalogObjects, new Comparers.SortByYear{ IsReverse = isReverse });
            return catalogObjects;
        }

        public IBook[] SearchBooksByAuthors(string name)
        {
            var count = 0;
            var arrResult = new IBook[count];
            Array.ForEach(catalogObjects, m =>
            {              
                if (!(m is IBook book)) return;
                var arrAuthors = book.Authors;             
                if (arrAuthors == null) return;
                foreach (var t in arrAuthors)
                {
                    if (t.Contains(name))
                    {
                        Array.Resize(ref arrResult, ++count);
                        arrResult[count - 1] = book;
                        break;
                    }
                }
            });
            return arrResult;
        }

        public IBook[][] GetSortBooks(string symb)
        {
            var count = 0;
            var arrResult = new IBook[count];
            var books = new IBook[count][];
            Array.ForEach(catalogObjects, m =>
            {
                if (!(m is IBook book)) return;
                if (book.PubName.Contains(symb))
                {

                }
            });
            return books;
        }
    }
}
