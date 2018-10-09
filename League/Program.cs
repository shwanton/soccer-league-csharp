using System;
using System.IO;

namespace League
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileName = args[0];
                if (fileName == null)
                    throw new FileNotFoundException();

                var data = new FileLoader(fileName);
                //var data = file.Split("\n");
                //foreach (var line in data)
                //{
                //    Console.WriteLine(line);
                //}
            }
            catch (Exception)
            {
                Console.WriteLine("There was a problem loading the file");
            }
        }
    }
}
