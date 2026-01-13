namespace PokeRecipies.Routes.Recipes;

public partial class RecipePage : ContentPage
{
    private RecipePageViewModel _viewModel;
    public RecipePage(RecipePageViewModel model)
    {
        InitializeComponent();
        BindingContext = _viewModel = model;
    }
}