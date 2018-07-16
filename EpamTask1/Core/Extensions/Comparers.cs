using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Extensions
{
    public class Comparers
    {
        public class SortByYear : IComparer<ICatalogObject>
        {
            public bool IsReverse { get; set; } = false;

            public int Compare(ICatalogObject x, ICatalogObject y)
            {
                if (IsReverse)
                {
                    if (x?.PubYear > y?.PubYear)
                        return 1;

                    if (x?.PubYear < y?.PubYear)
                        return -1;

                    else
                        return 0;
                }
                else
                {
                    if (x?.PubYear < y?.PubYear)
                        return 1;

                    if (x?.PubYear > y?.PubYear)
                        return -1;

                    else
                        return 0;
                }
            }
        }
    }
}
