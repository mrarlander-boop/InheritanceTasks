using System;
using System.Collections.Generic;

namespace Task05_Shapes
{
    /// <summary>
    /// Базовый класс Фигура
    /// </summary>
    public class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Виртуальный метод вычисления площади
        /// </summary>
        public virtual double GetArea()
        {
            return 0.0;
        }
    }

    /// <summary>
    /// Прямоугольник, наследуется от Shape
    /// </summary>
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height) : base("Прямоугольник")
        {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }

    /// <summary>
    /// Круг, наследуется от Shape
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Круг")
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 5. Фигуры (Расчет площади GetArea) ===\n");

            Shape genericShape = new Shape("Точка");
            Rectangle rect = new Rectangle(5.0, 8.0);
            Circle circle = new Circle(4.0);

            List<Shape> shapes = new List<Shape> { genericShape, rect, circle };

            foreach (var s in shapes)
            {
                Console.WriteLine($"Фигура: {s.Name,-15} | Площадь: {s.GetArea():F2}");
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}