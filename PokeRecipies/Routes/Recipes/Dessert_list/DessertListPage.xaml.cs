namespace PokeRecipies.Routes.Recipes;

public partial class DessertListPage : ContentPage
{
    DessertListViewModel _viewModel;
    public DessertListPage(DessertListViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewmodel;
        Loaded += DessertListPage_Loaded; ;
    }

    private void DessertListPage_Loaded(object? sender, EventArgs e)
    {
        if(_viewModel.LoadDessertListCommand.CanExecute(null))
        {
            _viewModel.LoadDessertListCommand.Execute(null);
        }
    }
}