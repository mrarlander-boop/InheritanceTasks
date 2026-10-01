using System;
using System.Collections.Generic;

namespace Task23_TransportSystem
{
    /// <summary>
    /// Абстрактный класс Транспорт
    /// </summary>
    public abstract class Transport
    {
        public string Model { get; }
        public double AverageConsumptionPer100Km { get; } // л / 100 км

        protected Transport(string model, double avgConsumption)
        {
            Model = model;
            AverageConsumptionPer100Km = avgConsumption;
        }

        public abstract void Move();
        public abstract double GetFuelConsumption(double distanceKm);

        public virtual void DisplayRouteInfo(double distanceKm)
        {
            Console.WriteLine($"[{Model}] Расход на {distanceKm} км: {GetFuelConsumption(distanceKm):F2} литров.");
        }
    }

    /// <summary>
    /// Легковой автомобиль
    /// </summary>
    public class Car : Transport
    {
        public Car(string model) : base(model, 7.5) { }

        public override void Move()
        {
            Console.WriteLine($"Легковой авто {Model} плавно движется по шоссе на крейсерской скорости 110 км/ч.");
        }

        public override double GetFuelConsumption(double distanceKm)
        {
            return (distanceKm / 100.0) * AverageConsumptionPer100Km;
        }
    }

    /// <summary>
    /// Тяжелый грузовик
    /// </summary>
    public class Truck : Transport
    {
        public double CargoWeightTons { get; set; }

        public Truck(string model, double cargoWeightTons) : base(model, 30.0)
        {
            CargoWeightTons = cargoWeightTons;
        }

        public override void Move()
        {
            Console.WriteLine($"Грузовик {Model} перевозит {CargoWeightTons} тонн груза по федеральной трассе.");
        }

        public override double GetFuelConsumption(double distanceKm)
        {
            // Каждая тонна груза добавляет 1.2 л к расходу на 100 км
            double actualRate = AverageConsumptionPer100Km + (CargoWeightTons * 1.2);
            return (distanceKm / 100.0) * actualRate;
        }
    }

    /// <summary>
    /// Пассажирский автобус
    /// </summary>
    public class Bus : Transport
    {
        public int Passengers { get; set; }

        public Bus(string model, int passengers) : base(model, 25.0)
        {
            Passengers = passengers;
        }

        public override void Move()
        {
            Console.WriteLine($"Автобус {Model} с {Passengers} пассажирами следует по междугороднему маршруту.");
        }

        public override double GetFuelConsumption(double distanceKm)
        {
            // Каждые 10 пассажиров добавляют 0.5 л к расходу
            double actualRate = AverageConsumptionPer100Km + (Passengers / 10.0 * 0.5);
            return (distanceKm / 100.0) * actualRate;
        }
    }

    /// <summary>
    /// Мотоцикл
    /// </summary>
    public class Motorcycle : Transport
    {
        public Motorcycle(string model) : base(model, 4.2) { }

        public override void Move()
        {
            Console.WriteLine($"Мотоцикл {Model} маневренно обходит пробки и ускоряется.");
        }

        public override double GetFuelConsumption(double distanceKm)
        {
            return (distanceKm / 100.0) * AverageConsumptionPer100Km;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 23. Система транспорта (Move и GetFuelConsumption) ===\n");

            double distance = 250.0; // 250 км
            Console.WriteLine($"Расчет для маршрута длиной {distance} км:\n");

            List<Transport> transports = new List<Transport>
            {
                new Car("Volkswagen Passat"),
                new Truck("Scania R500", 18.0),
                new Bus("MAN Lion's Coach", 45),
                new Motorcycle("Honda CBR650R")
            };

            foreach (var t in transports)
            {
                t.Move();
                t.DisplayRouteInfo(distance);
                Console.WriteLine();
            }

            Console.WriteLine("Завершено успешно. Нажмите Enter...");
        }
    }
}