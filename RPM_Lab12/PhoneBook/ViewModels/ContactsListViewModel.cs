using System.Collections.ObjectModel;
using System.Windows.Input;
using PhoneBook.Data;
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
    private readonly PhoneBookDbContext _context;

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
    // PhoneBookDbContext внедряется для чтения данных из базы данных.
    public ContactsListViewModel(IDialogService dialogService, INavigationService navigationService, IContactRepository contactRepository, PhoneBookDbContext context)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        _context = context ?? throw new ArgumentNullException(nameof(context));

        // Загрузка контактов из базы данных при первом создании ViewModel
        LoadContactsFromDatabase();

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

    /// <summary>
    /// Загружает контакты из базы данных в ObservableCollection.
    /// Вызывается при запуске приложения (создании ViewModel).
    /// </summary>
    private void LoadContactsFromDatabase()
    {
        if (Contacts.Count > 0) return; // Данные уже загружены

        var dbContacts = _context.Contacts.ToList();
        foreach (var dbContact in dbContacts)
        {
            Contacts.Add(new Contact(dbContact.Name, dbContact.Phone) { Id = dbContact.Id });
        }
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

        // Создаём сущность БД и сохраняем
        var dbContact = new Data.Models.Contact { Name = Name.Trim(), Phone = Phone.Trim() };
        _context.Contacts.Add(dbContact);
        _context.SaveChanges();

        // Создаём модель ViewModel с Id из БД
        var contact = new Contact(Name, Phone) { Id = dbContact.Id };
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

        // Удаляем из базы данных
        var dbContact = _context.Contacts.Find(contact.Id);
        if (dbContact is not null)
        {
            _context.Contacts.Remove(dbContact);
            _context.SaveChanges();
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
