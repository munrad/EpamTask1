using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Interfaces.CoreLibrary
{
    public interface ILibraryObject : ICatalogObject
    {
        string Name { get; set; }       
        string Note { get; set; }
        int CountPages { get; set; }
        int Price { get; set; }
    }
}
