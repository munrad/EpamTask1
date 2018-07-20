using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
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
        private const string IsNull = "Обьект пуст или равен null";
        private const string IsZero = "Обьект меньше лиюл равен нулю";
        private const string IsLimit = "Обьект не удовлетворяет условиям органичения значения";

        public static void ValidateProp<T>(T myObject, bool isForce = false)
        {
            var prop = myObject.GetType().GetProperties();
            foreach (var propertyInfo in prop)
            {
                var attr = propertyInfo.CustomAttributes;
                foreach (var m in attr)
                {
                    try
                    {
                        var typeAttr = m.AttributeType;
                        if (typeAttr == typeof(IsNotNullOrEmpty))
                        {
                            var flag = IsAnyNullOrEmpty(propertyInfo, myObject);
                            if (flag)
                                throw new Exception($"{propertyInfo.Name} - {IsNull}");
                        }
                        if (typeAttr == typeof(IsNotLessZero))
                        {
                            var flag = IsAnyNullOrEmpty(propertyInfo, myObject);
                            if (flag)
                                throw new Exception($"{propertyInfo.Name} - {IsZero}");
                        }
                        if (typeAttr == typeof(Limit))
                        {
                            var propAttr = m.NamedArguments;
                            var flag = Limit(propAttr, propertyInfo, myObject);
                            if (flag)
                                throw new Exception($"{propertyInfo.Name} - {IsLimit}");
                        }
                    }
                    catch (Exception e)
                    {          
                        if (isForce)
                            Extensions.AddToLog(e.Message);
                        else
                        {
                            Extensions.AddToLog($"Работа завершена с ошибкой {e.Message}");
                            Environment.Exit(0);
                        }

                    }
                }
            }
        }

        private static bool Limit(IEnumerable<CustomAttributeNamedArgument> nm, PropertyInfo pi, object myObject)
        {
            foreach (var customAttributeNamedArgument in nm)
            {
                
            }
            if (pi.PropertyType != typeof(int)) return false;
            var value = (int)pi.GetValue(myObject);
            if (value <= 0)
            {
                return true;
            }
            return false;
        }

        private static bool IsNotLessZero(PropertyInfo pi, object myObject)
        {
            if (pi.PropertyType == typeof(string))
            {
                var value = (string)pi.GetValue(myObject);
                if (string.IsNullOrEmpty(value))
                {
                    return true;
                }
            }
            if (pi.PropertyType == typeof(List<string>))
            {
                var value = pi.GetValue(myObject) as List<string>;
                if (value == null)
                {
                    return true;
                }
            }
            if (pi.PropertyType == typeof(int))
            {
                var value = (int)pi.GetValue(myObject);
                if (value == 0)
                {
                    return true;
                }
            }
            if (pi.PropertyType == typeof(DateTime))
            {
                var value = (DateTime)pi.GetValue(myObject);
                if (value == new DateTime())
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsAnyNullOrEmpty(PropertyInfo pi, object myObject)
        {
            if (pi.PropertyType != typeof(int)) return false;
            var value = (int)pi.GetValue(myObject);
            if (value <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
