using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class Field : Attribute
    {
        public readonly string name;

        public Field(string name)
        {
            this.name = name;
        }
    }
}
