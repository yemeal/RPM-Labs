namespace OOP_Fundamentals_Library
{
    public class Employee : Person
    {
        private decimal _salary;

        public decimal Salary
        {
            get => _salary;
            protected set // Зарплату можно менять только внутри класса или наследников
            {
                if (value < 0) throw new ArgumentException("Salary cannot be negative.");
                _salary = value;
            }
        }

        public string Position { get; set; }

        public Employee(string name, int age, decimal salary, string position)
            : base(name, age)
        {
            Salary = salary;
            Position = position;
        }

        // Полиморфизм: Базовый метод повышения зарплаты
        public virtual void ProcessPayroll()
        {
            // Логика для обычного сотрудника
            Salary += 1000;
            Console.WriteLine($"Processed payroll for Employee {Name}. New Salary: {Salary}");
        }

        // Полиморфизм: Метод расчета бонуса
        public virtual decimal CalculateBonus(int years, bool hasCertification)
        {
            decimal bonus = Salary * 0.1m; // 10% база
            if (years > 5) bonus += 500;
            if (hasCertification) bonus += 300;
            return bonus;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Position: {Position}, Salary: {Salary}");
        }

        // Метод для повышения зарплаты извне (контролируемый)
        public void GiveRaise(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Raise amount must be positive");
            Salary += amount;
        }
    }
}