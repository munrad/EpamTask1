using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Extensions;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core
{
    public class Users
    {
        public List<User> ListUsers;

        public Users()
        {
            ListUsers = new List<User>();
        }

        //1 and 3 task
        public List<User> GetUsers(Func<User, int> func, int value)
        {
            return ListUsers.Where(m => func(m) > value) 
                as List<User>;
        }

        public Dictionary<User, List<string>> GetPubList()
        {
            var list = new Dictionary<User, List<string>>();
            var catalog = Catalog.CatalogObjects;
            try
            {
                foreach (var listUser in ListUsers)
                {
                    list.Add(listUser, catalog?.Where(m =>
                    {
                        if (!(m is ILetters letters)) throw new InvalidCastException(nameof(m));
                        return letters.PubCity == listUser.City;
                    }).Select(n =>
                    {
                        if (!(n is ILetters letters)) throw new InvalidCastException(nameof(n));
                        return letters.PubCity;
                    }).ToList());
                }
            }
            catch (Exception e)
            {
                Logger.AddToLog(e.Message);
            }

            return list;
        }
    }
}
