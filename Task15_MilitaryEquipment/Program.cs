using System;
using System.Collections.Generic;

namespace Task15_MilitaryEquipment
{
    /// <summary>
    /// Базовый класс Военная техника
    /// </summary>
    public class MilitaryVehicle
    {
        public string Model { get; set; }
        public int ArmorThicknessMm { get; set; }
        public int CrewCount { get; set; }

        public MilitaryVehicle(string model, int armorThicknessMm, int crewCount)
        {
            Model = model;
            ArmorThicknessMm = armorThicknessMm;
            CrewCount = crewCount;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"Военная техника {Model} ведет стандартный огонь.");
        }
    }

    /// <summary>
    /// Танк
    /// </summary>
    public class Tank : MilitaryVehicle
    {
        public int MainCannonCaliberMm { get; set; }

        public Tank(string model, int armorMm, int crew, int cannonCaliber) 
            : base(model, armorMm, crew)
        {
            MainCannonCaliberMm = cannonCaliber;
        }

        public override void Attack()
        {
            Console.WriteLine($"Танк {Model} (экипаж: {CrewCount}) производит выстрел бронебойным снарядом из гладкоствольной пушки {MainCannonCaliberMm} мм! *БА-БАХ!*");
        }
    }

    /// <summary>
    /// Боевой вертолет
    /// </summary>
    public class Helicopter : MilitaryVehicle
    {
        public int MissileCount { get; set; }

        public Helicopter(string model, int armorMm, int crew, int missileCount) 
            : base(model, armorMm, crew)
        {
            MissileCount = missileCount;
        }

        public override void Attack()
        {
            Console.WriteLine($"Ударный вертолет {Model} зависает над полем боя и выпускает залп из {MissileCount} управляемых противотанковых ракет \"Вихрь\"!");
        }
    }

    /// <summary>
    /// Бронеавтомобиль
    /// </summary>
    public class ArmoredCar : MilitaryVehicle
    {
        public double MachineGunCaliber { get; set; }

        public ArmoredCar(string model, int armorMm, int crew, double machineGunCaliber) 
            : base(model, armorMm, crew)
        {
            MachineGunCaliber = machineGunCaliber;
        }

        public override void Attack()
        {
            Console.WriteLine($"Бронеавтомобиль {Model} открывает шквальный огонь из крупнокалиберного пулемета {MachineGunCaliber} мм \"Корд\"!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 15. Военная техника (Attack) ===\n");

            List<MilitaryVehicle> unit = new List<MilitaryVehicle>
            {
                new Tank("Т-90М \"Прорыв\"", 850, 3, 125),
                new Helicopter("Ка-52 \"Аллигатор\"", 300, 2, 12),
                new ArmoredCar("Тигр-М", 150, 4, 12.7)
            };

            Console.WriteLine("--- Приказ: Начать наступление! ---");
            foreach (var vehicle in unit)
            {
                vehicle.Attack();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}