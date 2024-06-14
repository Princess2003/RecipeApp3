using RecipeApp3;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp3
{
    public partial class FilterRecipesWindow : Window
    {
        private List<Recipe> recipes;

        public FilterRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void FilterByIngredient_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientTextBox.Text;
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.Name.Contains(ingredient))).ToList();
            UpdateFilteredRecipesListBox(filteredRecipes);
        }

        private void FilterByFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            string foodGroup = FoodGroupTextBox.Text;
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.FoodGroup.Contains(foodGroup))).ToList();
            UpdateFilteredRecipesListBox(filteredRecipes);
        }

        private void FilterByMaxCalories_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(MaxCaloriesTextBox.Text, out double maxCalories))
            {
                var filteredRecipes = recipes.Where(r => r.GetTotalCalories() <= maxCalories).ToList();
                UpdateFilteredRecipesListBox(filteredRecipes);
            }
        }

        private void UpdateFilteredRecipesListBox(List<Recipe> filteredRecipes)
        {
            FilteredRecipesListBox.ItemsSource = filteredRecipes.Select(r => r.Name).ToList();
        }
    }
}
