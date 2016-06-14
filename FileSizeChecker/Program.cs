using System;
using System.IO;
using System.Threading;

namespace FileSizeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Console.ReadLine();
            long filesPreviousSize = 0;

            while (true)
            {
                long filesTotalSize = 0;
                Console.WriteLine("Sleeping for 10 seconds to give the files a chance to adjust");
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Console.WriteLine("Woke up, checking files now");
                var fileList = Directory.GetFiles(filePath);
                foreach (var file in fileList)
                {
                    var fi = new FileInfo(file);
                    var fileSize = fi.Length;
                    filesTotalSize = filesTotalSize + fileSize;
                    Console.WriteLine("Files total to {0} in size", filesTotalSize);
                }
                if (filesTotalSize != filesPreviousSize)
                {
                    Console.WriteLine("Files have changed, loop it again");
                    filesPreviousSize = filesTotalSize;
                    Console.WriteLine("Total now: {0} => Total Previous: {1}", filesTotalSize, filesPreviousSize);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Outside the loop, you can now quit");
            while (Console.Read() != 'q') ;
        }
    }
}
