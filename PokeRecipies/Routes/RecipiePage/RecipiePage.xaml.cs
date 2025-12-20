namespace PokeRecipies.Routes;

public partial class RecipiePage : ContentPage
{
    public RecipiePage(RecipiePageViewModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}