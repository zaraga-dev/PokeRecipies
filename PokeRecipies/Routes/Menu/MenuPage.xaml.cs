namespace PokeRecipies.Routes.Menu;

public partial class MenuPage : ContentPage
{
    public MenuPage(MenuPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}