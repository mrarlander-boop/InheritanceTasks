using System;

namespace Task07_StoreWorker
{
    /// <summary>
    /// Базовый класс Работник магазина
    /// </summary>
    public class Worker
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Worker(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Сотрудник: {Name} | Должность: {Position}");
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Name} выполняет свои рабочие обязанности в магазине.");
        }
    }

    /// <summary>
    /// Класс Кассир, наследуется от Worker
    /// </summary>
    public class Cashier : Worker
    {
        public int RegisterNumber { get; set; }

        public Cashier(string name, int registerNumber) 
            : base(name, "Кассир")
        {
            RegisterNumber = registerNumber;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" -> Рабочее место: Кассовый аппарат №{RegisterNumber}");
        }

        public void ServeCustomer(decimal sum)
        {
            Console.WriteLine($"Кассир {Name} на кассе №{RegisterNumber} пробил чек на сумму {sum:C}.");
        }
    }

    /// <summary>
    /// Класс Продавец-консультант, наследуется от Worker
    /// </summary>
    public class Seller : Worker
    {
        public string Department { get; set; }

        public Seller(string name, string department) 
            : base(name, "Продавец-консультант")
        {
            Department = department;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" -> Отдел продаж: {Department}");
        }

        public void SellItem(string item, decimal price)
        {
            Console.WriteLine($"Продавец {Name} помог выбрать и продал \"{item}\" стоимостью {price:C}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 7. Работник магазина (Cashier и Seller) ===\n");

            Cashier cashier = new Cashier("Марина Иванова", 3);
            Seller seller = new Seller("Сергей Павлов", "Бытовая техника и электроника");

            cashier.DisplayInfo();
            cashier.ServeCustomer(3450.50m);

            Console.WriteLine();

            seller.DisplayInfo();
            seller.SellItem("Телевизор 4K OLED", 79990.00m);

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}