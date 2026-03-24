namespace RPM_Lab7.Strategy;

public interface IFormatStrategy
{
    string Format(string message, DateTime timestamp);
}