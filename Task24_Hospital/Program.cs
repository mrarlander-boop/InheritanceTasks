using System;
using System.Collections.Generic;

namespace Task24_Hospital
{
    /// <summary>
    /// Базовый класс Медицинский работник
    /// </summary>
    public class MedicalWorker
    {
        public string Name { get; set; }
        public int ExperienceYears { get; set; }
        public string Position { get; protected set; }

        public MedicalWorker(string name, int experienceYears, string position)
        {
            Name = name;
            ExperienceYears = experienceYears;
            Position = position;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Position} {Name} (стаж: {ExperienceYears} лет) выполняет служебные обязанности в клинике.");
        }
    }

    /// <summary>
    /// Врач-терапевт
    /// </summary>
    public class Doctor : MedicalWorker
    {
        public string Specialization { get; set; }

        public Doctor(string name, int experienceYears, string specialization) 
            : base(name, experienceYears, "Врач")
        {
            Specialization = specialization;
        }

        public override void Work()
        {
            Console.WriteLine($"[Врач] {Name} ({Specialization}) ведёт амбулаторный приём, проводит осмотр и ставит диагнозы.");
        }

        public void PrescribeMedicine(string patientName, string medicine)
        {
            Console.WriteLine($" -> Врач {Name} выписал рецепт пациенту {patientName} на препарат \"{medicine}\".");
        }
    }

    /// <summary>
    /// Медицинская сестра / медбрат
    /// </summary>
    public class Nurse : MedicalWorker
    {
        public int WardNumber { get; set; }

        public Nurse(string name, int experienceYears, int wardNumber) 
            : base(name, experienceYears, "Медсестра")
        {
            WardNumber = wardNumber;
        }

        public override void Work()
        {
            Console.WriteLine($"[Медсестра] {Name} дежурит в отделении (палата №{WardNumber}), ставит капельницы и выдает лекарства.");
        }

        public void TakeBloodPressure(string patientName)
        {
            Console.WriteLine($" -> Медсестра {Name} измерила артериальное давление пациенту {patientName}: 120/80 мм рт. ст.");
        }
    }

    /// <summary>
    /// Хирург
    /// </summary>
    public class Surgeon : MedicalWorker
    {
        public int CompletedSurgeriesCount { get; set; }

        public Surgeon(string name, int experienceYears, int completedSurgeries) 
            : base(name, experienceYears, "Хирург")
        {
            CompletedSurgeriesCount = completedSurgeries;
        }

        public override void Work()
        {
            Console.WriteLine($"[Хирург] {Name} проводит плановые и экстренные высокотехнологичные операции (выполнено: {CompletedSurgeriesCount} операций).");
        }

        public void PerformOperation(string operationType)
        {
            CompletedSurgeriesCount++;
            Console.WriteLine($" -> Хирург {Name} успешно провел операцию: {operationType}! Общее число операций: {CompletedSurgeriesCount}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 24. Больница (MedicalWorker: Doctor, Nurse, Surgeon) ===\n");

            Doctor doctor = new Doctor("Екатерина Смирнова", 12, "Кардиолог");
            Nurse nurse = new Nurse("Анна Курочкина", 5, 4);
            Surgeon surgeon = new Surgeon("Григорий Потапов", 20, 480);

            List<MedicalWorker> shiftWorkers = new List<MedicalWorker> { doctor, nurse, surgeon };

            Console.WriteLine("--- Утренняя смена медицинского персонала ---");
            foreach (var worker in shiftWorkers)
            {
                worker.Work();
            }

            Console.WriteLine("\n--- Индивидуальные медицинские манипуляции ---");
            doctor.PrescribeMedicine("Иванов А. В.", "Кардиомагнил");
            nurse.TakeBloodPressure("Иванов А. В.");
            surgeon.PerformOperation("Аортокоронарное шунтирование");

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}