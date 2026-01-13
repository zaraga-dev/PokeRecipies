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
    public partial class SaladsListViewModel : ObservableObject
    {
        private const int RECIPETYPE_SALAD = 2;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoadSaladListCommand))]
        private bool _loadingSaladList;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ReloadSaladDataCommand))]
        bool _reloadingRecipes = false;

        [ObservableProperty]
        bool _viewDetail;

        [ObservableProperty]
        ObservableCollection<RecipeModel> _recipeList;


        public SaladsListViewModel()
        {
            RecipeList = new ObservableCollection<RecipeModel>();
        }


        private bool CanLoadSaladList()
        {
            return !LoadingSaladList;
        }

        private bool CanReloadRecipesData()
        {
            return !ReloadingRecipes;
        }

        private bool CanViewRecipeDetail()
        {
            return !ViewDetail;
        }

        [RelayCommand(CanExecute = nameof(CanLoadSaladList))]
        private async Task LoadSaladList()
        {
            LoadingSaladList = true;

            RecipeList.Clear();
            var recipes = await RecipeDataStore.Instance.GetRecipes();
            if (recipes != null)
            {
                var filter = recipes.Where(x => x.RecipeTypeOrder == RECIPETYPE_SALAD).OrderBy(x => x.Id);
                foreach (var item in filter)
                {
                    RecipeList.Add(item);
                }
            }

            LoadingSaladList = false;
        }

        [RelayCommand(CanExecute = nameof(CanReloadRecipesData))]
        private async Task ReloadSaladData()
        {
            ReloadingRecipes = true;

            RecipeList.Clear();
            var recipes = await RecipeDataStore.Instance.GetRecipes();
            if (recipes != null)
            {
                var filter = recipes.Where(x => x.RecipeTypeOrder == RECIPETYPE_SALAD).OrderBy(x => x.Id);
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
