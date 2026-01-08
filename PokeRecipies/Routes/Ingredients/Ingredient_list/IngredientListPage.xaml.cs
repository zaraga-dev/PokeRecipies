namespace PokeRecipies.Routes.Ingredients;

public partial class IngredientListPage : ContentPage
{
    public IngredientListPage(IngredientListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}