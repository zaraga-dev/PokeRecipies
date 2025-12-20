using CommunityToolkit.Maui;
using FirestoreCommunication;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Newtonsoft.Json.Serialization;
using PokeRecipies.Routes;
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
                .UseFirestoreCommunication()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            SetupPages(builder.Services);


#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }


        private static void SetupPages(IServiceCollection services)
        {
            services.AddSingleton<RecipiesListPage, RecipiesListViewModel>();
            services.AddSingleton<RecipiePage, RecipiePageViewModel>();



            services.AddSingleton<FirestoreCommunication.Shared>();

        }


    }
}