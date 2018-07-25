using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EpamTask1.Core;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Extensions;
using EpamTask1.Core.Interfaces.Catalog;
using static EpamTask1.Core.Catalog;

namespace EpamTask1
{
    public class Library
    {
        public readonly Users Users;
        public readonly Archives Archives;
        public readonly Catalog Catalog;

        public Library()
        {
            Archives = new Archives();
            Users = new Users();
            Catalog = new Catalog();
        }

        public void Save(string objectName)
        {
            var list = new List<string>();
            if (!(Catalog.GetAllObjects() is List<ICatalogObject> catalogLocal))
            {
                throw new Exception("Каталог пуст!");
            }
            foreach (var catItem in catalogLocal)
            {
                Extensions.Serializer(list, catItem);
            }

            File.WriteAllLines(objectName, list);
        }

        public void Load(string objectName, bool isForce = false)
        {
            var obj = File.ReadAllLines(objectName).ToList();
            Extensions.Deserialize(ref Catalog.CatalogObjects, obj, isForce);
        }
    }
}
