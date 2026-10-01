using System;
using System.Collections.Generic;

namespace Task06_VehicleMovement
{
    /// <summary>
    /// Базовый класс Транспорт
    /// </summary>
    public class Vehicle
    {
        public string Model { get; set; }

        public Vehicle(string model)
        {
            Model = model;
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Model} осуществляет движение.");
        }
    }

    /// <summary>
    /// Автомобиль
    /// </summary>
    public class Car : Vehicle
    {
        public Car(string model) : base(model) { }

        public override void Move()
        {
            Console.WriteLine($"Автомобиль {Model} едет по автомагистрали, маневрируя в потоке машин.");
        }
    }

    /// <summary>
    /// Автобус
    /// </summary>
    public class Bus : Vehicle
    {
        public Bus(string model) : base(model) { }

        public override void Move()
        {
            Console.WriteLine($"Автобус {Model} движется по выделенной полосе с остановками для посадки пассажиров.");
        }
    }

    /// <summary>
    /// Поезд
    /// </summary>
    public class Train : Vehicle
    {
        public Train(string model) : base(model) { }

        public override void Move()
        {
            Console.WriteLine($"Поезд {Model} мчится по железнодорожным рельсам между городами.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 6. Транспорт с методом движения Move() ===\n");

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Audi A6"),
                new Bus("ЛиАЗ-5292"),
                new Train("Сапсан ЭВС2")
            };

            foreach (var v in vehicles)
            {
                v.Move();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}