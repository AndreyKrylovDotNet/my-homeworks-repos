using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_06
{
    class Program
    {
        /*Создать справочник «Сотрудники».
         Разработать для предполагаемой компании программу, которая будет добавлять записи новых сотрудников в файл. 
         Файл должен содержать следующие данные:
             ID
             Дата и время добавления записи
             Ф. И. О.
             Возраст
             Рост
             Дата рождения
             Место рождения

         Для этого необходим ввод данных с клавиатуры. После ввода данных:
             если файла не существует, его необходимо создать; 
             если файл существует, то необходимо записать данные сотрудника в конец файла. 
         При запуске программы должен быть выбор:

             введём 1 — вывести данные на экран;
             введём 2 — заполнить данные и добавить новую запись в конец файла.

         Файл должен иметь следующую структуру:

             1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
             2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск
             …
         
        Обратить внимание, что в строке есть символ # — разделитель в строке. При чтении файла необходимо убрать символ #. 
        (Разбить строку на массив элементов поможет разделение строк с помощью метода String.Split).
        Разбить программу на методы (чтение, запись).
        Новую запись внести в конец файла. Проверить, создан файл или нет.
        
        Что оценивается:
            Структура файла после добавления сотрудника идентична.
            Каждый метод выполняет одну задачу.
            Запись корректно выводится в консоль.
            Файл корректно закрывается после записи и чтения.*/

        /// <summary>
        /// Вывод данных на экран
        /// </summary>
        static void ReadData()
        {
            using (StreamReader employeeRead = new StreamReader("database.txt"))
            {
                string line;

                Console.WriteLine($"{"ID",2} {"Время записи",17} {"Ф.И.О.",30} {"Возраст",8} {"Рост",5} {"Дата рождения",14} {"Место рождения",20}\n");

                while ((line = employeeRead.ReadLine()) != null)
                {
                    string[] data = line.Split('#');

                    Console.WriteLine($"{data[0],2} {data[1],17} {data[2],30} {data[3],8} {data[4],5} {data[5],14} {data[6],20}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Заполнение данными и добавление новой записи в конец файла
        /// </summary>
        static void RecordData()
        {
            int id = File.ReadAllLines("database.txt").Length;

            using (StreamWriter employeeRec = new StreamWriter("database.txt", true))
            {
                char selectAction;

                do
                {
                    StringBuilder note = new StringBuilder();

                    id++;

                    note.Append(id + "#");

                    string dateNow = DateTime.Now.ToShortDateString();
                    note.Append(dateNow + " ");

                    string timeNow = DateTime.Now.ToShortTimeString();
                    note.Append(timeNow + "#");

                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine();
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите отчество: ");
                    string middlename = Console.ReadLine();
                    string fio = surname + " " + name + " " + middlename;
                    note.Append(fio + "#");

                    Console.Write("Введите возраст: ");
                    string age = Console.ReadLine();
                    note.Append(age + "#");

                    Console.Write("Введите рост (см): ");
                    string growth = Console.ReadLine();
                    note.Append(growth + "#");

                    Console.Write("Введите дату рождения (DD.MM.YYYY): ");
                    string dateOfBirth = Console.ReadLine();
                    note.Append(dateOfBirth + "#");

                    Console.Write("Введите место рождения: ");
                    string birthplace = Console.ReadLine();
                    note.Append(birthplace);

                    employeeRec.WriteLine(note);

                    Console.WriteLine("\n Для продолжения ввода данных и их записи нажмите 1\n" +
                                      " Для выхода — любую клавишу\n");
                    selectAction = Console.ReadKey(true).KeyChar;

                } while (selectAction == '1');
            }
        }

        static void Main(string[] args)
        {
            string notice = "Нажмите соответствующую клавишу:\n\n" +
                             " 1 — вывести данные на экран;\n" +
                             " 2 — заполнить данные и добавить новую запись в конец файла\n";
            Console.WriteLine(notice);

            char key = Console.ReadKey(true).KeyChar;
            Console.WriteLine();

            while (key != '1' && key != '2')
            {
                Console.WriteLine(notice);
                key = Console.ReadKey(true).KeyChar;
                Console.WriteLine();
            }

            switch (key)
            {
                case '1':
                    ReadData();
                    break;

                case '2':
                    RecordData();
                    break;
            }
        }
    }
}
