using RPM_Lab8.Mediator;

namespace RPM_Lab8.State;

public class Document(string title, string text) : Colleague
{
    private IDocumentState _documentState = new NewState();
    
    public readonly string Title = title;
    public readonly string Text = text;
    
    public void SetState(IDocumentState state) 
        => _documentState = state;

    public void Print() 
        => _documentState.Print(this);

    public void AddToQueue() 
        => _documentState.AddToQueue(this);

    public void CompletePrinting() 
        => _documentState.CompletePrinting(this);

    public void FailPrinting() 
        => _documentState.FailPrinting(this);

    public void Reset() 
        =>  _documentState.Reset(this);
    
       
    
}