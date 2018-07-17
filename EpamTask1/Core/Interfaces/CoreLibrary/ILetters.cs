namespace EpamTask1.Core.Interfaces.CoreLibrary
{
    public interface ILetters : ILibraryObject
    {
        string PubCity { get; set; }
        string PubName { get; set; }
        int CountCopies { get; set; }
    }
}
