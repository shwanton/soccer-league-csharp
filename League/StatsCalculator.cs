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
                    Team team1 = game.Team1;
                    Team team2 = game.Team2;

                    if (!acc.ContainsKey(team1.Name))
                        acc.Add(team1.Name, new Team() { Name = team1.Name, Score = 0 });

                    if (!acc.ContainsKey(team2.Name))
                        acc.Add(team2.Name, new Team() { Name = team2.Name, Score = 0 });

                    var newTeam1 = acc[team1.Name];
                    var newTeam2 = acc[team2.Name];

                    if (team1.Points > team2.Points)
                    {
                        newTeam1.Score += 3;
                    } else if (team2.Points > team1.Points)
                    {
                        newTeam2.Score += 3;
                    }
                    else
                    {
                        newTeam1.Score += 1;
                        newTeam2.Score += 1;
                    }

                    //acc[team1.Name] = newTeam1;
                    //acc[team2.Name] = newTeam2;

                    //foreach (var score in acc)
                    //{
                    //    Console.WriteLine(score);
                    //}
                    return acc;
                })
                .Values
                .ToList();
        }
    }

}
