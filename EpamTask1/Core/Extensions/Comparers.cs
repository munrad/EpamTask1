using System.Collections.Generic;
using EpamTask1.Core.Interfaces;
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

                    return 0;
                }
                if (x?.PubYear < y?.PubYear)
                    return 1;

                if (x?.PubYear > y?.PubYear)
                    return -1;

                return 0;
            }
        }

        public class SortByPubName : IComparer<IBook>
        {
            public int Compare(IBook x, IBook y)
            {
                return string.CompareOrdinal(x?.PubName, y?.PubName);
            }
        }
    }
}
