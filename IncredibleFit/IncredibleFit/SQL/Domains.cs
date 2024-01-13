using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.SQL
{
    public struct AppointmentStatus
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short Open = 0;
        public static readonly short Closed = 1;

        private AppointmentStatus(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(AppointmentStatus value)
        {
            return value.Value;
        }

        public static implicit operator AppointmentStatus(short value)
        {
            return new AppointmentStatus(value);
        }
    }

    public struct Authorization
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short User = 0;
        public static readonly short Admin = 1;

        private Authorization(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(Authorization value)
        {
            return value.Value;
        }

        public static implicit operator Authorization(short value)
        {
            return new Authorization(value);
        }
    }

    public struct ExerciseType
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short Warmup = 0;
        public static readonly short Cooldown = 1;
        public static readonly short Main = 2;

        private ExerciseType(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(ExerciseType value)
        {
            return value.Value;
        }

        public static implicit operator ExerciseType(short value)
        {
            return new ExerciseType(value);
        }
    }

    public struct FoodCategory
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short Meat = 0;
        public static readonly short Vegetarian = 1;
        public static readonly short Vegan = 2;

        private FoodCategory(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(FoodCategory value)
        {
            return value.Value;
        }

        public static implicit operator FoodCategory(short value)
        {
            return new FoodCategory(value);
        }
    }

    public struct MealType
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short Breakfast = 0;
        public static readonly short Supper = 1;
        public static readonly short Dinner = 2;
        public static readonly short Snack = 3;
        public static readonly short Drink = 4;

        private MealType(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(MealType value)
        {
            return value.Value;
        }

        public static implicit operator MealType(short value)
        {
            return new MealType(value);
        }
    }

    public struct QuantityUnit
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short Gram = 0;
        public static readonly short Liter = 1;
        public static readonly short Pound = 2;
        public static readonly short FluidOunce = 3;

        private QuantityUnit(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(QuantityUnit value)
        {
            return value.Value;
        }

        public static implicit operator QuantityUnit(short value)
        {
            return new QuantityUnit(value);
        }
    }
    

    public struct Difficulty
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short Easy = 0;
        public static readonly short Medium = 1;
        public static readonly short Hard = 2;

        private Difficulty(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(Difficulty value)
        {
            return value.Value;
        }

        public static implicit operator Difficulty(short value)
        {
            return new Difficulty(value);
        }
    }

    public struct Visibility
    {
        public readonly short Value;

        public static readonly short Invalid = -1;
        public static readonly short Private = 0;
        public static readonly short Public = 1;
        public static readonly short Friends = 2;

        private Visibility(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(Visibility value)
        {
            return value.Value;
        }

        public static implicit operator Visibility(short value)
        {
            return new Visibility(value);
        }
    }

    public struct Weekday
    {
        public readonly short Value;

        public static readonly short FridayFridayGottaGetDownOnFriday = -1;
        public static readonly short Monday = 0;
        public static readonly short Tuesday = 1;
        public static readonly short Wednesday = 2;
        public static readonly short Thursday = 3;
        public static readonly short Friday = 4;
        public static readonly short Saturday = 5;
        public static readonly short Sunday = 6;

        private Weekday(short status)
        {
            this.Value = status;
        }

        public static implicit operator short(Weekday value)
        {
            return value.Value;
        }

        public static implicit operator Weekday(short value)
        {
            return new Weekday(value);
        }
    }
}
