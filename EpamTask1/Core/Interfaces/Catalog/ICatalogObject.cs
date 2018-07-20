using System;

namespace EpamTask1.Core.Interfaces.Catalog
{
    public interface ICatalogObject : IComparable
    {
        int PubYear { get; set; }
    }
}
