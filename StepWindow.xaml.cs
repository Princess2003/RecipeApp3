using RecipeApp3;
using System.Windows;

namespace RecipeApp3
{



public partial class StepWindow : Window
{
        public Step Step { get; private set; }

    public StepWindow()
    {
        InitializeComponent();
    }

    private void AddStep_Click(object sender, RoutedEventArgs e)
    {
        string description = StepDescriptionTextBox.Text;
        Step = new Step(description);
        DialogResult = true;
        Close();
    }
}
}

