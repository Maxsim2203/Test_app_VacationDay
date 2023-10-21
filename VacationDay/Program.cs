using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary > employeesVacations = new Dictionary()>

        // Заполнение списка отпусков сотрудников
        employeesVacations.Add("Иванов Пётр Иванович", new List { "Понедельник", "Вторник", "Среда" });
        employeesVacations.Add("Кирилов Максим Игорьевич", new List { "Пятница", "Суббота", "Воскресенье" });
        employeesVacations.Add("Роженников Вадим Мельник", new List { "Среда", "Четверг", "Пятница" });

        Console.WriteLine("Список отпусков сотрудников и дни недели, когда они могут пойти в отпуск:");
        Console.WriteLine();

        foreach (var employee in employeesVacations)
        {
            Console.WriteLine("Сотрудник: " + employee.Key);
            Console.WriteLine("Дни отпуска:");

            foreach (var vacationDay in employee.Value)
            {
                Console.WriteLine("- " + vacationDay);
            }

            Console.WriteLine();
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}