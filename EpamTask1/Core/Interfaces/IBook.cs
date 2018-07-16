﻿using EpamTask1.Core.Interfaces.CoreLibrary;

namespace EpamTask1.Core.Interfaces
{
    public interface IBook : ILetters
    {      
        string Isbn { get; set; }
        string[] Authors { get; set; }
    }
}
