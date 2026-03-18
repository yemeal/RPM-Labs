using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Bridge
{
    public interface IRenderEngine
    {
        void RenderCircle(float radius);
        void RenderRectangle(float width, float height);
    }
}
