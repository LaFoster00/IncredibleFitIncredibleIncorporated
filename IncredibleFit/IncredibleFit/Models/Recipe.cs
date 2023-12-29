using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.Models
{
    public class Recipe
    {
        private string name;
        private string description;
        private string instructions;         //CLOB in PDM??
        private int visibility;
        private string category;
        private int energy;
        private List<Ingredient> ingredients = new List<Ingredient> { };

        public Recipe(string name, string description, string instructions, int visibility, string category, int energy, List<Ingredient> ingredients)
        {
            this.name = name;
            this.description = description;
            this.instructions = instructions;
            this.visibility = visibility;
            this.category = category;
            this.energy = energy;
            this.ingredients = ingredients;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Instructions { get { return instructions; } set { instructions = value; } }
        public int Visibility { get { return visibility; } set { visibility = value; } }
        public string Category { get { return category; } set { category = value; } }
        public int Energy { get { return energy; } set { energy = value; } }
        public List<Ingredient> Ingredients { get { return ingredients; } set { ingredients = value; } }
    }
}
