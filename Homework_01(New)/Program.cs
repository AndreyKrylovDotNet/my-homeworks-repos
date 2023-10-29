namespace Homework_01_New_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 1:
            /*Добавить оператор вывода на экран Console.WriteLine и с его помощью вывести надпись: Hello World!!!
              Добавить задержку Console.ReadKey, чтобы приложение не закрывалось по завершении выполнения.*/
            #endregion 

            Console.WriteLine("Hello World!!!");    
            Console.ReadKey();

            #region Задание 2:
            /*Вывести на экран надпись Hello World!!!, используя метод Console.Write. 
              Использовать Console.Write для каждого слова (у нас будет три вызова метода: сначала для слова Hello, 
            потом для слова World, а затем — для трёх восклицательных знаков).
              Чтобы слова не «слипались», использовать пробелы внутри кавычек.
              Добавить задержку Console.ReadLine, чтобы приложение не закрывалось по завершении выполнения.*/
            #endregion 

            Console.Write("Hello ");   
            Console.Write("World");
            Console.Write("!!!");
            Console.ReadLine();    

        }
    }
}