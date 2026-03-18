using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Bridge
{
    public class Render2D : IRenderEngine
    {
        public void RenderCircle(float radius) =>
            Console.WriteLine($"[Bridge - 2D Движок] Отрисовка плоского круга (R={radius})");

        public void RenderRectangle(float width, float height) =>
            Console.WriteLine($"[Bridge - 2D Движок] Отрисовка плоского прямоугольника ({width}x{height})");
    }
}
