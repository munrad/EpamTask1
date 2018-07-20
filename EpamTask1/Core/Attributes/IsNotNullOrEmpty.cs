using System;

namespace EpamTask1.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IsNotNullOrEmpty : Attribute { }
}
