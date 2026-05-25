using System.Collections.ObjectModel;
using System.Windows.Input;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.ViewModels;

// ViewModel связывает View с моделью Contact.
// Здесь находится состояние формы ввода, коллекция контактов и команды пользователя.
public class ContactsListViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;
    private readonly IContactRepository _contactRepository;

    // Коллекция берётся из общего репозитория (Singleton)
    public ObservableCollection<Contact> Contacts => _contactRepository.Contacts;
    
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            if (Set(ref _name, value))
            {
                RefreshValidation();
            }
        }
    }
    
    private string _phone = string.Empty;
    public string Phone
    {
        get => _phone;
        set
        {
            if (Set(ref _phone, value))
            {
                RefreshValidation();
            }
        }
    }
    
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand EditCommand { get; }

    // Constructor Injection: DI-контейнер автоматически передаёт зависимости.
    public ContactsListViewModel(IDialogService dialogService, INavigationService navigationService, IContactRepository contactRepository)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));

        // AddCommand не принимает параметров: данные берутся из свойств ViewModel.
        AddCommand = new RelayCommand(AddContact, CanAddContact);

        // DeleteCommand принимает выбранный Contact из CommandParameter.
        DeleteCommand = new RelayCommand<Contact>(DeleteContact, CanDeleteContact);
        
        // Команда редактирования: навигация к экрану редактирования,
        // передавая выбранный контакт в качестве параметра.
        EditCommand = new RelayCommand(
            () => _navigationService.NavigateTo<ContactEditViewModel>(SelectedContact),
            () => SelectedContact is not null
        );

    }
    
    public Contact? SelectedContact
    {
        get;
        set
        {
            if (Set(ref field, value))
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }

    public string ValidationMessage
    {
        get;
        private set => Set(ref field, value);
    } = "Введите имя и телефон в формате +7XXXXXXXXXX или XXXXXXXXXX.";

    
    private void AddContact()
    {
        // Проверка на дубликат по номеру телефона
        if (Contacts.Any(c => c.Phone == Phone))
        {
            _dialogService.ShowWarning("Контакт с таким номером уже существует!", "Предупреждение");
            return;
        }

        var contact = new Contact(Name, Phone);
        Contacts.Add(contact);

        Name = string.Empty;
        Phone = string.Empty;
        ValidationMessage = "Контакт добавлен.";
        
        // Информационное сообщение об успешном добавлении
        _dialogService.ShowInfo("Контакт успешно добавлен!", "Информация");
    }

    private bool CanAddContact()
        => Contact.Validate(Name, Phone);

    private void DeleteContact(Contact? contact)
    {
        if (contact is null)
        {
            return;
        }

        // Запрос подтверждения удаления
        var confirm = _dialogService.ShowConfirmation($"Удалить контакт \"{contact.Name}\"?", "Подтверждение удаления");
        if (!confirm)
        {
            return;
        }

        Contacts.Remove(contact);
        if (SelectedContact == contact)
        {
            SelectedContact = null;
        }
        
        // Информационное сообщение об успешном удалении
        _dialogService.ShowInfo("Контакт успешно удален!", "Информация");
        ValidationMessage = "Контакт удален.";
    }

    private static bool CanDeleteContact(Contact? contact)
        => contact is not null;

    private void RefreshValidation()
    {
        ValidationMessage = Contact.Validate(Name, Phone)
            ? string.Empty
            : "Имя не должно быть пустым; телефон: +7XXXXXXXXXX или XXXXXXXXXX.";
        CommandManager.InvalidateRequerySuggested();
    }
}
