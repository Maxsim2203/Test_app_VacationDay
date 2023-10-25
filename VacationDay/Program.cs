using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

        {
            var VacationDictionary = new Dictionary<string, List<DateTime>>()
            {
                ["Иванов Иван Иванович"] = new List<DateTime>(),
                ["Петров Петр Петрович"] = new List<DateTime>(),
                ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
                ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
                ["Павлов Павел Павлович"] = new List<DateTime>(),
                ["Георгиев Георг Георгиевич"] = new List<DateTime>()
            };
            foreach (var employee in VacationDictionary)
            {
                string[] employeeData = employee.Split(' ');
                string lastName = employeeData[0];
                string firstName = employeeData[1];
                string middleName = employeeData[2];

                List<DateTime> vacations = GenerateVacations();

                Console.WriteLine("Сотрудник: " + lastName + " " + firstName + " " + middleName);
                Console.WriteLine("Отпускные даты:");
                foreach (DateTime date in vacations)
                {
                    Console.WriteLine(date.ToString("dd.MM.yyyy"));
                }

                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static List<DateTime> GenerateVacations()
        {
            List<DateTime> vacations = new List<DateTime>();
            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endOfYear = new DateTime(DateTime.Now.Year, 12, 31);

            int vacationDaysLeft = 28;

            while (vacationDaysLeft > 0)
            {
                DateTime startDate = GetRandomDate(startOfYear, endOfYear);
                int vacationDuration = GetRandomDuration(vacationDaysLeft);

                if (startDate.Month == 12 && (startDate.Day + vacationDuration) > 31)
                {
                    continue; // Пропускаем отпуск в декабре с переходом на январь
                }

                for (int i = 0; i < vacationDuration; i++)
                {
                    vacations.Add(startDate.AddDays(i));
                }

                vacationDaysLeft -= vacationDuration;
            }

            return vacations;
        }

        static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            Random rand = new Random();
            int days = (endDate - startDate).Days;
            int randomDays = rand.Next(days + 1);
            return startDate.AddDays(randomDays);
        }

        static int GetRandomDuration(int remainingVacationDays)
        {
            Random rand = new Random();
            int[] durations = { 7, 14 };
            int randomIndex = rand.Next(durations.Length);
            return Math.Min(remainingVacationDays, durations[randomIndex]);
        }
    }
}