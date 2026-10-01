using System;
using System.Collections.Generic;

namespace Task22_OnlineStore
{
    /// <summary>
    /// Базовый класс Товар интернет-магазина
    /// </summary>
    public class Product
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }

        public Product(string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }

        /// <summary>
        /// Виртуальный метод расчета итоговой цены с учетом специфики категории
        /// </summary>
        public virtual decimal CalculateFinalPrice()
        {
            return BasePrice;
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine($"{Name,-30} | Базовая цена: {BasePrice,10:C} | Итоговая цена: {CalculateFinalPrice(),10:C}");
        }
    }

    /// <summary>
    /// Электроника: включает стоимость расширенной гарантии и обязательный эко-сбор
    /// </summary>
    public class Electronics : Product
    {
        public int WarrantyMonths { get; set; }

        public Electronics(string name, decimal basePrice, int warrantyMonths) 
            : base(name, basePrice)
        {
            WarrantyMonths = warrantyMonths;
        }

        public override decimal CalculateFinalPrice()
        {
            // Эко-сбор 2% + сервисный сбор за каждый год гарантии
            decimal warrantySurcharge = BasePrice * (0.03m * (WarrantyMonths / 12m));
            decimal ecoFee = BasePrice * 0.02m;
            return BasePrice + warrantySurcharge + ecoFee;
        }
    }

    /// <summary>
    /// Одежда: сезонная скидка или надбавка за премиальные размеры/коллекцию
    /// </summary>
    public class Clothing : Product
    {
        public string Size { get; set; }
        public decimal SeasonalDiscountPercent { get; set; } // Например, 0.20m = скидка 20%

        public Clothing(string name, decimal basePrice, string size, decimal discountPercent) 
            : base(name, basePrice)
        {
            Size = size;
            SeasonalDiscountPercent = discountPercent;
        }

        public override decimal CalculateFinalPrice()
        {
            decimal discount = BasePrice * SeasonalDiscountPercent;
            return BasePrice - discount;
        }
    }

    /// <summary>
    /// Продукты питания: скидка в зависимости от срока годности
    /// </summary>
    public class Food : Product
    {
        public int DaysUntilExpiration { get; set; }

        public Food(string name, decimal basePrice, int daysUntilExpiration) 
            : base(name, basePrice)
        {
            DaysUntilExpiration = daysUntilExpiration;
        }

        public override decimal CalculateFinalPrice()
        {
            // Если до конца срока годности 2 дня или меньше — скидка 40%
            if (DaysUntilExpiration <= 2)
            {
                return BasePrice * 0.60m;
            }
            return BasePrice;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 22. Интернет-магазин (Различные способы расчёта цены) ===\n");

            List<Product> cart = new List<Product>
            {
                new Electronics("Ноутбук ASUS ZenBook", 95000m, 24),
                new Clothing("Зимняя куртка Columbia", 18000m, "L", 0.25m),
                new Food("Молоко пастеризованное 3.2%", 110m, 1), // Срочная уценка
                new Food("Сыр Пармезан 200г", 450m, 30) // Свежий
            };

            decimal totalCart = 0;
            Console.WriteLine("Корзина покупателя:");
            Console.WriteLine(new string('-', 75));
            foreach (var item in cart)
            {
                item.PrintDetails();
                totalCart += item.CalculateFinalPrice();
            }
            Console.WriteLine(new string('-', 75));
            Console.WriteLine($"ИТОГО К ОПЛАТЕ: {totalCart:C}");

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}