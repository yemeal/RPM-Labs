using RPM_Lab7.Strategy;

namespace RPM_Lab7.Template_Method;

public class ConsoleHandler(IFormatStrategy formatStrategy) : EventHandlerBase(formatStrategy)
{
    protected override void SendMessage(string message)
    {
        Console.WriteLine("=== [ConsoleHandler] Отправка сообщения ===");
        Console.WriteLine(message);
    }

    protected override void LogResult()
    {
        Console.WriteLine("[LOG] Событие успешно обработано и выведено в консоль.\n");
    }
}