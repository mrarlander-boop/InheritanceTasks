using System;
using System.Collections.Generic;

namespace Task16_GameCharacters
{
    /// <summary>
    /// Базовый класс Игровой персонаж
    /// </summary>
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public bool IsAlive => Health > 0;

        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name} атакует {target.Name} и наносит {Damage} урона.");
            target.TakeDamage(Damage);
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            Health = Math.Max(0, Health - incomingDamage);
            Console.WriteLine($" -> У {Name} осталось {Health} HP.");
        }
    }

    /// <summary>
    /// Воин: рубящий удар мечом и щитовая броня
    /// </summary>
    public class Warrior : Character
    {
        public int Armor { get; set; }

        public Warrior(string name, int health, int damage, int armor) 
            : base(name, health, damage)
        {
            Armor = armor;
        }

        public override void Attack(Character target)
        {
            int totalDmg = Damage + 10;
            Console.WriteLine($"[Воин] {Name} с яростным боевым кличем наносит сокрушительный удар секирой по {target.Name} ({totalDmg} урона)!");
            target.TakeDamage(totalDmg);
        }

        public override void TakeDamage(int incomingDamage)
        {
            int reducedDmg = Math.Max(1, incomingDamage - Armor);
            Console.WriteLine($"[Воин] Броня {Name} поглощает {Armor} ед. урона!");
            base.TakeDamage(reducedDmg);
        }
    }

    /// <summary>
    /// Маг: атакует огненными заклинаниями, используя ману
    /// </summary>
    public class Mage : Character
    {
        public int Mana { get; set; }

        public Mage(string name, int health, int damage, int mana) 
            : base(name, health, damage)
        {
            Mana = mana;
        }

        public override void Attack(Character target)
        {
            if (Mana >= 25)
            {
                Mana -= 25;
                int magicDmg = Damage * 2;
                Console.WriteLine($"[Маг] {Name} произносит заклинание и обрушивает \"Огненный шар\" на {target.Name} ({magicDmg} магического урона)! Остаток маны: {Mana}.");
                target.TakeDamage(magicDmg);
            }
            else
            {
                Console.WriteLine($"[Маг] {Name} истощил ману и бьет {target.Name} деревянным посохом ({Damage} урона).");
                target.TakeDamage(Damage);
            }
        }
    }

    /// <summary>
    /// Лучник: прицельный выстрел с возможностью критического урона
    /// </summary>
    public class Archer : Character
    {
        public double CriticalChance { get; set; }
        private static readonly Random Rnd = new Random();

        public Archer(string name, int health, int damage, double criticalChance) 
            : base(name, health, damage)
        {
            CriticalChance = criticalChance;
        }

        public override void Attack(Character target)
        {
            bool isCrit = Rnd.NextDouble() < CriticalChance;
            int finalDmg = isCrit ? (int)(Damage * 2.2) : Damage;
            string critMsg = isCrit ? " [КРИТИЧЕСКИЙ ВЫСТРЕЛ В ГОЛОВУ!]" : "";

            Console.WriteLine($"[Лучник] {Name} пускает стрелу из длинного лука в {target.Name}{critMsg} ({finalDmg} урона)!");
            target.TakeDamage(finalDmg);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 16. Игровые персонажи (Warrior, Mage, Archer) ===\n");

            Warrior warrior = new Warrior("Конан", 120, 25, 8);
            Mage mage = new Mage("Гэндальф", 80, 20, 60);
            Archer archer = new Archer("Леголас", 90, 22, 0.40);

            Character dummyTarget = new Character("Тренировочный манекен (Голем)", 200, 0);

            List<Character> heroes = new List<Character> { warrior, mage, archer };

            foreach (var hero in heroes)
            {
                hero.Attack(dummyTarget);
                Console.WriteLine();
            }

            Console.WriteLine("--- Дуэль: Воин атакует Мага ---");
            warrior.Attack(mage);
            Console.WriteLine("\n--- Ответный удар: Маг атакует Воина ---");
            mage.Attack(warrior);

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}