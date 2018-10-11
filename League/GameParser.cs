using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace League
{
    public interface IGameParser
    {
        List<Game> LoadGames();
    }

    public class GameParser : IGameParser
    {
        private readonly IDataLoader _loader;

        public GameParser(IDataLoader loader)
        {
            _loader = loader;
        }

        public List<Game> LoadGames()
        {
            return _loader
                .LoadData()
                .Split("\n")
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(CreateGame)
                .ToList();
        }

        private Game CreateGame(string line)
        {
            string pattern = @"^([\w ]+) (\d+), ([\w ]+) (\d+)";
            Match m = Regex.Match(line, pattern, RegexOptions.Singleline);
            GroupCollection groups = m.Groups;

            return new Game()
            {
                Team1Name = groups[1].Value,
                Team1Points = Convert.ToInt32(groups[2].Value),
                Team2Name = groups[3].Value,
                Team2Points = Convert.ToInt32(groups[4].Value),
            };
        }
    }
}
