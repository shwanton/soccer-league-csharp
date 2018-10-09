using System;
using System.IO;

namespace League
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllText(args[0]);
            var data = file.Split("\n");
            foreach (var line in data)
            {
                Console.WriteLine(line);
            }
        }
    }
}
