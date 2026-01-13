using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeRecipies.Routes.Ingredients;
using PokeRecipies.Routes.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes.Menu
{
    public partial class MenuPageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(GenerateDatastoreDataCommand))]
        private bool _isGeneratingData;


        private bool CanGenerateDatastoreData()
        {
            return !IsGeneratingData;
        }


        [RelayCommand(CanExecute = nameof(CanGenerateDatastoreData))]
        private async Task GenerateDatastoreData()
        {
            try
            {
                IsGeneratingData = true;

                await RecipeDataStore.Instance.GenerateRecipes();
                await IngredientsDataStore.Instance.GenerateIngredients();

                await Shell.Current.DisplayAlert("Exito", "Base de Datos Generada Correctamente", "OK");

                IsGeneratingData = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
