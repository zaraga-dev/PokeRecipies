namespace PokeRecipies.Routes.Recipes;

public partial class SaladsListPage : ContentPage
{
    private SaladsListViewModel _viewModel;

    public SaladsListPage(SaladsListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        Loaded += SaladsListPage_Loaded;
    }

    private void SaladsListPage_Loaded(object? sender, EventArgs e)
    {
        if(_viewModel.LoadSaladListCommand.CanExecute(null))
        {
            _viewModel.LoadSaladListCommand.Execute(null);
        }
    }
}