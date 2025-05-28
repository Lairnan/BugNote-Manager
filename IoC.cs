using System.IO;
using BugNoteManager.Interfaces;
using BugNoteManager.Interfaces.ViewModels.Windows;
using BugNoteManager.Interfaces.Views.Windows;
using BugNoteManager.Services;
using BugNoteManager.Services.Implementation;
using BugNoteManager.Services.Interface;
using BugNoteManager.ViewModels;
using BugNoteManager.Views;
using BugNoteManager.Views.Implementations;
using BugNoteManager.Views.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugNoteManager;

public static class IoC
{
    private static readonly IServiceProvider _provider;

    static IoC()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);

        var configuration = builder.Build();

        var services = new ServiceCollection();

        services.AddSingleton(configuration);

        services.AddWindows()
                .AddPages();
        
        // Services
        services.AddTransient<IPageService, PageService>();
        services.AddSingleton<IViewFactory, ViewFactory>();

        _provider = services.BuildServiceProvider();

        foreach (var service in services.Where(s => s.Lifetime == ServiceLifetime.Singleton))
            _provider.GetRequiredService(service.ServiceType);
    }

    private static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddTransient<IMainWindow, MainWindow>();
        services.AddTransient<IAdditionalWindow, AdditionalWindow>();
        
        services.AddTransient<IWindowBase, WindowBase>();
        
        services.AddTransient<IMainWindowVm, MainViewModel>();
        services.AddTransient<IAdditionalWindowVm, AdditionalViewModel>();
        
        return services;
    }

    private static IServiceCollection AddPages(this IServiceCollection services)
    {
        services.AddTransient<IPageBase, PageBase>();
        
        services.AddTransient<IPopUp, PopUpControl>();
        return services;
    }

    public static T Resolve<T>() where T : notnull
        => _provider.GetRequiredService<T>();
}