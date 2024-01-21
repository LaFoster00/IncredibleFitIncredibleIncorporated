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
using IncredibleFit.ValueConverters;
using Microsoft.VisualBasic;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace IncredibleFit.SQL
{
    public static class DatabaseExtensions
    {

        public static bool IsNullable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type GetNullableUnderlying(this Type type)
        {
            if (type.IsNullable())
                return Nullable.GetUnderlyingType(type) ?? throw new InvalidOperationException();

            return type;
        }

        public static List<T> ToObjectList<T>(this OracleDataReader? reader)
        {
            if (reader == null)
            {
                Debug.WriteLine("Reader is null. Cant convert to list of objects.");
                return new List<T>();
            }

            var type = typeof(T);
            if (type.TryGetEntity() == null)
                return new List<T>();

            var list = new List<T>();
            while (reader.Read())
            {
                var newInstance = (T)Activator.CreateInstance(typeof(T), true)!;
                foreach (var propertyInfo in type.GetProperties())
                {
                    var fieldAttribute = propertyInfo.TryGetField();
                    if (fieldAttribute == null)
                        continue;
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.GetName(i).Equals(fieldAttribute.Name))
                            continue;
                        if (reader.GetValue(i).Equals(DBNull.Value))
                            break;

                        propertyInfo.SetValue(newInstance, reader.GetValue(i).ToSystemObject(fieldAttribute.Type, propertyInfo.PropertyType));

                        break;
                    }
                }

                list.Add(newInstance);
            }

            return list;
        }

        // Target type should be the property type including the nullable so no underlying types
        public static object? ToNullable(this object? value, Type targetType)
        {
            if (!targetType.IsNullable())
                return value;

            return Activator.CreateInstance(targetType, new[] { value });
        }

        // System type should be the type of the property, will return a domain in case the system type is a domain
        public static object? ToSystemObject(this object? o, OracleDbType? type, Type systemType)
        {
            if (o is null)
                return o.ToNullable(systemType);

            object? sysObject = o switch
            {
                OracleDecimal or => or.Value,
                OracleString os => os.Value,
                _ => o
            };

            type ??= OracleDatabase.TypeToDb[systemType.GetNullableUnderlying()];

            switch (sysObject)
            {
                case decimal dc:
                    switch (type)
                    {
                        case OracleDbType.Decimal:
                            sysObject = dc;
                            break;
                        case OracleDbType.Int32:
                            sysObject = (int)dc;
                            break;
                        case OracleDbType.Int64:
                            sysObject = (long)dc;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                    break;
            }

            return sysObject.ToNullable(systemType).ToDomain(systemType);
        }
    }
}
