namespace PokeRecipies.Routes.Recipes;

public partial class CurryListPage : ContentPage
{
    private CurryListViewModel viewModel;

    public CurryListPage(CurryListViewModel model)
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