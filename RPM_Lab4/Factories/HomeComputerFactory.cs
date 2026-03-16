using RPM_Lab4.Interfaces;
using RPM_Lab4.Models;
using RPM_Lab4.Builders;

using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace RPM_Lab4.Factories
{
    internal class HomeComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i5 13600K")
                .WithRAM(64)
                .WithGPU("NVIDIA GeForce RTX 4060")
                .WithComponent("Mouse")
                .WithComponent("Keyboard")
                .WithComponent("Monitor")
                .Build();
        }
    }
}
