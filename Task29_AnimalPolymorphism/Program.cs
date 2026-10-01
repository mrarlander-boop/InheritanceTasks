using System;
using System.Collections.Generic;

namespace Task29_AnimalPolymorphism
{
    /// <summary>
    /// Базовый класс Животное
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }

        public Animal(string name, string species)
        {
            Name = name;
            Species = species;
        }

        /// <summary>
        /// Виртуальный метод подачи голоса
        /// </summary>
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Species} {Name} издаёт звук.");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name, "Собака") { }
        public override void MakeSound() => Console.WriteLine($"[{Species} {Name}]: Гав-гав! *радостно машет хвостом*");
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name, "Кошка") { }
        public override void MakeSound() => Console.WriteLine($"[{Species} {Name}]: Мур-р-р... Мяу!");
    }

    public class Cow : Animal
    {
        public Cow(string name) : base(name, "Корова") { }
        public override void MakeSound() => Console.WriteLine($"[{Species} {Name}]: Му-у-у-у-у!");
    }

    public class Sheep : Animal
    {
        public Sheep(string name) : base(name, "Овца") { }
        public override void MakeSound() => Console.WriteLine($"[{Species} {Name}]: Бе-е-е-е-е!");
    }

    public class Horse : Animal
    {
        public Horse(string name) : base(name, "Лошадь") { }
        public override void MakeSound() => Console.WriteLine($"[{Species} {Name}]: И-го-го-го! *бьет копытом*");
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 29. Полиморфизм + наследование (List<Animal> и один цикл) ===\n");

            // Коллекция базового типа List<Animal> содержащая 5 различных потомков
            List<Animal> farmAnimals = new List<Animal>
            {
                new Dog("Шарик"),
                new Cat("Матроскин"),
                new Cow("Бурёнка"),
                new Sheep("Долли"),
                new Horse("Буцефал")
            };

            Console.WriteLine($"В загоне фермы находится {farmAnimals.Count} животных. Слушаем их голоса:\n");

            // ЕДИНЫЙ ЦИКЛ, вызывающий полиморфный метод MakeSound()
            foreach (Animal animal in farmAnimals)
            {
                animal.MakeSound();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}