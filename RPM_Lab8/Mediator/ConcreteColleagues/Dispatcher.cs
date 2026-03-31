namespace RPM_Lab8.Mediator;

public class Dispatcher : Colleague
{
    public void CommandProcessQueue()
    {
        Console.WriteLine("[Dispatcher] Начал обрабатывать очередь.");
        Mediator.Notify(this, "ProcessQueue");
    }
}