using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL
{
    /// <summary>
    /// Marks a class as an Entity(Table) in a database, with a specific name that is defined
    /// independent of the class name
    /// </summary>
    [AttributeUsage(AttributeTargets.Class), DebuggerDisplay("Entity: {Name}")]
    public class Entity : Attribute
    {
        public readonly string Name;

        public Entity(string name)
        {
            this.Name = name;
        }
    }

    /// <summary>
    /// Helper extensions for entity related type checks
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Cache for already accessed types for faster accessing of type information
        /// </summary>
        private static readonly Dictionary<Type, Entity?> Entities = new();

        /// <summary>
        /// Returns the entity attribute in case it exists
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Entity? TryGetEntity(this Type type)
        {
            if (Entities.TryGetValue(type, out var entity))
            {
                return entity;
            }
            else
            {
                Entities.Add(type, type.GetCustomAttribute<Entity>());
                return Entities[type];
            }
        }

        /// <summary>
        /// Returns the entity name (if existent) of the type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string? TryGetEntityName(this Type type)
        {
            return type.TryGetEntity()?.Name;
        }
    }

    /// <summary>
    /// Holds all necessary information needed to map a property to a field in a database entity
    /// </summary>
    [AttributeUsage(AttributeTargets.Property), DebuggerDisplay("Field: {Name}, {Type.ToString()}, {Size}")]
    public class Field : Attribute
    {
        public readonly string Name;
        public readonly OracleDbType? Type = null;
        public readonly int Size = 0;

        public Field(string name)
        {
            this.Name = name;
        }

        public Field(string name, OracleDbType type)
        {
            this.Name = name;
            this.Type = type;
        }

        public Field(string name, OracleDbType type, int size)
        {
            this.Name = name;
            this.Type = type;
            this.Size = size;
        }
    }

    /// <summary>
    /// Helper extensions for field related type checks
    /// </summary>
    public static class FieldExtensions
    {
        /// <summary>
        /// Cache for already accessed types for faster accessing of type information
        /// </summary>
        private static readonly Dictionary<PropertyInfo, Field?> Fields = new();

        /// <summary>
        /// Returns the field attribute (if existent) of a property
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Field? TryGetField(this PropertyInfo info)
        {
            if (Fields.TryGetValue(info, out var field))
            {
                return field;
            }
            Fields.Add(info, info.GetCustomAttribute<Field>());
            return Fields[info];
        }

        public static string? TryGetFieldName(this PropertyInfo info)
        {
            return info.TryGetField()?.Name;
        }

        public static OracleDbType? TryGetFieldOracleDbType(this PropertyInfo info)
        {
            return info.TryGetField()?.Type;
        }
    }

    /// <summary>
    /// Marks a field as server generated (e.g. Auto Increment).
    /// Causes the oracle database to read back this value after an object is inserted into a table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ServerGenerated : Attribute
    {

    }

    /// <summary>
    /// Helper extensions for ID related type checks
    /// </summary>
    public static class ServerGeneratedExtensions
    {
        /// <summary>
        /// Cache for already accessed types for faster accessing of type information
        /// </summary>
        private static readonly Dictionary<PropertyInfo, ServerGenerated?> ServerGenerateds = new();

        /// <summary>
        /// Returns the ServerGenerated attribute (if existent) of a property
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static ServerGenerated? TryGetServerGenerated(this PropertyInfo info)
        {
            if (ServerGenerateds.TryGetValue(info, out var serverGenerated))
            {
                return serverGenerated;
            }
            ServerGenerateds.Add(info, info.GetCustomAttribute<ServerGenerated>());
            return ServerGenerateds[info];
        }
    }

    /// <summary>
    /// Marks a field as primary identifier.
    /// These attributes will be used to identify an object for selective operations such as delete.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ID : Attribute
    {

    }

    /// <summary>
    /// Helper extensions for ID related type checks
    /// </summary>
    public static class IdExtensions
    {
        /// <summary>
        /// Cache for already accessed types for faster accessing of type information
        /// </summary>
        private static readonly Dictionary<PropertyInfo, ID?> Ids = new();

        /// <summary>
        /// Returns the ID attribute (if existent) of a property
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static ID? TryGetId(this PropertyInfo info)
        {
            if (Ids.TryGetValue(info, out var id))
            {
                return id;
            }
            Ids.Add(info, info.GetCustomAttribute<ID>());
            return Ids[info];
        }
    }

    /// <summary>
    /// Allows a field to specify routine that should be called to populate its parameter instead of a literal.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property), DebuggerDisplay("{Subroutine}")]
    public class CreateWithSubroutine : Attribute
    {
        public readonly string Subroutine;

        public CreateWithSubroutine(string subroutine)
        {
            this.Subroutine = subroutine;
        }
    }

    /// <summary>
    /// Helper extensions for CreateWithSubroutine related type checks
    /// </summary>
    public static class SubroutineExtensions
    {
        /// <summary>
        /// Cache for already accessed types for faster accessing of type information
        /// </summary>
        private static readonly Dictionary<PropertyInfo, CreateWithSubroutine?> Subroutines = new();

        /// <summary>
        /// Returns the subroutine attribute (if existent) of a property
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static CreateWithSubroutine? TryGetCreateWithSubroutine(this PropertyInfo info)
        {
            if (Subroutines.TryGetValue(info, out var subroutine))
                return subroutine;
            Subroutines.Add(info, info.GetCustomAttribute<CreateWithSubroutine>());
            return Subroutines[info];
        }

        /// <summary>
        /// Returns the subroutine (if existent) of a property
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string? TryGetCreateSubroutine(this PropertyInfo info)
        {
            return info.TryGetCreateWithSubroutine()?.Subroutine;
        }
    }
}
