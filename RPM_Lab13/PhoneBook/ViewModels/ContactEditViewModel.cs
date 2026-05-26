using System.Windows.Input;
using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.ViewModels;

public class ContactEditViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;
    private readonly PhoneBookDbContext _context;
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

    public ContactEditViewModel(INavigationService navigationService, IDialogService dialogService, PhoneBookDbContext context)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
        _context = context;

        SaveCommand = new RelayCommand(() =>
        {
            try
            {
                // Update: применяем изменения к оригинальному контакту
                if (_contact is not null)
                {
                    _contact.Name = _editName.Trim();
                    _contact.Phone = _editPhone.Trim();

                    // Находим отслеживаемую сущность и обновляем поля
                    var dbContact = _context.Contacts.Find(_contact.Id);
                    if (dbContact is not null)
                    {
                        dbContact.Name = _contact.Name;
                        dbContact.Phone = _contact.Phone;
                        // SaveChanges обнаруживает Modified-состояние и генерирует UPDATE
                        _context.SaveChanges();
                    }
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