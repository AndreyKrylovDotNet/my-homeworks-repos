using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework_07
{
    internal class Repository
    {
        /// <summary>
        /// Чтение из файла и возврат массива считанных экземпляров
        /// </summary>
        /// <returns>Массив экземпляров Worker</returns>
        public Worker[] GetAllWorkers()
        {
            Worker worker = new Worker();
            // определение количества строк, равному длине массива Worker[]
            int numberLines = File.ReadAllLines("DataBaseWorkers.txt").Length; 

            worker.workers = new Worker[numberLines];

            using (StreamReader workersRead = new StreamReader("DataBaseWorkers.txt"))
            {
                string line;

                worker.PrintTitle();

                while ((line = workersRead.ReadLine()) != null)
                {
                    // массив данных одной записи файла
                    string[] dataWorker = line.Split('#');
                    // цикл инициализации полей нового экземпляра Worker соответствующими данными
                    for (int i = 0; i < dataWorker.Length; i++) 
                    {
                        if (i == 0)
                            worker.Id = uint.Parse(dataWorker[0]);
                        else if (i == 1)
                            worker.RecordCreationDate = DateTime.Parse(dataWorker[1]);
                        else if (i == 2)
                            worker.FIO = dataWorker[2];
                        else if (i == 3)
                            worker.Age = uint.Parse(dataWorker[3]);
                        else if (i == 4)
                            worker.Growth = uint.Parse(dataWorker[4]);
                        else if (i == 5)
                            worker.DateOfBirth = dataWorker[5];
                        else if (i == 6)
                            worker.BirthPlace = dataWorker[6];
                    }
                    worker.PrintData(worker);
                    // заполнение массива Worker[] экземплярами Worker с начального индекса
                    worker[worker.Id - 1] = worker;
                }
            }
            return worker.workers;
        }

        /// <summary>
        /// Чтение из файла, поиск Worker по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Экземпляр Worker с запрашиваемым ID</returns>
        public Worker GetWorkerById(uint id)
        {
            Worker worker = new Worker();

            worker.workers = GetAllWorkers();

            Console.WriteLine("Для вывода записи по выбранному ID нажмите любую клавишу");  
            Console.ReadKey();
            Console.Clear();

            worker.PrintTitle();
            worker.PrintData(worker[id - 1]);

            return worker[id - 1];
        }

        /// <summary>
        /// Присваивание экземпляру Worker уникального ID и запись нового экземпляра в файл 
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            int id = File.ReadAllLines("DataBaseWorkers.txt").Length;
            // блок создания новой записи
            using (StreamWriter workersRec = new StreamWriter("DataBaseWorkers.txt", true))
            {
                char key;
                do
                {
                    StringBuilder newWorkerString = new StringBuilder();
                    // присвоение Worker соответствующего ID
                    worker.Id = (uint)++id;
                    newWorkerString.Append(worker.Id.ToString() + '#');
                    // присвоение Worker даты создания записи
                    worker.RecordCreationDate = DateTime.Now;
                    newWorkerString.Append(worker.RecordCreationDate.ToString() + '#');
                    // ввод ФИО
                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine();
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите отчество: ");
                    string middlename = Console.ReadLine();
                    string fio = surname + " " + name + " " + middlename;
                    while (fio.Length > 30)
                    {
                        Console.Write("Сократите запись ФИО до 30 символов: ");
                        Console.Write("Введите фамилию: ");
                        surname = Console.ReadLine();
                        Console.Write("Введите имя: ");
                        name = Console.ReadLine();
                        Console.Write("Введите отчество: ");
                        middlename = Console.ReadLine();
                        fio = surname + " " + name + " " + middlename;
                    }
                    worker.FIO = fio;
                    newWorkerString.Append(worker.FIO.ToString() + "#");
                    // ввод возраста
                    Console.Write("Введите возраст: ");
                    bool success;
                    uint age;
                    while (!(success = uint.TryParse(Console.ReadLine(), out age)) || age < 1 || age > 130)
                    {
                        if (success == false)
                            Console.Write("Некорректный ввод: ");
                        else
                            Console.Write("Возраст должен быть в диапазоне от 1 до 130 лет: ");
                    }
                    worker.Age = age;
                    newWorkerString.Append(worker.Age.ToString() + "#");
                    // ввод роста
                    Console.Write("Введите рост (см): ");
                    uint growth;
                    while (!(success = uint.TryParse(Console.ReadLine(), out growth)) || growth < 100 || growth > 250)
                    {
                        if (success == false)
                            Console.Write("Некорректный ввод: ");
                        else
                            Console.Write("Рост должен быть в диапазоне от 100 до 250 см: ");
                    }
                    worker.Growth = growth;
                    newWorkerString.Append(worker.Growth.ToString() + "#");
                    // ввод даты рождения
                    Console.Write("Введите дату рождения (DD.MM.YYYY): ");
                    string dateOfBirth = Console.ReadLine();
                    while (dateOfBirth.Length > 10)
                    {
                        Console.Write("Некорректный ввод формата даты (DD.MM.YYYY): ");
                        dateOfBirth = Console.ReadLine();
                    }
                    worker.DateOfBirth = dateOfBirth;
                    newWorkerString.Append(worker.DateOfBirth.ToString() + "#");
                    // ввод места рождения
                    Console.Write("Введите место рождения: ");
                    string birthPlace = Console.ReadLine();
                    while (birthPlace.Length > 20)
                    {
                        Console.Write("Сократите запись до 20 символов: ");
                        birthPlace = Console.ReadLine();
                    }
                    worker.BirthPlace = birthPlace;
                    newWorkerString.Append(worker.BirthPlace.ToString());
                    // запись строки Worker в файл
                    workersRec.WriteLine(newWorkerString);

                    Console.WriteLine("\nЗапись добавлена" +
                                      "\nДля продолжения ввода данных нажмите клавишу R\n" +
                                      "Для выхода - любая клавиша\n");
                    key = Console.ReadKey(true).KeyChar;

                } while (key == 'R' || key == 'r' || key == 'К' || key == 'к');             
            }

        }

        /// <summary>
        /// Чтение из файла, поиск нужного Worker и его удаление, запись в файл без удаляемого Worker
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(uint id)
        {
            Worker worker = new Worker();

            worker.workers = GetAllWorkers();

            Console.WriteLine("Для записи в файл без выбранного ID нажмите любую клавишу");
            Console.ReadKey();

            string[] strWorkers = File.ReadAllLines("DataBaseWorkers.txt");

            using (StreamWriter workersRec = new StreamWriter("DataBaseWorkers.txt", false))
            {
                uint newId = 1;
                int countOfStrings = 0;
                // цикл для поиска нужной записи и перезапись остальных строк в файл так,
                // чтобы все ID были по порядку
                foreach (string strWorker in strWorkers)
                {
                    countOfStrings++;

                    StringBuilder newStrWorker = new StringBuilder();
                    // условие для пропуска (удаления) выбранной по ID записи
                    if (id == newId)
                    {
                        id--;
                        continue;
                    }
                    // условие для перезаписи однозначного ID
                    if (countOfStrings < 10)
                    {
                        newStrWorker.Append(newId.ToString() + strWorker.Remove(0, 1));
                    }
                    // условие для перезаписи двузначного ID
                    else if (countOfStrings < 100)
                    {
                        newStrWorker.Append(newId.ToString() + strWorker.Remove(0, 2));
                    }
                    // условие для перезаписи трёхзначного ID
                    else if (countOfStrings < 1000)
                    {
                        newStrWorker.Append(newId.ToString() + strWorker.Remove(0, 3));
                    }

                    workersRec.WriteLine(newStrWorker);

                    newId++; 
                }
            }
            Console.WriteLine("\nФайл перезаписан." +
                              "\nДля вывода нового файла нажмите клавишу R\n");

            char key = Console.ReadKey(true).KeyChar;

            if (key == 'R' || key == 'r' || key == 'К' || key == 'к')
            {
                GetAllWorkers();
            }              
        }

        /// <summary>
        /// Чтение из файла, фильтрация нужных записей в выбранном диапазоне дат
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns>Массив считанных экземпляров</returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker worker = new Worker();

            worker.workers = GetAllWorkers();
            Console.Clear();

            worker.PrintTitle();

            Worker[] workersBetweenTwoDates = new Worker[0];
            int count = 0;

            for (uint i = 0; i < worker.workers.Length; i++)
            {
                if (worker[i].RecordCreationDate.Date >= dateFrom && worker[i].RecordCreationDate.Date <= dateTo)
                {
                    worker.PrintData(worker.workers[i]);

                    Array.Resize(ref workersBetweenTwoDates, ++count);

                    workersBetweenTwoDates[count - 1] = worker.workers[i];
                }
            }
            return workersBetweenTwoDates;
        }
    }
}
