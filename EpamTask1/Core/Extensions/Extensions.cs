using EpamTask1.Core.Interfaces.Catalog;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public static void Deserialize(ref List<ICatalogObject> obj, List<string> file, bool isForce = false)
        {
            try
            {            
                var objTmpList = new List<ICatalogObject>();
                foreach (var item in file)
                {             
                    var objMySerialize = item.Split('/');                   
                    var arrTypeObj = objMySerialize[1].Split('>');
                    
                    var typeObj = Activator.CreateInstance(Type.GetType(objMySerialize[0]) 
                                                           ?? throw new InvalidOperationException());
                    foreach (var allProp in arrTypeObj)
                    {
                        var typeAndProp = allProp.Split('\\');                     
                        var nameAndVal = typeAndProp[1].Split(':');
                        var name = nameAndVal[0];
                        var val = nameAndVal[1];
                        ObjectCreator(ref typeObj, name, val);                       
                    }

                    Validator.ValidateProp(typeObj, isForce);
                    objTmpList.Add(typeObj as ICatalogObject);
                }
                
                obj = objTmpList;
            }
            catch (Exception e)
            {
                Logger.AddToLog(e.Message);
            }
        }

        private static void ObjectCreator<T>(ref T obj, string name, string val)
        {
            var t = obj.GetType();
            var prop = t.GetProperties();
            foreach (var propertyInfo in prop)
            {
                if (!propertyInfo.Name.Equals(name)) continue;
                if (propertyInfo.PropertyType == typeof(List<string>))
                {
                    var arr = val.Split('|').ToList();
                    propertyInfo.SetValue(obj, arr);
                }
                else if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    var date = DateTime.Parse(val);
                    propertyInfo.SetValue(obj, date);
                }
                else if(propertyInfo.PropertyType == typeof(int))
                {
                    propertyInfo.SetValue(obj, int.Parse(val));
                }
                else
                {
                    propertyInfo.SetValue(obj, val);
                }
            }
        }

        public static void Serializer<T>(List<string> list, T obj)
        {
            var type = typeof(T);
            var prop = type.GetProperties();
            var builder = new StringBuilder();
            builder.Append($"{type.FullName}/");
            builder = prop.Aggregate(builder, (current, propertyInfo) =>
            {
                builder.Append($"{current}{propertyInfo.PropertyType}\\{propertyInfo.Name}:");
                if (propertyInfo.PropertyType == typeof(List<string>))
                {
                    var propVal = string.Empty;
                    if (propertyInfo.GetValue(obj, null) is List<string> listTmp)
                    {
                        propVal = listTmp.Cast<object>().Aggregate(propVal, (current1, n) => current1 + $"{n}|");
                        propVal = propVal.Remove(propVal.LastIndexOf('|'), 1);
                    }
                    builder.Append($"{propVal}>");
                }
                else if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    var date = (DateTime)propertyInfo.GetValue(obj, null);
                    builder.Append($"{date.ToShortDateString()}>");
                }
                else
                {
                    builder.Append($"{propertyInfo.GetValue(obj)}>");
                }
                return builder;
            });

            builder = builder.Remove(builder.ToString().LastIndexOf('>'), 1);
            list.Add(builder.ToString());
        }
    }
}
