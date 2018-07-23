using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Extensions;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;
using EpamTask1.Core.Interfaces.CoreLibrary;

namespace EpamTask1.Core
{
    public class Users
    {
        public List<IUser> ListUsers;

        public Users()
        {
            ListUsers = new List<IUser>();
        }

        //1 and 3 task
        public List<IUser> GetUsers(Func<IUser, int> func, int value)
        {
            return ListUsers.Where(m => func(m) > value) 
                as List<IUser>;
        }

        public Dictionary<IUser, List<string>> GetPubList()
        {
            var list = new Dictionary<IUser, List<string>>();
            var catalog = Catalog.GetAllObjects() as List<ICatalogObject>;
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
