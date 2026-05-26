using System.Text.RegularExpressions;
using PhoneBook.ViewModels;

namespace PhoneBook.Models;

// Model хранит данные предметной области телефонной книги.
// Класс не знает о View и может использоваться независимо от интерфейса.
public class Contact : ObservableObject
{
    private static readonly Regex PhoneRegex = new(@"^(?:\+7\d{10}|\d{10})$", RegexOptions.Compiled);

    private string _name = string.Empty;
    private string _phone = string.Empty;

    /// <summary>
    /// Идентификатор контакта в базе данных.
    /// </summary>
    public int Id { get; init; }

    public Contact(string name, string phone)
    {
        name = name.Trim();
        phone = phone.Trim();

        if (!Validate(name, phone))
        {
            throw new ArgumentException("Имя не должно быть пустым, телефон должен иметь формат +7XXXXXXXXXX или XXXXXXXXXX.");
        }

        _name = name;
        _phone = phone;
    }

    public string Name
    {
        get => _name;
        set
        {
            var trimmedValue = value.Trim();
            if (!_ValidateName(trimmedValue))
            {
                throw new ArgumentException("Имя контакта не должно быть пустым.");
            }

            Set(ref _name, trimmedValue);
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            var trimmedValue = value.Trim();
            if (!_ValidatePhone(trimmedValue))
            {
                throw new ArgumentException("Телефон должен иметь формат +7XXXXXXXXXX или XXXXXXXXXX.");
            }

            Set(ref _phone, trimmedValue);
        }
    }

    public static bool Validate(string name, string phone)
        => _ValidateName(name) && _ValidatePhone(phone);

    private static bool _ValidateName(string name)
        => !string.IsNullOrWhiteSpace(name);

    private static bool _ValidatePhone(string phone)
        => PhoneRegex.IsMatch(phone.Trim());
}
