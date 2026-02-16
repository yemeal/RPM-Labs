using System;

namespace OOP_Fundamentals_Library
{
    // јбстрактный класс не позвол€ет создавать экземпл€ры "просто человека"
    public abstract class Person
    {
        private string _name;
        private int _age;

        // »нкапсул€ци€: свойства с валидацией
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentException("Invalid age.");
                _age = value;
            }
        }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // ¬иртуальный метод дл€ полиморфизма (каждый может представить себ€ по-своему)
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Type: {GetType().Name}, Name: {Name}, Age: {Age}");
        }
    }
}