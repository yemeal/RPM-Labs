using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Flyweight
{
    public class CharacterFactory
    {
        private Dictionary<string, CharacterFormat> _characters = new Dictionary<string, CharacterFormat>();

        public CharacterFormat GetCharacter(char symbol, string font, int size)
        {
            string key = $"{symbol}_{font}_{size}";
            if (!_characters.ContainsKey(key))
            {
                _characters[key] = new CharacterFormat(symbol, font, size);
                Console.WriteLine($"[Flyweight] Создан новый объект для '{symbol}'");
            }
            else
            {
                Console.WriteLine($"[Flyweight] Взят из кэша объект для '{symbol}'");
            }
            return _characters[key];
        }
    }
}
