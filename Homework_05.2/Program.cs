using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_05._2
{
    class Program
    {
        /*Пользователь вводит в программе длинное предложение. Каждое слово разделено одним пробелом. После ввода пользователь нажимает клавишу Enter. 
          Необходимо создать два метода:
          - первый метод разделяет слова в предложении;
          - второй метод меняет эти слова местами (в обратной последовательности). 
          При этом один метод вызывается внутри другого метода, то есть в методе main 
          вызывается метод cо следующей сигнатурой — ReversWords (string inputPhrase). 
          Внутри этого метода вызывается метод по разделению входной фразы на слова.

          Для сложения строк можно использовать конкатенацию строк. Выражение вида ResultString += NewString + “ ” добавит к текущей строке, 
          которая представлена переменной ResultString, новую строку из переменной NewString и также добавит пробел к концу строки. 
          Для реализации алгоритма разделения строки на слова можно воспользоваться рекомендациями из задания 1.

          Вызов метода по разделению на слова происходит внутри метода, который отвечает непосредственно за инвертирование слов в предложении.*/

        /// <summary>
        /// Метод вывода слов предложения в обратной последовательности
        /// </summary>
        /// <param name="inputPhrase"></param>
        static void ReversWords(string inputPhrase)
        {
            string[] sameStringsArray = GetStringSplit(inputPhrase);

            string reversePhrase = null;

            for (int i = sameStringsArray.Length - 1; i >= 0; i--)
            {
                reversePhrase += sameStringsArray[i] + " ";
            }

            Console.WriteLine($"\nВведённое предложение в обратной последовательноcти слов:\n\n{reversePhrase}");
        }

        /// <summary>
        /// Метод разделения входного предложения на слова
        /// </summary>
        /// <param name="samePhrase"></param>
        /// <returns></returns>
        static string[] GetStringSplit(string samePhrase)
        {
             string[] stringsArray = samePhrase.Split(' ');

             return stringsArray;
        }

        /// <summary>
        /// Главный метод программы, её точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое предложение, с разделением слов пробелом:\n");

            string enteredPhrase = Console.ReadLine();

            ReversWords(enteredPhrase);

            Console.ReadLine();
        }
    }
}
