using System;
using System.Collections.Generic;

namespace Task13_CompanyWorkers
{
    /// <summary>
    /// Базовый класс Сотрудник
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual decimal GetSalary()
        {
            return BaseSalary;
        }

        public virtual void PrintSalaryInfo()
        {
            Console.WriteLine($"{Name,-20} | Итоговая зарплата: {GetSalary():C}");
        }
    }

    /// <summary>
    /// Программист: базовая ставка + бонусы за закрытые таски
    /// </summary>
    public class Programmer : Employee
    {
        public int CompletedTasks { get; set; }
        public decimal BonusPerTask { get; set; }

        public Programmer(string name, decimal baseSalary, int completedTasks, decimal bonusPerTask) 
            : base(name, baseSalary)
        {
            CompletedTasks = completedTasks;
            BonusPerTask = bonusPerTask;
        }

        public override decimal GetSalary()
        {
            return BaseSalary + (CompletedTasks * BonusPerTask);
        }
    }

    /// <summary>
    /// Дизайнер: базовая ставка + бонусы за утвержденные дизайн-макеты
    /// </summary>
    public class Designer : Employee
    {
        public int ApprovedMockups { get; set; }
        public decimal BonusPerMockup { get; set; }

        public Designer(string name, decimal baseSalary, int approvedMockups, decimal bonusPerMockup) 
            : base(name, baseSalary)
        {
            ApprovedMockups = approvedMockups;
            BonusPerMockup = bonusPerMockup;
        }

        public override decimal GetSalary()
        {
            return BaseSalary + (ApprovedMockups * BonusPerMockup);
        }
    }

    /// <summary>
    /// Менеджер: базовая ставка + процент от успешных проектов
    /// </summary>
    public class Manager : Employee
    {
        public decimal ProjectsRevenue { get; set; }
        public decimal BonusPercent { get; set; } // Например, 0.05m = 5%

        public Manager(string name, decimal baseSalary, decimal projectsRevenue, decimal bonusPercent) 
            : base(name, baseSalary)
        {
            ProjectsRevenue = projectsRevenue;
            BonusPercent = bonusPercent;
        }

        public override decimal GetSalary()
        {
            return BaseSalary + (ProjectsRevenue * BonusPercent);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 13. Работники компании (Индивидуальные формулы GetSalary) ===\n");

            List<Employee> staff = new List<Employee>
            {
                new Programmer("Илья (Senior C#)", 130000m, 14, 5000m),
                new Designer("Анна (UI/UX Lead)", 100000m, 8, 7000m),
                new Manager("Виктор (Project Manager)", 110000m, 1200000m, 0.04m)
            };

            decimal totalPayroll = 0;
            foreach (var emp in staff)
            {
                emp.PrintSalaryInfo();
                totalPayroll += emp.GetSalary();
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Общий зарплатный фонд отдела: {totalPayroll:C}");

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}