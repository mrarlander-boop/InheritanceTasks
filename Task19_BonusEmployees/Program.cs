using System;
using System.Collections.Generic;

namespace Task19_BonusEmployees
{
    /// <summary>
    /// Базовый класс Сотрудник с зарплатой и процентом бонуса
    /// </summary>
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public double BonusPercentage { get; set; }

        public Employee(string name, decimal salary, double bonusPercentage)
        {
            Name = name;
            Salary = salary;
            BonusPercentage = bonusPercentage;
        }

        public virtual decimal CalculateBonus()
        {
            return Salary * (decimal)BonusPercentage;
        }

        public virtual decimal CalculateTotalSalary()
        {
            return Salary + CalculateBonus();
        }

        public virtual void DisplaySalaryReport()
        {
            Console.WriteLine($"{Name,-22} | Оклад: {Salary,10:C} | Бонус ({BonusPercentage:P0}): {CalculateBonus(),10:C} | Итого: {CalculateTotalSalary(),10:C}");
        }
    }

    /// <summary>
    /// Менеджер (бонус 20% + надбавка за выполнение KPI отдела)
    /// </summary>
    public class Manager : Employee
    {
        public Manager(string name, decimal salary) 
            : base(name, salary, 0.20) { }

        public override decimal CalculateBonus()
        {
            // Фиксированная надбавка за выполнение командного KPI
            decimal kpiBonus = 10000m;
            return base.CalculateBonus() + kpiBonus;
        }
    }

    /// <summary>
    /// Разработчик (бонус 15% + надбавка за сложность проектов)
    /// </summary>
    public class Developer : Employee
    {
        public Developer(string name, decimal salary) 
            : base(name, salary, 0.15) { }

        public override decimal CalculateBonus()
        {
            decimal projectBonus = 15000m;
            return base.CalculateBonus() + projectBonus;
        }
    }

    /// <summary>
    /// Менеджер по продажам (бонус 30% + премия от объема заключенных контрактов)
    /// </summary>
    public class SalesManager : Employee
    {
        public decimal TotalDealsVolume { get; set; }

        public SalesManager(string name, decimal salary, decimal totalDealsVolume) 
            : base(name, salary, 0.30)
        {
            TotalDealsVolume = totalDealsVolume;
        }

        public override decimal CalculateBonus()
        {
            // 2% от объема закрытых сделок плюсом к базовому бонусу
            decimal commission = TotalDealsVolume * 0.02m;
            return base.CalculateBonus() + commission;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 19. Сотрудники с бонусами (Manager, Developer, SalesManager) ===\n");

            List<Employee> staff = new List<Employee>
            {
                new Manager("Елена Соколова", 120000m),
                new Developer("Максим Орлов", 160000m),
                new SalesManager("Артем Кузнецов", 90000m, 1500000m)
            };

            foreach (var emp in staff)
            {
                emp.DisplaySalaryReport();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}