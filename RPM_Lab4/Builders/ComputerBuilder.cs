using RPM_Lab4.Interfaces;
using RPM_Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab4.Builders
{
    public class ComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();
        public ComputerBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._computer = new Computer();
        }

        #region Добавление комплектующих
        public IComputerBuilder WithCPU(string CPU)
        {
            _computer.CPU = CPU;
            return this;
        }

        public IComputerBuilder WithRAM(int RAM)
        {
            _computer.RAM = RAM;
            return this;
        }

        public IComputerBuilder WithGPU(string GPU)
        {
            _computer.GPU = GPU;
            return this;
        }

        public IComputerBuilder WithComponent(string component)
        {
            _computer.AdditionalComponents.Add(component);
            return this;
        }
        #endregion

        public Computer Build()
        {
            Computer result = this._computer;
            this.Reset();
            return result;
        }

    }
}
