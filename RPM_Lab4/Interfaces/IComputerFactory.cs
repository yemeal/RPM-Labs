using RPM_Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab4.Interfaces
{
    public interface IComputerFactory
    {
        Computer Construct();
    }
}
