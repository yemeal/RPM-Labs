using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPM_Lab3.Models;
using System.Windows.Media;

namespace RPM_Lab3.Creators
{ 
    // Abstraction
    public abstract class CircleCreator
    {
        public abstract Circle CreateCircle();
    };


    // Realisations 
    public class RedCircleCreator : CircleCreator
    {
        public override Circle CreateCircle()
        {
            return new Circle
            {
                Color = Colors.Red
            };
        }
    }


    public class BlueCircleCreator : CircleCreator
    {
        public override Circle CreateCircle()
        {
            return new Circle
            {
                Color = Colors.Blue
            };
        }
    }


    public class GreenCircleCreator : CircleCreator
    {
        public override Circle CreateCircle()
        {
            return new Circle
            {
                Color = Colors.Green
            };
        }
    }
}
