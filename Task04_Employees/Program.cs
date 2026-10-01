using System;

namespace Task04_Employees
{
    /// <summary>
    /// Базовый класс Сотрудник
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Сотрудник: {Name} | Оклад: {Salary:C}");
        }
    }

    /// <summary>
    /// Класс Менеджер с дополнительным полем: размер команды (TeamSize)
    /// </summary>
    public class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, decimal salary, int teamSize) 
            : base(name, salary)
        {
            TeamSize = teamSize;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" -> Должность: Менеджер | Людей в подчинении: {TeamSize}");
        }

        public void ConductMeeting()
        {
            Console.WriteLine($"Менеджер {Name} проводит ежедневный планёрку для команды из {TeamSize} человек.");
        }
    }

    /// <summary>
    /// Класс Разработчик с дополнительным полем: основной язык программирования (PrimaryLanguage)
    /// </summary>
    public class Developer : Employee
    {
        public string PrimaryLanguage { get; set; }

        public Developer(string name, decimal salary, string primaryLanguage) 
            : base(name, salary)
        {
            PrimaryLanguage = primaryLanguage;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" -> Должность: Разработчик | Язык программирования: {PrimaryLanguage}");
        }

        public void WriteCode()
        {
            Console.WriteLine($"Разработчик {Name} пишет высокопроизводительный код на {PrimaryLanguage}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 4. Сотрудники (Manager и Developer) ===\n");

            Manager manager = new Manager("Ольга Викторовна", 120000m, 8);
            Developer developer = new Developer("Дмитрий Козлов", 150000m, "C# / .NET");

            manager.DisplayInfo();
            manager.ConductMeeting();

            Console.WriteLine();

            developer.DisplayInfo();
            developer.WriteCode();

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}