namespace PokeRecipies.Routes.Recipes;

public partial class RecipePage : ContentPage
{
    private RecipePageViewModel _viewModel;
    public RecipePage(RecipePageViewModel model)
    {
        InitializeComponent();
        BindingContext = _viewModel = model;
        Loaded += RecipePage_Loaded;
    }

    private void RecipePage_Loaded(object? sender, EventArgs e)
    {
        //if (_viewModel.LoadInitialDataCommand.CanExecute(null))
        //{
        //    _viewModel.LoadInitialDataCommand.Execute(null);
        //}
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel.LoadInitialDataCommand.CanExecute(null))
        {
            _viewModel.LoadInitialDataCommand.Execute(null);
        }
    }
}