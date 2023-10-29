namespace Homework_03._2_New_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 2. Программа подсчёта суммы карт в игре «21»
            /*Есть довольно простая карточная игра, она называется «21». Суть игры сводится к подсчёту карт. 
              Каждая карта имеет свой «вес». Написать программу, которая подсчитает сумму всех карт у вас на руках. 
              Задача программы сводится к следующему алгоритму:

                1. Программа приветствует пользователя и спрашивает, сколько у него на руках карт.
                2. Пользователь вводит целое число.
                3. Преобразуем это число в счётчик для цикла.
                4. С помощью цикла for итеративно просим пользователя ввести номинал каждой карты. 
                     Для карт с числовым номиналом он вводит только цифру. 
                   Для «картинок» следует принять обозначения латинскими буквами:
                     Валет = J
                     Дама = Q
                     Король = K
                     Туз = T
                5. Внутри цикла, используя оператор switch, «вес» каждой карты складываем в общую переменную суммы, 
                     которая объявлена до тела основного цикла.
                   Для числовых карт их «вес» равен весу, указанному при вводе пользователем. Для «картинок» «вес» равен 10.
                6. По завершении ввода на экране появится значение суммы карт. 
            
               Программа выводит на экран информацию о сумме карт на руках у пользователя. 
               Программа выводит на экран в текстовом виде информацию о том, что должен сделать пользователь. Например: 
                 «Введите номинал следующей карты».*/
            #endregion

            Console.WriteLine("Сколько у вас карт на руках?");
            bool successfulInput = int.TryParse(Console.ReadLine(), out int numbOfCards);   //блок правильного ввода кол-ва карт

            while (successfulInput != true || numbOfCards <= 0 || numbOfCards > 52)
            {
                if (successfulInput != true)
                    Console.WriteLine("Необходимо ввести количество карт");
                else if (numbOfCards <= 0)
                    Console.WriteLine("Количество карт не может быть нулевым или отрицательным");
                else if (numbOfCards > 52)
                    Console.WriteLine("Количество карт в колоде равно 52");
                successfulInput = int.TryParse(Console.ReadLine(), out numbOfCards);
            }

            int sum = 0;

            Console.WriteLine("Введите номинал каждой карты (1,2,3,4,5,6,7,8,9,10,J,Q,K,T)");

            for (int i = 1; i <= numbOfCards; i++)   //блок правильного ввода значения карты
            {
                Console.Write($"Карта {i}: ");
                string faceValueOfTheCar = Console.ReadLine();

                while (faceValueOfTheCar != "1" && faceValueOfTheCar != "2" && faceValueOfTheCar != "3" &&
                    faceValueOfTheCar != "4" && faceValueOfTheCar != "5" && faceValueOfTheCar != "6" &&
                    faceValueOfTheCar != "7" && faceValueOfTheCar != "8" && faceValueOfTheCar != "9" &&
                    faceValueOfTheCar != "10" && faceValueOfTheCar != "J" && faceValueOfTheCar != "Q" &&
                    faceValueOfTheCar != "K" && faceValueOfTheCar != "T") 
                {
                    Console.WriteLine("Такой карты не существует");
                    Console.Write($"Карта {i}: ");
                    faceValueOfTheCar = Console.ReadLine();
                }

                switch (faceValueOfTheCar)   //суммирование номиналов введённых карт по выборке    
                { 
                    case "1": sum += 1;
                        break;
                    case "2": sum += 2;
                        break;
                    case "3": sum += 3;
                        break;
                    case "4": sum += 4;
                        break;
                    case "5": sum += 5;
                        break;
                    case "6": sum += 6;
                        break;
                    case "7": sum += 7;
                        break;
                    case "8": sum += 8;
                        break;
                    case "9": sum += 9;
                        break;
                    case "10": sum += 10;
                        break;
                    case "J": sum += 10;
                        break;
                    case "Q": sum += 10;
                        break;
                    case "K": sum += 10;
                        break;
                    case "T": sum += 10;
                        break;
                }

                Console.WriteLine("Сумма карт на руках у пользователя: " + sum);
            }
         
            Console.ReadLine();
        }
    }





}