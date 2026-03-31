using RPM_Lab8.State;

namespace RPM_Lab8.Mediator;

public class PrintSystemMediator : IMediator
{
    private readonly Printer _printer;
    private readonly PrintQueue _queue;
    private readonly Logger _logger;

    public PrintSystemMediator(Printer printer, PrintQueue queue, Logger logger)
    {
        _printer = printer;
        _queue = queue;
        _logger = logger;
        _printer.SetMediator(this);
        _queue.SetMediator(this);
        _logger.SetMediator(this);
    }

    public void Notify(Colleague sender, string ev, Document document = null)
    {
        switch (ev)
        {
            // Событие от Документа (через State): "Хочу в очередь"
            case "AddToQueue":
                _logger.WriteMessage($"Документ '{document.Title}' запрошен в очередь.");
                _queue.EnqueueItem(document);
                break;
            
            // Событие от Очереди: "Документ добавлен"
            case "Enqueued":
                _logger.WriteMessage($"Документ '{document.Title}' помещен в очередь.");
                break;
            
            // Событие от Документа (через State): "Хочу печататься"
            case "RequestPrint": 
                _logger.WriteMessage($"Документ '{document.Title}' запрошен в печать.");
                _printer.StartPrint(document); 
                break;
                
            // Событие от Диспетчера: "Печатай всю очередь"
            case "ProcessQueue":
                while (!_queue.IsEmpty)
                {
                    _logger.WriteMessage($"Очередь не пуста. Вытаскиваем следующий документ.");
                    var nextDoc = _queue.DequeueItem();
                    nextDoc.Print();
                }
                
                _logger.WriteMessage("Очередь пуста.");
                return;
            
            
            // Событие от Принтера: "Успех"
            case "PrintSuccess":
                document.CompletePrinting();
                _logger.WriteMessage($"Успешно напечатан '{document.Title}'.");
                break;
            
            // Событие от Принтера: "Ошибка"
            case "PrintFailed":
                document.FailPrinting();
                _logger.WriteMessage($"ОШИБКА печати '{document.Title}'.");
                break;
        }       
    }
}