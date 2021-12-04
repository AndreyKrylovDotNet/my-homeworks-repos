using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_04._1
{
    class Program
    {
        /*Выведение на экран матрицы заданного размера и заполнение её случайными числами. Детальный алгоритм работы приложения:

          1. Пользователю предлагается ввести количество строк в будущей матрице.
          2. Ввести количество столбцов в будущей матрице.
          3. После того, как данные будут получены, создать в памяти матрицу заданного размера.
          4. Используя Random, заполнить матрицу случайными целыми числами.
          5. Вывести полученную матрицу на экран.
          6. Вывести суммы всех элементов этой матрицы на экран отдельной строкой.*/
        static void Main(string[] args)
        {
            byte lines, columns;

            int minRandomNum, maxRandomNum;
            //Ввод количества строк
            Console.Write("Введите количество строк матрицы: ");
            while (!byte.TryParse(Console.ReadLine(), out lines))
            {
                Console.Write("Ошибка ввода!\nВведите количество строк: ");
            }
            //Ввод количества столбцов
            Console.Write("Введите количество столбцов матрицы: ");
            while (!byte.TryParse(Console.ReadLine(), out columns))
            {
                Console.Write("Ошибка ввода!\nВведите количество столбцов: ");
            }
            //Ввод диапазона для генерации случайных чисел
            Console.Write("Введите минимальное значение диапазона (тип Int32) для генерации\n" +
                          "случайных чисел, которыми заполнится матрица: ");
            while (!int.TryParse(Console.ReadLine(), out minRandomNum))
            {
                Console.Write($"Ошибка ввода!\nВведите число от {Int32.MinValue} до {Int32.MaxValue}: ");
            }

            Console.Write("Введите максимальное значение диапазона (тип Int32) для генерации\n" +
                          "случайных чисел, которыми заполнится матрица: ");
            while (!int.TryParse(Console.ReadLine(), out maxRandomNum) || minRandomNum >= maxRandomNum)
            {
                Console.Write($"Ошибка ввода!\nВведите число от {minRandomNum + 1} до {Int32.MaxValue}: ");
            }
            //Создание двумерного массива
            int[,] matrix = new int[lines, columns];

            int sum = 0;

            Random random = new Random();
            //Вложенный цикл для заполнения матрицы сгенерированными случайными числами
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(minRandomNum, maxRandomNum);

                    sum += matrix[i, j];   //Выражение для подсчёта всех чисел матрицы

                    Console.Write($"{matrix[i, j], 13}");   //Вывод матрицы 
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nСумма всех чисел матрицы: {sum}");

            Console.ReadLine();
        }
    }
}
