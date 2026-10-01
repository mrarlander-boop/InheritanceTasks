using System;

namespace Task09_Books
{
    /// <summary>
    /// Базовый класс Книга
    /// </summary>
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"\"{Title}\" — {Author}");
        }
    }

    /// <summary>
    /// Бумажная книга
    /// Уникальные свойства: количество страниц и тип обложки
    /// </summary>
    public class PaperBook : Book
    {
        public int PageCount { get; set; }
        public string CoverType { get; set; }

        public PaperBook(string title, string author, int pageCount, string coverType)
            : base(title, author)
        {
            PageCount = pageCount;
            CoverType = coverType;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  [Бумажное издание] Страниц: {PageCount}, Переплет: {CoverType}");
        }
    }

    /// <summary>
    /// Электронная книга
    /// Уникальные свойства: размер файла и формат
    /// </summary>
    public class EBook : Book
    {
        public double FileSizeMb { get; set; }
        public string Format { get; set; }

        public EBook(string title, string author, double fileSizeMb, string format)
            : base(title, author)
        {
            FileSizeMb = fileSizeMb;
            Format = format;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  [Электронная книга] Размер: {FileSizeMb:F1} МБ, Формат: {Format}");
        }

        public void Download()
        {
            Console.WriteLine($"Скачивание электронной книги \"{Title}\" в формате {Format} завершено.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 9. Книги (PaperBook и EBook) ===\n");

            PaperBook paperBook = new PaperBook("Преступление и наказание", "Ф. М. Достоевский", 672, "Твердый переплет");
            EBook eBook = new EBook("Чистый код", "Роберт Мартин", 14.8, "EPUB");

            paperBook.DisplayInfo();
            Console.WriteLine();
            eBook.DisplayInfo();
            eBook.Download();

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}