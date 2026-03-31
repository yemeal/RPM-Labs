using RPM_Lab8.State;

namespace RPM_Lab8.Mediator;

public class PrintQueue : Colleague
{
    private readonly Queue<Document> _queue = new();
    public bool IsEmpty => _queue.Count == 0;

    public void EnqueueItem(Document document)
    {
        _queue.Enqueue(document);
        Mediator.Notify(this, "Enqueued", document);
    }

    public Document DequeueItem()
    {
        var document = _queue.Dequeue();
        return document;
    }
    
}