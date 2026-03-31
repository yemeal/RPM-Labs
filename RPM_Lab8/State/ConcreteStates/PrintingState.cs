namespace RPM_Lab8.State;

public class PrintingState : IDocumentState
{
    public void Print(Document document) 
        => Console.WriteLine("[FSM: Printing] Документ уже в процессе печати.");

    public void AddToQueue(Document document) 
        => Console.WriteLine("[FSM: Printing] Нельзя добавить в очередь, идет печать.");

    public void CompletePrinting(Document document)
    {
        document.SetState(new DoneState());
    }

    public void FailPrinting(Document document)
    {
        document.SetState(new ErrorState());
    }

    public void Reset(Document document) 
        => Console.WriteLine("[FSM: Printing] Нельзя сбросить во время печати.");
}