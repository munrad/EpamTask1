using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Extensions;

namespace EpamTask1.Core
{
    public class Archives
    {
        public List<Archive> ListArchive;

        public Archives()
        {
            ListArchive = new List<Archive>();
        }

        public void Add(Archive obj, bool isForce = true)
        {
            Validator.ValidateProp(obj, isForce);
            ListArchive.Add(obj);
        }

        public Dictionary<DateTime, User> GetFirstIssueForUser()
        {
            var dic = new Dictionary<DateTime, User>();
            return dic;
        }
    }
}
