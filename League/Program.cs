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
                if (args == null && args.Length == 0)
                    throw new FileNotFoundException();

                var file = File.ReadAllText(args[0]);
                var data = file.Split("\n");
                foreach (var line in data)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was a problem loading the file");
            }
        }
    }
}
