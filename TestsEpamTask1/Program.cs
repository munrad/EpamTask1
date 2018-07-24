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
            lib.Add(new Book { Name = "3" });
            lib.Add(new Book { Name = "4" });
            lib.Add(new Paper { Name = "4" });
            var t1 = lib.SearchByName("4");
        }
    }
}
