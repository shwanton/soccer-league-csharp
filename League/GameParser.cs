﻿using System;
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
                .Select(line =>
            {
                string pattern = @"^([\w ]+) (\d+), ([\w ]+) (\d+)";
                Match m = Regex.Match(line, pattern, RegexOptions.Singleline);
                GroupCollection groups = m.Groups;
                
                return new Game()
                {
                    Team1 = CreateTeam(groups[1].Value, groups[2].Value),
                    Team2 = CreateTeam(groups[3].Value, groups[4].Value),
                };
            })
                .ToList();
        }

        private Team CreateTeam(string name, string pts)
        {
            var points = Convert.ToInt32(pts);
            return new Team()
            {
                Name = name,
                Points = points,
            };
        }
    }
}
