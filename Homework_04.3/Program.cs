using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_04._3
{
    class Program
    {
        /*Игра «Угадай число». Программа имеет следующий алгоритм:

         1. Пользователь вводит максимальное целое число диапазона. 
         2. На основе диапазона целых чисел (от 0 до «введено пользователем») программа генерирует случайное целое число из диапазона. 
         3. Пользователю предлагается ввести загаданное программой случайное число. Пользователь вводит свои предположения в консоли 
            приложения: 
            - Если число меньше загаданного, программа сообщает об этом пользователю. 
            - Если больше, то тоже сообщает, что число больше загаданного. 
         4. Программа завершается, когда пользователь угадал число. 
         5. Если пользователь устал играть, то вместо ввода числа он вводит пустую строку и нажимает Enter. 
            Тогда программа завершается, предварительно показывая, какое число было загадано.*/
        static void Main(string[] args)
        {
            //Ввод диапазона, в котором будет сгенерировано случайное число
            int maxNumOfRange;
            Console.Write("Введите максимальное целое число диапазона (тип Int32): ");
            while (!int.TryParse(Console.ReadLine(), out maxNumOfRange) || maxNumOfRange < 0)
            {
                    Console.Write($"Ошибка ввода! Введите значение, от 0 до {Int32.MaxValue}: ");               
            }

            Random randomNum = new Random();
            int randomIntNum = randomNum.Next(0, maxNumOfRange);

            //Угадывание заданного числа 
            int mysteriousNum = 0;
            do
            {
                Console.Write("\nУгадайте загаданное программой число: ");

                while (!int.TryParse(Console.ReadLine(), out mysteriousNum) || mysteriousNum < 0 || mysteriousNum > maxNumOfRange) 
                {
                    Console.Write($"Ошибка ввода! Введите число в выбранном диапазоне, от 0 до {maxNumOfRange}: ");                 
                }

                if (mysteriousNum > randomIntNum)
                {
                    Console.WriteLine("Введёное число больше загадонного");
                }
                else if (mysteriousNum < randomIntNum)
                {
                    Console.WriteLine("Введёное число меньше загадонного");
                }
                else break;

                Console.WriteLine("Для выхода из угадайки нажмите Enter! Для продолжения - любую другую клавишу!");
                ConsoleKey exitKey = Console.ReadKey().Key;
                if (exitKey == ConsoleKey.Enter) break;
            }
            while (mysteriousNum != randomIntNum);

            if (mysteriousNum == randomIntNum)
            {
                Console.WriteLine("Верно! Вы угадали загаданное число!");
            }
            else
            {
                Console.WriteLine("\nЗагаданное число равно: " + randomIntNum);
            }

            Console.ReadLine();
        }

    }
}
