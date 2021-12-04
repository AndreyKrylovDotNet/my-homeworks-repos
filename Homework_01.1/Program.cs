using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание базы данных из 20 сотрудников
            Repository repository = new Repository(20);

            // Печать в консоль всех сотрудников
            repository.Print("База данных до преобразования");

            // Увольнение всех работников с именем "Агата"
            //repository.DeleteWorkerByName("Агата");

            // Печать в консоль сотрудников, которые не попали под увольнение
            //repository.Print("База данных после первого преобразования");

            // Увольнение всех работников с именем "Аделина"
            //repository.DeleteWorkerByName("Аделина");

            // Печать в консоль сотрудников, которые не попали под увольнение
            //repository.Print("База данных после второго преобразования");


            #region Домашнее задание 1.01

            // Уровень сложности: просто
            //Задание 1.Переделать программу так, чтобы до первой волны увольнения в отделе было не более 20 сотрудников

            #endregion

        }
    }
}
