using Microsoft.Extensions.Logging;

namespace EducationalGame
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<EducationalGame.Services.DatabaseService>();
            builder.Services.AddSingleton<EducationalGame.Services.ThemeService>();
            builder.Services.AddTransient<EducationalGame.ViewModels.MainViewModel>();
            builder.Services.AddTransient<EducationalGame.MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif      

            return builder.Build();
        }
    }
}
