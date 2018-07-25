using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1;
using EpamTask1.Core;
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
            var users = new Users();

            lib.Catalog.Add(new Book { Name = "1", PubName = "p1"});
            lib.Catalog.Add(new Book { Name = "2", PubName = "p1" });
            lib.Catalog.Add(new Book { Name = "3", PubName = "p2" });
            lib.Catalog.Add(new Paper { Name = "1", PubName = "p1" });
            lib.Catalog.Add(new Paper { Name = "2", PubName = "p2" });
            lib.Catalog.Add(new Paper { Name = "3", PubName = "p1" });
            lib.Catalog.Add(new Patent { Name = "1"});
            lib.Catalog.Add(new Patent { Name = "2" });
            lib.Catalog.Add(new Patent { Name = "3" });
            var t1 = lib.Catalog.GetSortCatalogByPublishers();
        }
    }
}
