using RPM_Lab7.Observer;
using RPM_Lab7.Strategy;

namespace RPM_Lab7.Template_Method;

public abstract class EventHandlerBase(IFormatStrategy formatStrategy)
{
    private IFormatStrategy FormatStrategy { get; set; } = formatStrategy;

    public void SetFormatStrategy(IFormatStrategy formatStrategy)
    {
        FormatStrategy = formatStrategy;
    }

    protected virtual string FormatMessage(string type, object data)
    {
        var rawMessage = $"Type: {type} | Data: {data}";
        
        // Если данные формата MetricData, берем оригинальный Timestamp
        if (data is MetricData metricData)
        {
            return FormatStrategy.Format(rawMessage, metricData.Timestamp);
        }
        
        return FormatStrategy.Format(rawMessage, DateTime.UtcNow);
    }
    
    protected abstract void SendMessage(string message);
    protected abstract void LogResult();

    public void ProcessEvent(MetricEventArgs e)
    {
        var message = FormatMessage(e.EventType, e.Data);
        SendMessage(message);
        LogResult();
    }
    
}