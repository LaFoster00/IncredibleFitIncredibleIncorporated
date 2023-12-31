using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.IncredibleFit.SQL
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Entity : Attribute
    {
        public readonly string name;

        public Entity(string name)
        {
            this.name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Field : Attribute
    {
        public readonly string Name;
        public readonly OracleDbType? Mapping = null;

        public Field(string name)
        {
            this.Name = name;
        }

        public Field(string name, OracleDbType mapping)
        {
            this.Name = name;
            this.Mapping = mapping;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ServersideSetup : Attribute
    {

    }
}
