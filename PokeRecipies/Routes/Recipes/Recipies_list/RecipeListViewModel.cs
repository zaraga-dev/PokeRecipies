using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes.Recipes;

public partial class RecipeListViewModel : ObservableObject
{
    [ObservableProperty] bool _loadingRecipes = false;
    [ObservableProperty] bool _viewDetail = false;

    [ObservableProperty] ObservableCollection<RecipeModel> _recipeList;


    public RecipeListViewModel()
    {
        RecipeList = new();
    }

    private bool CanViewRecipeDetail()
    {
        return !ViewDetail;
    }


    /// <summary>
    /// Carga la lista de informacion
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task LoadRecipesData()
    {
        LoadingRecipes = true;

        var recipes = await RecipeDataStore.Instance.GetRecipes();
        if (recipes != null)
        {
            RecipeList = new ObservableCollection<RecipeModel>(recipes);
        }
        else
        {
            RecipeList.Clear();
        }

        LoadingRecipes = false;
    }


    [RelayCommand]
    private async Task GoToRecipeDetail()
    {
        await Shell.Current.GoToAsync(nameof(RecipePage));
    }

    [RelayCommand(CanExecute = nameof(CanViewRecipeDetail))]
    private async Task ViewRecipeDetail(RecipeModel recipe)
    {
        if (string.IsNullOrWhiteSpace(recipe.Id))
        {
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(RecipePage)}" + $"?{nameof(RecipePageViewModel.RecipeId)}={recipe.Id}");
    }

}
