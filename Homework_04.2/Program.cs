using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_04._2
{
    class Program
    {
        /*Нахождение наименьшего элемента в последовательности, вводимой пользователем. Последовательность сохраняется в массив. 
          Детальный алгоритм программы:

          1. Пользователь вводит длину последовательности. 
          2. Пользователь последовательно вводит целые числа (как положительные, так и отрицательные). 
             Числа разделяются клавишей Enter.
          3. Каждое введённое число помещается в соответствующий элемент массива.
          4. После окончания ввода данных отдельный цикл проходит по последовательности и находит минимальное число. 
             Для этого он сравнивает каждое число в итерации с предыдущим найденным минимальным числом.*/ 
        static void Main(string[] args)
        {
            int numElements;

            Console.Write("Введите длину последовательности чисел: ");
            while (!int.TryParse(Console.ReadLine(), out numElements))
            {
                Console.Write("Ошибка ввода!\nВведите количество элементов последовательности: ");
            }

            int[] array = new int[numElements];
            //Ввод элементов массива с разделением через Enter
            for (int i = 0; i < numElements; i++)
            {
                Console.Write("Введите элемент последовательности №{0}: ", i);
                int element;
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.Write($"Ошибка ввода!\nВведите значение элемента №{i}: ");
                }
                array[i] = element;
            }
            //Вывод массива в консоли 
            Console.Write("\nВывод последовательности: ");

            foreach (int e in array)
            {
                Console.Write("{0} ", e);
            }
            //Поиск наименьшего числа в массиве и его вывод 
            int minValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }
            Console.WriteLine($"\n\nНаименьшее число последовательности равно: {minValue}");

            Console.ReadLine();
        }
    }
}
