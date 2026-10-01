using System;
using System.Collections.Generic;

namespace Task21_AbstractShapes
{
    /// <summary>
    /// Абстрактный базовый класс Геометрическая фигура
    /// </summary>
    public abstract class Shape
    {
        public string Name { get; }

        protected Shape(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Абстрактный метод вычисления площади (обязателен к реализации в потомках)
        /// </summary>
        public abstract double GetArea();

        /// <summary>
        /// Абстрактный метод вычисления периметра
        /// </summary>
        public abstract double GetPerimeter();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Name,-16} | Площадь: {GetArea(),8:F2} | Периметр: {GetPerimeter(),8:F2}");
        }
    }

    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Круг")
        {
            Radius = radius > 0 ? radius : throw new ArgumentException("Радиус должен быть больше 0");
        }

        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }

    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height) : base("Прямоугольник")
        {
            Width = width > 0 ? width : throw new ArgumentException("Ширина должна быть > 0");
            Height = height > 0 ? height : throw new ArgumentException("Высота должна быть > 0");
        }

        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => 2 * (Width + Height);
    }

    /// <summary>
    /// Треугольник (расчет по трем сторонам через формулу Герона)
    /// </summary>
    public class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double a, double b, double c) : base("Треугольник")
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Некорректные стороны для существования треугольника");

            SideA = a;
            SideB = b;
            SideC = c;
        }

        public override double GetPerimeter() => SideA + SideB + SideC;

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
    }

    /// <summary>
    /// Квадрат
    /// </summary>
    public class Square : Shape
    {
        public double Side { get; set; }

        public Square(double side) : base("Квадрат")
        {
            Side = side > 0 ? side : throw new ArgumentException("Сторона квадрата должна быть > 0");
        }

        public override double GetArea() => Side * Side;
        public override double GetPerimeter() => 4 * Side;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 21. Абстрактные фигуры (Circle, Rectangle, Triangle, Square) ===\n");

            List<Shape> shapes = new List<Shape>
            {
                new Circle(5.0),
                new Rectangle(4.0, 7.0),
                new Triangle(3.0, 4.0, 5.0), // Египетский треугольник со сторонами 3, 4, 5
                new Square(6.0)
            };

            Console.WriteLine("Каталог геометрических фигур:");
            Console.WriteLine(new string('-', 50));
            foreach (var shape in shapes)
            {
                shape.DisplayInfo();
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}