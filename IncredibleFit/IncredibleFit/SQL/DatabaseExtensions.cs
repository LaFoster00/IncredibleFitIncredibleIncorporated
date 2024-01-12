using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.IncredibleFit.SQL
{
    public static class DatabaseExtensions
    {
        /*public static List<T> ToObjectList<T>(this OracleDataReader reader)
        {
            TypeInfo typeInfo = typeof(T).GetTypeInfo();
            var entityName = typeInfo.GetCustomAttribute(typeof(Entity));
            if (entityName == null)
                return null;
            var list = new List<T>();
            while (reader.Read())
            {
                var newInstance = Activator.CreateInstance<T>();
                foreach (var propertyInfo in typeInfo.GetProperties())
                {
                    var fieldAttribute = propertyInfo.GetCustomAttribute<Field>();
                    if (fieldAttribute == null)
                        continue;
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetName(i).Equals(fieldAttribute.name))
                        {
                            if (!reader.GetValue(i).Equals(DBNull.Value))
                            {
                                propertyInfo.SetValue(newInstance,
                                    Convert.ChangeType(
                                        reader.GetValue(i),
                                        reader.GetFieldType(i)));
                            }

                            break;
                        }
                    }
                }
                list.Add(newInstance);
            }
            return list;
        }*/
    }
}
