using System.Collections.ObjectModel;
using PhoneBook.Models;

namespace PhoneBook.Services;

/// <summary>
/// Общее хранилище контактов. Регистрируется как Singleton,
/// чтобы данные сохранялись при пересоздании Transient-ViewModels.
/// </summary>
public interface IContactRepository
{
    ObservableCollection<Contact> Contacts { get; }
}

public class ContactRepository : IContactRepository
{
    public ObservableCollection<Contact> Contacts { get; } = new();
}
