using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_05._1
{
    class Program
    {
        /*Пользователь вводит в консольном приложении длинное предложение. Каждое слово в этом предложении отделено одним пробелом. 
          Необходимо создать метод, который в качестве входного параметра принимает строковую переменную, а в качестве возвращаемого значения — массив слов. 
          После вызова данного метода программа вызывает второй метод, который выводит каждое слово в отдельной строке.   

          Для реализации данной программы можно написать алгоритм разделения на слова самостоятельно, используя цикл.
         
          Также можно использовать метод string.Split(‘ ’); Об этом методе можно прочитать подробнее на странице документации Microsoft. 
          Для именования методов необходимо использовать стиль CamelCase (когда каждое следующее слово начинается с заглавной буквы). 
          Например, метод с именем GetPositiveRandomInt возвращает положительное целое случайное число.

          В программе, помимо основного метода main, присутствует два других метода, которые вызываются в теле метода main. 
          Названием методов соответствуют тому, что они делают (разделяют или выводят данные).*/

        /// <summary>
        /// Метод создания массива слов из введённого предложения
        /// </summary>
        /// <param name="inputPhrase"></param>
        /// <returns></returns>
        static string[] GetWordsArray(string inputPhrase)
        {
            char[] charsArray = inputPhrase.ToCharArray(0, inputPhrase.Length);   //Создание массива символов из предложения

            int index = 0;

            string[] WordsArray = new string[inputPhrase.Length];

            for (int i = 0; i < inputPhrase.Length; i++)   //Создание массива слов из массива символов
            {
                if (charsArray[i] != ' ')
                {
                    WordsArray[index] = string.Concat(WordsArray[index], charsArray[i]);
                }
                else
                {
                    index++;
                }
            }
            Array.Resize(ref WordsArray, index + 1);   //Удаление пустых элементов нового массива слов

            return WordsArray;
        }

        /// <summary>
        /// Метод вывода каждого слова массива в отдельной строке
        /// </summary>
        /// <param name="WordsArray"></param>
        static void GetWordsInSeparateLine(string[] WordsArray)
        {
            Console.WriteLine($"Вариант1:\n");

            foreach (string word in WordsArray)
            {
                Console.WriteLine(word);
            }
        }

        /// <summary>
        /// Метод вывода каждого слова в отдельной строке при получении строки с использованием String.Split
        /// </summary>
        /// <param name="inputPhrase"></param>
        static void GetStringSplitInSeparateLines(string inputPhrase)
        {
            string[] substrings = inputPhrase.Split(' ');

            Console.WriteLine($"Вариант2:\n");

            foreach (var substr in substrings)
            {
                Console.WriteLine(substr);
            }
        }

        /// <summary>
        /// Главный метод программы, её точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое предложение, с разделением слов пробелом:\n");

            string enteredPhrase = Console.ReadLine();

            Console.WriteLine();

            string[] newWordsArray = GetWordsArray(enteredPhrase);

            GetWordsInSeparateLine(newWordsArray);

            Console.WriteLine();

            GetStringSplitInSeparateLines(enteredPhrase);

            Console.ReadLine();
        }
    }
}
