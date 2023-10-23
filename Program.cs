using System;
using System.Diagnostics;
using System.IO;

namespace PDFPrinterWatcher
{
    class Program
    {
        private const string WatchDirectory = @"[Path-to-the-directory-you-want-to-monitor]"; // Replace with your directory - Not required if you want to use the console input
        private static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private const string PDFtoPrinterFileName = "PDFtoPrinter.exe";
        private static readonly string PDFtoPrinterPath = Path.Combine(CurrentDirectory, PDFtoPrinterFileName);


        static void Main(string[] args)
        {
            // 1. Capture User Input
            Console.WriteLine("Please enter the directory you want to watch:");
            string watchDirectory = Console.ReadLine();

            // 2. Validate the Directory
            while (!Directory.Exists(watchDirectory))
            {
                Console.WriteLine("The provided directory does not exist or is not accessible. Please try again:");
                watchDirectory = Console.ReadLine();
            }

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                // watcher.Path = WatchDirectory;
                watcher.Path = watchDirectory;
                watcher.Filter = "*.pdf";
                watcher.Created += OnCreated;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine($"Watching {WatchDirectory} for new PDFs. Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Detected new PDF: {e.FullPath}");
            PrintPDF(e.FullPath);
        }

        private static void PrintPDF(string pdfPath)
        {
            var processInfo = new ProcessStartInfo(PDFtoPrinterPath, $"\"{pdfPath}\"")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = Process.Start(processInfo);
            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();
            var errors = process.StandardError.ReadToEnd();

            if (string.IsNullOrWhiteSpace(errors))
            {
                Console.WriteLine($"Successfully printed {pdfPath}");
            }
            else
            {
                Console.WriteLine($"Error while printing {pdfPath}: {errors}");
            }
        }
    }
}
