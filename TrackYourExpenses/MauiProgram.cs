using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using TrackYourExpenses.Services;
using TrackYourExpenses.Services.Interface;

namespace TrackYourExpenses
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            //injecing the services of user service 
            builder.Services.AddScoped<IUser, UserService>();
            //adding mud blazor
            builder.Services.AddMudServices();
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
