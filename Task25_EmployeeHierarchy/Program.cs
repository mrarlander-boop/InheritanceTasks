using System;

namespace Task25_EmployeeHierarchy
{
    // ========================================================
    // Уровень 1: Person (Человек)
    // Минимум 2 свойства: FirstName, LastName, Age
    // Минимум 1 метод: GetFullName(), DisplayPersonalInfo()
    // ========================================================
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string GetFullName() => $"{LastName} {FirstName}";

        public virtual void DisplayPersonalInfo()
        {
            Console.WriteLine($"[Человек] ФИО: {GetFullName()}, Возраст: {Age} лет");
        }
    }

    // ========================================================
    // Уровень 2: Employee (Сотрудник)
    // Добавлены свойства: EmployeeId, Department, BaseSalary
    // Добавлены методы: Work()
    // ========================================================
    public class Employee : Person
    {
        public string EmployeeId { get; set; }
        public string Department { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee(string firstName, string lastName, int age, 
                        string employeeId, string department, decimal baseSalary)
            : base(firstName, lastName, age)
        {
            EmployeeId = employeeId;
            Department = department;
            BaseSalary = baseSalary;
        }

        public virtual void Work()
        {
            Console.WriteLine($"Сотрудник {GetFullName()} (ID: {EmployeeId}) выполняет профильные задачи в отделе \"{Department}\".");
        }

        public override void DisplayPersonalInfo()
        {
            base.DisplayPersonalInfo();
            Console.WriteLine($" -> Должность: Рядовой специалист | Отдел: {Department} | Табельный №: {EmployeeId} | Оклад: {BaseSalary:C}");
        }
    }

    // ========================================================
    // Уровень 3: Manager (Менеджер проекта / команды)
    // Добавлены свойства: TeamSize, ManagedProject
    // Добавлены методы: ConductMeeting(), AssignTask()
    // ========================================================
    public class Manager : Employee
    {
        public int TeamSize { get; set; }
        public string ManagedProject { get; set; }

        public Manager(string firstName, string lastName, int age, 
                       string employeeId, string department, decimal baseSalary,
                       int teamSize, string managedProject)
            : base(firstName, lastName, age, employeeId, department, baseSalary)
        {
            TeamSize = teamSize;
            ManagedProject = managedProject;
        }

        public void ConductMeeting()
        {
            Console.WriteLine($"Менеджер {GetFullName()} проводит спринт-планирование по проекту \"{ManagedProject}\" для {TeamSize} человек.");
        }

        public override void Work()
        {
            Console.WriteLine($"Менеджер {GetFullName()} координирует проект \"{ManagedProject}\" и отслеживает дедлайны.");
        }

        public override void DisplayPersonalInfo()
        {
            base.DisplayPersonalInfo();
            Console.WriteLine($" -> Уровень: Менеджер | Команда: {TeamSize} чел. | Проект: \"{ManagedProject}\"");
        }
    }

    // ========================================================
    // Уровень 4: Director (Директор компании)
    // Добавлены свойства: CompanyDivision, StrategicBudget
    // Добавлены методы: SignContract(), ApproveBudget()
    // ========================================================
    public class Director : Manager
    {
        public string CompanyDivision { get; set; }
        public decimal StrategicBudget { get; set; }

        public Director(string firstName, string lastName, int age, 
                        string employeeId, string department, decimal baseSalary,
                        int teamSize, string managedProject,
                        string companyDivision, decimal strategicBudget)
            : base(firstName, lastName, age, employeeId, department, baseSalary, teamSize, managedProject)
        {
            CompanyDivision = companyDivision;
            StrategicBudget = strategicBudget;
        }

        public void SignContract(string partnerCompany, decimal contractValue)
        {
            Console.WriteLine($"Генеральный директор {GetFullName()} подписал стратегический контракт с компанией \"{partnerCompany}\" на сумму {contractValue:C}!");
        }

        public void ApproveBudget()
        {
            Console.WriteLine($"Директор филиала \"{CompanyDivision}\" {GetFullName()} утвердил годовой бюджет подразделения: {StrategicBudget:C}.");
        }

        public override void Work()
        {
            Console.WriteLine($"Директор {GetFullName()} управляет развитием дивизиона \"{CompanyDivision}\" и участвует в совете директоров.");
        }

        public override void DisplayPersonalInfo()
        {
            base.DisplayPersonalInfo();
            Console.WriteLine($" -> Топ-менеджмент: Генеральный директор | Дивизион: {CompanyDivision} | Годовой фонд: {StrategicBudget:C}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 25. Иерархия: Person -> Employee -> Manager -> Director ===\n");

            Director director = new Director(
                firstName: "Владислав",
                lastName: "Белов",
                age: 48,
                employeeId: "DIR-001",
                department: "Высшее руководство",
                baseSalary: 450000m,
                teamSize: 120,
                managedProject: "Цифровая трансформация холдинга",
                companyDivision: "Восточно-Европейский сектор",
                strategicBudget: 85000000m
            );

            Console.WriteLine("--- Полные данные директора (наследование 4 уровней) ---");
            director.DisplayPersonalInfo();

            Console.WriteLine("\n--- Демонстрация методов всех уровней иерархии ---");
            director.Work();
            director.ConductMeeting();
            director.ApproveBudget();
            director.SignContract("ООО \"Глобал Текнолоджис\"", 25000000m);

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}