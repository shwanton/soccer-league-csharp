using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class StatsCalulator
    {
        private List<Game> _games;

        public StatsCalulator(List<Game> games)
        {
            _games = games;
        }

        public List<Team> Calculate()
        {
            return _games
                .Aggregate(new Dictionary<string, Team>(), (acc, game) =>
                {
                    if (!acc.ContainsKey(game.Team1.Name))
                        acc.Add(game.Team1.Name, new Team() { Name = game.Team1.Name, Score = 0 });

                    if (!acc.ContainsKey(game.Team2.Name))
                        acc.Add(game.Team2.Name, new Team() { Name = game.Team2.Name, Score = 0 });

                    var seasonTeam1 = acc[game.Team1.Name];
                    var seasonTeam2 = acc[game.Team2.Name];

                    if (game.Team1.Points > game.Team2.Points)
                    {
                        seasonTeam1.Score += 3;
                    } else if (game.Team2.Points > game.Team1.Points)
                    {
                        seasonTeam2.Score += 3;
                    }
                    else
                    {
                        seasonTeam1.Score += 1;
                        seasonTeam2.Score += 1;
                    }

                    return acc;
                })
                .Values
                .ToList();
        }
    }

}
