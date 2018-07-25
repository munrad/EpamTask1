using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Classes
{
    public class Archive
    {
        public User User { get; set; }
        public Book Book { get; set; }
        public Paper Paper { get; set; }
        public Patent Patent { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateNeedReturn { get; set; }
        public DateTime DateReturn { get; set; }

        public Archive(User user, ICatalogObject obj, int dateNeedReturn)
        {
            User = user;
            DateNeedReturn = DateTime.Now.AddDays(dateNeedReturn);
            DateOfIssue = DateTime.Now;
            switch (obj)
            {
                case Book book:         
                    Book = book;
                    break;
                case Paper paper:
                    Paper = paper;
                    break;
                case Patent patent:
                    Patent = patent;
                    break;
            }
        }
    }
}
