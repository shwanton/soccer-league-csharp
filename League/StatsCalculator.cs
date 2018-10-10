using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class StatsCalulator
    {
        private List<Dictionary<string, Team>> _games;

        public StatsCalulator(List<Dictionary<string, Team>> games)
        {
            _games = games;
        }

        public List<KeyValuePair<string, int>> Calculate()
        {
            return _games
                .Aggregate(new Dictionary<string, int>(), (acc, game) =>
                {
                    Team team1 = game["team1"];
                    Team team2 = game["team2"];

                    if (!acc.ContainsKey(team1.Name))
                        acc.Add(team1.Name, 0);

                    if (!acc.ContainsKey(team2.Name))
                        acc.Add(team2.Name, 0);

                    var team1Score = acc[team1.Name];
                    var team2Score = acc[team2.Name];

                    if (team1Score > team2Score)
                    {
                        team1Score += 3;
                    } else if (team2Score > team1Score)
                    {
                        team2Score += 3;
                    }
                    else
                    {
                        team1Score += 1;
                        team2Score += 1;
                    }

                    acc[team1.Name] = team1Score;
                    acc[team2.Name] = team2Score;

                    //foreach (var score in acc)
                    //{
                    //    Console.WriteLine(score);
                    //}
                    return acc;
                })
                .ToList();
        }
    }

}
