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
    public abstract class SquareCreator
    {
        public abstract Square CreateSquare();
    };


    // Realisations 
    public class RedSquareCreator : SquareCreator
    {
        public override Square CreateSquare()
        {
            return new Square
            {
                Color = Colors.Red
            };
        }
    }


    public class BlueSquareCreator : SquareCreator
    {
        public override Square CreateSquare()
        {
            return new Square
            {
                Color = Colors.Blue
            };
        }
    }


    public class GreenSquareCreator : SquareCreator
    {
        public override Square CreateSquare()
        {
            return new Square
            {
                Color = Colors.Green
            };
        }
    }
}
