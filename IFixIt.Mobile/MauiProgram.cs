using CommunityToolkit.Maui;
using IFixIt.Mobile.Views.Consumers;
using IFixIt.Mobile.Views.Controls;
using IFixIt.Mobile.Views.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Syncfusion.Maui.Core.Hosting;

namespace IFixIt.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<LoginServices>();

        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddSingleton<RegisterServices>();

        builder.Services.AddSingleton<ForgotPasswordPage>();
        builder.Services.AddSingleton<ForgotPasswordViewModel>();
        builder.Services.AddSingleton<ForgotPasswordServices>();

        builder.Services.AddSingleton<ServicePage>();
        builder.Services.AddSingleton<ServicePageViewModel>();
        builder.Services.AddSingleton<ServicePageServices>();

        builder.Services.AddSingleton<SelectServiceMopupPage>();
        builder.Services.AddSingleton<SelectServiceMopupPageViewModel>();


        builder.Services.AddSingleton<SelectedServiceOptionsPage>();
        builder.Services.AddSingleton<SelectedServiceOptionsPageService>();
        builder.Services.AddSingleton<SelectedServiceOptionsViewModel>();

        builder.Services.AddSingleton<UpdateWorkCatalogMopup>();
        builder.Services.AddSingleton<UpdateWorkCatalogMopupService>();
        builder.Services.AddSingleton<UpdateWorkCatalogMopupViewModel>();

        // builder.Services.AddTransient<ISelectedServiceOptionsPageService, SelectedServiceOptionsPageService>();

        builder.Services.AddSingleton<JobsPage>();
        builder.Services.AddSingleton<JobRequestViewModels>();
        builder.Services.AddSingleton<JobRequestService>();


        Routing.RegisterRoute("SelectedServiceOptionsPage", typeof(SelectedServiceOptionsPage));
        Routing.RegisterRoute("ProviderServicePage", typeof(ProviderServicePage));
        Routing.RegisterRoute("ChatMessagesPage", typeof(ChatMessagesPage));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}