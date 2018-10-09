using System;
using System.IO;

namespace League
{

    class Program
    {
        static void Main(string[] args)
        {
            // **Read data - Data Loader**
            // **Parse data into object**
            // Calculate season scores
            // Sort
            // Calculate ranking number
            // Print

            try
            {
                var fileName = args[0];
                if (fileName == null)
                    throw new FileNotFoundException();

                var data = new FileLoader(fileName).LoadData();
                var parsed = new GameParser(data).Parse();

                foreach (var line in parsed)
                {
                    Console.WriteLine(line.Values);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem loading the file: {ex}");
            }
        }
    }
}
