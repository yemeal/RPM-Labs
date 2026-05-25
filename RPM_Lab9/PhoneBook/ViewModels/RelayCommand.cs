using System.Windows.Input;

namespace PhoneBook.ViewModels;

// ICommand-обертка для команд без параметра.
// View вызывает команду через Binding, а ViewModel остается независимой от кнопок и событий UI.
public class RelayCommand(Action execute, Func<bool>? canExecute = null) : ICommand
{
    private readonly Action _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Func<bool>? _canExecute = canExecute;

    public bool CanExecute(object? parameter = null)
        => _canExecute?.Invoke() ?? true;

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            _execute.Invoke();
        }
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}

// ICommand-обертка для команд с параметром, например удаления выбранного контакта.
public class RelayCommand<T>(Action<T?> execute, Predicate<T?>? canExecute = null) : ICommand
{
    private readonly Action<T?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Predicate<T?>? _canExecute = canExecute;

    public bool CanExecute(object? parameter)
        => _canExecute?.Invoke(ConvertParameter(parameter)) ?? true;

    public void Execute(object? parameter)
    {
        var convertedParameter = ConvertParameter(parameter);
        if (CanExecute(convertedParameter))
        {
            _execute.Invoke(convertedParameter);
        }
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    private static T? ConvertParameter(object? parameter)
        => parameter is T value ? value : default;
}
