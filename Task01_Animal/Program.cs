using System;
using System.Collections.Generic;

namespace Task01_Animal
{
    /// <summary>
    /// Базовый класс Животное
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Виртуальный метод подачи голоса (может быть переопределен в дочерних классах)
        /// </summary>
        public virtual void Speak()
        {
            Console.WriteLine($"{Name} издает неопределенный звук.");
        }
    }

    /// <summary>
    /// Класс Собака, наследуется от Animal
    /// </summary>
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        /// <summary>
        /// Переопределение метода Speak для собаки
        /// </summary>
        public override void Speak()
        {
            Console.WriteLine($"{Name} (Собака): Гав-гав!");
        }
    }

    /// <summary>
    /// Класс Кот, наследуется от Animal
    /// </summary>
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        /// <summary>
        /// Переопределение метода Speak для кота
        /// </summary>
        public override void Speak()
        {
            Console.WriteLine($"{Name} (Кот): Мяу-мяу!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 1. Животное (Наследование и переопределение Speak) ===\n");

            // Создание экземпляров базового и производных классов
            Animal genericAnimal = new Animal("Неизвестное существо");
            Dog dog = new Dog("Барбос");
            Cat cat = new Cat("Мурка");

            // Прямой вызов методов
            Console.WriteLine("--- Прямой вызов методов ---");
            genericAnimal.Speak();
            dog.Speak();
            cat.Speak();

            // Демонстрация полиморфизма через коллекцию базового типа
            Console.WriteLine("\n--- Полиморфный вызов через List<Animal> ---");
            List<Animal> animals = new List<Animal> { genericAnimal, dog, cat };

            foreach (var animal in animals)
            {
                animal.Speak();
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}