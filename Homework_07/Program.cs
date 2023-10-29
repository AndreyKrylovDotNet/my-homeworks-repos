using System.IO;
using System.Text;

namespace Homework_07
{
    /*Создать структуру Worker со следующими свойствами:

          ID
          Дата и время добавления записи
          Ф.И.О.
          Возраст
          Рост
          Дата рождения
          Место рождения

      Создать класс Repository, который будет отвечать за работу с экземплярами Worker.

      В репозитории должны быть реализованы следующие функции:

          Просмотр всех записей.
          Просмотр одной записи. Функция должна на вход принимать параметр ID записи, которую необходимо вывести на экран. 
          Создание записи.
          Удаление записи.
          Загрузка записей в выбранном диапазоне дат.

      Имя файла должно храниться в приватном поле Repository. Файл, который использует репозиторий, должен выглядеть примерно так:
          
          1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
          2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск

      Используя структуру Worker и класс Repository, в основном методе Main реализовать программу для работы с записями. 
      Также предоставить пользователю возможность сортировать данные по разным полям.
      
      Обратить внимание, что в строке есть символ # — разделитель. 
      Символа # не должно быть при чтении (разбить строку на массив поможет разделение строк с помощью метода String.Split).
      Создать методы для работы с записями.
      Файла изначально нет, поэтому программа при первом запуске должна его создать, чтобы не было ошибки.    
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("DataBaseWorkers.txt"))
                File.Create("DataBaseWorkers.txt");

            while (true)
            {
                Console.WriteLine("Выберите нужную функцию:\n" +
                              "\n1 - Просмотр всех записей" +
                              "\n2 - Просмотр одной записи по ID" +
                              "\n3 - Создание записи и добавление в файл" +
                              "\n4 - Удаление записи" +
                              "\n5 - Загрузка записей в выбранном диапазоне дат" +
                              "\n\nДля выхода - любая клавиша");

                char key = Console.ReadKey(true).KeyChar;

                Repository repository = new Repository();

                Worker worker = new Worker();

                Console.Clear();

                switch (key)
                {
                    case '1':  // Просмотр всех записей

                        repository.GetAllWorkers();

                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    case '2':  // Просмотр одной записи по ID

                        int numberLines = File.ReadAllLines("DataBaseWorkers.txt").Length;  // определение количества записей в файле
                        Console.Write($"Введите номер ID (в файле записей: {numberLines}): ");
                        uint id;
                        while (!uint.TryParse(Console.ReadLine(), out id) || id == 0 || id > numberLines)
                        {
                            Console.Write("\nНеверное значение. Введите номер ID: ");
                        }

                        repository.GetWorkerById(id);

                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    case '3':  // Создание записи и добавление в файл

                        repository.AddWorker(worker);

                        break;

                    case '4':  // Удаление записи

                        numberLines = File.ReadAllLines("DataBaseWorkers.txt").Length;  // определение количества записей в файле
                        Console.Write($"Введите номер ID удаляемой записи (в файле записей: {numberLines}): ");
                        while (!uint.TryParse(Console.ReadLine(), out id) || id == 0 || id > numberLines)
                        {
                            Console.Write("\nНеверное значение. Введите номер ID: ");
                        }

                        repository.DeleteWorker(id);

                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    case '5':  // Загрузка записей в выбранном диапазоне дат.

                        repository.GetAllWorkers();

                        DateTime dateFrom, dateTo;

                        Console.Write("\nВведите дату начала диапазона дат (DD.MM.YYYY): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out dateFrom)) 
                        {
                            Console.Write("Неверное значение. Введите дату (DD.MM.YYYY): ");
                        }
                        dateFrom.ToShortDateString();

                        Console.Write("\nВведите дату конца диапазона дат (DD.MM.YYYY): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out dateTo) || dateTo < dateFrom) 
                        {
                            if (dateTo == DateTime.MinValue)
                                Console.Write("Неверное значение. Введите дату (DD.MM.YYYY): ");
                            else if (dateTo < dateFrom)
                                Console.Write("Дата конца диапазона должна быть более поздней, чем дата начала (DD.MM.YYYY): ");
                        }
                        dateTo.ToShortDateString();

                        Console.WriteLine("\nДля вывода запиcей в выбранном диапазоне дат нажмите любую клавишу");
                        Console.ReadKey();

                        repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);

                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    default:
                        key = '\0';
                        break;
                }

                if (key == '\0') break;

                Console.Clear();
            }         
        }
    }
}
