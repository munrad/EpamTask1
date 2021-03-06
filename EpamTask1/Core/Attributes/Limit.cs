﻿using System;

namespace EpamTask1.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class Limit : Attribute
    {
        public int CountPages { get; set; }
        public int Lenght { get; set; }
        public int PubYear { get; set; }
    }
}
