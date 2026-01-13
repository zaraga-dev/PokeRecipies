using CommunityToolkit.Mvvm.ComponentModel; // Necesario
using CommunityToolkit.Mvvm.Input;          // Necesario para los comandos
using IntelliJ.Lang.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRecipies.Routes.Recipes;

[QueryProperty(nameof(RecipeId), nameof(RecipeId))]
public partial class RecipePageViewModel : ObservableObject
{
    // Propiedad para controlar el indicador de carga y deshabilitar el botón
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadInitialDataCommand))] // Avisa al comando que re-evalúe si puede ejecutarse
    private bool _isBusy;

    [ObservableProperty]
    public string _recipeId = "";

    [ObservableProperty]
    private string? _statusMessage;

    [ObservableProperty]
    private string _recipeName = "";

    [ObservableProperty]
    private string _recipeDescription = "";

    [ObservableProperty]
    private string _recipeImage = "";



    partial void OnRecipeIdChanged(string value)
    {
        LoadInitialDataCommand.Execute(null);
    }


    // DEFINICIÓN DEL COMANDO ASÍNCRONO
    // Al poner [RelayCommand], se genera automáticamente "LoadInitialDataCommand"
    [RelayCommand(CanExecute = nameof(CanLoadInitialData))]
    private async Task LoadInitialData()
    {
        try
        {
            IsBusy = true;
            StatusMessage = "Cargando datos...";

            RecipeName = "";
            RecipeDescription = "";
            RecipeImage = "";
            if (string.IsNullOrWhiteSpace(RecipeId))
            {
                await Shell.Current.GoToAsync("..");
                return;
            }

            RecipeModel? selectedRecipe = await RecipeDataStore.Instance.GetRecipe(RecipeId);
            StatusMessage = "";
            IsBusy = false;

            if (selectedRecipe == null)
            {
                await Shell.Current.GoToAsync("..");
                return;
            }

            RecipeName = selectedRecipe.RecipeName ?? "";
            RecipeDescription = selectedRecipe.RecipeDescription ?? "";
            RecipeImage = selectedRecipe.RecipeImage ?? "";
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            await Shell.Current.GoToAsync("..");

        }
    }

    // Regla para saber si se puede invocar el comando
    private bool CanLoadInitialData()
    {
        // Solo se puede loguear si NO está ocupado
        return !IsBusy;
    }



    //[RelayCommand]
    //private async Task AddRecipe()
    //{
    //    try
    //    {
    //        IsBusy = true;
    //        await RecipeDataStore.Instance.AddRecipe(RecipeName, RecipeDescription, RecipeImage);
    //        IsBusy = false;
    //        await Shell.Current.DisplayAlert("Aviso", "Receta agregada correctamente.", "OK");
    //        await Shell.Current.GoToAsync("..");
    //    }
    //    catch (Exception ex)
    //    {
    //        IsBusy = false;
    //        await Shell.Current.DisplayAlert("Error", $"No se pudo agregar la receta: {ex.Message}", "OK");
    //    }
    //}

}
