using System;

namespace Task02_Vehicle
{
    /// <summary>
    /// Базовый класс Транспортное средство
    /// </summary>
    public class Vehicle
    {
        // Поля Brand и Speed инкапсулированы через свойства
        public string Brand { get; set; }
        public double Speed { get; set; }

        public Vehicle(string brand, double speed)
        {
            Brand = brand;
            Speed = speed;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Марка: {Brand} | Текущая/макс. скорость: {Speed} км/ч");
        }
    }

    /// <summary>
    /// Класс Легковой автомобиль, наследуется от Vehicle
    /// Добавлено собственное свойство NumberOfDoors
    /// </summary>
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string brand, double speed, int numberOfDoors) 
            : base(brand, speed)
        {
            NumberOfDoors = numberOfDoors;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" -> Тип: Легковой автомобиль | Количество дверей: {NumberOfDoors}");
        }
    }

    /// <summary>
    /// Класс Мотоцикл, наследуется от Vehicle
    /// Добавлено собственное свойство HasSidecar (наличие люльки)
    /// </summary>
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(string brand, double speed, bool hasSidecar) 
            : base(brand, speed)
        {
            HasSidecar = hasSidecar;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            string sidecarInfo = HasSidecar ? "Да (есть люлька)" : "Нет (без люльки)";
            Console.WriteLine($" -> Тип: Мотоцикл | Наличие люльки/коляски: {sidecarInfo}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 2. Транспорт (Свойства и наследование) ===\n");

            Car car = new Car("Toyota Camry", 210, 4);
            Motorcycle motorcycle = new Motorcycle("Ural", 120, true);
            Motorcycle sportBike = new Motorcycle("Yamaha R1", 299, false);

            car.DisplayInfo();
            Console.WriteLine();
            motorcycle.DisplayInfo();
            Console.WriteLine();
            sportBike.DisplayInfo();

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}