using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Bridge
{
    public class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderEngine engine, float radius) : base(engine)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            _engine.RenderCircle(_radius);
        }
    }
}
