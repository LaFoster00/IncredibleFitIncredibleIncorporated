using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Entity : Attribute
    {
        public readonly string Name;

        public Entity(string name)
        {
            this.Name = name;
        }
    }

    public static class EntityExtensions
    {
        public static Entity? GetEntity(this Type type)
        {
            return type.GetCustomAttribute<Entity>();
        }

        public static string? GetEntityName(this Type type)
        {
            var entity = type.GetEntity();
            if (entity == null)
                return null;
            else
                return entity.Name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Field : Attribute
    {
        public readonly string Name;
        public readonly OracleDbType? Mapping = null;
        public readonly int Size = 0;

        public Field(string name)
        {
            this.Name = name;
        }

        public Field(string name, OracleDbType mapping)
        {
            this.Name = name;
            this.Mapping = mapping;
        }

        public Field(string name, OracleDbType mapping, int size)
        {
            this.Name = name;
            this.Mapping = mapping;
            this.Size = size;
        }
    }

    public static class FieldExtensions
    {
        public static Field? GetField(this PropertyInfo info)
        {
            return info.GetCustomAttribute<Field>();
        }

        public static string? GetFieldName(this PropertyInfo info)
        {
            var field = info.GetField();
            if (field == null)
                return null;
            else
                return field.Name;
        }

        public static OracleDbType? GetFieldOracleDbType(this PropertyInfo info)
        {
            var field = info.GetField();
            if (field == null)
                return null;
            else
                return field.Mapping;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class AutoIncrement : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ID : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CreateWithSubroutine : Attribute
    {
        public readonly string subroutine;

        public CreateWithSubroutine(string subroutine)
        {
            this.subroutine = subroutine;
        }
    }

    public static class SubroutineExtensions
    {
        public static CreateWithSubroutine? GetCreateWithSubroutine(this PropertyInfo info)
        {
            return info.GetCustomAttribute<CreateWithSubroutine>();
        }
        public static string? GetSubroutine(this PropertyInfo info)
        {
            var subroutine = info.GetCreateWithSubroutine();
            if (subroutine == null)
                return null;
            else
                return subroutine.subroutine;
        }
    }
}
