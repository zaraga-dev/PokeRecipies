using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes.Recipes
{
    public partial class DessertListViewModel : ObservableObject
    {
        private const int RECIPETYPE_DESSERT = 3;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoadDessertListCommand))]
        private bool _loadingDessertList;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ReloadDessertDataCommand))]
        bool _reloadingRecipes = false;

        [ObservableProperty]
        bool _viewDetail;

        [ObservableProperty]
        ObservableCollection<RecipeModel> _recipeList;


        public DessertListViewModel()
        {
            RecipeList = new ObservableCollection<RecipeModel>();
        }


        private bool CanLoadDessertList()
        {
            return !LoadingDessertList;
        }

        private bool CanReloadRecipesData()
        {
            return !ReloadingRecipes;
        }

        private bool CanViewRecipeDetail()
        {
            return !ViewDetail;
        }

        [RelayCommand(CanExecute = nameof(CanLoadDessertList))]
        private async Task LoadDessertList()
        {
            LoadingDessertList = true;

            RecipeList.Clear();
            var recipes = await RecipeDataStore.Instance.GetRecipes();
            if (recipes != null)
            {
                var filter = recipes.Where(x => x.RecipeTypeOrder == RECIPETYPE_DESSERT).OrderBy(x => x.Id);
                foreach (var item in filter)
                {
                    RecipeList.Add(item);
                }
            }

            LoadingDessertList = false;
        }

        [RelayCommand(CanExecute = nameof(CanReloadRecipesData))]
        private async Task ReloadDessertData()
        {
            ReloadingRecipes = true;

            RecipeList.Clear();
            var recipes = await RecipeDataStore.Instance.GetRecipes();
            if (recipes != null)
            {
                var filter = recipes.Where(x => x.RecipeTypeOrder == RECIPETYPE_DESSERT).OrderBy(x => x.Id);
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
}
