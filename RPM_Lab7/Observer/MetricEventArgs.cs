namespace RPM_Lab7.Observer;

public class MetricEventArgs(string eventType, MetricData data) : EventArgs
{
    public string EventType { get; } = eventType ?? throw new ArgumentNullException(nameof(eventType));
    
    public MetricData Data { get; } = data ?? throw new ArgumentNullException(nameof(data));
}