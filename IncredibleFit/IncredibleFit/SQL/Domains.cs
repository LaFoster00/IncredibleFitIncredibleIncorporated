using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.SQL
{
    public static class DomainTools
    {
        public static object? ToDomain(this object? o, Type domainType)
        {
            if (o == null)
            {
                return null;
            }

            if (domainType.IsEnum)
                return Enum.ToObject(domainType, o);
            else
                return o;
        }

        public static object? FromDomain(this object? o)
        {
            if (o == null)
            {
                return null;
            }

            if (o.GetType().IsEnum)
            {
                return (short)o;
            }

            return o;
        }
    }

    public enum AppointmentStatus : short
    {
        Invalid = -1,
        Open = 0,
        Closed = 1,
    }

    public enum Authorization : short
    {
        Invalid = -1,
        User = 0,
        Admin = 1,
    }

    public enum ExerciseType : short
    {
        Invalid = -1,
        Warmup = 0,
        Cooldown = 1,
        Main = 2,
    }

    public enum FoodCategory : short
    {
        Invalid = -1,
        Meat = 0,
        Vegetarian = 1,
        Vegan = 2,
    }

    public enum MealType : short
    {
        Invalid = -1,
        Breakfast = 0,
        Supper = 1,
        Dinner = 2,
        Snack = 3,
        Drink = 4,
    }

    public enum QuantityUnit : short
    {
        Invalid = -1,
        Gram = 0,
        Liter = 1,
        Pound = 2,
        FluidOunce = 3,
        Pieces = 4
    }

    public enum Difficulty : short
    {
        Invalid = -1,
        Easy = 0,
        Medium = 1,
        Hard = 2,
    }

    public enum Visibility : short
    {
        Invalid = -1,
        Private = 0,
        Public = 1,
        Friends = 2,
    }

    public enum Weekday : short
    {
        FridayFridayGottaGetDownOnFriday = -1,
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
}
