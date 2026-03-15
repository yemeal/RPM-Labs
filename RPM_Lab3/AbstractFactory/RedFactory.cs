using RPM_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RPM_Lab3.AbstractFactory
{
    public class RedFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle { Color = Colors.Red};
        public Square CreateSquare() => new Square { Color = Colors.Red };
        public Triangle CreateTriangle() => new Triangle { Color = Colors.Red };
    }
}
