using System;
using System.Collections.Generic;

namespace Task12_TransportCompany
{
    /// <summary>
    /// Базовый класс Транспорт
    /// </summary>
    public class Transport
    {
        public string Model { get; set; }
        public double BaseFare { get; set; }

        public Transport(string model, double baseFare)
        {
            Model = model;
            BaseFare = baseFare;
        }

        public virtual decimal CalculateCost(double distanceKm)
        {
            return (decimal)(BaseFare + distanceKm * 10);
        }
    }

    /// <summary>
    /// Легковое такси/автомобиль
    /// </summary>
    public class Car : Transport
    {
        public double RatePerKm { get; set; }

        public Car(string model, double baseFare, double ratePerKm) 
            : base(model, baseFare)
        {
            RatePerKm = ratePerKm;
        }

        public override decimal CalculateCost(double distanceKm)
        {
            return (decimal)(BaseFare + (distanceKm * RatePerKm));
        }
    }

    /// <summary>
    /// Грузовой автомобиль (учитывает тоннаж груза)
    /// </summary>
    public class Truck : Transport
    {
        public double CargoWeightTons { get; set; }
        public double TonPerKmRate { get; set; }

        public Truck(string model, double baseFare, double cargoWeightTons, double tonPerKmRate) 
            : base(model, baseFare)
        {
            CargoWeightTons = cargoWeightTons;
            TonPerKmRate = tonPerKmRate;
        }

        public override decimal CalculateCost(double distanceKm)
        {
            return (decimal)(BaseFare + (distanceKm * CargoWeightTons * TonPerKmRate));
        }
    }

    /// <summary>
    /// Пассажирский автобус (учитывает число мест и скидку на дальние рейсы)
    /// </summary>
    public class Bus : Transport
    {
        public int PassengerCount { get; set; }
        public double TicketRatePerKm { get; set; }

        public Bus(string model, double baseFare, int passengerCount, double ticketRatePerKm) 
            : base(model, baseFare)
        {
            PassengerCount = passengerCount;
            TicketRatePerKm = ticketRatePerKm;
        }

        public override decimal CalculateCost(double distanceKm)
        {
            // Корпоративный заказ всего автобуса
            return (decimal)(BaseFare + (distanceKm * PassengerCount * TicketRatePerKm * 0.85));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 12. Транспортная компания (CalculateCost) ===\n");

            double distance = 150.0; // 150 км
            Console.WriteLine($"Расчет стоимости доставки/поездки на расстояние {distance} км:\n");

            List<Transport> fleet = new List<Transport>
            {
                new Car("Skoda Octavia (Такси)", 200, 25),
                new Truck("KAMAZ-5490 (Грузоперевозка 10 тонн)", 2000, 10, 6.5),
                new Bus("Mercedes Sprinter (Трансфер 18 пассажиров)", 1500, 18, 4.0)
            };

            foreach (var t in fleet)
            {
                decimal cost = t.CalculateCost(distance);
                Console.WriteLine($"{t.Model,-45} | Стоимость: {cost:C}");
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}