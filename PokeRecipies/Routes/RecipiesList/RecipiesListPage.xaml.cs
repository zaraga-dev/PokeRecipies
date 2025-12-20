namespace PokeRecipies.Routes;

public partial class RecipiesListPage : ContentPage
{
    private RecipiesListViewModel viewModel;

    public RecipiesListPage(RecipiesListViewModel model)
    {
        InitializeComponent();
        BindingContext = viewModel = model;
        //BindingContext = viewModel = new RecipiesListViewModel();
    }

}