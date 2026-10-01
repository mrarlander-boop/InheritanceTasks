using System;
using System.Collections.Generic;

namespace Task27_FileSystem
{
    /// <summary>
    /// Базовый класс Файл
    /// </summary>
    public class File
    {
        public string FileName { get; set; }
        public long SizeKb { get; set; }

        public File(string fileName, long sizeKb)
        {
            FileName = fileName;
            SizeKb = sizeKb;
        }

        public virtual void Open()
        {
            Console.WriteLine($"Открытие неизвестного бинарного файла: {FileName} ({SizeKb} КБ)");
        }
    }

    /// <summary>
    /// Текстовый файл
    /// </summary>
    public class TextFile : File
    {
        public string EncodingName { get; set; }
        public int LineCount { get; set; }

        public TextFile(string fileName, long sizeKb, string encodingName, int lineCount)
            : base(fileName, sizeKb)
        {
            EncodingName = encodingName;
            LineCount = lineCount;
        }

        public override void Open()
        {
            Console.WriteLine($"[Блокнот] Открыт текстовый файл \"{FileName}\".");
            Console.WriteLine($" -> Кодировка: {EncodingName} | Строк: {LineCount} | Размер: {SizeKb} КБ");
            Console.WriteLine(" -> Содержимое: [Текст успешно загружен и отображён пользователю]");
        }
    }

    /// <summary>
    /// Графический файл (изображение)
    /// </summary>
    public class ImageFile : File
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string ColorSpace { get; set; }

        public ImageFile(string fileName, long sizeKb, int width, int height, string colorSpace)
            : base(fileName, sizeKb)
        {
            Width = width;
            Height = height;
            ColorSpace = colorSpace;
        }

        public override void Open()
        {
            Console.WriteLine($"[Просмотр фотографий] Открыто изображение \"{FileName}\".");
            Console.WriteLine($" -> Разрешение: {Width}x{Height} px | Цветовое пространство: {ColorSpace} | Размер: {SizeKb} КБ");
            Console.WriteLine(" -> Рендеринг пикселей на экране завершен.");
        }
    }

    /// <summary>
    /// Видеофайл
    /// </summary>
    public class VideoFile : File
    {
        public TimeSpan Duration { get; set; }
        public string Codec { get; set; }

        public VideoFile(string fileName, long sizeKb, TimeSpan duration, string codec)
            : base(fileName, sizeKb)
        {
            Duration = duration;
            Codec = codec;
        }

        public override void Open()
        {
            Console.WriteLine($"[Медиаплеер] Воспроизведение видеофайла \"{FileName}\".");
            Console.WriteLine($" -> Длительность: {Duration} | Кодек: {Codec} | Размер: {SizeKb} КБ");
            Console.WriteLine(" -> Воспроизведение: 00:00:01 ▶ [======-------------] Громкость 100%");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 27. Файлы (TextFile, ImageFile, VideoFile) ===\n");

            List<File> files = new List<File>
            {
                new TextFile("readme.txt", 12, "UTF-8", 145),
                new ImageFile("landscape_4k.jpg", 8450, 3840, 2160, "sRGB 24-bit"),
                new VideoFile("movie_trailer.mp4", 125000, TimeSpan.FromMinutes(2.5), "H.264 / AAC")
            };

            Console.WriteLine("Диспетчер файлов — Открытие документов:");
            Console.WriteLine(new string('=', 60));

            foreach (var file in files)
            {
                file.Open();
                Console.WriteLine(new string('-', 60));
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}