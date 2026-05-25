using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Services;
using PhoneBook.ViewModels;

namespace PhoneBook;

/// <summary>
/// Точка входа приложения. Переносит управление жизненным циклом и
/// привязку DataContext из XAML-разметки в процедурный код с использованием DI.
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var services = new ServiceCollection();
        
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<IContactRepository, ContactRepository>();
        services.AddTransient<ContactsListViewModel>();
        services.AddTransient<AboutViewModel>();
        services.AddTransient<ContactEditViewModel>();
        services.AddSingleton<MainWindowViewModel>();
        
        services.AddSingleton<MainWindow>(sp =>
        {
            var window = new MainWindow();
            window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
            return window;
        });
        
        var serviceProvider = services.BuildServiceProvider();
        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
