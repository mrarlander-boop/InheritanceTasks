using System;

namespace Task03_PersonStudent
{
    /// <summary>
    /// Базовый класс Человек
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age} лет");
        }
    }

    /// <summary>
    /// Класс Студент, наследуется от Person
    /// Добавлены специальность (Specialty) и курс (Course)
    /// </summary>
    public class Student : Person
    {
        public string Specialty { get; set; }
        public int Course { get; set; }

        public Student(string name, int age, string specialty, int course) 
            : base(name, age)
        {
            Specialty = specialty;
            Course = course;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Специальность: {Specialty}, Курс: {Course}");
        }

        public void Study()
        {
            Console.WriteLine($"{Name} изучает профильные предметы по специальности \"{Specialty}\".");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 3. Человек и студент ===\n");

            Person person = new Person("Алексей Смирнов", 45);
            Student student = new Student("Иван Петров", 19, "Информационные системы и программирование", 2);

            Console.WriteLine("--- Информация о человеке ---");
            person.DisplayInfo();

            Console.WriteLine("\n--- Информация о студенте ---");
            student.DisplayInfo();
            student.Study();

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}