namespace PokeRecipies.Routes.Recipes;

public partial class SaladsListPage : ContentPage
{
    private SaladsListViewModel ViewModel;

    public SaladsListPage(SaladsListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = ViewModel = viewModel;
    }
}