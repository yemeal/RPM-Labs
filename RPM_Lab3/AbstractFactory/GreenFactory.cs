using RPM_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RPM_Lab3.AbstractFactory
{
    public class GreenFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle { Color = Colors.Green };
        public Square CreateSquare() => new Square { Color = Colors.Green };
        public Triangle CreateTriangle() => new Triangle { Color = Colors.Green };
    }
    
}
