using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;


namespace TestsEpamTask1
{

    class Program
    {
        static void Main(string[] args)
        {
            var lib = new Library();
            lib.Add(new Patent { PubDate = new DateTime(1994, 01, 01) });
            lib.Add(new Book { Authors = new List<string> { "h", "u", "k" } });
            lib.Add(new Book { Isbn = "2" });
            lib.Add(new Book());
            lib.Add(new Book { Isbn = "1" });
            lib.Add(new Book { Name = "3" });
            lib.Add(new Book { Name = "4" });
            lib.Add(new Paper { Name = "4" });
            lib.Add(new Book { PubYear = 1994 });
            lib.Add(new Book { PubYear = 1995 });
            lib.Add(new Book { PubYear = 1999 });
            lib.Add(new Book { Authors = new List<string> { "Lol", "Kek" } });
            lib.Add(new Book { Authors = new List<string> { "Lol", "Kek", "Cheburek" } });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 33" });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 22" });
            lib.Add(new Book { PubName = "Kek" });
            lib.Add(new Book { PubName = "Kek 22" });
            lib.Add(new Book { PubName = "Kek 33" });
            lib.Add(new Book { PubName = "Kuk" });
            lib.Add(new Paper { PubYear = 1994 });
            lib.Add(new Patent { PubDate = new DateTime(1994, 01, 01) });
            var t = lib.Sort<ICatalogObject>(m => m);
        }
    }
}
