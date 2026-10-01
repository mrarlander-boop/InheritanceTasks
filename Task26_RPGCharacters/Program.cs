using System;
using System.Collections.Generic;

namespace Task26_RPGCharacters
{
    /// <summary>
    /// Абстрактный базовый класс Игровой персонаж
    /// </summary>
    public abstract class Character
    {
        public string Name { get; }
        public int Health { get; protected set; }
        public int MaxHealth { get; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        protected Character(string name, int maxHealth, int attackPower, int defense)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
            Defense = defense;
        }

        public bool IsAlive => Health > 0;

        /// <summary>
        /// Базовая атака персонажа
        /// </summary>
        public abstract void Attack(Character target);

        /// <summary>
        /// Защита / блокирование входящего урона
        /// </summary>
        public abstract void Defend(int incomingDamage);

        /// <summary>
        /// Особая суперспособность / ультимейт
        /// </summary>
        public abstract void SpecialAttack(Character target);

        public virtual void DisplayStats()
        {
            Console.WriteLine($"{Name,-12} | HP: {Health,3}/{MaxHealth,3} | Сила: {AttackPower,2} | Защита: {Defense,2}");
        }
    }

    /// <summary>
    /// Воин
    /// </summary>
    public class Warrior : Character
    {
        public int ShieldBlockBonus { get; set; } = 15;

        public Warrior(string name) : base(name, 150, 25, 12) { }

        public override void Attack(Character target)
        {
            Console.WriteLine($"[Воин] {Name} совершает рубящий удар мечом по {target.Name} на {AttackPower} урона.");
            target.Defend(AttackPower);
        }

        public override void Defend(int incomingDamage)
        {
            int blockedDmg = Math.Max(0, incomingDamage - Defense - ShieldBlockBonus);
            Health = Math.Max(0, Health - blockedDmg);
            Console.WriteLine($"[Воин] {Name} поднимает стальной щит! Заблокировано {Defense + ShieldBlockBonus} урона. Получено: {blockedDmg}. HP: {Health}/{MaxHealth}.");
        }

        public override void SpecialAttack(Character target)
        {
            int specialDmg = AttackPower * 2 + 10;
            Console.WriteLine($"[Воин] {Name} использует ультимейт: \"Вихрь клинков\" по {target.Name}! Наносится {specialDmg} сокрушительного урона!");
            target.Defend(specialDmg);
        }
    }

    /// <summary>
    /// Маг
    /// </summary>
    public class Mage : Character
    {
        public int Mana { get; set; } = 100;

        public Mage(string name) : base(name, 80, 35, 4) { }

        public override void Attack(Character target)
        {
            Console.WriteLine($"[Маг] {Name} метает заряд \"Ледяная стрела\" в {target.Name} на {AttackPower} урона.");
            target.Defend(AttackPower);
        }

        public override void Defend(int incomingDamage)
        {
            // Магический щит за счет маны
            int absorbed = 0;
            if (Mana >= 20)
            {
                absorbed = 15;
                Mana -= 20;
            }
            int taken = Math.Max(0, incomingDamage - Defense - absorbed);
            Health = Math.Max(0, Health - taken);
            Console.WriteLine($"[Маг] {Name} поглощает урон барьером (поглощено {Defense + absorbed}). Получено: {taken}. HP: {Health}/{MaxHealth} (Мана: {Mana}).");
        }

        public override void SpecialAttack(Character target)
        {
            if (Mana >= 40)
            {
                Mana -= 40;
                int magicNuke = AttackPower * 3;
                Console.WriteLine($"[Маг] {Name} читает высшее заклинание: \"Метеоритный дождь\" на {target.Name}! Урон: {magicNuke}!");
                target.Defend(magicNuke);
            }
            else
            {
                Console.WriteLine($"[Маг] Недостаточно маны для особого удара!");
                Attack(target);
            }
        }
    }

    /// <summary>
    /// Лучник
    /// </summary>
    public class Archer : Character
    {
        public Archer(string name) : base(name, 100, 30, 6) { }

        public override void Attack(Character target)
        {
            Console.WriteLine($"[Лучник] {Name} делает прицельный выстрел из длинного лука в {target.Name} на {AttackPower} урона.");
            target.Defend(AttackPower);
        }

        public override void Defend(int incomingDamage)
        {
            // Шанс уклонения
            Console.WriteLine($"[Лучник] {Name} ловко уворачивается от удара кувырком!");
            int reducedDmg = Math.Max(0, (incomingDamage / 2) - Defense);
            Health = Math.Max(0, Health - reducedDmg);
            Console.WriteLine($"Получено лишь частичное касание ({reducedDmg} урона). HP: {Health}/{MaxHealth}.");
        }

        public override void SpecialAttack(Character target)
        {
            int barrageDmg = (int)(AttackPower * 2.4);
            Console.WriteLine($"[Лучник] {Name} выпускает \"Град отравленных стрел\" в {target.Name}! Урон: {barrageDmg}!");
            target.Defend(barrageDmg);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 26. Игра: персонажи (Attack, Defend, SpecialAttack) ===\n");

            Warrior warrior = new Warrior("Торвальд");
            Mage mage = new Mage("Мерлин");
            Archer archer = new Archer("Робин");

            Console.WriteLine("Начальные характеристики персонажей:");
            warrior.DisplayStats();
            mage.DisplayStats();
            archer.DisplayStats();

            Console.WriteLine("\n--- Раунд 1: Воин атакует Мага ---");
            warrior.Attack(mage);

            Console.WriteLine("\n--- Раунд 2: Маг использует Спецатаку на Воина ---");
            mage.SpecialAttack(warrior);

            Console.WriteLine("\n--- Раунд 3: Лучник использует Спецатаку на Мага ---");
            archer.SpecialAttack(mage);

            Console.WriteLine("\nИтог сражения:");
            warrior.DisplayStats();
            mage.DisplayStats();
            archer.DisplayStats();

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}