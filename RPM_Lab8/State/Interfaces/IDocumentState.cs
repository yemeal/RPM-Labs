using RPM_Lab8.Mediator;

namespace RPM_Lab8.State;

public interface IDocumentState
{
    void Print(Document document);
    void AddToQueue(Document document);
    void CompletePrinting(Document document);
    void FailPrinting(Document document);
    void Reset(Document document);
}   