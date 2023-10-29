using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    internal class Consultant : IChangeData
    {
        private string lastName;
        private string firstName;
        private string middleName;
        private string phoneNumber;
        private string passportSeriesAndNumber;

        private string dateOfChange;
        private string whatChange;
        private string typeOfChange;
        private string whoChange;

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; } 
        public string PassportSeriesAndNumber { get; set; }

        public string DateOfChange { get; set; }
        public string WhatChange { get; set; }
        public string TypeOfChange { get; set; }
        public string WhoChange { get; set; }

        public Consultant() { }

        private Consultant(string lastName, string firstName, string middleName, string phoneNumber, string passportSeriesAndNumber,
                           string dateOfChange, string whatChange, string typeOfChange, string whoChange) 
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            PassportSeriesAndNumber = passportSeriesAndNumber;
            DateOfChange = dateOfChange;
            WhatChange = whatChange;
            TypeOfChange = typeOfChange;
            WhoChange = whoChange;
        }

        /// <summary>
        /// Создаёт список объектов clients из текстового файла
        /// </summary>
        /// <returns>listOfClients</returns>
        public List<Consultant> GetListOfClients() 
        {
            List<Consultant> listOfClients = new List<Consultant>();

            using (StreamReader clients = new StreamReader("DBClients.txt"))
            {
                string line;

                while ((line = clients.ReadLine()) != null)
                {
                    string[] dataClient = line.Split('#');

                    for (int i = 0; i < dataClient.Length; i++)
                    {
                        if (i == 0)
                            lastName = dataClient[0];
                        else if (i == 1)
                            firstName = dataClient[1];
                        else if (i == 2)
                            middleName = dataClient[2];
                        else if (i == 3)
                            phoneNumber = dataClient[3];
                        else if (i == 4)
                            passportSeriesAndNumber = dataClient[4];
                        else if (i == 5)
                            dateOfChange = dataClient[5];
                        else if (i == 6)    
                            whatChange = dataClient[6];
                        else if (i == 7)
                            typeOfChange = dataClient[7];
                        else if (i == 8)
                            whoChange = dataClient[8];
                    }
                    Consultant client = new Consultant(lastName, firstName, middleName, phoneNumber, passportSeriesAndNumber,
                                                       dateOfChange, whatChange, typeOfChange, whoChange);
                    listOfClients.Add(client);
                }
            }
            return listOfClients;
        }

        /// <summary>
        /// Вывод списка clients в консоли
        /// </summary>
        public virtual void Print(List<Consultant> listOfClients)
        {
            Console.WriteLine($"\n{"Фамилия",-16} {"Имя",-16} {"Отчество",-16} {"Номер телефона",-20} " +
                              $"{"Серия и номер паспорта",-24} {"Дата и время изменения записи",-31} {"Какие данные изменены",-24} " +
                              $"{"Тип изменений",-18} {"Кто изменил данные",-18}\n");

            foreach (Consultant client in listOfClients) 
            {
                Console.WriteLine($"{client.LastName,-16} {client.FirstName,-16} {client.MiddleName,-16} {client.PhoneNumber,-20} " +
                                  $"{"************",-24} {client.DateOfChange,-31} {client.WhatChange,-24} " +
                                  $"{client.TypeOfChange,-18} {client.WhoChange,-18}"); 
            }                   
        }

        /// <summary>
        /// Добавляет (изменяет) данные клиентов (phoneNumber) с перезаписью текстового файла
        /// </summary>
        public void ChangeData(List<Consultant> listOfClients) 
        {
            while (true)
            {
                Console.Write("\nВыберите запись по фамилии для изменения номера телефона: ");
                string inputOfLastName = Console.ReadLine();

                int i;

                for (i = 0; i < listOfClients.Count; i++)  // Поиск нужной записи по фамилии
                {
                    if (listOfClients[i].LastName == inputOfLastName)
                    {
                        long newNumberOfPhone;

                        while (true)  // Ввод номера телефона
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
                        listOfClients[i].DateOfChange = DateTime.Now.ToString();

                        listOfClients[i].WhatChange = "Номер телефона";

                        listOfClients[i].TypeOfChange = "Изменено";

                        listOfClients[i].WhoChange = "Consultant";
                        // Вывод в консоль изменённой записи
                        Console.WriteLine($"\n{"Фамилия",-16} {"Имя",-16} {"Отчество",-16} " +
                                          $"{"Номер телефона",-20} {"Серия и номер паспорта",-24} {"Дата и время изменения записи",-31} " +
                                          $"{"Какие данные изменены",-24} {"Тип изменений",-18} {"Кто изменил данные",-18}");

                        Console.WriteLine($"\n{listOfClients[i].LastName,-16} {listOfClients[i].FirstName,-16} {listOfClients[i].MiddleName,-16} " +
                                          $"{listOfClients[i].PhoneNumber,-20} {"************",-24} {listOfClients[i].DateOfChange,-31} " +
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
    }
}
