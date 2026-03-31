using RPM_Lab8.State;

namespace RPM_Lab8.Mediator;

public class Printer : Colleague
{
    public bool SimulateFailure { get; set; } = false;

    public void StartPrint(Document document)
    {
        Console.WriteLine($"[Printer] Физическая печать '{document.Title}': {document.Text}");

        if (SimulateFailure)
        {
            SimulateFailure = false;
            Mediator.Notify(this, "PrintFailed",  document);
            return;
        }

        Mediator.Notify(this, "PrintSuccess", document);

    }
}