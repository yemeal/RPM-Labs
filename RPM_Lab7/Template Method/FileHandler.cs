using RPM_Lab7.Strategy;

namespace RPM_Lab7.Template_Method;

public class FileHandler(IFormatStrategy formatStrategy, string filePath = "events.txt" ) : EventHandlerBase(formatStrategy)
{
    private readonly string _filePath= filePath 
                                       ?? throw new ArgumentNullException(nameof(filePath));
    protected override void SendMessage(string message)
    {
        File.AppendAllText(_filePath, message + Environment.NewLine);
    }

    protected override void LogResult()
    {
        Console.WriteLine($"[LOG] Событие успешно обработано и записано в файл: {_filePath}\\n");
    }
}