using System;
using System.Collections.Generic;

namespace Task20_ZooAnimals
{
    /// <summary>
    /// Базовый класс Животное зоопарка
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        public Animal(string name, string species, int age)
        {
            Name = name;
            Species = species;
            Age = age;
        }

        public virtual void Eat()
        {
            Console.WriteLine($"{Species} {Name} принимает пищу.");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{Species} {Name} издает природный звук.");
        }
    }

    /// <summary>
    /// Лев
    /// </summary>
    public class Lion : Animal
    {
        public Lion(string name, int age) : base(name, "Лев", age) { }

        public override void Eat()
        {
            Console.WriteLine($"[Лев] {Name} поедает свежую порцию сочного мяса (говядину).");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"[Лев] {Name} издает мощный устрашающий рык: Р-р-р-а-а-у-у-г-х!");
        }
    }

    /// <summary>
    /// Слон
    /// </summary>
    public class Elephant : Animal
    {
        public Elephant(string name, int age) : base(name, "Слон", age) { }

        public override void Eat()
        {
            Console.WriteLine($"[Слон] {Name} ловко захватывает хоботом сено, ветки акации и бананы.");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"[Слон] {Name} трубит хоботом: Па-у-у-у-у-т!");
        }
    }

    /// <summary>
    /// Обезьяна
    /// </summary>
    public class Monkey : Animal
    {
        public Monkey(string name, int age) : base(name, "Обезьяна", age) { }

        public override void Eat()
        {
            Console.WriteLine($"[Обезьяна] {Name} с удовольствием очищает и ест сладкие бананы и орехи.");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"[Обезьяна] {Name} прыгает по веткам с криком: У-у-у, а-а-а!");
        }
    }

    /// <summary>
    /// Пингвин
    /// </summary>
    public class Penguin : Animal
    {
        public Penguin(string name, int age) : base(name, "Пингвин", age) { }

        public override void Eat()
        {
            Console.WriteLine($"[Пингвин] {Name} ныряет в бассейн и проглатывает мелкую рыбешку (мойву).");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"[Пингвин] {Name} забавно гогочет и хлопает ластами: Кряк-кряк-виии!");
        }
    }

    /// <summary>
    /// Волк
    /// </summary>
    public class Wolf : Animal
    {
        public Wolf(string name, int age) : base(name, "Волк", age) { }

        public override void Eat()
        {
            Console.WriteLine($"[Волк] {Name} быстро расправляется со своей мясной порцией.");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"[Волк] {Name} поднимает морду к небу и протяжно воет: У-у-у-у-у-у!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 20. Животные зоопарка (5 видов: Eat и MakeSound) ===\n");

            List<Animal> zoo = new List<Animal>
            {
                new Lion("Симба", 5),
                new Elephant("Джамбо", 12),
                new Monkey("Читта", 3),
                new Penguin("Шкипер", 4),
                new Wolf("Акела", 6)
            };

            Console.WriteLine("--- Время кормления в зоопарке ---");
            foreach (var animal in zoo)
            {
                animal.Eat();
            }

            Console.WriteLine("\n--- Звуки зоопарка ---");
            foreach (var animal in zoo)
            {
                animal.MakeSound();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}