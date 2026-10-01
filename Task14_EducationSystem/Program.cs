using System;

namespace Task14_EducationSystem
{
    /// <summary>
    /// Уровень 1: Человек
    /// </summary>
    public class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[Человек]");
            Console.WriteLine($"ФИО: {FullName}");
            Console.WriteLine($"Возраст: {Age} лет");
        }
    }

    /// <summary>
    /// Уровень 2: Студент (наследуется от Person)
    /// Добавлены университет, специальность, курс и средний балл
    /// </summary>
    public class Student : Person
    {
        public string University { get; set; }
        public string Major { get; set; }
        public int CourseYear { get; set; }
        public double Gpa { get; set; }

        public Student(string fullName, int age, string university, string major, int courseYear, double gpa)
            : base(fullName, age)
        {
            University = university;
            Major = major;
            CourseYear = courseYear;
            Gpa = gpa;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"[Студент]");
            Console.WriteLine($"ВУЗ: {University} | Специальность: {Major}");
            Console.WriteLine($"Курс: {CourseYear} | Средний балл (GPA): {Gpa:F2}");
        }
    }

    /// <summary>
    /// Уровень 3: Аспирант (наследуется от Student)
    /// Добавлены тема кандидатской диссертации, научный руководитель и число публикаций
    /// </summary>
    public class GraduateStudent : Student
    {
        public string DissertationTopic { get; set; }
        public string AcademicAdvisor { get; set; }
        public int PublicationsCount { get; set; }

        public GraduateStudent(string fullName, int age, string university, string major, 
                               int courseYear, double gpa, string dissertationTopic, 
                               string academicAdvisor, int publicationsCount)
            : base(fullName, age, university, major, courseYear, gpa)
        {
            DissertationTopic = dissertationTopic;
            AcademicAdvisor = academicAdvisor;
            PublicationsCount = publicationsCount;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"[Аспирант]");
            Console.WriteLine($"Тема диссертации: \"{DissertationTopic}\"");
            Console.WriteLine($"Научный руководитель: {AcademicAdvisor}");
            Console.WriteLine($"Количество научных публикаций: {PublicationsCount}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 14. Система образования (Person -> Student -> GraduateStudent) ===\n");

            GraduateStudent gradStudent = new GraduateStudent(
                fullName: "Николаев Роман Сергеевич",
                age: 25,
                university: "Московский политехнический университет",
                major: "Прикладная информатика и искусственный интеллект",
                courseYear: 2,
                gpa: 4.95,
                dissertationTopic: "Архитектуры нейросетевых агентов в распределенных системах",
                academicAdvisor: "д.т.н., профессор Соколов В. П.",
                publicationsCount: 7
            );

            Console.WriteLine("--- Полное досье обучающегося ---");
            gradStudent.DisplayInfo();

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}