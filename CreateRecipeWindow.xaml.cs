using RecipeApp3;
using System.Collections.Generic;
using System.Windows;

namespace RecipeApp3
{
    public partial class CreateRecipeWindow : Window
    {
        public Recipe Recipe { get; private set; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<Step> steps = new List<Step>();

        public CreateRecipeWindow()
        {
            InitializeComponent();
        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            int numIngredients;
            if (int.TryParse(NumIngredientsTextBox.Text, out numIngredients))
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    var ingredientWindow = new IngredientWindow();
                    if (ingredientWindow.ShowDialog() == true)
                    {
                        ingredients.Add(ingredientWindow.GetIngredient());
                    }
                }
            }
        }

        private void AddSteps_Click(object sender, RoutedEventArgs e)
        {
            int numSteps;
            if (int.TryParse(NumStepsTextBox.Text, out numSteps))
            {
                for (int i = 0; i < numSteps; i++)
                {
                    var stepWindow = new StepWindow();
                    if (stepWindow.ShowDialog() == true)
                    {
                        steps.Add(stepWindow.Step);
                    }
                }
            }
        }

        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            Recipe = new Recipe(recipeName, ingredients, steps);
            DialogResult = true;
            Close();
        }
    }
}

