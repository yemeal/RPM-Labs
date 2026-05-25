namespace PhoneBook.Services;

/// <summary>
/// Интерфейс сервиса диалоговых окон для абстрагирования UI-взаимодействий от ViewModel.
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Отображает информационное сообщение.
    /// </summary>
    void ShowInfo(string message, string title = "Информация");

    /// <summary>
    /// Отображает предупреждающее сообщение.
    /// </summary>
    void ShowWarning(string message, string title = "Предупреждение");

    /// <summary>
    /// Отображает сообщение об ошибке.
    /// </summary>
    void ShowError(string message, string title = "Ошибка");

    /// <summary>
    /// Запрашивает подтверждение у пользователя (Да/Нет).
    /// </summary>
    /// <returns>True, если пользователь выбрал "Да"; иначе False.</returns>
    bool ShowConfirmation(string message, string title = "Подтверждение");
}
