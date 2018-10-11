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

        public static List<Team> GameStats(List<Game> games)
        {
            return games
                .Aggregate(new Dictionary<string, Team>(), (acc, game) =>
                {
                    var seasonTeam1 = acc.ContainsKey(game.Team1Name) ? acc[game.Team1Name] : Team.Season(game.Team1Name);
                    var seasonTeam2 = acc.ContainsKey(game.Team2Name) ? acc[game.Team2Name] : Team.Season(game.Team2Name);

                    var outcome = game.Outcome();
                    switch (outcome)
                    {
                        case GameOutcome.Team1Win:
                            seasonTeam1.Score += (int)Scoring.Win;
                            break;
                        case GameOutcome.Team2Win:
                            seasonTeam2.Score += (int)Scoring.Win;
                            break;
                        case GameOutcome.Tie:
                            seasonTeam1.Score += (int)Scoring.Tie;
                            seasonTeam2.Score += (int)Scoring.Tie;
                            break;
                    }

                    seasonTeam1.GoalDiff += game.Team1Points - game.Team2Points;
                    seasonTeam2.GoalDiff += game.Team2Points - game.Team1Points;

                    acc[game.Team1Name] = seasonTeam1;
                    acc[game.Team2Name] = seasonTeam2;

                    return acc;
                })
                .Values
                .ToList();
        }
    }
}
