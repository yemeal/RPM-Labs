using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Bridge
{
    public class Render3D : IRenderEngine
    {
        public void RenderCircle(float radius) =>
            Console.WriteLine($"[Bridge - 3D Движок] Отрисовка объемной сферы (R={radius})");

        public void RenderRectangle(float width, float height) =>
            Console.WriteLine($"[Bridge - 3D Движок] Отрисовка объемного куба ({width}x{height})");
    }
}
