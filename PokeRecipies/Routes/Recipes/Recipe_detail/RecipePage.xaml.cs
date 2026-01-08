namespace PokeRecipies.Routes.Recipes;

public partial class RecipePage : ContentPage
{
    public RecipePage(RecipePageViewModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}