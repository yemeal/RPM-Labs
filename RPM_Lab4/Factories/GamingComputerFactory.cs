using RPM_Lab4.Interfaces;
using RPM_Lab4.Models;
using RPM_Lab4.Builders;

using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace RPM_Lab4.Factories
{
    internal class GamingComputerFactory : IComputerFactory
    {
        public Computer Construct()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i9 14900K")
                .WithRAM(64)
                .WithGPU("NVIDIA GeForce RTX 5090")
                .WithComponent("Gaming Mouse")
                .WithComponent("Gaming Keyboard")
                .WithComponent("Gaming Monitor")
                .Build();
        }
    }
}
