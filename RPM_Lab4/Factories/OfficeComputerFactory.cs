using RPM_Lab4.Interfaces;
using RPM_Lab4.Models;
using RPM_Lab4.Builders;

using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace RPM_Lab4.Factories
{
    internal class OfficeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i3 6100F")
                .WithRAM(4)
                .WithGPU("NVIDIA GeForce GTX 1050")
                .WithComponent("Office Mouse")
                .WithComponent("Office Keyboard")
                .WithComponent("Office Monitor")
                .Build();
        }
    }
}
