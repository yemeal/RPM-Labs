namespace RPM_Lab7.Observer;

public delegate void MetricEventHandler(MetricEventArgs e);

/// <summary>
/// Субъект (Subject). Вместо интерфейса ISubject и методов Attach/Detach
/// использует стандартное событие .NET.
/// </summary>
public class EventMonitor
{
    // Событие (Event) — это ключевой элемент паттерна Observer в C#
    public event MetricEventHandler? OnMetricExceeded;

    public void CheckMetric(string metricName, double value, double threshold)
    {
        Console.WriteLine($"[Monitor]: Checking {metricName} ({value} vs {threshold})");
        if (!(value > threshold)) return;
        
        MetricData eventData = new(metricName, value, threshold, DateTime.UtcNow);
        OnMetricExceeded?.Invoke(new MetricEventArgs(eventType: metricName +
                                                                "_Exceeded", data: eventData));
    }
}