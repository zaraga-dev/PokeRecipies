namespace PokeRecipies.Routes.Ingredients;

public partial class IngredientPage : ContentPage
{
    public IngredientPage(IngredientPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}