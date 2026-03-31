namespace RPM_Lab8.Mediator;

public class Logger : Colleague
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}