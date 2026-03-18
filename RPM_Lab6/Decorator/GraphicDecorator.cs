using RPM_Lab6.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Decorator
{
    public abstract class GraphicDecorator : IGraphic
    {
        protected IGraphic _wrapper;

        protected GraphicDecorator(IGraphic wrapper)
        {
            _wrapper = wrapper;
        }

        public virtual void Draw()
        {
            _wrapper.Draw();
        }
    }
}
