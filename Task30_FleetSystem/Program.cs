using System;
using System.Collections.Generic;
using System.Linq;

namespace Task30_FleetSystem
{
    /// <summary>
    /// Базовый класс Транспортное средство
    /// </summary>
    public abstract class Vehicle
    {
        public int Id { get; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public double MaxSpeed { get; set; }
        public double FuelConsumptionPer100Km { get; set; } // литры или кВт*ч на 100 км

        protected Vehicle(int id, string brand, string model, int year, decimal price, double maxSpeed, double fuelConsumption)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            MaxSpeed = maxSpeed;
            FuelConsumptionPer100Km = fuelConsumption;
        }

        public abstract string GetVehicleType();

        public virtual double CalculateTripFuel(double distanceKm)
        {
            return (distanceKm / 100.0) * FuelConsumptionPer100Km;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[ID: {Id,2}] {GetVehicleType(),-15} {Brand} {Model} ({Year} г.) | Скорость: {MaxSpeed,3} км/ч | Цена: {Price,12:C} | Расход: {FuelConsumptionPer100Km:F1} л/100км");
        }
    }

    /// <summary>
    /// Легковой автомобиль
    /// </summary>
    public class Car : Vehicle
    {
        public int TrunkVolumeLiters { get; set; }
        public int PassengerSeats { get; set; }

        public Car(int id, string brand, string model, int year, decimal price, double maxSpeed, double fuelConsumption, int trunkLiters, int passengerSeats)
            : base(id, brand, model, year, price, maxSpeed, fuelConsumption)
        {
            TrunkVolumeLiters = trunkLiters;
            PassengerSeats = passengerSeats;
        }

        public override string GetVehicleType() => "Легковой авто";

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"      -> Багажник: {TrunkVolumeLiters} л | Мест: {PassengerSeats}");
        }
    }

    /// <summary>
    /// Грузовой транспорт
    /// </summary>
    public class Truck : Vehicle
    {
        public double LoadCapacityTons { get; set; }
        public int AxlesCount { get; set; }

        public Truck(int id, string brand, string model, int year, decimal price, double maxSpeed, double fuelConsumption, double loadCapacityTons, int axlesCount)
            : base(id, brand, model, year, price, maxSpeed, fuelConsumption)
        {
            LoadCapacityTons = loadCapacityTons;
            AxlesCount = axlesCount;
        }

        public override string GetVehicleType() => "Грузовик";

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"      -> Грузоподъемность: {LoadCapacityTons} т | Осей: {AxlesCount}");
        }
    }

    /// <summary>
    /// Автобус
    /// </summary>
    public class Bus : Vehicle
    {
        public int PassengerCapacity { get; set; }
        public bool HasAccessibilityRamp { get; set; }

        public Bus(int id, string brand, string model, int year, decimal price, double maxSpeed, double fuelConsumption, int passengerCapacity, bool hasRamp)
            : base(id, brand, model, year, price, maxSpeed, fuelConsumption)
        {
            PassengerCapacity = passengerCapacity;
            HasAccessibilityRamp = hasRamp;
        }

        public override string GetVehicleType() => "Автобус";

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            string ramp = HasAccessibilityRamp ? "Есть" : "Нет";
            Console.WriteLine($"      -> Вместимость: {PassengerCapacity} чел. | Доступная среда: {ramp}");
        }
    }

    /// <summary>
    /// Электромобиль (переопределяет расход: кВт·ч на 100 км)
    /// </summary>
    public class ElectricCar : Vehicle
    {
        public double BatteryCapacityKwh { get; set; }
        public int RangeKm { get; set; }

        public ElectricCar(int id, string brand, string model, int year, decimal price, double maxSpeed, double kwhPer100Km, double batteryKwh, int rangeKm)
            : base(id, brand, model, year, price, maxSpeed, kwhPer100Km)
        {
            BatteryCapacityKwh = batteryKwh;
            RangeKm = rangeKm;
        }

        public override string GetVehicleType() => "Электромобиль";

        public override double CalculateTripFuel(double distanceKm)
        {
            // Возвращает расход электроэнергии в кВт*ч
            return (distanceKm / 100.0) * FuelConsumptionPer100Km;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[ID: {Id,2}] {GetVehicleType(),-15} {Brand} {Model} ({Year} г.) | Скорость: {MaxSpeed,3} км/ч | Цена: {Price,12:C} | Расход: {FuelConsumptionPer100Km:F1} кВт·ч/100км");
            Console.WriteLine($"      -> Батарея: {BatteryCapacityKwh} кВт·ч | Запас хода: {RangeKm} км");
        }
    }

    /// <summary>
    /// Мотоцикл
    /// </summary>
    public class Motorcycle : Vehicle
    {
        public int EngineDisplacementCc { get; set; }
        public bool HasSidecar { get; set; }

        public Motorcycle(int id, string brand, string model, int year, decimal price, double maxSpeed, double fuelConsumption, int displacementCc, bool hasSidecar)
            : base(id, brand, model, year, price, maxSpeed, fuelConsumption)
        {
            EngineDisplacementCc = displacementCc;
            HasSidecar = hasSidecar;
        }

        public override string GetVehicleType() => "Мотоцикл";

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            string sidecar = HasSidecar ? "Есть коляска" : "Без коляски";
            Console.WriteLine($"      -> Объём двигателя: {EngineDisplacementCc} см³ | {sidecar}");
        }
    }

    /// <summary>
    /// Класс управления корпоративным автопарком
    /// </summary>
    public class FleetManager
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            _vehicles.Add(vehicle);
            Console.WriteLine($"[+] Транспорт добавлен в парк: {vehicle.Brand} {vehicle.Model} (ID: {vehicle.Id})");
        }

        public bool RemoveVehicle(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                _vehicles.Remove(vehicle);
                Console.WriteLine($"[-] Транспорт с ID {id} ({vehicle.Brand} {vehicle.Model}) успешно списан из автопарка.");
                return true;
            }
            Console.WriteLine($"[!] Транспорт с ID {id} не найден.");
            return false;
        }

        public void PrintAllVehicles()
        {
            Console.WriteLine($"\n--- СПИСОК ТРАНСПОРТА АВТОПАРКА (Всего: {_vehicles.Count} ед.) ---");
            foreach (var v in _vehicles)
            {
                v.DisplayInfo();
            }
        }

        public Vehicle? FindFastestVehicle()
        {
            return _vehicles.OrderByDescending(v => v.MaxSpeed).FirstOrDefault();
        }

        public Vehicle? FindMostExpensiveVehicle()
        {
            return _vehicles.OrderByDescending(v => v.Price).FirstOrDefault();
        }

        public void CalculateTripConsumptionReport(double distanceKm)
        {
            Console.WriteLine($"\n--- РАСХОД ТОПЛИВА И ЭНЕРГИИ НА МАРШРУТ {distanceKm} КМ ---");
            double totalFuelLitres = 0;
            double totalElectricKwh = 0;

            foreach (var v in _vehicles)
            {
                double consumption = v.CalculateTripFuel(distanceKm);
                if (v is ElectricCar)
                {
                    totalElectricKwh += consumption;
                    Console.WriteLine($"{v.Brand} {v.Model,-20} ({v.GetVehicleType()}): {consumption,7:F2} кВт·ч");
                }
                else
                {
                    totalFuelLitres += consumption;
                    Console.WriteLine($"{v.Brand} {v.Model,-20} ({v.GetVehicleType()}): {consumption,7:F2} л бензина/дизеля");
                }
            }

            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"Суммарный расход жидкого топлива : {totalFuelLitres:F2} л");
            Console.WriteLine($"Суммарный расход электроэнергии  : {totalElectricKwh:F2} кВт·ч");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==================================================================");
            Console.WriteLine("   Задание 30. Итоговая система автопарка (Fleet Management)     ");
            Console.WriteLine("==================================================================\n");

            FleetManager fleet = new FleetManager();

            // Добавление различных видов техники
            fleet.AddVehicle(new Car(1, "Toyota", "Camry", 2023, 3400000m, 210, 7.8, 524, 5));
            fleet.AddVehicle(new Truck(2, "Volvo", "FH16", 2022, 12500000m, 130, 31.5, 25.0, 3));
            fleet.AddVehicle(new Bus(3, "Mercedes-Benz", "Tourismo", 2021, 9800000m, 125, 26.0, 53, true));
            fleet.AddVehicle(new ElectricCar(4, "Tesla", "Model S Plaid", 2024, 11200000m, 322, 18.5, 100, 600));
            fleet.AddVehicle(new Motorcycle(5, "BMW", "R 1250 GS", 2023, 2100000m, 205, 4.75, 1254, false));

            // Вывод всего автопарка
            fleet.PrintAllVehicles();

            // Поиск самого быстрого транспорта
            var fastest = fleet.FindFastestVehicle();
            Console.WriteLine($"\n[🏁] Самый быстрый транспорт: {fastest?.Brand} {fastest?.Model} со скоростью {fastest?.MaxSpeed} км/ч");

            // Поиск самого дорогого транспорта
            var mostExpensive = fleet.FindMostExpensiveVehicle();
            Console.WriteLine($"[💰] Самый дорогой транспорт: {mostExpensive?.Brand} {mostExpensive?.Model} стоимостью {mostExpensive?.Price:C}");

            // Расчет расхода топлива для маршрута 350 км
            fleet.CalculateTripConsumptionReport(350.0);

            // Удаление транспорта
            Console.WriteLine("\n--- Операция списания транспорта ---");
            fleet.RemoveVehicle(5); // Списание мотоцикла

            fleet.PrintAllVehicles();

            Console.WriteLine("\n==================================================================");
            Console.WriteLine("Работа системы автопарка успешно завершена!");
            Console.WriteLine("==================================================================");
        }
    }
}