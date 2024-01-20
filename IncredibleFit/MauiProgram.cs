using CommunityToolkit.Maui;
using IncredibleFit.ViewModels;
using IncredibleFit.Screens;
using IncredibleFit.SQL;
using Microsoft.Extensions.Logging;
using IncredibleFit.ContentViews;

namespace IncredibleFit;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<SessionInfo>();

        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<SignUpViewModel>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();

        builder.Services.AddSingleton<Login>();
        builder.Services.AddSingleton<SignUp>();
        builder.Services.AddSingleton<Profile>();
        builder.Services.AddSingleton<Settings>();
        builder.Services.AddSingleton<CalorieTracker>();
        builder.Services.AddSingleton<RecipeFavorites>();
        builder.Services.AddSingleton<RecipeSearch>();
        builder.Services.AddSingleton<Training>();
        builder.Services.AddSingleton<Trainingplan>();
        builder.Services.AddSingleton<SelectTrainingplan>();

        builder.Services.AddTransient<EditableField>();
        builder.Services.AddTransient<TrainingPlanUnitField>();
        builder.Services.AddTransient<RecipeField>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}