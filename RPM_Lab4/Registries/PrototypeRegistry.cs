using RPM_Lab4.Models;
using RPM_Lab4.Factories;

namespace RPM_Lab4.Registries
{
    public class PrototypeRegistry
    {
        private readonly Dictionary<string, Computer> _prototypesDict = [];
        private PrototypeRegistry () 
        {
            ComputerConstructor computerConstructor = new();

            OfficeComputerFactory officeComputerFactory = new();
            GamingComputerFactory gamingComputerFactory = new();
            HomeComputerFactory homeComputerFactory = new();

            Computer officeComputer = computerConstructor.Construct(officeComputerFactory);
            Computer gamingComputer = computerConstructor.Construct(gamingComputerFactory);
            Computer homeComputer = computerConstructor.Construct(homeComputerFactory);

            _prototypesDict["office"] = officeComputer;
            _prototypesDict["gaming"] = gamingComputer;
            _prototypesDict["home"] = homeComputer;
        }

        private static volatile PrototypeRegistry? _instance = null;
        private static readonly Lock _lock = new();
        public static PrototypeRegistry Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock) 
                    { 
                        _instance ??= new PrototypeRegistry ();
                    }
                }
                return _instance;
            }

        }

        public Computer GetPrototype(string key)
        {
            return _prototypesDict[key].DeepCopy();
        }
        
    }
}
