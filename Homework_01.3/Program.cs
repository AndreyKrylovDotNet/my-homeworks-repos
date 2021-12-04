using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01._3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание базы данных из 50 сотрудников
            Repository repository = new Repository(50);

            // Печать в консоль всех сотрудников
            repository.Print("База данных до преобразования");

            // Увольнение всех работников, чья зарплата превышает 30000руб
            repository.DeleteWorkerBySalary(30_000);

            // Печать в консоль сотрудников, которые не попали под увольнение
            repository.Print("База данных после первого преобразования");


            #region Домашнее задание 1.03

            // Уровень сложности: сложно
            // ** Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников
            //               чья зарплата превышает 30000руб

            #endregion

        }
    }
}
