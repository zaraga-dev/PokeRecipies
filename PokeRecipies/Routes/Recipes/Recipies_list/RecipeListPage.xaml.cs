namespace PokeRecipies.Routes.Recipes;

public partial class RecipeListPage : ContentPage
{
    private RecipeListViewModel viewModel;

    public RecipeListPage(RecipeListViewModel model)
    {
        InitializeComponent();
        BindingContext = viewModel = model;
        //BindingContext = viewModel = new RecipiesListViewModel();
    }

}