using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Data;
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
        
        // Регистрация контекста базы данных (Entity Framework Core + PostgreSQL)
        services.AddDbContext<PhoneBookDbContext>(options =>
            options.UseNpgsql("Host=localhost;Port=25432;Database=PhoneBookDB_Emelyanov_2307d2;Username=phonebook;Password=phonebook123"));
        
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
