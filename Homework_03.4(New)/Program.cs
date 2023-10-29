namespace Homework_03._4_New_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 4. Наименьший элемент в последовательности
            /*Найти наименьший элемент в последовательности, которую вводит пользователь. Детальный алгоритм программы:

                1. Пользователь вводит длину последовательности. 
                2. Затем пользователь последовательно вводит целые числа (как положительные, так и отрицательные). 
                     Числа разделяются клавишей Enter.
                3. Каждое введённое число сравнивается со значением переменной, отвечающей за минимальный элемент. 
                     Если введённое число оказывается меньше, то нужно обновить значение переменной.
              
              Программа выводит на экран наименьшее число из последовательности пользователя.*/
            #endregion

            Console.Write("Введите длину последовательности целых чисел: ");

            bool successfulInput = int.TryParse(Console.ReadLine(), out int sequenceLength);   //блок правильного ввода длины последовательности

            while (successfulInput != true)
            {
                Console.Write("Введите длину последовательности целых чисел: ");
                successfulInput = int.TryParse(Console.ReadLine(), out sequenceLength);
            }

            int minValue = 0;
            int maxValue = int.MaxValue;

            for (int i = 1; i <= sequenceLength; i++)   //блок цикла последовательного ввода целого числа и поиска наименьшего
            {
                Console.Write($"Введите {i}е целое число: ");   //блок правильного ввода целого числа

                successfulInput = int.TryParse(Console.ReadLine(), out int enteredInteger);

                while (successfulInput != true)
                {
                    Console.Write($"Введите {i}е целое число: ");
                    successfulInput = int.TryParse(Console.ReadLine(), out enteredInteger);
                }

                if (enteredInteger < maxValue)   //условие для поиска наименьшего числа и обновления соответсвующей переменной
                {
                    minValue = enteredInteger;
                    maxValue = minValue;
                }
            }

            Console.WriteLine("Минимальное число последовательности: " + minValue);

            Console.ReadKey();
        }
    }
}