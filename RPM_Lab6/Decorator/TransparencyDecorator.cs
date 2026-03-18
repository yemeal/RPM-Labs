using RPM_Lab6.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Decorator
{
    public class TransparencyDecorator : GraphicDecorator
    {
        private int _percent;

        public TransparencyDecorator(IGraphic wrapper, int percent) : base(wrapper)
        {
            _percent = percent;
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"   + Применена прозрачность {_percent}%");
        }
    }
}
