namespace OOP_Fundamentals_Library
{
    public static class ReportService
    {
        // Работает для любого наследника Person
        public static void GenerateReport(Person person)
        {
            Console.WriteLine("Report:");
            person.PrintInfo(); // Вызовет переопределенный метод конкретного класса
            Console.WriteLine("\n");
        }
    }
}