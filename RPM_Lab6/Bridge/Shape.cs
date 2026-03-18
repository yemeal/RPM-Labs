using RPM_Lab6.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Bridge
{
    public abstract class Shape : IGraphic
    {
        protected IRenderEngine _engine;

        protected Shape(IRenderEngine engine)
        {
            _engine = engine;
        }

        public abstract void Draw();
    }
}
