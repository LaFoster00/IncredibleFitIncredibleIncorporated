﻿using CommunityToolkit.Maui;
using IncredibleFit.ViewModels;
using IncredibleFit.Screens;
using IncredibleFit.ViewModels;
using Microsoft.Extensions.Logging;

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

        builder.Services.AddSingleton<Login>();
        builder.Services.AddSingleton<SignUp>();
        builder.Services.AddSingleton<Profile>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}