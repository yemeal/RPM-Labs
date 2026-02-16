namespace OOP_Fundamentals_Library
{
    public class Customer : Person
    {
        public Customer(string name, int age) : base(name, age) { }

        // Customer использует базовую реализацию PrintInfo или может переопределить её
    }
}