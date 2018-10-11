using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public static class Calculator
    {
        public enum Scoring : int
        {
            Tie = 1,
            Win = 3,
        }

        public static List<Team> GameStats(List<Game>games)
        {
            return games
                .Aggregate(new Dictionary<string, Team>(), (acc, game) =>
                {
                    var team1 = acc.ContainsKey(game.Team1.Name) ? acc[game.Team1.Name] : Team.DefaultTeam(game.Team1.Name);
                    var team2 = acc.ContainsKey(game.Team2.Name) ? acc[game.Team2.Name] : Team.DefaultTeam(game.Team2.Name);

                    if (game.Team1.Points > game.Team2.Points)
                    {
                        team1.Score += (int)Scoring.Win;
                    }
                    else if (game.Team2.Points > game.Team1.Points)
                    {
                        team2.Score += (int)Scoring.Win;
                    }
                    else
                    {
                        team1.Score += (int)Scoring.Tie;
                        team2.Score += (int)Scoring.Tie;
                    }

                    team1.GoalDiff += game.Team1.Points - game.Team2.Points;
                    team2.GoalDiff += game.Team2.Points - game.Team1.Points;

                    acc[game.Team1.Name] = team1;
                    acc[game.Team2.Name] = team2;

                    return acc;
                })
                .Values
                .ToList();
        }
    }
}
