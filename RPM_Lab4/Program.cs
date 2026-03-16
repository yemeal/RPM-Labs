using RPM_Lab4.Models;
using RPM_Lab4.Factories;


#region Паттерн "Строитель"
Console.WriteLine("=== Builder Pattern ===\n");
ComputerConstructor computerConstructor = new();

OfficeComputerFactory officeComputerFactory = new();
GamingComputerFactory gamingComputerFactory = new();
HomeComputerFactory homeComputerFactory = new();

Computer officeComputer = computerConstructor.Construct(officeComputerFactory);
Computer gamingComputer = computerConstructor.Construct(gamingComputerFactory);
Computer homeComputer = computerConstructor.Construct(homeComputerFactory);

Console.WriteLine("Office Computer:\n");
Console.WriteLine(officeComputer.Display());
Console.WriteLine("\nGaming Computer:\n");
Console.WriteLine(gamingComputer.Display());
Console.WriteLine("\nHome Computer:\n");
Console.WriteLine(homeComputer.Display());
#endregion


#region Паттерн "Прототип"
Console.WriteLine("\n\n=== Prototype Pattern ===\n");
Console.WriteLine("Home Computer:\n");
Console.WriteLine(homeComputer.Display());
Computer shallowClone = homeComputer.ShallowCopy();
Computer deepClone = homeComputer.DeepCopy();

homeComputer.AdditionalComponents.Add("Webcam");

Console.WriteLine("\nHome Computer with Webcam:\n");
Console.WriteLine(homeComputer.Display());
Console.WriteLine("\nShallow clone:\n");
Console.WriteLine(shallowClone.Display());
Console.WriteLine("\nDeep clone:\n");
Console.WriteLine(deepClone.Display());

#endregion


#region Паттерн "Синглтон"
#endregion