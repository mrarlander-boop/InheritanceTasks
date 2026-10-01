using System;
using System.Collections.Generic;

namespace Task28_PayrollSystem
{
    /// <summary>
    /// Абстрактный базовый класс Сотрудник
    /// </summary>
    public abstract class Employee
    {
        public string Name { get; }
        public string EmployeeId { get; }

        protected Employee(string name, string employeeId)
        {
            Name = name;
            EmployeeId = employeeId;
        }

        /// <summary>
        /// Абстрактный метод расчета заработной платы
        /// </summary>
        public abstract decimal CalculateSalary();

        public virtual void PrintPayrollStatement()
        {
            Console.WriteLine($"[{EmployeeId}] {Name,-25} | Зарплата к выплате: {CalculateSalary(),12:C}");
        }
    }

    /// <summary>
    /// Почасовой сотрудник (ставка в час + сверхурочные при работе свыше 160 ч в месяц)
    /// </summary>
    public class HourlyEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public HourlyEmployee(string name, string id, decimal hourlyRate, double hoursWorked) 
            : base(name, id)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateSalary()
        {
            if (HoursWorked <= 160)
            {
                return (decimal)HoursWorked * HourlyRate;
            }

            // Сверхурочные с коэффициентом 1.5
            double standardHours = 160;
            double overtimeHours = HoursWorked - 160;
            return ((decimal)standardHours * HourlyRate) + ((decimal)overtimeHours * HourlyRate * 1.5m);
        }
    }

    /// <summary>
    /// Штатный сотрудник на фиксированном окладе
    /// </summary>
    public class SalariedEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }
        public decimal PerformanceBonus { get; set; }

        public SalariedEmployee(string name, string id, decimal monthlySalary, decimal performanceBonus = 0) 
            : base(name, id)
        {
            MonthlySalary = monthlySalary;
            PerformanceBonus = performanceBonus;
        }

        public override decimal CalculateSalary()
        {
            return MonthlySalary + PerformanceBonus;
        }
    }

    /// <summary>
    /// Сотрудник на комиссионной основе (базовый оклад + процент от продаж)
    /// </summary>
    public class CommissionEmployee : Employee
    {
        public decimal BaseSalary { get; set; }
        public decimal GrossSales { get; set; }
        public decimal CommissionRate { get; set; } // Например, 0.08m = 8%

        public CommissionEmployee(string name, string id, decimal baseSalary, decimal grossSales, decimal commissionRate) 
            : base(name, id)
        {
            BaseSalary = baseSalary;
            GrossSales = grossSales;
            CommissionRate = commissionRate;
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary + (GrossSales * CommissionRate);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 28. Система оплаты зарплаты (Расчёт общего фонда) ===\n");

            List<Employee> staff = new List<Employee>
            {
                new HourlyEmployee("Илья Мастеров (Токарь)", "EMP-101", 650m, 175), // 15 ч сверхурочно
                new HourlyEmployee("Олег Техников (Наладчик)", "EMP-102", 500m, 160),
                new SalariedEmployee("Алина Смирнова (Бухгалтер)", "EMP-201", 95000m, 15000m),
                new SalariedEmployee("Дмитрий Архипов (Архитектор)", "EMP-202", 210000m, 30000m),
                new CommissionEmployee("Сергей Продажин (B2B Sales)", "EMP-301", 50000m, 1200000m, 0.06m)
            };

            Console.WriteLine("Расчетная ведомость по заработной плате за текущий месяц:");
            Console.WriteLine(new string('=', 65));

            decimal totalPayrollFund = 0;
            foreach (var emp in staff)
            {
                emp.PrintPayrollStatement();
                totalPayrollFund += emp.CalculateSalary();
            }

            Console.WriteLine(new string('=', 65));
            Console.WriteLine($"ИТОГОВЫЙ ОБЩИЙ ФОНД ОПЛАТЫ ТРУДА (ФОТ): {totalPayrollFund:C}");

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}