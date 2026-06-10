using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.ViewModels;

/// <summary>
/// ViewModel для экрана редактирования контакта.
/// ЛР14: Вместо прямого внедрения PhoneBookDbContext используется IDbContextFactory.
/// Операция сохранения реализована по паттерну Fetch-Modify-Save:
/// 1. Создаётся новый контекст в блоке using.
/// 2. Сущность загружается из БД заново (Fetch) - она отслеживается этим контекстом.
/// 3. Поля сущности обновляются данными из UI (Modify).
/// 4. Вызывается SaveChanges - Change Tracker генерирует UPDATE только для изменённых полей (Save).
/// Это избегает использования context.Update(), который помечает ВСЕ поля как Modified.
/// </summary>
public class ContactEditViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;
    private readonly IDbContextFactory<PhoneBookDbContext> _contextFactory;
    private Contact? _contact;

    // Локальные копии — изменения применяются к оригиналу только по «Сохранить»
    private string _editName = string.Empty;
    private string _editPhone = string.Empty;
    private string _validationMessage = string.Empty;

    public string EditName
    {
        get => _editName;
        set
        {
            if (Set(ref _editName, value))
                RefreshValidation();
        }
    }

    public string EditPhone
    {
        get => _editPhone;
        set
        {
            if (Set(ref _editPhone, value))
                RefreshValidation();
        }
    }

    public string ValidationMessage
    {
        get => _validationMessage;
        private set => Set(ref _validationMessage, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    // ЛР14: Конструктор принимает IDbContextFactory вместо PhoneBookDbContext
    public ContactEditViewModel(
        INavigationService navigationService,
        IDialogService dialogService,
        IDbContextFactory<PhoneBookDbContext> contextFactory)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
        _contextFactory = contextFactory;

        SaveCommand = new RelayCommand(() =>
        {
            try
            {
                // ЛР14: Паттерн Fetch-Modify-Save с использованием локального контекста.
                if (_contact is not null)
                {
                    using var context = _contextFactory.CreateDbContext();
                    
                    // 1. Fetch: загружаем сущность из БД в новом контексте.
                    //    Теперь она отслеживается этим контекстом.
                    var contactToUpdate = context.Contacts.Find(_contact.Id);
                    if (contactToUpdate is not null)
                    {
                        // 2. Modify: переносим данные из UI в отслеживаемый объект.
                        //    Change Tracker автоматически фиксирует, какие именно
                        //    свойства изменились, и пометит только их как Modified.
                        contactToUpdate.Name = _editName.Trim();
                        contactToUpdate.Phone = _editPhone.Trim();
                        
                        // 3. Save: Change Tracker генерирует оптимальный UPDATE,
                        //    обновляя только изменённые столбцы.
                        context.SaveChanges();
                    }
                    
                    // Обновляем UI-модель для отображения на экране списка
                    _contact.Name = _editName.Trim();
                    _contact.Phone = _editPhone.Trim();
                }
                _navigationService.NavigateTo<ContactsListViewModel>();
            }
            catch (Exception ex)
            {
                _dialogService.ShowError($"Ошибка при сохранении изменений: {ex.Message}", "Ошибка");
            }
        },
        // Кнопка «Сохранить» активна только при валидных данных
        () => Contact.Validate(_editName, _editPhone));

        CancelCommand = new RelayCommand(() =>
        {
            // Просто уходим назад — оригинальный контакт не изменён
            _navigationService.NavigateTo<ContactsListViewModel>();
        });
    }

    public void OnNavigatedTo(object? parameter)
    {
        if (parameter is Contact contact)
        {
            _contact = contact;
            // Копируем значения для редактирования
            _editName = contact.Name;
            _editPhone = contact.Phone;
            OnPropertyChanged(nameof(EditName));
            OnPropertyChanged(nameof(EditPhone));
            RefreshValidation();
        }
    }

    private void RefreshValidation()
    {
        ValidationMessage = Contact.Validate(_editName, _editPhone)
            ? string.Empty
            : "Имя не должно быть пустым; телефон: +7XXXXXXXXXX или XXXXXXXXXX.";
        CommandManager.InvalidateRequerySuggested();
    }
}