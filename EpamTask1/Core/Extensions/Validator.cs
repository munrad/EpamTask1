using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Attributes;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Interfaces;

namespace EpamTask1.Core.Extensions
{
    public class Validator
    {
        public static void ValidateProp<T>(T myObject)
        {
            var prop = myObject.GetType().GetProperties();
            foreach (var propertyInfo in prop)
            {
                var attr = propertyInfo.CustomAttributes;
                if (attr.Any(m => m.AttributeType == typeof(IsNotNullOrEmpty)))
                    IsAnyNullOrEmpty(myObject);
            }
        }

        private static bool IsAnyNullOrEmpty(object myObject)
        {
            return myObject.GetType().GetProperties()
                .Where(pi => pi.GetValue(myObject) is string)
                .Select(pi => (string)pi.GetValue(myObject))
                .Any(string.IsNullOrEmpty);
        }
    }
}
