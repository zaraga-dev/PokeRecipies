using Android.Net;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PokeRecipies.Routes;
using PokeRecipies.Routes.Ingredients;
using PokeRecipies.Routes.Menu;
using PokeRecipies.Routes.Recipes;
using zaraga.FirestoreCommunication;
using zaraga.logger.extensions;

namespace PokeRecipies
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .AddZaragaLogger()
                .UseFirestoreCommunication(applicationId: "pokerecipies")
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .SetupPages();


            RegisterRoutes();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }


        private static MauiAppBuilder SetupPages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MenuPage, MenuPageViewModel>();

            builder.Services.AddSingleton<CurryListPage, CurryListViewModel>();
            builder.Services.AddSingleton<RecipePage, RecipePageViewModel>();
            builder.Services.AddSingleton<SaladsListPage, SaladsListViewModel>();
            builder.Services.AddSingleton<DessertListPage, DessertListViewModel>();

            builder.Services.AddSingleton<IngredientListPage, IngredientListViewModel>();
            builder.Services.AddSingleton<IngredientPage, IngredientPageViewModel>();

            return builder;
        }

        private static void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
            Routing.RegisterRoute(nameof(IngredientPage), typeof(IngredientPage));
        }

    }
}