using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL
{
    public static class DatabaseExtensions
    {
        public static List<T> ToObjectList<T>(this OracleDataReader? reader)
        {
            if (reader == null)
            {
                Debug.WriteLine("Reader is null. Cant convert to list of objects.");
                return new List<T>();
            }

            var typeInfo = typeof(T).GetTypeInfo();
            var entityName = typeInfo.GetCustomAttribute(typeof(Entity));
            if (entityName == null)
                return new List<T>();

            var list = new List<T>();
            while (reader.Read())
            {
                var newInstance = (T)Activator.CreateInstance(typeof(T), true)!;
                foreach (var propertyInfo in typeInfo.GetProperties())
                {
                    var fieldAttribute = propertyInfo.GetCustomAttribute<Field>();
                    if (fieldAttribute == null)
                        continue;
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.GetName(i).Equals(fieldAttribute.Name))
                            continue;
                        if (reader.GetValue(i).Equals(DBNull.Value))
                            break;
                        object? readerValue = reader.GetValue(i);
                        if (Nullable.GetUnderlyingType(propertyInfo.PropertyType) != null)
                        {
                            var toNullableConverter = ToNullableInfo!.MakeGenericMethod(Nullable.GetUnderlyingType(propertyInfo.PropertyType)!);
                            object? nullable = null;
                            try
                            {
                                nullable = toNullableConverter.Invoke(null, new[]
                                {
                                    readerValue
                                });
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            
                            propertyInfo.SetValue(newInstance, nullable);
                        }
                        else
                        {
                            propertyInfo.SetValue(newInstance, readerValue);
                        }

                        break;
                    }
                }

                list.Add(newInstance);
            }

            return list;
        }

        private static readonly MethodInfo ToNullableInfo =
            typeof(DatabaseExtensions).GetMethod("ToNullable") ?? throw new InvalidOperationException();

        public static T? ToNullable<T>(T value)
        {
            return (T?)value;
        }
    }
}
