using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes;

public partial class RecipiesListViewModel : ObservableObject
{

    [ObservableProperty]
    string exampleText;


    public RecipiesListViewModel()
    {
        ExampleText = "Hello from RecipiesListViewModel";
    }



}
