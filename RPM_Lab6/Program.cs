using RPM_Lab6.Bridge;
using RPM_Lab6.Core;
using RPM_Lab6.Decorator;
using RPM_Lab6.Flyweight;
using RPM_Lab6.Proxy;

class Program
{
    static void Main()
    {
        Console.WriteLine("======== 1. Тестирование FLYWEIGHT ========");
        CharacterFactory fontFactory = new CharacterFactory();
        var char1 = fontFactory.GetCharacter('A', "Arial", 12);
        var char2 = fontFactory.GetCharacter('B', "Arial", 12);
        var char3 = fontFactory.GetCharacter('A', "Arial", 12); // Взят из кэша
        char1.Draw(10, 10);
        char2.Draw(20, 10);
        char3.Draw(30, 10);

        Console.WriteLine("\n======== 2. Тестирование PROXY ========");
        IGraphic lazyImg = new ImageProxy("background_4k.jpg");
        Console.WriteLine("Объект Proxy создан, но файл еще не прочитан.");
        Console.WriteLine("Вызываем Draw() первый раз:");
        lazyImg.Draw();
        Console.WriteLine("Вызываем Draw() второй раз:");
        lazyImg.Draw(); // Загрузки не будет, только отрисовка

        Console.WriteLine("\n======== 3. Тестирование BRIDGE ========");
        IRenderEngine engine2D = new Render2D();
        IRenderEngine engine3D = new Render3D();
        Shape circle2D = new Circle(engine2D, 15.5f);
        Shape circle3D = new Circle(engine3D, 15.5f);
        circle2D.Draw();
        circle3D.Draw();

        Console.WriteLine("\n======== 4. Тестирование DECORATOR ========");
        // Берем наш 3D круг и оборачиваем его в тень и рамку
        IGraphic decoratedShape = new FrameDecorator(new ShadowDecorator(circle3D));
        decoratedShape.Draw();

        Console.WriteLine("\n--- Комбинация паттернов (Proxy + Decorator) ---");
        // Декорируем прокси-изображение (оно загрузится только при вызове Draw внутри декоратора)
        IGraphic avatarImg = new ImageProxy("avatar.png");
        IGraphic styledAvatar = new TransparencyDecorator(new FrameDecorator(avatarImg), 50);
        styledAvatar.Draw();

        Console.ReadLine();
    }
}
