using RPM_Lab6.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Decorator
{
    public class FrameDecorator : GraphicDecorator
    {
        public FrameDecorator(IGraphic wrapper) : base(wrapper) { }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("   + Добавлена красивая рамка");
        }
    }
}
