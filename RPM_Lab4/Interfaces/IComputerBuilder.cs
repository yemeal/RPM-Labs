using RPM_Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab4.Interfaces
{
    public interface IComputerBuilder
    {
        IComputerBuilder WithCPU(string CPU);
        IComputerBuilder WithRAM(int RAM);
        IComputerBuilder WithGPU(string GPU);
        IComputerBuilder WithComponent(string component);
        Computer Build();

    }
}
