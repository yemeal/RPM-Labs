using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.ViewModels;

// ViewModel связывает View с моделью Contact.
// Здесь находится состояние формы ввода, коллекция контактов и команды пользователя.
// ЛР14: Вместо прямого внедрения PhoneBookDbContext используется IDbContextFactory.
// Каждая CRUD-операция создаёт собственный короткоживущий контекст в блоке using,
// что предотвращает утечки памяти через Change Tracker и Captive Dependency.
public class ContactsListViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;
    private readonly IDbContextFactory<PhoneBookDbContext> _contextFactory;

    // Локальная коллекция контактов для UI.
    // Данные загружаются из БД при каждом создании ViewModel.
    public ObservableCollection<Contact> Contacts { get; } = new();

    /// <summary>
    /// Представление с поддержкой фильтрации для привязки к DataGrid.
    /// Фильтрация выполняется по уже загруженной коллекции без обращения к БД.
    /// </summary>
    public ICollectionView FilteredContacts { get; }

    private string _searchText = string.Empty;
    /// <summary>
    /// Текст поиска. При изменении коллекция фильтруется по имени и телефону.
    /// </summary>
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (Set(ref _searchText, value))
            {
                FilteredContacts.Refresh();
            }
        }
    }
    
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
    // ЛР14: Вместо PhoneBookDbContext внедряется IDbContextFactory<PhoneBookDbContext>.
    // Фабрика - Singleton, но создаваемые ею контексты - короткоживущие.
    public ContactsListViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        IDbContextFactory<PhoneBookDbContext> contextFactory)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));

        // Загрузка контактов из базы данных при первом создании ViewModel (Read)
        LoadContactsFromDatabase();

        // Настройка фильтрации через ICollectionView
        FilteredContacts = CollectionViewSource.GetDefaultView(Contacts);
        FilteredContacts.Filter = FilterContact;

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
    /// Предикат фильтрации контакта по SearchText.
    /// Поиск выполняется по имени и телефону без учёта регистра.
    /// </summary>
    private bool FilterContact(object obj)
    {
        if (string.IsNullOrWhiteSpace(_searchText))
            return true;

        if (obj is Contact contact)
        {
            return contact.Name.Contains(_searchText, StringComparison.OrdinalIgnoreCase)
                || contact.Phone.Contains(_searchText, StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }

    /// <summary>
    /// Read: загружает контакты из базы данных в ObservableCollection.
    /// ЛР14: Создаётся локальный контекст через фабрику в блоке using.
    /// После загрузки данных контекст немедленно уничтожается,
    /// очищая Change Tracker и освобождая ресурсы.
    /// </summary>
    private void LoadContactsFromDatabase()
    {
        try
        {
            using var context = _contextFactory.CreateDbContext();
            var dbContacts = context.Contacts.AsNoTracking().ToList();
            
            Contacts.Clear();
            foreach (var dbContact in dbContacts)
            {
                Contacts.Add(new Contact(dbContact.Name, dbContact.Phone) { Id = dbContact.Id });
            }
        }
        catch (Exception ex)
        {
            _dialogService.ShowError($"Ошибка загрузки данных из БД: {ex.Message}", "Ошибка");
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

    
    /// <summary>
    /// Create: добавляет новый контакт в БД и в ObservableCollection.
    /// ЛР14: Создаётся локальный контекст через фабрику в блоке using.
    /// Контекст существует только на время выполнения INSERT-операции,
    /// после чего уничтожается вместе с Change Tracker.
    /// </summary>
    private void AddContact()
    {
        // Проверка на дубликат по номеру телефона
        if (Contacts.Any(c => c.Phone == Phone))
        {
            _dialogService.ShowWarning("Контакт с таким номером уже существует!", "Предупреждение");
            return;
        }

        try
        {
            using var context = _contextFactory.CreateDbContext();
            
            // Создаём сущность БД и помечаем как Added
            var dbContact = new Data.Models.Contact { Name = Name.Trim(), Phone = Phone.Trim() };
            context.Contacts.Add(dbContact);
            // SaveChanges генерирует INSERT и сохраняет в БД
            context.SaveChanges();

            // Создаём модель ViewModel с Id, сгенерированным БД
            var contact = new Contact(Name, Phone) { Id = dbContact.Id };
            Contacts.Add(contact);

            Name = string.Empty;
            Phone = string.Empty;
            ValidationMessage = "Контакт добавлен.";
        
            _dialogService.ShowInfo("Контакт успешно добавлен!", "Информация");
        }
        catch (Exception ex)
        {
            _dialogService.ShowError($"Ошибка при добавлении контакта: {ex.Message}", "Ошибка");
        }
    }

    private bool CanAddContact()
        => Contact.Validate(Name, Phone);

    /// <summary>
    /// Delete: удаляет контакт из БД и из ObservableCollection.
    /// ЛР14: Создаётся локальный контекст через фабрику в блоке using.
    /// Сущность загружается заново в новом контексте по Id (она отсоединена
    /// от предыдущего контекста), помечается как Deleted и удаляется.
    /// </summary>
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

        try
        {
            using var context = _contextFactory.CreateDbContext();
            
            // Находим сущность в новом контексте по Id и помечаем как Deleted
            var dbContact = context.Contacts.Find(contact.Id);
            if (dbContact is not null)
            {
                context.Contacts.Remove(dbContact);
                // SaveChanges генерирует DELETE и сохраняет в БД
                context.SaveChanges();
            }

            // Обновляем UI-коллекцию
            Contacts.Remove(contact);
            if (SelectedContact == contact)
            {
                SelectedContact = null;
            }
        
            _dialogService.ShowInfo("Контакт успешно удален!", "Информация");
            ValidationMessage = "Контакт удален.";
        }
        catch (Exception ex)
        {
            _dialogService.ShowError($"Ошибка при удалении контакта: {ex.Message}", "Ошибка");
        }
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
