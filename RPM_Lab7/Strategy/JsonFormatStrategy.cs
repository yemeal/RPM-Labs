namespace RPM_Lab7.Strategy;

public class JsonFormatStrategy : IFormatStrategy
{
    public string Format(string message, DateTime timestamp)
    {
        return $"{{\"timestamp\":\"{timestamp:O}\",\"message\":\"{message}\"}}";
    }
}