using System;
using EpamTask1.Core.Interfaces.CoreLibrary;

namespace EpamTask1.Core.Interfaces
{
    public interface IPaper : ILetters
    {
        int Number { get; set; }       
        string Issn { get; set; }
        DateTime Date { get; set; }
    }
}
