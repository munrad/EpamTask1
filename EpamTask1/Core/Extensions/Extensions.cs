using EpamTask1.Core.Interfaces.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Interfaces;
using System.IO;

namespace EpamTask1.Core.Extensions
{
    internal class Extensions
    {
        public static void Deserialize(ref List<ICatalogObject> obj, List<string> file)
        {
            try
            {
                foreach (var item in file)
                {
                    var tmp = item.Split('/');
                    var tmp1 = tmp[1].Split('>');
                }
            }
            catch (Exception e)
            {

            }
        }

        public static void Serializer<T>(ref List<string> list, T obj)
        {
            var type = typeof(T);
            var prop = type.GetProperties();
            var str = $"{type.FullName}/";
            str = prop.Aggregate(str, (current, propertyInfo) =>
            {
                var result = current + $"{propertyInfo.Name}:";
                if (propertyInfo.PropertyType == typeof(List<string>))
                {
                    var propVal = string.Empty;
                    if (propertyInfo.GetValue(obj, null) is List<string> listTmp)
                    {
                        propVal = listTmp.Cast<object>().Aggregate(propVal, (current1, n) => current1 + $"{n}|");
                        propVal = propVal.Remove(propVal.LastIndexOf('|'), 1);
                    }
                    result += $"{propVal}>";
                }
                else
                {
                    result += $"{propertyInfo.GetValue(obj)}>";
                }
                return result;
            });
            str = str.Remove(str.LastIndexOf('>'), 1);
            list.Add(str);
        }

        public static void AddToLog(string message)
        {
            File.AppendAllText("error.log", $"{DateTime.Now.ToUniversalTime()}: {message}{Environment.NewLine}");
        }
    }
}
