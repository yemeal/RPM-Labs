using RPM_Lab7.Strategy;
using RPM_Lab7.Observer;
using RPM_Lab7.Template_Method;

namespace RPM_Lab7;

public static class Program
{
    public static void Main(string[] args)
    {
        // 1. Создаем монитор событий (Издатель / Subject в паттерне Наблюдатель)
        EventMonitor monitor = new();

        // 2. Создаем стратегии форматирования (Паттерн Стратегия)
        IFormatStrategy textStrategy = new TextFormatStrategy();
        IFormatStrategy jsonStrategy = new JsonFormatStrategy();

        // 3. Создаем конкретные обработчики (Паттерн Шаблонный метод)
        // Внедряем в них различные стратегии форматирования
        ConsoleHandler consoleHandler = new(textStrategy);
        
        const string logFilePath = "metrics_log.txt";
        FileHandler fileHandler = new(jsonStrategy, logFilePath);

        // 4. Регистрируем обработчики в мониторе (Паттерн Наблюдатель)
        // Метод ProcessEvent (шаблонный метод) идеально подходит под делегат MetricEventHandler
        monitor.OnMetricExceeded += consoleHandler.ProcessEvent;
        monitor.OnMetricExceeded += fileHandler.ProcessEvent;

        Console.WriteLine("=== Запуск системы мониторинга ===\n");

        // 5. Смоделируем несколько нормальных событий (порог не превышен)
        // В этом случае OnMetricExceeded не вызовется
        monitor.CheckMetric("CPU Usage", 45.0, 80.0);
        monitor.CheckMetric("Memory Usage", 60.0, 90.0);

        Console.WriteLine("\n--- Имитация превышения порогов (Срабатывание триггеров) ---\n");

        // Смоделируем критические события (порог превышен)
        // Это инициирует рассылку событий всем подписчикам
        monitor.CheckMetric("CPU Usage", 85.5, 80.0);
        monitor.CheckMetric("Memory Usage", 95.0, 90.0);

        // 6. Демонстрация гибкости: смена стратегии «на лету»
        Console.WriteLine("\n--- Изменяем стратегию форматирования для консоли на JSON ---\n");
        consoleHandler.SetFormatStrategy(jsonStrategy);
        
        // Генерируем еще одно событие
        monitor.CheckMetric("Network Activity", 1200.0, 1000.0);

        Console.WriteLine("\n=== Симуляция завершена ===");
        Console.ReadLine();
    }
}