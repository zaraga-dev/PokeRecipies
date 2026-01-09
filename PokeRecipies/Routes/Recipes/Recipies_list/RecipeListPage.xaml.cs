namespace PokeRecipies.Routes.Recipes;

public partial class RecipeListPage : ContentPage
{
    private RecipeListViewModel viewModel;

    public RecipeListPage(RecipeListViewModel model)
    {
        InitializeComponent();
        BindingContext = viewModel = model;
        Loaded += RecipeListPage_Loaded;
    }

    private void RecipeListPage_Loaded(object? sender, EventArgs e)
    {
        if (viewModel.LoadRecipesDataCommand.CanExecute(null))
        {
            viewModel.LoadRecipesDataCommand.Execute(null);
        }
    }
}