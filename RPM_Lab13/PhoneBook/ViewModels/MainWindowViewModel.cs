using System.Windows.Input;
using PhoneBook.Services;

namespace PhoneBook.ViewModels;

public class MainWindowViewModel
{
    public INavigationService NavigationService { get; }
    public MainWindowViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            ShowContactsCommand = new RelayCommand(
                () => NavigationService.NavigateTo<ContactsListViewModel>()
            );
            ShowAboutCommand = new RelayCommand(
                () => NavigationService.NavigateTo<AboutViewModel>()
            );
            NavigationService.NavigateTo<ContactsListViewModel>();
        }
    public ICommand ShowContactsCommand { get; }
    public ICommand ShowAboutCommand { get; }
}