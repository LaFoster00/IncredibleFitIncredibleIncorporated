using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.IncredibleFit.Models
{
    public class Recipe
    {
        private string _name;
        private string _description;
        private string _instructions;         //CLOB in PDM??
        private int _visibility;
        private string _category;
        private int _energy;
        private List<Ingredient> _ingredients = new List<Ingredient> { };

        public Recipe(string name, string description, string instructions, int visibility, string category, int energy, List<Ingredient> ingredients)
        {
            this._name = name;
            this._description = description;
            this._instructions = instructions;
            this._visibility = visibility;
            this._category = category;
            this._energy = energy;
            this._ingredients = ingredients;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Instructions { get { return _instructions; } set { _instructions = value; } }
        public int Visibility { get { return _visibility; } set { _visibility = value; } }
        public string Category { get { return _category; } set { _category = value; } }
        public int Energy { get { return _energy; } set { _energy = value; } }
        public List<Ingredient> Ingredients { get { return _ingredients; } set { _ingredients = value; } }
    }
}
