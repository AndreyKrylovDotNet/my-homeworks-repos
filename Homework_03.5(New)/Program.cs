namespace Homework_03._5_New_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 5. Игра «Угадай число»
            /*Разработайте программу по следующему алгоритму:

                1. Пользователь вводит максимальное целое число диапазона.
                2. На основе диапазона целых чисел (от 0 до «введено пользователем») программа генерирует 
                     случайное целое число из диапазона. 
                3. Пользователю предлагается ввести загаданное программой случайное число. 
                     Пользователь вводит свои предположения в консоли приложения. 
                       Если число меньше загаданного, программа сообщает об этом пользователю. 
                       Если больше, то тоже сообщает, что число больше загаданного.
                4. Программа завершается, когда пользователь угадывает число. 
                5. Если пользователь устал играть, то вместо ввода числа он вводит пустую строку и нажимает Enter. 
                     Тогда программа завершается, предварительно показывая, какое число было загадано.*/
            #endregion

            Console.Write("Введите максимальное целое число диапазона: ");

            bool successfulInput = int.TryParse(Console.ReadLine(), out int maxSequenceLength);   //блок правильного ввода длины последовательности

            while (successfulInput != true || maxSequenceLength < 0)
            {
                if (maxSequenceLength < 0)
                    Console.WriteLine("Число диапазона должно быть положительным");
                Console.Write("Введите максимальное целое число диапазона: ");
                successfulInput = int.TryParse(Console.ReadLine(), out maxSequenceLength);
            }

            Random randomNum = new Random();

            int gameNum = randomNum.Next(0, maxSequenceLength);   //генерация случайного числа от 0 до «введено пользователем»

            Console.Write("Угадайте загаданное программой число: ");

            int estimatedNum = 0;

            while (true)   //блок ввода пользователем загаданного программой числа
            {               
                successfulInput = int.TryParse(Console.ReadLine(), out estimatedNum);   //блок правильности ввода пользователем 

                while (successfulInput != true || estimatedNum < 0 || estimatedNum > maxSequenceLength) 
                {                  
                    if (estimatedNum < 0 || estimatedNum > maxSequenceLength)
                        Console.WriteLine($"Загаданное число в диапазоне от 0 до {maxSequenceLength}");

                    Console.Write("Угадайте загаданное программой число: ");

                    successfulInput = int.TryParse(Console.ReadLine(), out estimatedNum);
                }

                if (estimatedNum > gameNum)   //условие угадываемости введённого числа
                    Console.WriteLine("Введённое число больше загаданного");
                else if (estimatedNum < gameNum)
                    Console.WriteLine("Введённое число меньше загаданного");                     
                else if (estimatedNum == gameNum)
                {
                    Console.WriteLine("Вы угадали загаданное число!");
                    break;
                }

                Console.WriteLine("\nДля выхода введите пустую строку и нажмите Enter.\n" +   //блок предложения выхода из программы
                                  "Для продолжения - любую кнопку и Enter.");
                bool str = Console.ReadLine().Contains(" ");
                if (str)
                {
                    Console.WriteLine("Загаданное число равнялось " + gameNum);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}