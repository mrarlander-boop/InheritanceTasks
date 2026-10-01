using System;

namespace Task08_Computers
{
    /// <summary>
    /// Базовый класс Компьютер
    /// </summary>
    public class Computer
    {
        public string Processor { get; set; }
        public int RamGb { get; set; }

        public Computer(string processor, int ramGb)
        {
            Processor = processor;
            RamGb = ramGb;
        }

        public virtual void DisplaySpecs()
        {
            Console.WriteLine($"Процессор: {Processor} | Оперативная память: {RamGb} ГБ");
        }
    }

    /// <summary>
    /// Ноутбук, наследуется от Computer
    /// Уникальные свойства: емкость батареи и вес
    /// </summary>
    public class Laptop : Computer
    {
        public int BatteryCapacityMah { get; set; }
        public double WeightKg { get; set; }

        public Laptop(string processor, int ramGb, int batteryCapacityMah, double weightKg)
            : base(processor, ramGb)
        {
            BatteryCapacityMah = batteryCapacityMah;
            WeightKg = weightKg;
        }

        public override void DisplaySpecs()
        {
            Console.WriteLine("[Ноутбук]");
            base.DisplaySpecs();
            Console.WriteLine($"Аккумулятор: {BatteryCapacityMah} мА·ч | Вес: {WeightKg} кг");
        }
    }

    /// <summary>
    /// Настольный ПК, наследуется от Computer
    /// Уникальные свойства: форм-фактор корпуса и мощность блока питания
    /// </summary>
    public class Desktop : Computer
    {
        public string CaseFormFactor { get; set; }
        public int PowerSupplyWattage { get; set; }

        public Desktop(string processor, int ramGb, string caseFormFactor, int powerSupplyWattage)
            : base(processor, ramGb)
        {
            CaseFormFactor = caseFormFactor;
            PowerSupplyWattage = powerSupplyWattage;
        }

        public override void DisplaySpecs()
        {
            Console.WriteLine("[Настольный компьютер (Desktop)]");
            base.DisplaySpecs();
            Console.WriteLine($"Корпус: {CaseFormFactor} | Блок питания: {PowerSupplyWattage} Вт");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 8. Компьютеры (Laptop и Desktop) ===\n");

            Laptop laptop = new Laptop("Intel Core i7-13700H", 16, 5400, 1.45);
            Desktop desktop = new Desktop("AMD Ryzen 7 7800X3D", 32, "Midi-Tower ATX", 850);

            laptop.DisplaySpecs();
            Console.WriteLine();
            desktop.DisplaySpecs();

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}