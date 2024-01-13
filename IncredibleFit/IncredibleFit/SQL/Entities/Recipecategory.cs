﻿using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPECATEGORY")]
    public class Recipecategory : BindableObject
    {
        [ID, Field("RECIPECATEGORYID", OracleDbType.Int32), AutoIncrement]
        public int RecipeCategoryID
        {
            get => (int)GetValue(RecipeCategoryIDProperty);
            private set => SetValue(RecipeCategoryIDProperty, value);
        }

        [Field("MEALTYPE", OracleDbType.Int16)] //Domain in ERD
        public MealType Mealtype
        {
            get => (MealType)GetValue(MealtypeProperty);
            set => SetValue(MealtypeProperty, value);
        }

        [Field("FOODCATEGORY", OracleDbType.Int16)] //Domain in ERD
        public FoodCategory Foodcategory
        {
            get => (FoodCategory)GetValue(FoodcategoryProperty);
            set => SetValue(FoodcategoryProperty, value);
        }

        public static readonly BindableProperty RecipeCategoryIDProperty =
            BindableProperty.Create(
                nameof(RecipeCategoryID), 
                typeof(int), 
                typeof(Recipecategory), 
                -1);

        public static readonly BindableProperty MealtypeProperty =
            BindableProperty.Create(
                nameof(Mealtype), 
                typeof(MealType), 
                typeof(Recipecategory), 
                MealType.Invalid);

        public static readonly BindableProperty FoodcategoryProperty =
            BindableProperty.Create(
                nameof(Foodcategory), 
                typeof(FoodCategory), 
                typeof(Recipecategory), 
                FoodCategory.Invalid);

        private Recipecategory() { }
        public Recipecategory(short mealtype, short foodcategory)
        {
            Mealtype = mealtype;
            Foodcategory = foodcategory;
        }
    }
}
