using System;
using System.Reflection;
using System.Text;

namespace Homework_07
{
    public struct Worker
    {
        private uint id;
        private DateTime recordCreationDate;
        private string fio;
        private uint age;
        private uint growth;
        private string dateOfBirth;
        private string birthPlace;

        public uint Id { get; set; }
        public DateTime RecordCreationDate { get; set; }
        public string FIO { get; set; }  
        public uint Age { get; set; }
        public uint Growth { get; set; }
        public string DateOfBirth { get; set; }   
        public string BirthPlace { get; set; }

        public Worker[] workers;

        public Worker this[uint index]
        {
            get { return workers[index]; }
            set { workers[index] = value; }
        }

        /// <summary>
        /// Вывод заголовков для выводимых в консоль данных
        /// </summary>
        public void PrintTitle()
        {
            Console.WriteLine($"\n{"ID",-4} {"Время записи",-20} {"Ф.И.О.",-30} {"Возраст",-9} {"Рост",-6} " +
                              $"{"Дата рождения",-15} {"Место рождения",-20}");
        }
        /// <summary>
        /// Вывод данных экземпляра типа Worker
        /// </summary>
        /// <param name="worker"></param>
        public void PrintData(Worker worker)
        {

            Console.WriteLine($"{worker.Id,-4} {worker.RecordCreationDate,-20} {worker.FIO,-30} {worker.Age,-9} {worker.Growth,-6} " +
                              $"{worker.DateOfBirth,-15} {worker.BirthPlace,-20}");
        }
    }
}

