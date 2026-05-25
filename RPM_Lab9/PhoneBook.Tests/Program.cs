using PhoneBook.Models;
using PhoneBook.ViewModels;

var tests = new (string Name, Action Test)[]
{
    ("Contact accepts +7 phone format", ContactAcceptsCountryCodePhone),
    ("Contact accepts local phone format", ContactAcceptsLocalPhone),
    ("Contact rejects empty name", ContactRejectsEmptyName),
    ("Contact rejects invalid phone", ContactRejectsInvalidPhone),
    ("MainViewModel adds valid contact and clears input", ViewModelAddsContactAndClearsInput),
    ("MainViewModel prevents invalid add", ViewModelPreventsInvalidAdd),
    ("MainViewModel deletes command parameter", ViewModelDeletesCommandParameter)
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

static void ViewModelAddsContactAndClearsInput()
{
    var viewModel = new MainViewModel
    {
        Name = "Мария",
        Phone = "+79135554433"
    };

    AssertTrue(viewModel.AddCommand.CanExecute(null), "AddCommand must be enabled for valid input.");
    viewModel.AddCommand.Execute(null);

    AssertEqual(1, viewModel.Contacts.Count);
    AssertEqual("Мария", viewModel.Contacts[0].Name);
    AssertEqual(string.Empty, viewModel.Name);
    AssertEqual(string.Empty, viewModel.Phone);
}

static void ViewModelPreventsInvalidAdd()
{
    var viewModel = new MainViewModel
    {
        Name = string.Empty,
        Phone = "123"
    };

    AssertFalse(viewModel.AddCommand.CanExecute(null), "AddCommand must be disabled for invalid input.");
}

static void ViewModelDeletesCommandParameter()
{
    var viewModel = new MainViewModel
    {
        Name = "Петр",
        Phone = "9130001122"
    };

    viewModel.AddCommand.Execute(null);
    var contact = viewModel.Contacts[0];

    AssertTrue(viewModel.DeleteCommand.CanExecute(contact), "DeleteCommand must be enabled when contact parameter is supplied.");
    viewModel.DeleteCommand.Execute(contact);

    AssertEqual(0, viewModel.Contacts.Count);
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
