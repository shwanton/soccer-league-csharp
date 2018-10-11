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

                var loader = new GameParser(new FileLoader(fileName));

                var league = new LeagueStats(loader);

                Console.Write(league.GetSeason());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem with the League: {ex}");
            }
        }
    }
}
