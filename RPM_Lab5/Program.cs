using RPM_Lab5.Adapter;
using RPM_Lab5.Composite;
using RPM_Lab5.Facade;
using File = RPM_Lab5.Composite.File;

// 1. Демонстрация Компоновщика (Composite)
Folder rootDir = new("Root");
Folder docsDir = new("Documents");

// Файлы с имитацией размера в байтах
File file1 = new("resume.pdf", 1024);
File file2 = new("photo.jpg", 2048);
File file3 = new("config.sys", 512);

// Собираем дерево
docsDir.Add(file1);
docsDir.Add(file2);
rootDir.Add(docsDir);
rootDir.Add(file3);

// Вывод размера корневой директории
Console.WriteLine($"Размер корневой директории '{rootDir.Name}': {rootDir.GetSize()} байт\n");

// 2 & 3. Демонстрация Адаптера и Фасада
// Создаем адаптеры, связывая целевой интерфейс IFileSystem с нашей иерархией
IFileSystem localFS = new FileSystemAdapter(rootDir);
IFileSystem cloudFS = new FileSystemAdapter(new Folder("CloudRoot"));

// Создаем Фасад
SyncFacade facade = new(localFS, cloudFS);

// Выполняем простые операции через Фасад
facade.SyncFolder("C:\\LocalRoot", "Cloud:\\Backup");
facade.Backup("C:\\LocalRoot\\Documents", "Cloud:\\Archive");
