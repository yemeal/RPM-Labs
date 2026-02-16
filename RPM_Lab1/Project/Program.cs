using OOP_Fundamentals_Library;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Создаем клиентов и сотрудников через конструкторы (валидация сработает сразу)
            try
            {
                var customer = new Customer("Петя", 30);

                // Создаем сотрудника
                var employee = new Employee("Алиса", 25, 50000, "Разработчик");

                // Создаем менеджера
                var manager = new Manager("Боб", 40, 80000, "IT");
                manager.AddToTeam(employee); // Используем метод, а не прямой доступ к списку

                Console.WriteLine("Инфо:");
                ReportService.GenerateReport(customer);
                ReportService.GenerateReport(employee);
                ReportService.GenerateReport(manager);

                var payroll = new PayrollSystem();

                Console.WriteLine("\nPayroll Processing:");
                // Полиморфизм в действии: метод один, а поведение разное
                payroll.ProcessSalary(employee); // Добавит 1000
                payroll.ProcessSalary(manager);  // Добавит 2000 (автоматически определит логику менеджера)

                Console.WriteLine("\nBonus Processing:");
                // Бонус считается по-разному (10% для сотрудника, 20% для менеджера)
                decimal empBonus = payroll.CalculateBonus(employee, 6, true);
                decimal mgrBonus = payroll.CalculateBonus(manager, 6, true);

                Console.WriteLine($"Бонус для {employee.Name}: {empBonus}");
                Console.WriteLine($"Бонус для {manager.Name}: {mgrBonus}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
