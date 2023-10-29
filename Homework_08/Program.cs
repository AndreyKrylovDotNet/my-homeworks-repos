using System;
using System.Xml.Linq;

namespace Homework_08
{
    internal class Program
    {
        /*Задание 1. Работа с листом    
             
              1. Создать лист целых чисел. 
              2. Заполнить лист 100 случайными числами в диапазоне от 0 до 100. 
              3. Вывести коллекцию чисел на экран. 
              4. Удалить из листа числа, которые больше 25, но меньше 50. 
              5. Снова вывести числа на экран. 

              Рекомендация:
                 Сделать отдельные методы для заполнения, удаления и вывода на экран.

              Что оценивается:
                 В программе используется три отдельных метода. 
                 В качестве хранилища данных используется List.*/

        /// <summary>
        /// Заполняет List диапазоном случайных чисел от 0 до 100
        /// </summary>
        /// <param name="myList"></param>
        /// <returns>Коллекция List со 100 случайными числами</returns>
        static List<int> AddListRandomNumb(List<int> myList)
        {
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                myList.Add(rnd.Next(0, 100));
            }
            return myList;
        }
        /// <summary>
        /// Выводит в консоль коллекцию List
        /// </summary>
        /// <param name="myList"></param>
        static void PrintList(List<int> myList)
        {
            foreach (int i in myList)
            {
                Console.Write(i + " ");
            }
        }
        /// <summary>
        /// Удаляет из List числа, которые больше 25, но меньше 50
        /// </summary>
        /// <param name="myList"></param>
        /// <returns>List после удаления чисел</returns>
        static List<int> RemoveFromlist(List<int> myList)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] > 25 && myList[i] < 50)
                {
                    myList.Remove(myList[i]);
                }
            }
            return myList;
        }

        /*Задание 2. Телефонная книга   

              1. Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев. 
              2. В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, 
                 а значением — ФИО владельца. Таким образом, у одного владельца может быть несколько номеров телефонов. 
                 Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки.  
              3. Далее программа предлагает найти владельца по введенному номеру телефона. Пользователь вводит номер 
                 телефона и ему выдаётся ФИО владельца. Если владельца по такому номеру телефона не зарегистрировано, 
                 программа выводит на экран соответствующее сообщение. 

              Рекомендация:
                 Для того, чтобы находить значение в Dictionary, нужно использовать TryGetValue.
          
              Что оценивается:
                 Программа разделена на логические методы.
                 Для хранения элементов записной книжки используется Dictionary.*/
        /// <summary>
        /// Предлагает ввести номера телефонов и ФИО их владельцев
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns>Dictionary, представляющий собой телефонную книгу</returns>
        static Dictionary<string, string> AddKeyValuePairsInDict(Dictionary<string, string> keyValuePairs)
        {
            string phoneNumber, fullName;
            while (true)
            {
                Console.Write("\nВведите номер телефона: ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber == "") break;

                Console.Write("Введите ФИО: ");
                fullName = Console.ReadLine();
                if (fullName == "") break;

                keyValuePairs.Add(phoneNumber, fullName);
            }
            return keyValuePairs;
        }
        /// <summary>
        /// Предлагает найти владельца по введённому номеру телефона
        /// </summary>
        /// <param name="keyValuePairs"></param>
        static void SearchByPhoneNumber(Dictionary<string, string> keyValuePairs)
        {
            Console.Write("\nВведите номер телефона для поиска абонента: ");

            string phoneNumber = Console.ReadLine();

            if (keyValuePairs.TryGetValue(phoneNumber, out string value))
            {
                Console.WriteLine($"\nНомер {phoneNumber} принадлежит абоненту {value}");
            }
            else
            {
                Console.WriteLine("\nПо такому номеру абонента не зарегистрировано");
            }
        }

        /*Задание 3. Проверка повторов   

              Пользователь вводит число. Число сохраняется в HashSet коллекцию. Если такое число уже присутствует в коллекции, 
              то пользователю на экран выводится сообщение, что число уже вводилось ранее. Если числа нет, то появляется 
              сообщение о том, что число успешно сохранено. 

              Рекомендация:
                 Для добавление числа в HashSet использовать метод Add. 
          
              Что оценивается:
                 В программе в качестве коллекции используется HashSet.*/
        /// <summary>
        /// Запрашивает ввод числа и сохраняет его в коллекцию HashSet
        /// </summary>
        /// <param name="set"></param>
        /// <returns>Коллекция HashSet</returns>
        static HashSet<int> AddsToHashSet(HashSet<int> set)
        {
            char escapeButton;
            do
            {
                int elementSet;
                Console.Write("\nВведите число для добавления его в коллекцию: ");

                while (!int.TryParse(Console.ReadLine(), out elementSet))
                {
                    Console.Write("\nНекорректный ввод. Введите число: ");
                }

                if (set.Contains(elementSet))
                {
                    Console.WriteLine("Число вводилось ранее!" +
                                      "\nНовое число должно быть уникальным для данной коллекции\n");
                }
                else
                {
                    set.Add(elementSet);
                    Console.WriteLine("Число сохранено");
                }
                Console.WriteLine("Для продолжения ввода чисел - любая клавиша / Для выхода - Esc");

                escapeButton = Console.ReadKey(true).KeyChar;

            } while (escapeButton != (char)ConsoleKey.Escape);

            Console.WriteLine("\nДля вывода коллекции нажмите любую клавишу\n");
            Console.ReadKey();

            foreach (int elementSet in set)
            {
                Console.Write(elementSet + " ");
            }
            return set;
        }

        /*Задание 4. Записная книжка

              Программа спрашивает у пользователя данные о контакте:
                
                ФИО
                Улица
                Номер дома
                Номер квартиры
                Мобильный телефон
                Домашний телефон

              С помощью XElement создать xml файл, в котором есть введенная информация. 
              XML файл должен содержать следующую структуру:
              
              <Person name=”ФИО человека” >
                  <Address>
                      <Street>Название улицы</Street>
                      <HouseNumber>Номер дома</HouseNumber>
                      <FlatNumber>Номер квартиры</FlatNumber>
                  </Address>
                  <Phones>
                      <MobilePhone>89999999999999</MobilePhone>
                      <FlatPhone>123-45-67<FlatPhone>
                  </Phones>
              </Person>

              Рекомендация:
                 Заполнять XElement в ходе заполнения данных. Изучить возможности XElement в документации Microsoft.
          
              Что оценивается:
                 Программа создаёт Xml файл, содержащий все данные о контакте.*/

        struct Person 
        {
            public string FullName { get; set; }
            public string Street {  get; set; }
            public string HouseNumber { get; set; }
            public string FlatNumber { get; set; }
            public string MobilePhone { get; set; }
            public string FlatPhone { get; set; }

            public Person (string fullName, string street, string houseNumber, string flatNumber, string mobilePhone, string flatPhone) 
            {
                FullName = fullName;
                Street = street;
                HouseNumber = houseNumber;
                FlatNumber = flatNumber;                  
                MobilePhone = mobilePhone;
                FlatPhone = flatPhone;
            }
        }
        /// <summary>
        /// Сериализует объект Person в формат XML
        /// </summary>
        /// <param name="person"></param>
        static void XmlSerializePerson(Person person) 
        {
            XDocument xdoc = new XDocument();

            XElement personElem = new XElement("Person");
            XAttribute nameAttr = new XAttribute("name", person.FullName);
            personElem.Add(nameAttr);  // добавление аттрибута к корневому элементу Person

            XElement addressElem = new XElement("Address");
            XElement streetElem = new XElement("Street", person.Street);
            XElement houseElem = new XElement("HouseNumber", person.HouseNumber);
            XElement flatNumberElem = new XElement("FlatNumber", person.FlatNumber);
            addressElem.Add(streetElem, houseElem, flatNumberElem);  // добавление вложенных элементов в элемент Address
            personElem.Add(addressElem);  // добавление элемента Address, вложенного в корневой элемент Person

            XElement phonesElem = new XElement("Phones");
            XElement mobilePhoneElem = new XElement("MobilePhone", person.MobilePhone);
            XElement flatPhoneElem = new XElement("FlatPhone", person.FlatPhone);
            phonesElem.Add(mobilePhoneElem, flatPhoneElem);  // добавление вложенных элементов в элемент Phones
            personElem.Add(phonesElem);  // добавление элемента Phones, вложенного в корневой элемент Person

            xdoc.Add(personElem);  // добавление корневого элемента в документ
            xdoc.Save("person.xml");  // сохранение документа

            Console.WriteLine("\nXML-файл с данными объекта Person создан");
        }

        static void Main(string[] args)
        {
            List<int> myList = new List<int>();

            while (true) 
            {
                Console.WriteLine("Нажмите соответствующую цифровую клавишу для выполнения нужной операции:\n" +
                                  "Задание [1]: Работа с List'ом\n" +
                                  "Задание [2]: Телефонная книга \n" +
                                  "Задание [3]: Проверка повторов\n" +
                                  "Задание [4]: Записная книжка\n" +
                                  "\nДля выхода из программы - любая клавиша");

                char button = Console.ReadKey(true).KeyChar;

                switch (button) 
                {
                    case '1':  // Работа с List'ом

                        AddListRandomNumb(myList);
                        Console.WriteLine("\nНажмите любую клавишу для вывода коллекции List на 100 случайных чисел:\n");
                        Console.ReadKey();
                        PrintList(myList);

                        RemoveFromlist(myList);
                        Console.WriteLine("\n\nНажмите любую клавишу для вывода той же коллекции List без чисел," +
                                          "\nкоторые больше 25, но меньше 50:\n");
                        Console.ReadKey();

                        PrintList(myList);

                        Console.WriteLine("\n\nДля продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    case '2':  // Телефонная книга

                        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                        AddKeyValuePairsInDict(keyValuePairs);

                        SearchByPhoneNumber(keyValuePairs);

                        Console.WriteLine("\nДля продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    case '3':  // Проверка повторов

                        HashSet<int> set = new HashSet<int>();

                        AddsToHashSet(set);

                        Console.WriteLine("\n\nДля продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    case '4':  // Записная книжка

                        Person person = new Person();

                        Console.Write("\nВведите ФИО: ");
                        person.FullName = Console.ReadLine();

                        Console.Write("\nВведите название улицы: ");
                        person.Street = Console.ReadLine();

                        Console.Write("\nВведите номер дома: ");
                        person.HouseNumber = Console.ReadLine();

                        Console.Write("\nВведите номер квартиры: ");
                        person.FlatNumber = Console.ReadLine();

                        Console.Write("\nВведите номер мобильного телефона: ");
                        person.MobilePhone = Console.ReadLine();

                        Console.Write("\nВведите номер стационарного телефона: ");
                        person.FlatPhone = Console.ReadLine();

                        XmlSerializePerson(person);

                        Console.WriteLine("\nДля продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;

                    default:
                        button = '\0';
                        break;
                }
                if (button == '\0') break;
                Console.Clear();
            }
        }
    }
}
