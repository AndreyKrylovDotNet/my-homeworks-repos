using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_03._1
{
    class Program
    {
        /*Правила игры выводятся на экран. Игроки имеют возможность ввести с клавиатуры свои имена.
          Число gameNumber задаётся случайно. Число userTry вводится с клавиатуры. После каждого хода игрока из gameNumber вычитается userTry.
          Если gameNumber равен нулю, игра завершается победой ходившего игрока.
          После окончания игры предлагается сыграть реванш. В случае если был выбран реванш, игра начинается заново, иначе приложение завершается. */
        static void Main(string[] args)
        {
            Console.WriteLine(@"                                                   Правила игры:
            Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.
            Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.
            UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.
            Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.");

            Console.WriteLine("\n После ознакомления с правилами нажмите любую кнопку для начала игры...");
            Console.ReadKey();
            //Ввод имени игроков
            Console.Write(" Введите имя игрока 1:  ");
            string playerName1 = Console.ReadLine();

            Console.Write(" Введите имя игрока 2:  ");
            string playerName2 = Console.ReadLine();

            int randomIntResult = 0;

            while (randomIntResult == 0)   //Цикл выполнения хода игры
            {
                Random gameNumber = new Random();   //Блок кода для генерации случайного числа
                randomIntResult = gameNumber.Next(12, 120);

                int count = 0;

                int userTry;

                while (randomIntResult != 0)   //Цикл выполнения игры с условием, что случайное число не равно 0
                {
                    Console.WriteLine(" Случайное число gameNumber равно:  " + randomIntResult);

                    if (count % 2 == 0)   //Условие для поочерёдного ввода числа двумя игроками
                    {
                        Console.Write($" Игрок {playerName1}, введите число от 1 до 4:  ");
                    }
                    else
                    {
                        Console.Write($" Игрок {playerName2}, введите число от 1 до 4:  ");
                    }

                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }

                    while (userTry < 1 || userTry > 4)   //Условие для правильного ввода игроками числа в заданном диапазоне
                    {
                        Console.Write(" Необходимо ввести число от 1 до 4:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                    //Условие для правильного ввода игроками числа userTry, чтобы оно не превышало gameNumber к окончанию игрового цикла
                    while (userTry > randomIntResult || userTry == 0)
                    {
                        Console.Write($" Необходимо ввести число меньшее, чем текущее gameNumber ({randomIntResult}):  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }

                    randomIntResult -= userTry;   //Вычитание очередного хода игрока из случайного числа
                    count++;
                }

                if (count % 2 != 0)   //Условие для победы 1ого игрока на основании нечётности его хода по счётчику итерации
                {
                    Console.WriteLine($" Поздравляем с победой игрока {playerName1}!");
                }

                if (count % 2 == 0)   //Условие для победы 2ого игрока на основании чётности его хода по счётчику итерации
                {
                    Console.WriteLine($" Поздравляем с победой игрока {playerName2}!");
                }

                Console.Write("\n Желаете реванша? Y/N ?  ");  //Блок кода для определения игроком дальнейшего хода игры при нажатии соответствующей клавиши               

                char.TryParse(Console.ReadLine(), out char key);

                while (!(key == 'y' || key == 'Y' || key == 'н' || key == 'Н' || key == 'n' || key == 'N' || key == 'т' || key == 'Т'))
                {
                    Console.Write(" \nНажмите клавишу Y для продолжения, или N для выхода!  ");
                    char.TryParse(Console.ReadLine(), out key); ;
                }

                if (key == 'y' || key == 'Y' || key == 'н' || key == 'Н')   //Условие, при котором нажата клавиша Y без привязки к раскладке
                {
                    Console.Clear();
                    continue;   //Начало новой игры
                }
                else if (key == 'n' || key == 'N' || key == 'т' || key == 'Т')   //Условие, при котором нажата клавиша N без привязки к раскладке
                {
                    break;   //Выход из игры                  
                }
            }
        }
    }
}
