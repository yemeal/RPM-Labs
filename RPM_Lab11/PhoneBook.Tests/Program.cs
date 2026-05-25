using System.Collections.ObjectModel;
using PhoneBook.Models;
using PhoneBook.ViewModels;
using PhoneBook.Services;

var tests = new (string Name, Action Test)[]
{
    ("Contact accepts +7 phone format", ContactAcceptsCountryCodePhone),
    ("Contact accepts local phone format", ContactAcceptsLocalPhone),
    ("Contact rejects empty name", ContactRejectsEmptyName),
    ("Contact rejects invalid phone", ContactRejectsInvalidPhone),
    ("MainViewModel adds valid contact, clears input, and prompts Info", ViewModelAddsContactClearsInputAndPromptsInfo),
    ("MainViewModel prevents duplicate contact and prompts Warning", ViewModelPreventsDuplicateAndPromptsWarning),
    ("MainViewModel deletes contact when user confirms", ViewModelDeletesContactOnConfirmation),
    ("MainViewModel retains contact when user cancels deletion", ViewModelRetainsContactOnCancellation),
    ("MainViewModel prevents invalid add", ViewModelPreventsInvalidAdd)
};

var failed = 0;
foreach (var (name, test) in tests)
{
    try
    {
        test();
        Console.WriteLine($"PASS: {name}");
    }
    catch (Exception ex)
    {
        failed++;
        Console.WriteLine($"FAIL: {name}");
        Console.WriteLine(ex.Message);
    }
}

return failed;

static void ContactAcceptsCountryCodePhone()
{
    var contact = new Contact("Анна", "+79131234567");
    AssertEqual("Анна", contact.Name);
    AssertEqual("+79131234567", contact.Phone);
}

static void ContactAcceptsLocalPhone()
{
    var contact = new Contact("Иван", "9131234567");
    AssertEqual("Иван", contact.Name);
    AssertEqual("9131234567", contact.Phone);
}

static void ContactRejectsEmptyName()
{
    AssertThrows<ArgumentException>(() => _ = new Contact(" ", "+79131234567"));
}

static void ContactRejectsInvalidPhone()
{
    AssertThrows<ArgumentException>(() => _ = new Contact("Анна", "123"));
}

static void ViewModelAddsContactClearsInputAndPromptsInfo()
{
    var mockDialog = new MockDialogService();
    var viewModel = CreateViewModel(mockDialog);
    viewModel.Name = "Мария";
    viewModel.Phone = "+79135554433";

    AssertTrue(viewModel.AddCommand.CanExecute(null), "AddCommand must be enabled for valid input.");
    viewModel.AddCommand.Execute(null);

    AssertEqual(1, viewModel.Contacts.Count);
    AssertEqual("Мария", viewModel.Contacts[0].Name);
    AssertEqual(string.Empty, viewModel.Name);
    AssertEqual(string.Empty, viewModel.Phone);
    AssertEqual("Контакт успешно добавлен!", mockDialog.LastInfoMessage);
}

static void ViewModelPreventsDuplicateAndPromptsWarning()
{
    var mockDialog = new MockDialogService();
    var viewModel = CreateViewModel(mockDialog);
    viewModel.Name = "Мария";
    viewModel.Phone = "+79135554433";

    // Добавляем первый контакт
    viewModel.AddCommand.Execute(null);
    AssertEqual(1, viewModel.Contacts.Count);

    // Пытаемся добавить контакт с тем же номером
    viewModel.Name = "Петр";
    viewModel.Phone = "+79135554433";
    viewModel.AddCommand.Execute(null);

    // Проверяем, что контакт не добавился и вывелось предупреждение
    AssertEqual(1, viewModel.Contacts.Count);
    AssertEqual("Контакт с таким номером уже существует!", mockDialog.LastWarningMessage);
}

static void ViewModelDeletesContactOnConfirmation()
{
    var mockDialog = new MockDialogService { ConfirmationResult = true };
    var viewModel = CreateViewModel(mockDialog);
    viewModel.Name = "Петр";
    viewModel.Phone = "9130001122";

    viewModel.AddCommand.Execute(null);
    var contact = viewModel.Contacts[0];

    AssertTrue(viewModel.DeleteCommand.CanExecute(contact), "DeleteCommand must be enabled when contact parameter is supplied.");
    viewModel.DeleteCommand.Execute(contact);

    AssertEqual(0, viewModel.Contacts.Count);
}

static void ViewModelRetainsContactOnCancellation()
{
    var mockDialog = new MockDialogService { ConfirmationResult = false };
    var viewModel = CreateViewModel(mockDialog);
    viewModel.Name = "Петр";
    viewModel.Phone = "9130001122";

    viewModel.AddCommand.Execute(null);
    var contact = viewModel.Contacts[0];

    AssertTrue(viewModel.DeleteCommand.CanExecute(contact), "DeleteCommand must be enabled when contact parameter is supplied.");
    viewModel.DeleteCommand.Execute(contact);

    // Так как пользователь отказался, контакт должен остаться в списке
    AssertEqual(1, viewModel.Contacts.Count);
}

static void ViewModelPreventsInvalidAdd()
{
    var mockDialog = new MockDialogService();
    var viewModel = CreateViewModel(mockDialog);
    viewModel.Name = string.Empty;
    viewModel.Phone = "123";

    AssertFalse(viewModel.AddCommand.CanExecute(null), "AddCommand must be disabled for invalid input.");
}

/// <summary>
/// Фабричный метод для создания ContactsListViewModel со всеми mock-зависимостями.
/// </summary>
static ContactsListViewModel CreateViewModel(MockDialogService? dialog = null)
{
    return new ContactsListViewModel(
        dialog ?? new MockDialogService(),
        new MockNavigationService(),
        new MockContactRepository()
    );
}

static void AssertEqual<T>(T expected, T actual)
{
    if (!EqualityComparer<T>.Default.Equals(expected, actual))
    {
        throw new InvalidOperationException($"Expected: {expected}; actual: {actual}.");
    }
}

static void AssertTrue(bool condition, string message)
{
    if (!condition)
    {
        throw new InvalidOperationException(message);
    }
}

static void AssertFalse(bool condition, string message)
{
    if (condition)
    {
        throw new InvalidOperationException(message);
    }
}

static void AssertThrows<TException>(Action action)
    where TException : Exception
{
    try
    {
        action();
    }
    catch (TException)
    {
        return;
    }

    throw new InvalidOperationException($"Expected exception {typeof(TException).Name}.");
}

/// <summary>
/// Тестовый Mock для проверки взаимодействия ViewModel с диалоговыми окнами.
/// </summary>
public class MockDialogService : IDialogService
{
    public bool ConfirmationResult { get; set; } = true;
    public string? LastInfoMessage { get; private set; }
    public string? LastWarningMessage { get; private set; }
    public string? LastErrorMessage { get; private set; }

    public void ShowInfo(string message, string title = "Информация")
    {
        LastInfoMessage = message;
    }

    public void ShowWarning(string message, string title = "Предупреждение")
    {
        LastWarningMessage = message;
    }

    public void ShowError(string message, string title = "Ошибка")
    {
        LastErrorMessage = message;
    }

    public bool ShowConfirmation(string message, string title = "Подтверждение")
    {
        return ConfirmationResult;
    }
}

/// <summary>
/// Тестовый Mock навигации — не выполняет реальную навигацию.
/// </summary>
public class MockNavigationService : INavigationService
{
    public object? CurrentViewModel { get; private set; }

    public void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class
    {
        // В тестах навигация не выполняется
    }
}

/// <summary>
/// Тестовый Mock репозитория контактов — хранит контакты в памяти.
/// </summary>
public class MockContactRepository : IContactRepository
{
    public ObservableCollection<Contact> Contacts { get; } = new();
}

