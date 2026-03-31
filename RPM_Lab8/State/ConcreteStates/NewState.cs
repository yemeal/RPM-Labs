namespace RPM_Lab8.State;

public class NewState : IDocumentState
{
    public void Print(Document document)
    {
        document.SetState(new PrintingState());
        document.Mediator.Notify(document, "RequestPrint", document);
    }

    public void AddToQueue(Document document)
    {
        document.Mediator.Notify(document, "AddToQueue", document);
    }
    
    public void CompletePrinting(Document document) { /* Игнорируем */ }
    
    public void FailPrinting(Document document) { /* Игнорируем */ }
    
    public void Reset(Document document) { /* Уже в NewState */ }
}