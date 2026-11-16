using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommunityToolkitWpfApp.ViewModels;

namespace CommunityToolkitWpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost? _host;
    public static IServiceProvider? Services { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddKeyedSingleton<IMessenger>(MessengerType.Weak, WeakReferenceMessenger.Default);
                services.AddKeyedSingleton<IMessenger>(MessengerType.Strong, StrongReferenceMessenger.Default);

                services.AddSingleton<EventsViewModel>();
                services.AddSingleton<CounterViewModel>();
                services.AddSingleton<ImageViewModel>();
                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton<MainWindow>();
            })
            .Build();

        _host.Start();
        Services = _host.Services;

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host?.Dispose();
        base.OnExit(e);
    }
}

