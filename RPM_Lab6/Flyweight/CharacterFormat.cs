using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Flyweight
{
    public class CharacterFormat
    {
        public char Symbol { get; }
        public string Font { get; }
        public int Size { get; }

        public CharacterFormat(char symbol, string font, int size)
        {
            Symbol = symbol;
            Font = font;
            Size = size;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Отрисовка символа '{Symbol}' [Шрифт: {Font}, Размер: {Size}] на ({x}, {y})");
        }
    }
}
