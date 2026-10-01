using System;
using System.Collections.Generic;

namespace Task10_Pets
{
    /// <summary>
    /// Базовый класс Домашнее животное
    /// </summary>
    public class Pet
    {
        public string Name { get; set; }

        public Pet(string name)
        {
            Name = name;
        }

        public virtual void Eat()
        {
            Console.WriteLine($"{Name} принимает пищу.");
        }
    }

    /// <summary>
    /// Собака
    /// </summary>
    public class Dog : Pet
    {
        public Dog(string name) : base(name) { }

        public override void Eat()
        {
            Console.WriteLine($"Собака {Name} с аппетитом грызёт мясную косточку и сухой корм.");
        }
    }

    /// <summary>
    /// Кошка
    /// </summary>
    public class Cat : Pet
    {
        public Cat(string name) : base(name) { }

        public override void Eat()
        {
            Console.WriteLine($"Кошка {Name} аккуратно лакомится лососем и тихонько мурлычет.");
        }
    }

    /// <summary>
    /// Попугай
    /// </summary>
    public class Parrot : Pet
    {
        public Parrot(string name) : base(name) { }

        public override void Eat()
        {
            Console.WriteLine($"Попугай {Name} весело щёлкает просо, семечки подсолнечника и клюёт фрукты.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 10. Домашние животные (Eat) ===\n");

            List<Pet> myPets = new List<Pet>
            {
                new Dog("Рекс"),
                new Cat("Барсик"),
                new Parrot("Кеша")
            };

            Console.WriteLine("Время кормления питомцев:");
            foreach (var pet in myPets)
            {
                pet.Eat();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}