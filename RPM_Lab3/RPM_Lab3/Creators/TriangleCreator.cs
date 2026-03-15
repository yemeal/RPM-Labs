using RPM_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RPM_Lab3.Creators
{
    // Abstraction
    public abstract class TriangleCreator
    {
        public abstract Triangle CreateTriangle();
    };


    // Realisations 
    public class RedTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle()
        {
            return new Triangle
            {
                Color = Colors.Red
            };
        }
    }


    public class BlueTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle()
        {
            return new Triangle
            {
                Color = Colors.Blue
            };
        }
    }


    public class GreenTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle()
        {
            return new Triangle
            {
                Color = Colors.Green
            };
        }
    }
}
