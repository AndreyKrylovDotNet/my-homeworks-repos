using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    internal class Manager : Consultant, IChangeData
    {
        public Manager() { }

        /// <summary>
        /// Вывод списка clients в консоли
        /// </summary>
        public override void Print(List<Consultant> listOfClients)
        {
            Console.WriteLine($"\n{"Фамилия",-16} {"Имя",-16} {"Отчество",-16} {"Номер телефона",-20} " +
                              $"{"Серия и номер паспорта",-24} {"Дата и время изменения записи",-31} {"Какие данные изменены",-24} " +
                              $"{"Тип изменений",-18} {"Кто изменил данные",-18}\n");

            foreach (Consultant client in listOfClients)
            { 
                Console.WriteLine($"{client.LastName,-16} {client.FirstName,-16} {client.MiddleName,-16} {client.PhoneNumber,-20} " +
                                  $"{client.PassportSeriesAndNumber,-24} {client.DateOfChange,-31} {client.WhatChange,-24} " +
                                  $"{client.TypeOfChange,-18} {client.WhoChange,-18}");
            }
        }

        /// <summary>
        /// Изменяет данные клиентов с перезаписью текстового файла
        /// </summary>
        public void ChangeData(List<Consultant> listOfClients)
        {
            while (true)
            {
                Console.Write("\nВыберите запись по фамилии для изменения данных: ");
                string inputOfLastName = Console.ReadLine();

                int i;

                for (i = 0; i < listOfClients.Count; i++)  // Поиск нужной записи по фамилии
                {
                    if (listOfClients[i].LastName == inputOfLastName) 
                    {
                        char selectionKey;

                        do
                        {
                            Console.WriteLine("\nВыберите данные, которые хотите изменить:" +
                                              "\n<1> - Фамилия\n<2> - Имя\n<3> - Отчество" +
                                              "\n<4> - Номер телефона\n<5> - Серия и номер паспорта");

                            selectionKey = Console.ReadKey(true).KeyChar;
                            if (selectionKey != '1' && selectionKey != '2' && selectionKey != '3' && selectionKey != '4' && selectionKey != '5')
                            {
                                Console.WriteLine("\nНеверный ввод");
                            }
                        } while (selectionKey != '1' && selectionKey != '2' && selectionKey != '3' && selectionKey != '4' && selectionKey != '5');

                        switch (selectionKey)
                        {
                            case '1':  // Ввод фамилия
                                while (true)
                                {
                                    Console.Write("\nВведите фамилию: ");
                                    string newLastName = Console.ReadLine();
                                    if (newLastName.Length > 14)
                                    {
                                        Console.WriteLine("Сократите имя до 14 знаков");
                                        continue;
                                    }
                                    listOfClients[i].LastName = newLastName;
                                    break;
                                }
                                listOfClients[i].WhatChange = "Фамилия";
                                break;

                            case '2':  // Ввод имени
                                while (true)
                                {
                                    Console.Write("\nВведите имя: ");
                                    string newFirstName = Console.ReadLine();
                                    if (newFirstName.Length > 14)
                                    {
                                        Console.WriteLine("Сократите имя до 14 знаков");
                                        continue;
                                    }
                                    listOfClients[i].FirstName = newFirstName;
                                    break;
                                }
                                listOfClients[i].WhatChange = "Имя";
                                break;

                            case '3':  // Ввод отчества
                                while (true)
                                {
                                    Console.Write("\nВведите отчество: ");
                                    string newMiddleName = Console.ReadLine();
                                    if (newMiddleName.Length > 14)
                                    {
                                        Console.WriteLine("Сократите имя до 14 знаков");
                                        continue;
                                    }
                                    listOfClients[i].MiddleName = newMiddleName;
                                    break;
                                }
                                listOfClients[i].WhatChange = "Отчество";
                                break;

                            case '4':  // Ввод номера телефона
                                long newNumberOfPhone;

                                while (true)
                                {
                                    Console.Write("\nВведите номер телефона (11 цифр в формате ###########): ");

                                    bool parseSuccess = long.TryParse(Console.ReadLine(), out newNumberOfPhone);

                                    string phoneNumberString = newNumberOfPhone.ToString();
                                    if (parseSuccess && phoneNumberString.Length == 11)
                                    {
                                        listOfClients[i].PhoneNumber = newNumberOfPhone.ToString("+# (###) ###-##-##");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nНеверный ввод");
                                    }
                                }
                                listOfClients[i].WhatChange = "Номер телефона";
                                break;

                            case '5':  // Ввод серии и номера паспорта
                                long NewPassportSeriesAndNumber;

                                while (true)
                                {
                                    Console.Write("\nВведите серию и номер паспорта (10 цифр в формате ##########): ");

                                    bool parseSuccess = long.TryParse(Console.ReadLine(), out NewPassportSeriesAndNumber);

                                    string passportSeriesAndNumberString = NewPassportSeriesAndNumber.ToString();
                                    if (parseSuccess && passportSeriesAndNumberString.Length == 10)
                                    {
                                        listOfClients[i].PassportSeriesAndNumber = NewPassportSeriesAndNumber.ToString("## ## ######");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nНеверный ввод");
                                        continue;
                                    }
                                }
                                listOfClients[i].WhatChange = "Серия и номер паспорта";
                                break;

                            default:
                                break;
                        }
                        listOfClients[i].DateOfChange = DateTime.Now.ToString();

                        listOfClients[i].TypeOfChange = "Изменено";

                        listOfClients[i].WhoChange = "Manager";
                        // Вывод в консоль изменённой записи
                        Console.WriteLine($"\n{"Фамилия",-16} {"Имя",-16} {"Отчество",-16} " +
                                          $"{"Номер телефона",-20} {"Серия и номер паспорта",-24} {"Дата и время изменения записи",-31} " +
                                          $"{"Какие данные изменены",-24} {"Тип изменений",-18} {"Кто изменил данные",-18}");

                        Console.WriteLine($"\n{listOfClients[i].LastName,-16} {listOfClients[i].FirstName,-16} {listOfClients[i].MiddleName,-16} " +
                                          $"{listOfClients[i].PhoneNumber,-20} {listOfClients[i].PassportSeriesAndNumber,-24} {listOfClients[i].DateOfChange,-31} " +
                                          $"{listOfClients[i].WhatChange,-24} {listOfClients[i].TypeOfChange,-18} {listOfClients[i].WhoChange,-18}");

                        using (StreamWriter clientsRec = new StreamWriter("DBClients.txt", false))  // Перезапись файла с обновлёнными данными
                        {
                            for (int j = 0; j < listOfClients.Count; j++)
                            {
                                StringBuilder record = new StringBuilder();

                                record.Append(listOfClients[j].LastName + "#");
                                record.Append(listOfClients[j].FirstName + "#");
                                record.Append(listOfClients[j].MiddleName + "#");
                                record.Append(listOfClients[j].PhoneNumber + "#");
                                record.Append(listOfClients[j].PassportSeriesAndNumber + "#");
                                record.Append(listOfClients[j].DateOfChange + "#");
                                record.Append(listOfClients[j].WhatChange + "#");
                                record.Append(listOfClients[j].TypeOfChange + "#");
                                record.Append(listOfClients[j].WhoChange + "#");

                                clientsRec.WriteLine(record);
                            }
                            Console.WriteLine("\nФайл перезаписан");
                            break;
                        }
                    }
                }
                if (i == listOfClients.Count)
                {
                    Console.WriteLine("\nЗапись не найдена");
                }
                Console.WriteLine("\nДля продолжения нажмите любую клавишу / Для выхода - Esc");
                char key = Console.ReadKey(true).KeyChar;
                if (key == (char)ConsoleKey.Escape)
                    break;
                else
                    continue;
            }
        }

        /// <summary>
        /// Добавляет новые записи в текстовый файл
        /// </summary>
        public void AddData()
        {
            using (StreamWriter clientsRec = new StreamWriter("DBClients.txt", true))
            {
                char key;
                do
                {
                    StringBuilder record = new StringBuilder();

                    #region Ввод ФИО
                    while (true)
                    {
                        Console.Write("\nВведите фамилию: ");
                        string lastName = Console.ReadLine();
                        if (lastName.Length > 14) 
                        {
                            Console.WriteLine("\nСократите имя до 14 знаков");
                            continue;       
                        }
                        record.Append(lastName + "#");
                        break;
                    }
                    while (true) 
                    { 
                        Console.Write("\nВведите имя: ");                        
                        string firstName = Console.ReadLine();
                        if (firstName.Length > 14)
                        {
                            Console.WriteLine("\nСократите имя до 14 знаков");
                            continue;
                        }
                        record.Append(firstName + "#");
                        break;
                    }
                    while (true)
                    {
                        Console.Write("\nВведите отчество: ");
                        string middleName = Console.ReadLine();
                        if (middleName.Length > 14)
                        {
                            Console.WriteLine("\nСократите имя до 14 знаков");
                            continue;
                        }
                        record.Append(middleName + "#");
                        break;
                    }                  
                    #endregion

                    #region Ввод номера телефона
                    while (true)
                    {
                        Console.Write("\nВведите номер телефона (11 цифр в формате ###########): ");

                        bool parseSuccess = long.TryParse(Console.ReadLine(), out long phoneNumber);

                        string phoneNumberString = phoneNumber.ToString();
                        if (parseSuccess && phoneNumberString.Length == 11)
                        {
                            record.Append(phoneNumber.ToString("+# (###) ###-##-##") + "#");
                            break;
                        }
                        else 
                        {
                            Console.WriteLine("\nНеверный ввод");
                            continue;
                        }
                    }
                    #endregion

                    #region Ввод серии и номера паспорта
                    while (true) 
                    {
                        Console.Write("\nВведите серию и номер паспорта (10 цифр в формате ##########): ");

                        bool parseSuccess = long.TryParse(Console.ReadLine(), out long passportSeriesAndNumber);

                        string passportSeriesAndNumberString = passportSeriesAndNumber.ToString();
                        if (parseSuccess && passportSeriesAndNumberString.Length == 10) 
                        {
                            record.Append(passportSeriesAndNumber.ToString("## ## ######") + "#");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nНеверный ввод");
                            continue;
                        }
                    }
                    #endregion

                    #region Заполнение строки остальными данными
                    // Дата и время изменения записи
                    DateTime dateOfChange = DateTime.Now;
                    record.Append(dateOfChange.ToString() + "#");
                    // Какие данные изменены
                    string whatChange = "Никакие" + "#";
                    record.Append(whatChange);
                    // Тип изменений
                    string typeOfChange = "Добавлена запись" + "#";
                    record.Append(typeOfChange);
                    // Кто изменил данные
                    string whoChange = "Manager";
                    record.Append(whoChange);
                    #endregion

                    clientsRec.WriteLine(record);

                    Console.WriteLine("\nДля продолжения ввода данных и их записи нажмите любую клавишу / Для выхода - Esc");
                    key = Console.ReadKey(true).KeyChar;

                } while (key != (char)ConsoleKey.Escape);
            }
        }
    }
}
