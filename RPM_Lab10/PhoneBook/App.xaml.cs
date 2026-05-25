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

        // 1. Создаем коллекцию сервисов для регистрации зависимостей
        var services = new ServiceCollection();

        // 2. Регистрация сервисов:
        // DialogService регистрируется как Singleton (одиночка), так как этот класс не хранит
        // состояние конкретных пользователей или интерфейса и может использоваться повторно на протяжении всей работы приложения.
        services.AddSingleton<IDialogService, DialogService>();

        // 3. Регистрация ViewModel:
        // MainViewModel регистрируется как Transient (временный), так как при потенциальной
        // навигации между окнами или экранами нам могут потребоваться новые изолированные экземпляры этой ViewModel.
        services.AddTransient<MainViewModel>();

        // 4. Регистрация View (Главного окна):
        // MainWindow регистрируется как Singleton с явной передачей DataContext через лямбда-выражение.
        // Это гарантирует, что DataContext, разрешенный IoC-контейнером (MainViewModel со внедренными зависимостями),
        // будет корректно передан окну при инициализации.
        services.AddSingleton<MainWindow>(sp =>
        {
            var window = new MainWindow();
            window.DataContext = sp.GetRequiredService<MainViewModel>();
            return window;
        });

        // 5. Создаем сервис-провайдер (IoC-контейнер)
        var serviceProvider = services.BuildServiceProvider();

        // 6. Получаем экземпляр главного окна из DI-контейнера и отображаем его
        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
