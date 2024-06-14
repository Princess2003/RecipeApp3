using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp3
{
    public class Recipe
    {
        public string Name { get; }
        public List<Ingredient> Ingredients { get; }
        public List<Step> Steps { get; }
        public event Action<string, double> RecipeCaloriesExceededEvent;

        public Recipe(string name, List<Ingredient> ingredients, List<Step> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public void DisplayRecipe()
        {
            // Display logic for console application can be omitted here
        }

        public double GetTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories * i.Quantity);
        }

        public void CheckCalories()
        {
            double totalCalories = GetTotalCalories();
            if (totalCalories > 300)
            {
                RecipeCaloriesExceededEvent?.Invoke(Name, totalCalories);
            }
        }
    }
}

