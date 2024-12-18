﻿using System.Collections.Generic;

namespace Homework_10
{
    internal class Program
    {
        #region Задание 1

        /*Для банка «А» необходимо разработать программу консультанта для просмотра данных клиента. 
          У консультанта нет прав для изменения или просмотра некоторых данных. Создать класс, в 
          котором будут содержаться следующие поля:

          · Фамилия
          · Имя
          · Отчество
          · Номер телефона
          · Серия, номер паспорта

          Реализовать методы доступа для следующих ситуаций:

          · Консультант не имеет доступа к просмотру информации. Вместо серии и номера паспорта он видит символы: 
            «************», — если поле не пустое.
          · Консультант не может изменять поля «Фамилия», «Имя», «Отчество», но может их просматривать.
          · Консультант может изменить «Номер телефона», но при этом поле должно быть всегда заполнено.  

          Можно использовать как консольное приложение, так и приложение с графическим пользовательским интерфейсом. 
          Указать типы для данных по своему усмотрению. Также по своему усмотрению решить, где и как будут храниться данные. 

          Что оценивается:

          · Используется инкапсуляция.
          · Корректное описание данных в классе.
          · Наличие конструктора в классе.*/
        #endregion

        #region Задание 2

        /*Расширить программу из задания 1. У нас есть класс для консультанта со своими методами и полями. Добавить в 
          программу новый класс для нового пользователя — менеджера.

          Менеджер наследует функционал консультанта в дополнение к собственному. При этом менеджер может добавлять 
          «Фамилию», «Имя», «Отчество», «Телефон», «Серию, номер паспорта».

          Можно использовать как консольное приложение, так и приложение с графическим пользовательским интерфейсом.
          Указать типы для данных на своё усмотрение, но так, чтобы типы подходили к данным. Также на своё усмотрение, где 
          и как будут храниться данные (рекомендуется текстовый файл с разделителем). Если реализация будет в консольном варианте, 
          в таком случае при запуске должен быть выбор, кто работает в системе: консультант или менеджер. Если же будет использован 
          графический интерфейс, то в таком случае можно использовать компонент WPF ComboBox.

          Что оценивается:

          · Используется наследование.
          · Корректное описание данных в классе.
          · Наличие конструктора в классе.*/
        #endregion

        #region Задание 3
   
            /*Расширить и изменить программу из задания 1 и 2. У нас есть два класса для консультанта и менеджера. У классов 
              есть метод изменения данных. Исходя из этого, добавить к данным из задания 1 дополнительные поля:

              Дата и время изменения записи;
              Какие данные изменены;
              Тип изменений;
              Кто изменил данные (консультант или менеджер).

              А также создать интерфейсы и реализовать в них методы по изменению существующей записи для консультанта и менеджера. 
              Для менеджера разрешить добавление новой записи. Новые поля необходимо заполнять, как только записи клиентов были изменены. 
              Теперь консультант может изменять только номер телефона клиента, а менеджер может изменять все данные.

              Что оценивается:

              · Используется полиморфизм.
              · Наличие интерфейсов.
              · Корректное описание данных в классе.
              · Наличие конструктора в классах.*/
        #endregion

        static void Main(string[] args)
        {
            if (!File.Exists("DBClients.txt"))
                File.Create("DBClients.txt");

            List<Consultant> listOfClients = new List<Consultant>();
            Consultant consultant = new Consultant();
            Manager manager = new Manager();

            void DoAction(IChangeData changeData) // Mетод, принимающий в качестве параметра объект интерфейса IChangeData
            {
                changeData.ChangeData(listOfClients);
            } 

            while (true) 
            {
                char accessCategory;

                do 
                {
                    Console.Clear();

                    Console.WriteLine("\nВыберите категорию доступа:\n\n<1> - Консультант\n\n<2> - Менеджер");

                    accessCategory = Console.ReadKey(true).KeyChar;

                } while (accessCategory != '1' && accessCategory != '2');

                switch (accessCategory)
                {
                    case '1':  // Case для Consultant
                        Console.Clear();
                        char selectAction;

                        do
                        {
                            Console.WriteLine("Выберите действие:\n\n<1> - Вывод данных\n" +
                                          "\n<2> - Изменение данных (номера телефона)");
                            selectAction = Console.ReadKey(true).KeyChar;

                        } while (selectAction != '1' && selectAction != '2');

                        switch (selectAction) 
                        {
                            case '1':  // Вывод данных для Consultant
                                Console.Clear();

                                listOfClients = consultant.GetListOfClients();
                                consultant.Print(listOfClients);

                                Console.WriteLine("\nДля продолжения нажмите любую клавишу");
                                Console.ReadKey();
                                break;

                            case '2':  // Изменение данных (номера телефона) для Consultant
                                Console.Clear();

                                listOfClients = consultant.GetListOfClients();
                                consultant.Print(listOfClients);

                                DoAction(consultant);
                                break;
                        }
                        break;

                    case '2':  // Case для Manager
                        Console.Clear();

                        do
                        {
                            Console.WriteLine("Выберите действие:\n\n<1> - Вывод данных\n\n<2> - Изменение данных\n" +
                                          "\n<3> - Добавление новой записи");
                            selectAction = Console.ReadKey(true).KeyChar;

                        } while (selectAction != '1' && selectAction != '2' && selectAction != '3');

                        switch (selectAction)
                        {
                            case '1':  // Вывод данных для Manager
                                Console.Clear();

                                listOfClients = manager.GetListOfClients();
                                manager.Print(listOfClients);;

                                Console.WriteLine("\nДля продолжения нажмите любую клавишу");
                                Console.ReadKey();
                                break;

                            case '2':  // Изменение данных для Manager
                                Console.Clear();

                                listOfClients = consultant.GetListOfClients();
                                manager.Print(listOfClients);

                                DoAction(manager);
                                break;

                            case '3':  // Добавление новой записи для Manager
                                Console.Clear();

                                manager.AddData();
                                break;
                        }
                        break;
                }
            }
        }
    }
}
