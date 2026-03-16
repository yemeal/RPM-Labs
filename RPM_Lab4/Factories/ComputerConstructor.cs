using System;
using System.Collections.Generic;
using System.Text;
using RPM_Lab4.Interfaces;
using RPM_Lab4.Models;

namespace RPM_Lab4.Factories
{
    public class ComputerConstructor
    {
        public Computer Construct(IComputerFactory _computerFactory) 
        {
            return _computerFactory.Construct();
        }
    }
}
