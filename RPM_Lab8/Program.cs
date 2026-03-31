using RPM_Lab8.Mediator;
using RPM_Lab8.State;

// 1. Инициализация коллег
Printer printer = new();
PrintQueue queue = new();
Logger logger = new();
Dispatcher dispatcher = new();

// 2. Создание посредника (коллеги подписываются внутри конструктора)
IMediator mediator = new PrintSystemMediator(printer, queue, logger);
dispatcher.SetMediator(mediator); // Подписываем диспетчера

// 3. Создание документов
Document doc1 = new("Отчет.pdf", "[Текст отчета]");
doc1.SetMediator(mediator);

Document doc2 = new("Договор.docx", "[Текст договора]");
doc2.SetMediator(mediator);

Document doc3 = new("Заметка.txt", "[Текст заметки]");
doc3.SetMediator(mediator);

Document doc4 = new("Отчет (2).pdf", "[Текст отчета]");
doc4.SetMediator(mediator);

Console.WriteLine("--- СЦЕНАРИЙ 1: Успешная печать ---");
doc1.AddToQueue();
doc2.AddToQueue();
dispatcher.CommandProcessQueue();

Console.WriteLine("\n--- СЦЕНАРИЙ 2: Ошибка принтера и восстановление ---");
doc3.AddToQueue();
printer.SimulateFailure = true; // Вызываем ошибку
dispatcher.CommandProcessQueue();

Console.WriteLine("\nПытаемся напечатать сломанный документ:");
doc3.Print(); // Ожидаем сообщение об ошибке FSM

Console.WriteLine("\nСбрасываем документ и печатаем снова:");
doc3.Reset();
doc3.Print();

Console.WriteLine("\n--- СЦЕНАРИЙ 3: Проверка финального состояния ---");
doc1.Print(); // Должен сообщить, что уже напечатан