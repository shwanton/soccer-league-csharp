using System;
using System.Collections.Generic;
using League;

namespace Tests
{
    public class Fixtures
    {
        public static string Input()
        {
            return "Lions 3, Snakes 3\nSnakes 1, FC Awesome 0\n";
        }

        public static List<Dictionary<string, Team>> Games()
        {
            var game1 = new Dictionary<string, Team>
            {
                {
                    "team1", new Team() { Name="Lions", Points=3 }
                },
                {
                    "team2", new Team() { Name="Snakes", Points=3 }
                },
            };

            var game2 = new Dictionary<string, Team>
            {
                {
                    "team1", new Team() { Name="Snakes", Points=1 }
                },
                {
                    "team2", new Team() { Name="FC Awesome", Points=0 }

                },
            };

            return new List<Dictionary<string, Team>> { game1, game2 };
        }

        public static List<KeyValuePair<string, int>> Stats()
        {
            return new List<KeyValuePair<string, int>>
            {
                KeyValuePair.Create<string, int>("Lions", 1),
                KeyValuePair.Create<string, int>("Snakes", 4),
                KeyValuePair.Create<string, int>("FC Awesome", 0),
            };
        }
    }
}
