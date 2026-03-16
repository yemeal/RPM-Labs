using RPM_Lab4.Models;
using RPM_Lab4.Factories;


#region Паттерн "Строитель"
ComputerConstructor computerConstructor = new();

OfficeComputerFactory officeComputerFactory = new();
GamingComputerFactory gamingComputerFactory = new();
HomeComputerFactory homeComputerFactory = new();

Computer officeComputer = computerConstructor.Construct(officeComputerFactory);
Computer gamingComputer = computerConstructor.Construct(gamingComputerFactory);
Computer homeComputer = computerConstructor.Construct(homeComputerFactory);

Console.WriteLine(officeComputer.Display());
Console.WriteLine(gamingComputer.Display());
Console.WriteLine(homeComputer.Display());
#endregion