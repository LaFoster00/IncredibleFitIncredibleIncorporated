// Written by Lasse Foster https://github.com/LaFoster00

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace IncredibleFit.SQL
{
    /// <summary>
    /// Database extensions for common operations of database related objects
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Returns if a type is a nullable value type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Returns the nullable underlying type (if type is of nullable value type)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Type GetNullableUnderlying(this Type type)
        {
            if (type.IsNullable())
                return Nullable.GetUnderlyingType(type) ?? throw new InvalidOperationException();

            return type;
        }

        /// <summary>
        /// The Field Properties and Field Attributes for a given type
        /// Fields is not IReadOnlyList since we want to use FindIndex which is only available on lists
        /// </summary>
        public static Dictionary<Type, (IReadOnlyList<PropertyInfo> Properties, List<Field> Fields)> EntityFields = new();

        /// <summary>
        /// Returns the Field Properties and Field Attributes for a given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static (IReadOnlyList<PropertyInfo> Properties, List<Field> Fields) GetDbFields(this Type? type)
        {
            // Return empty lists in case the type is null
            if (type == null)
                return (new List<PropertyInfo>(), new List<Field>());

            // Return the cached lists
            if (EntityFields.TryGetValue(type, out var f))
                return f;

            // Get the properties with a field attribute
            var properties = type.GetProperties().Where(info => info.TryGetField() != null).ToList();
            // Get the field attributes for those properties
            var fields = properties.Select(info => info.TryGetField()!).ToList();

            EntityFields.Add(type, (properties, fields));
            return EntityFields[type];
        }

        /// <summary>
        /// Converts an OracleDataReader to a list of objects of type T.
        /// Only fields that are both existent in the database and the c# object will be assigned a value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="debugMissingFields">If set to true missing fields in the C# class will be printed to the console</param>
        /// <returns></returns>
        public static List<T> ToObjectList<T>(this OracleDataReader? reader, bool debugMissingFields = false)
        {
            if (reader == null)
            {
                Debug.WriteLine("Reader is null. Cant convert to list of objects.");
                return new List<T>();
            }

            // Check if the type the reader is supposed to be converted to is an entity at all
            var type = typeof(T);
            if (type.TryGetEntity() == null)
                return new List<T>();

            var objects = new List<T>();
            // Get the field information for this type. This function call is cached an should provide vastly faster performance
            var fields = type.GetDbFields();
            while (reader.Read())
            {
                // Create a new instance of the c# object (with its private parameterless constructor) to assign the values to 
                var newInstance = (T)Activator.CreateInstance(typeof(T), true)!;
                // Go over all properties that are marked as field for this type and 
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    // Get the c# object field index of the current reader column 
                    var fieldIndex = fields.Fields.FindIndex(field => field.Name == reader.GetName(i));
                    if (fieldIndex == -1)
                    {
                        if (debugMissingFields)
                            Debug.WriteLine(
                                $"Field '{reader.GetName(i)}' in reader does not exist in C# Entity '{type.Name}'");
                        continue;
                    }

                    // Get the property info and field attribute for the current column
                    var propertyInfo = fields.Properties[fieldIndex];
                    var field = fields.Fields[fieldIndex];
                    // Get the value of the field and set it to null in case a db null value is returned
                    var value = (reader.GetValue(i) == DBNull.Value ? null : reader.GetValue(i));
                    // Set the value of the field property in the c# object
                    propertyInfo.SetValue(newInstance, value.ToSystemObject(propertyInfo.PropertyType, field.Type));
                }
                // Add the new object instance to the output list
                objects.Add(newInstance);
            }

            return objects;
        }

        /// <summary>
        /// Converts an object to a nullable reference in case it is supposed to be.
        /// Only converts objects to nullables in case target type is typeof(Nullable<>).
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType">The property type. Also in case of a nullable value type</param>
        /// <returns></returns>
        // Target type should be the property type including the nullable so no underlying types
        public static object? ToNullable(this object? value, Type targetType)
        {
            // Only convert to nullable if that is the target type
            if (!targetType.IsNullable())
                return value;

            // If the value is already nullable value return the value directly
            if (value != null && value.GetType() == targetType)
                return value;
            
            // Return a new instance of the nullable value type with value as its content
            return Activator.CreateInstance(targetType, new[] { value });
        }

        /// <summary>
        /// Converts an oracle object to a system object.
        /// The system object is then converted to its enum object in case it is supposed to be an enum.
        /// Will also convert the object to a Nullable<> of any type if needed
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="systemType">The property type. Also in case of a nullable value type</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Is thrown in case a conversion from a system object of one
        /// type to system object of another type (based on OracleDbType) is not implemented.</exception>
        public static object? ToSystemObject(this object? o, Type systemType, OracleDbType? type = null)
        {
            // In case object if null return null directly and convert to nullable if needed
            if (o is null)
                return o.ToNullable(systemType);

            // Convert from oracle type to system type
            object? sysObject = o switch
            {
                OracleDecimal or => or.Value,
                OracleString os => os.Value,
                _ => o
            };

            // Get fallback oracleDbType in case it wasn't specified for this invocation
            type ??= OracleDatabase.TypeToDb[systemType.GetNullableUnderlying()];

            // Convert from one system type to another in case the OracleDbType doesn't fit the current system object
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

            // Convert the value to nullable and then to enum if needed
            return sysObject.ToNullable(systemType).ToDomain(systemType);
        }
    }
}
