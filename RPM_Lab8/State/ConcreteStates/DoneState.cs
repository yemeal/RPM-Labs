namespace RPM_Lab8.State;

public class DoneState : IDocumentState
{
    public void Print(Document document) 
        => Console.WriteLine("[FSM: Done] Документ уже напечатан.");
    
    public void AddToQueue(Document document) 
        => Console.WriteLine("[FSM: Done] Напечатанный документ нельзя добавить в очередь.");
    
    public void CompletePrinting(Document document) {}
    
    public void FailPrinting(Document document) {}
    
    public void Reset(Document document) 
        => Console.WriteLine("[FSM: Done] Финальное состояние. Сброс невозможен.");
}