using System.Windows;

namespace RecipeApp3
{
    public partial class IngredientWindow : Window
    {
        private Ingredient ingredient;

        public Ingredient GetIngredient()
        {
            return ingredient;
        }

        private void SetIngredient(Ingredient value)
        {
            ingredient = value;
        }

        public IngredientWindow()
        {
            InitializeComponent();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientNameTextBox.Text;
            double quantity = double.Parse(QuantityTextBox.Text);
            string unit = UnitTextBox.Text;
            double calories = double.Parse(CaloriesTextBox.Text);
            string foodGroup = FoodGroupTextBox.Text;

            SetIngredient(new Ingredient(name, quantity, unit, calories, foodGroup));
            DialogResult = true;
            Close();
        }
    }
}

