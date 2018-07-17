using System;
using System.Collections.Generic;
using EpamTask1.Core.Interfaces.CoreLibrary;

namespace EpamTask1.Core.Interfaces
{
    public interface IPatent : ILibraryObject
    {
        int RegNumber { get; set; }      
        string Country { get; set; }
        List<string> Inventors { get; set; }
        DateTime AppDate { get; set; }
        DateTime PubDate { get; set; }
    }
}
