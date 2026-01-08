using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes.Recipes;

public partial class RecipeListViewModel : ObservableObject
{

    [ObservableProperty]
    string exampleText;


    public RecipeListViewModel()
    {
        ExampleText = "Hello from RecipiesListViewModel";
    }



}
