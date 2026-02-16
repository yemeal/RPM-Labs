namespace OOP_Fundamentals_Library
{
    public class PayrollSystem
    {
        // Принимает базовый класс Employee.
        // Благодаря полиморфизму вызовется правильный метод (для Employee или Manager)
        public void ProcessSalary(Employee emp)
        {
            emp.ProcessPayroll();
        }

        public decimal CalculateBonus(Employee emp, int years, bool hasCertification)
        {
            return emp.CalculateBonus(years, hasCertification);
        }
    }
}