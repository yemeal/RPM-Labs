using PhoneBook.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.Services;

public class NavigationService(IServiceProvider serviceProvider) : ObservableObject, INavigationService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private object? _currentViewModel;
    public object? CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

    public void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class
    {
        // 1. Получаем ViewModel из контейнера DI
        var vm = _serviceProvider.GetRequiredService<TViewModel>();
        
        // 2. Если ViewModel поддерживает прием параметров (опционально)
        if (vm is INavigationAware navigationAware)
        {
            navigationAware.OnNavigatedTo(parameter);
        }
        
        // 3. Обновляем CurrentViewModel. ContentControl подхватит изменение.
        CurrentViewModel = vm; 
    }
    
}