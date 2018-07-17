using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Interfaces;
using NUnit.Framework;


namespace TestsEpamTask1
{

    class Program
    {
        [Test]
        static void Main(string[] args)
        {
            var lib = new Library();
            lib.Add(new Book());
            lib.Add(new Book { Isbn = "2" });
            lib.Add(new Book());
            lib.Add(new Book { Isbn = "1" });
            lib.Add(new Book { Name = "3" });
            lib.Add(new Book { Name = "4" });
            lib.Add(new Paper { Name = "4" });
            lib.Remove(new Book());
            var t = lib.GetAllObjects();
            var t1 = lib.SearchByName("4");
            lib.Add(new Book { PubYear = 1994 });
            lib.Add(new Book { PubYear = 1995 });
            lib.Add(new Book { PubYear = 1999 });
            var t3 = lib.SortByYear(true);
            var t4 = lib.SortByYear(false);
            lib.Add(new Book { Authors = new List<string> { "Lol", "Kek"} });
            lib.Add(new Book { Authors = new List<string> { "Lol", "Kek", "Cheburek" } });
            var t5 = lib.SearchBooksByAuthors("Kek");
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 33" });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 22" });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 22" });
            lib.Add(new Book { PubName = "Kek 33" });
            lib.Add(new Book { PubName = "Kuk" });
            var t6 = lib.GetSortBooks("Kek");
            lib.Add(new Paper { PubYear = 1994 });
            lib.Add(new Patent { PubDate = new DateTime(1994, 01, 01) });
            var t7 = lib.GroupByYear();
            lib.Save();
        }
    }
}
