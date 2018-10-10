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
            // **Calculate season scores**
            // **Sort**
            // Calculate ranking number
            // Print

            // TODO: Refactor Team/Game

            try
            {
                var fileName = args[0];
                if (fileName == null)
                    throw new FileNotFoundException();

                var data = new FileLoader(fileName).LoadData();
                var parsed = new GameParser(data).Parse();
                var stats = new StatsCalulator(parsed).Calculate();
                var sorted = new Sorter(stats).Sort();

                foreach (var team in sorted)
                {
                    Console.WriteLine($"{team.Name} : {team.Score} : {team.Rank}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem loading the file: {ex}");
            }
        }
    }
}
