using System.Windows;
using PhoneBook.ViewModels;

namespace PhoneBook;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // View получает ViewModel через DataContext.
        // XAML обращается к свойствам и командам только через Data Binding.
        DataContext = new MainViewModel();
    }
}
