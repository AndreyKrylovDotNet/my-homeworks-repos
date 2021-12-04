using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_03._2
{
    class Program
    {
        /*Диапазон gameNumber вводится с клавиатуры. Также предусмотрен ввод максимально и минимально возможного значения для userTry.        
          Помимо добавления уровней сложности есть добавление возможности играть трём, четырём или пяти игрокам.       
          Если введённый userTry начинается с числа больше, чем один, предусмотрена возможность того, что gameNumber будет меньше, чем userTry. 
          Для этого изменён диапазон допустимого ввода для userTry так, чтобы игрок мог совершить последний ход. */
        static void Main(string[] args)
        {
            int numberOfPlayers = 0;
            string playerName1, playerName2, playerName3, playerName4, playerName5;
            playerName1 = playerName2 = playerName3 = playerName4 = playerName5 = null;
            int count = 0;

            Console.Write("\n Введите количество игроков, от 2 до 5:  ");

            while (numberOfPlayers < 2 || numberOfPlayers > 5)
            {
                while (!int.TryParse(Console.ReadLine(), out numberOfPlayers))
                {
                    Console.WriteLine(" Некорректный ввод!");
                    Console.Write(" Введите количество игроков, от 2 до 5:  ");
                }

                while (numberOfPlayers < 2 || numberOfPlayers > 5)
                {
                    Console.Write(" Возможное количество игроков от 2 до 5:  ");
                    while (!int.TryParse(Console.ReadLine(), out numberOfPlayers))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                        Console.Write(" Введите количество игроков, от 2 до 5:  ");
                    }
                }

                Console.Write(" Введите имя 1ого игрока:  ");
                playerName1 = Console.ReadLine();

                Console.Write(" Введите имя 2ого игрока:  ");
                playerName2 = Console.ReadLine();
                if (numberOfPlayers == 2) continue;

                Console.Write(" Введите имя 3ого игрока:  ");
                playerName3 = Console.ReadLine();
                if (numberOfPlayers == 3) continue;

                Console.Write(" Введите имя 4ого игрока:  ");
                playerName4 = Console.ReadLine();
                if (numberOfPlayers == 4) continue;

                Console.Write(" Введите имя 5ого игрока:  ");
                playerName5 = Console.ReadLine();
                if (numberOfPlayers == 5) continue;
            }

            Random gameNumber = new Random();
            int minValue, maxValue;

            Console.Write(" Введите начальное значение диапазона для генерации случайного числа:  ");

            while (!int.TryParse(Console.ReadLine(), out minValue))
            {
                Console.WriteLine(" Некорректный ввод!");
                Console.Write(" Введите начальное значение диапазона для генерации случайного числа:  ");
            }

            Console.Write(" Введите конечное значение диапазона для генерации случайного числа:  ");
            while (!int.TryParse(Console.ReadLine(), out maxValue))
            {
                Console.WriteLine(" Некорректный ввод!");
                Console.Write(" Введите конечное значение диапазона для генерации случайного числа:  ");
            }

            int randomIntResult = gameNumber.Next(minValue, maxValue);
            Console.WriteLine($" Случайное число gameNumber равно:  {randomIntResult}");

            int minUserTry, maxUserTry;
            Console.Write($" Введите минимальное число userTry, желательней поменьше сгенерированного числа" +
                          $"\ngameNumber ({randomIntResult}) для более увлекательного геймплея:  ");
            while (!int.TryParse(Console.ReadLine(), out minUserTry))
            {
                Console.WriteLine(" Некорректный ввод!");
                Console.Write(" Необходимо ввести минимальное число userTry:  ");
            }

            Console.Write($" Введите максимальное число userTry, не менее {minUserTry}, не более {randomIntResult}:  ");
            while (!int.TryParse(Console.ReadLine(), out maxUserTry))
            {
                Console.WriteLine(" Некорректный ввод!");
                Console.Write(" Необходимо ввести максимальное число userTry:  ");
            }

            int userTry;

            while (randomIntResult != 0)
            {
                count = 0;

                //Условия ввода числа для 1ого игрока

                count++;   //Счётчик циклов ввода числа каждым игроком
                if (randomIntResult >= minUserTry & randomIntResult <= maxUserTry)   //Условие 1, при котором текущее gameNumber попадает в заданный диапазон userTry
                {
                    Console.Write($" Игрок {playerName1}, введите число от {minUserTry} до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > randomIntResult)   //Контроль правильного ввода для условия 1
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else if (randomIntResult <= minUserTry)   //Условие 2, при котором текущее gameNumber меньше заданного диапазона userTry
                {
                    Console.Write($" Изменение диапазона ввода в связи с изменившимися условиями игры." +
                                  $"\n Игрок {playerName1}, введите число от 1 до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < 1 || userTry > randomIntResult)   //Контроль правильного ввода для условия 2
                    {
                        Console.Write($" Необходимо ввести число от 1 до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else   //Условие 3, при котором текущее gameNumber больше заданного диапазона userTry
                {
                    Console.Write($" Игрок {playerName1}, введите число от {minUserTry} до {maxUserTry}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > maxUserTry)   //Контроль правильного ввода для условия 3
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {maxUserTry}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                randomIntResult -= userTry;
                if (randomIntResult == 0) break;
                Console.WriteLine(" Заданное число gameNumber теперь равно:  " + randomIntResult);

                //Условия ввода числа для 2ого игрока

                count++;   //Счётчик циклов ввода числа каждым игроком
                if (randomIntResult >= minUserTry & randomIntResult <= maxUserTry)   //Условие 1, при котором текущее gameNumber попадает в заданный диапазон userTry
                {
                    Console.Write($" Игрок {playerName2}, введите число от {minUserTry} до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > randomIntResult)   //Контроль правильного ввода для условия 1
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else if (randomIntResult <= minUserTry)   //Условие 2, при котором текущее gameNumber меньше заданного диапазона userTry
                {
                    Console.Write($" Изменение диапазона ввода в связи с изменившимися условиями игры." +
                                  $"\n Игрок {playerName2}, введите число от 1 до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < 1 || userTry > randomIntResult)   //Контроль правильного ввода для условия 2
                    {
                        Console.Write($" Необходимо ввести число от 1 до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else   //Условие 3, при котором текущее gameNumber больше заданного диапазона userTry
                {
                    Console.Write($" Игрок {playerName2}, введите число от {minUserTry} до {maxUserTry}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > maxUserTry)   //Контроль правильного ввода для условия 3
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {maxUserTry}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                randomIntResult -= userTry;
                if (randomIntResult == 0) break;
                Console.WriteLine(" Заданное число gameNumber теперь равно:  " + randomIntResult);
                if (numberOfPlayers == 2) continue;   //Завершение цикла при 2х игроках

                //Условия ввода числа для 3ого игрока

                count++;   //Счётчик циклов ввода числа каждым игроком
                if (randomIntResult >= minUserTry & randomIntResult <= maxUserTry)   //Условие 1, при котором текущее gameNumber попадает в заданный диапазон userTry
                {
                    Console.Write($" Игрок {playerName3}, введите число от {minUserTry} до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > randomIntResult)   //Контроль правильного ввода для условия 1
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else if (randomIntResult <= minUserTry)   //Условие 2, при котором текущее gameNumber меньше заданного диапазона userTry
                {
                    Console.Write($" Изменение диапазона ввода в связи с изменившимися условиями игры." +
                                  $"\n Игрок {playerName3}, введите число от 1 до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < 1 || userTry > randomIntResult)   //Контроль правильного ввода для условия 2
                    {
                        Console.Write($" Необходимо ввести число от 1 до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else   //Условие 3, при котором текущее gameNumber больше заданного диапазона userTry
                {
                    Console.Write($" Игрок {playerName3}, введите число от {minUserTry} до {maxUserTry}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > maxUserTry)   //Контроль правильного ввода для условия 3
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {maxUserTry}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                randomIntResult -= userTry;
                if (randomIntResult == 0) break;
                Console.WriteLine(" Заданное число gameNumber теперь равно " + randomIntResult);
                if (numberOfPlayers == 3) continue;   //Завершение цикла при 3х игроках

                //Условия ввода числа для 4ого игрока

                count++;   //Счётчик циклов ввода числа каждым игроком
                if (randomIntResult >= minUserTry & randomIntResult <= maxUserTry)   //Условие 1, при котором текущее gameNumber попадает в заданный диапазон userTry
                {
                    Console.Write($" Игрок {playerName4}, введите число от {minUserTry} до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > randomIntResult)   //Контроль правильного ввода для условия 1
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else if (randomIntResult <= minUserTry)   //Условие 2, при котором текущее gameNumber меньше заданного диапазона userTry
                {
                    Console.Write($" Изменение диапазона ввода в связи с изменившимися условиями игры." +
                                  $"\n Игрок {playerName4}, введите число от 1 до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < 1 || userTry > randomIntResult)   //Контроль правильного ввода для условия 2
                    {
                        Console.Write($" Необходимо ввести число от 1 до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else   //Условие 3, при котором текущее gameNumber больше заданного диапазона userTry
                {
                    Console.Write($" Игрок {playerName4}, введите число от {minUserTry} до {maxUserTry}: ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > maxUserTry)   //Контроль правильного ввода для условия 3
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {maxUserTry}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                randomIntResult -= userTry;
                if (randomIntResult == 0) break;
                Console.WriteLine(" Заданное число gameNumber теперь равно:  " + randomIntResult);
                if (numberOfPlayers == 4) continue;   //Завершение цикла при 4х игроках

                //Условия ввода числа для 5ого игрока

                count++;   //Счётчик циклов ввода числа каждым игроком
                if (randomIntResult >= minUserTry & randomIntResult <= maxUserTry)   //Условие 1, при котором текущее gameNumber попадает в заданный диапазон userTry
                {
                    Console.Write($" Игрок {playerName5}, введите число от {minUserTry} до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > randomIntResult)   //Контроль правильного ввода для условия 1
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else if (randomIntResult <= minUserTry)   //Условие 2, при котором текущее gameNumber меньше заданного диапазона userTry
                {
                    Console.Write($" Изменение диапазона ввода в связи с изменившимися условиями игры." +
                                  $"\n Игрок {playerName5}, введите число от 1 до {randomIntResult}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < 1 || userTry > randomIntResult)   //Контроль правильного ввода для условия 2
                    {
                        Console.Write($" Необходимо ввести число от 1 до {randomIntResult}:  ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                else   //Условие 3, при котором текущее gameNumber больше заданного диапазона userTry
                {
                    Console.Write($" Игрок {playerName5}, введите число от {minUserTry} до {maxUserTry}:  ");
                    if (!int.TryParse(Console.ReadLine(), out userTry))
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    while (userTry < minUserTry || userTry > maxUserTry)   //Контроль правильного ввода для условия 3
                    {
                        Console.Write($" Необходимо ввести число от {minUserTry} до {maxUserTry}: ");
                        if (!int.TryParse(Console.ReadLine(), out userTry))
                        {
                            Console.WriteLine(" Некорректный ввод!");
                        }
                    }
                }
                randomIntResult -= userTry;
                if (randomIntResult == 0) break;
                Console.WriteLine(" Заданное число gameNumber теперь равно:  " + randomIntResult);
                if (numberOfPlayers == 5) continue;   //Завершение цикла при 5ти игроках
            }
            //Условие для объявления победителя
            if (count == 1) Console.WriteLine($" Победил игрок {playerName1} !!!");
            else if (count == 2) Console.WriteLine($" Победил игрок {playerName2} !!!");
            else if (count == 3) Console.WriteLine($" Победил игрок {playerName3} !!!");
            else if (count == 4) Console.WriteLine($" Победил игрок {playerName4} !!!");
            else if (count == 5) Console.WriteLine($" Победил игрок {playerName5} !!!");

            Console.ReadKey();
        }
    }
}
