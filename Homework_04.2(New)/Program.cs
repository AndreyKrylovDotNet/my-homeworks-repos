namespace Homework_04._2_New_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 2. Сложение матриц      
            /*Используя выбранные размеры, создайте две матрицы. Сложите эти матрицы.

              Сложение матриц А и В — это нахождение такой матрицы С, все элементы которой представляют собой сложенные
                попарно соответствующие элементы исходных матриц А и В. Складывать допускается только матрицы
                одинаковой размерности (допустим, m × n), то есть имеющие равное количество строк и равное количество столбцов.

              Таким образом, математически сумма матриц выглядит так:

                Аm×n + Bm×n = Cm×n

              Каждый элемент искомой матрицы равен сумме соответствующих элементов заданных матриц:

                Cij = Aij + Bij, где i принимает значение от 1 до m, j имеет значение от 1 до n.
                        
             Программа выводит на экран две случайные матрицы и их сумму.*/
            #endregion

            Console.WriteLine("Введите размеры матрицы\n");   //блок ввода размеров матрицы
            Console.Write("Число строк: ");

            bool successfulInput = int.TryParse(Console.ReadLine(), out int numberOfRows);

            while (successfulInput == false || numberOfRows <= 0)   //проверка на правильность ввода количества строк
            {
                if (successfulInput == false)
                    Console.Write("Число строк: ");
                else if (numberOfRows <= 0)
                    Console.Write("Число строк не может быть отрицательным или нулевым\n" +
                                  "Число строк: ");

                successfulInput = int.TryParse(Console.ReadLine(), out numberOfRows);
            }

            Console.Write("Число столбцов: ");

            successfulInput = int.TryParse(Console.ReadLine(), out int numberOfColumns);

            while (successfulInput == false || numberOfColumns <= 0)   //проверка на правильность ввода количества столбцов
            {
                if (successfulInput == false)
                    Console.Write("Число столбцов: ");
                else if (numberOfColumns <= 0)
                    Console.Write("Число столбцов не может быть отрицательным или нулевым\n" +
                                  "Число столбцов: ");

                successfulInput = int.TryParse(Console.ReadLine(), out numberOfColumns);
            }

            Console.WriteLine();

            int[,] matrixA = new int[numberOfRows, numberOfColumns];   //объявление 2х матриц одинакового размера
            int[,] matrixB = new int[numberOfRows, numberOfColumns];

            Random random = new Random();

            int i, j, k, l;

            for (i = 0; i < numberOfRows; i++)   //цикл заполнения матрицы A случайными числами и её вывод на консоль 
            {
                for (j = 0; j < numberOfColumns; j++)
                {
                    matrixA[i, j] = random.Next(-50, 50);

                    Console.Write($"{matrixA[i, j],5}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            for (k = 0; k < numberOfRows; k++)   //цикл заполнения матрицы B случайными числами и её вывод на консоль 
            {
                for (l = 0; l < numberOfColumns; l++)
                {
                    matrixB[k, l] = random.Next(-50, 50);

                    Console.Write($"{matrixB[k, l],5}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nСумма двух матриц:\n");

            int[,] matrixC = new int[numberOfRows, numberOfColumns];

            int m, n;

            for (i = 0; i < numberOfRows; i++)   //цикл для суммирования двух матриц A и B и вывод матрицы C на консоль
            {
                m = k = i;

                for (j = 0; j < numberOfColumns; j++)
                {
                    n = l = j;

                    matrixC[m, n] = matrixA[i, j] + matrixB[k, l];
                    Console.Write($"{matrixC[m, n],5}");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}