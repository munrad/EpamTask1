using System;

namespace EpamTask1.Core.Interfaces.Catalog
{
    public interface ICatalogObject : IComparable
    {
        string Name { get; set; }
        string Note { get; set; }
        int CountPages { get; set; }
        int Price { get; set; }
        int PubYear { get; set; }
    }
}
