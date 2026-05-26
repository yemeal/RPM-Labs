using System.IO;
using System.Windows;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Data;
using PhoneBook.Services;
using PhoneBook.ViewModels;

namespace PhoneBook;

/// <summary>
/// Точка входа приложения. Строка подключения собирается динамически
/// из файла .env — единого источника конфигурации для Docker и приложения.
/// Для загрузки .env используется библиотека DotNetEnv (аналог python-dotenv).
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Ищем .env файл, поднимаясь от bin/Debug/ к корню проекта
        var envPath = FindEnvFile();
        if (envPath is not null)
        {
            // DotNetEnv загружает переменные из .env в Environment
            Env.Load(envPath);
        }

        // Читаем переменные через стандартный API .NET
        var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "25432";
        var db   = Environment.GetEnvironmentVariable("POSTGRES_DB")   ?? "PhoneBookDB_Emelyanov_2307d2";
        var user = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "phonebook";
        var pass = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "phonebook123";

        var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={pass}";

        var services = new ServiceCollection();
        
        // Регистрация контекста базы данных (Entity Framework Core + PostgreSQL)
        services.AddDbContext<PhoneBookDbContext>(options =>
            options.UseNpgsql(connectionString));
        
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

    /// <summary>
    /// Ищет файл .env, поднимаясь вверх от каталога исполняемого файла.
    /// Необходимо, т.к. приложение запускается из bin/Debug/net9.0-windows/.
    /// </summary>
    private static string? FindEnvFile()
    {
        var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        while (dir is not null)
        {
            var candidate = Path.Combine(dir.FullName, ".env");
            if (File.Exists(candidate))
                return candidate;
            dir = dir.Parent;
        }

        return null;
    }
}
