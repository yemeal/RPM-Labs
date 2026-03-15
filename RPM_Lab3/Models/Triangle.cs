using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RPM_Lab3.Models
{
    public class Triangle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            var polygon = new Polygon
            {
                Points = new System.Windows.Media.PointCollection
                {
                    new Point(size / 2, 0),
                    new Point(0, size),
                    new Point(size, size)
                },

                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5),
                Width = size,
                Height = size,
                Stretch = Stretch.Fill,
            };
            return polygon;
        }
    }
}
