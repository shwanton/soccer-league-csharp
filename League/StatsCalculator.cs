﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class StatsCalulator
    {
        private List<Game> _games;

        public enum Scoring : int
        {
            Tie = 1,
            Win = 3,
        }

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
                        acc.Add(game.Team1.Name, CreateTeam(game.Team1.Name));

                    if (!acc.ContainsKey(game.Team2.Name))
                        acc.Add(game.Team2.Name, CreateTeam(game.Team2.Name));

                    var seasonTeam1 = acc[game.Team1.Name];
                    var seasonTeam2 = acc[game.Team2.Name];

                    if (game.Team1.Points > game.Team2.Points)
                    {
                        seasonTeam1.Score += (int)Scoring.Win;
                    }
                    else if (game.Team2.Points > game.Team1.Points)
                    {
                        seasonTeam2.Score += (int)Scoring.Win;
                    }
                    else
                    {
                        seasonTeam1.Score += (int)Scoring.Tie;
                        seasonTeam2.Score += (int)Scoring.Tie;
                    }

                    seasonTeam1.GoalDiff += game.Team1.Points - game.Team2.Points;
                    seasonTeam2.GoalDiff += game.Team2.Points - game.Team1.Points;

                    acc[game.Team1.Name] = seasonTeam1;
                    acc[game.Team2.Name] = seasonTeam2;

                    return acc;
                })
                .Values
                .ToList();
        }

        private Team CreateTeam(string name)
        {
            return new Team()
            {
                Name = name,
                Score = 0,
                GoalDiff = 0,
            };
        }
    }

}
