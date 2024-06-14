using RecipeApp3;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp3
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            var createRecipeWindow = new CreateRecipeWindow();
            if (createRecipeWindow.ShowDialog() == true)
            {
                var newRecipe = createRecipeWindow.Recipe;
                recipes.Add(newRecipe);
                newRecipe.RecipeCaloriesExceededEvent += HandleRecipeCaloriesExceeded;
                MessageBox.Show("Recipe created successfully!");
                UpdateRecipeListBox();
            }
        }

        private void DisplayRecipeList_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes created yet!");
                return;
            }

            var selectedRecipeName = RecipeListBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedRecipeName))
            {
                MessageBox.Show("Please select a recipe from the list.");
                return;
            }

            var selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(selectedRecipeName));
            if (selectedRecipe != null)
            {
                DisplayRecipeDetails(selectedRecipe);
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            var filterWindow = new FilterRecipesWindow(recipes);
            filterWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UpdateRecipeListBox()
        {
            RecipeListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void DisplayRecipeDetails(Recipe recipe)
        {
            RecipeDetailsTextBlock.Text = $"Recipe: {recipe.Name}\n\nIngredients:\n";
            foreach (var ingredient in recipe.Ingredients)
            {
                RecipeDetailsTextBlock.Text += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories)\n";
            }
            RecipeDetailsTextBlock.Text += "\nSteps:\n";
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                RecipeDetailsTextBlock.Text += $"{i + 1}. {recipe.Steps[i].Description}\n";
            }
            double totalCalories = recipe.GetTotalCalories();
            RecipeDetailsTextBlock.Text += $"\nTotal Calories: {totalCalories}";

            recipe.CheckCalories();
        }

        private void HandleRecipeCaloriesExceeded(string recipeName, double totalCalories)
        {
            MessageBox.Show($"Warning: {recipeName} has exceeded 300 calories with {totalCalories} calories!");
        }
    }
}
