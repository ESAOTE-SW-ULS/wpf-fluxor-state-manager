using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Fluxor;
using System.Reflection;

namespace FluxorWpfApp;

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
                services.AddFluxor(options =>
                {
                    options.ScanAssemblies(Assembly.GetExecutingAssembly());
                    // Also scan the MyLabFluxor assembly if it's in a separate assembly
                    // options.ScanAssemblies(typeof(UIFramework.Contract.MyLabFluxor.States.MyLabState).Assembly);
                });
                
                services.AddSingleton<MainWindow>();
                services.AddTransient<Views.CounterView>();
                services.AddTransient<Views.ImageView>();
                services.AddTransient<Views.EventsView>();
                services.AddTransient<Views.MyLabView>();
                
                // Register MyLab ViewModels
                services.AddTransient<Store.MyLab.MyLabViewModel>();
            })
            .Build();

        _host.Start();
        Services = _host.Services;

        // Initialize Fluxor store
        var store = _host.Services.GetRequiredService<Fluxor.IStore>();
        store.InitializeAsync().Wait();

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

