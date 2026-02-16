using System.Collections.Generic;
using System.Linq;

namespace OOP_Fundamentals_Library
{
    // Наследование: Manager ЯВЛЯЕТСЯ Employee
    public class Manager : Employee
    {
        public string Department { get; set; }

        // Инкапсуляция: Скрываем List, чтобы нельзя было сделать .Team = null
        private readonly List<Employee> _team = new();

        // Предоставляем доступ только для чтения
        public IReadOnlyCollection<Employee> Team => _team.AsReadOnly();

        public Manager(string name, int age, decimal salary, string department)
            : base(name, age, salary, "Manager")
        {
            Department = department;
        }

        public void AddToTeam(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            _team.Add(employee);
        }

        // Полиморфизм: Переопределяем поведение зарплаты
        public override void ProcessPayroll()
        {
            // Менеджеры получают большую прибавку
            GiveRaise(2000); // Используем метод базового класса
            Console.WriteLine($"Processed payroll for Manager {Name}. New Salary: {Salary}");
        }

        // Полиморфизм: Переопределяем расчет бонуса
        public override decimal CalculateBonus(int years, bool hasCertification)
        {
            // У менеджера база 20%, а не 10%
            decimal bonus = Salary * 0.2m;

            // Логика за стаж и сертификаты остается такой же или добавляется своя
            if (years > 5) bonus += 500;
            if (hasCertification) bonus += 300;

            return bonus;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Manager: {Name} (Dept: {Department})");
            Console.WriteLine($"  Team Size: {_team.Count}");
        }
    }
}