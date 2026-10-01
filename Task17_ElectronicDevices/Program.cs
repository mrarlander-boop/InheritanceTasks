using System;
using System.Collections.Generic;

namespace Task17_ElectronicDevices
{
    /// <summary>
    /// Базовый класс Электронное устройство
    /// </summary>
    public class Device
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsOn { get; protected set; }

        public Device(string brand, string model)
        {
            Brand = brand;
            Model = model;
            IsOn = false;
        }

        public virtual void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"[{Brand} {Model}] Устройство включено.");
        }

        public virtual void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"[{Brand} {Model}] Устройство выключено.");
        }
    }

    /// <summary>
    /// Смартфон
    /// </summary>
    public class Phone : Device
    {
        public int BatteryLevel { get; set; }

        public Phone(string brand, string model, int batteryLevel) 
            : base(brand, model)
        {
            BatteryLevel = batteryLevel;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($" -> Экран смартфона засветился. Заряд батареи: {BatteryLevel}%.");
        }

        public void MakeCall(string number)
        {
            if (!IsOn)
            {
                Console.WriteLine($"Невозможно позвонить: телефон {Brand} выключен!");
                return;
            }
            Console.WriteLine($"Набор номера {number} с телефона {Brand} {Model}...");
        }
    }

    /// <summary>
    /// Компьютер
    /// </summary>
    public class Computer : Device
    {
        public string OperatingSystem { get; set; }

        public Computer(string brand, string model, string os) 
            : base(brand, model)
        {
            OperatingSystem = os;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($" -> Загрузка операционной системы {OperatingSystem}...");
        }

        public void LaunchProgram(string programName)
        {
            if (!IsOn)
            {
                Console.WriteLine($"Компьютер выключен. Запуск {programName} невозможен.");
                return;
            }
            Console.WriteLine($"Запущена программа: {programName}.");
        }
    }

    /// <summary>
    /// Телевизор
    /// </summary>
    public class Television : Device
    {
        public int CurrentChannel { get; set; }

        public Television(string brand, string model) 
            : base(brand, model)
        {
            CurrentChannel = 1;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($" -> Включен ТВ-канал №{CurrentChannel}. Приятного просмотра!");
        }

        public void ChangeChannel(int newChannel)
        {
            if (!IsOn)
            {
                Console.WriteLine("Сначала включите телевизор!");
                return;
            }
            CurrentChannel = newChannel;
            Console.WriteLine($"Канал переключен на №{CurrentChannel}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 17. Электронные устройства (TurnOn / TurnOff) ===\n");

            Phone phone = new Phone("Apple", "iPhone 15 Pro", 87);
            Computer pc = new Computer("ASUS", "ROG Strix", "Windows 11 Pro");
            Television tv = new Television("Samsung", "QLED 65-inch");

            List<Device> devices = new List<Device> { phone, pc, tv };

            Console.WriteLine("--- Включение всех устройств ---");
            foreach (var d in devices)
            {
                d.TurnOn();
                Console.WriteLine();
            }

            Console.WriteLine("--- Использование устройств по назначению ---");
            phone.MakeCall("+7 (999) 123-45-67");
            pc.LaunchProgram("Visual Studio 2022");
            tv.ChangeChannel(5);

            Console.WriteLine("\n--- Выключение всех устройств ---");
            foreach (var d in devices)
            {
                d.TurnOff();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}