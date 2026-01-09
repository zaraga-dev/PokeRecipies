using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes.Recipes;

public partial class CurryListViewModel : ObservableObject
{
    private const int RECIPETYPE_CURRY = 1;

    [ObservableProperty] bool _loadingRecipes = false;
    [ObservableProperty] bool _reloadingRecipes = false;
    [ObservableProperty] bool _viewDetail = false;

    [ObservableProperty] ObservableCollection<RecipeModel> _recipeList;


    public CurryListViewModel()
    {
        RecipeList = new();
    }

    private bool CanLoadRecipesData()
    {
        return !LoadingRecipes;
    }

    private bool CanReloadRecipesData()
    {
        return !ReloadingRecipes;
    }

    private bool CanViewRecipeDetail()
    {
        return !ViewDetail;
    }


    /// <summary>
    /// Carga la lista de informacion
    /// </summary>
    /// <returns></returns>
    [RelayCommand(CanExecute = nameof(CanLoadRecipesData))]
    private async Task LoadRecipesData()
    {
        LoadingRecipes = true;

        RecipeList.Clear();
        var recipes = await RecipeDataStore.Instance.GetRecipes();
        if (recipes != null)
        {
            var filter = recipes.Where(x => x.RecipeTypeOrder == RECIPETYPE_CURRY);
            foreach (var item in filter)
            {
                RecipeList.Add(item);
            }
        }

        LoadingRecipes = false;
    }

    [RelayCommand(CanExecute = nameof(CanReloadRecipesData))]
    private async Task ReloadCurryData()
    {
        ReloadingRecipes = true;

        RecipeList.Clear();
        var recipes = await RecipeDataStore.Instance.GetRecipes();
        if (recipes != null)
        {
            var filter = recipes.Where(x => x.RecipeTypeOrder == RECIPETYPE_CURRY);
            foreach (var item in filter)
            {
                RecipeList.Add(item);
            }
        }

        ReloadingRecipes = false;
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
