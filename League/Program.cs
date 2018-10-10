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

                var result = new LeagueStats(new FileLoader(fileName));

                Console.Write(result.GetSeason());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem with the League: {ex}");
            }
        }
    }
}
