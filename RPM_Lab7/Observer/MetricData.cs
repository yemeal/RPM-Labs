namespace RPM_Lab7.Observer;

/// <summary>
/// Класс, представляющий данные о событии мониторинга
/// </summary>

public class MetricData(string metricName, double value, double threshold, DateTime timestamp)
{
    // Название метрики
    public string MetricName { get; } = metricName ?? throw new ArgumentNullException(nameof(metricName));
    
    // Зарегистрированное значение
    public double Value { get; } = value;
    
    // Критический порог
    public double Threshold { get; } = threshold;
    
    public DateTime Timestamp { get; } = timestamp;

    public override string ToString()
    {
        return $"Metric: {MetricName}, Value: {Value} (Threshold: {Threshold})";
    }
}