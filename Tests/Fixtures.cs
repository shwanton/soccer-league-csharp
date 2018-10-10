using System;
using System.Collections.Generic;
using League;

namespace Tests
{
    public class Fixtures
    {
        public static string Input()
        {
            return "Lions 3, Snakes 3\nTarantulas 1, FC Awesome 0\nLions 1, FC Awesome 1\n";
        }

        public static List<Dictionary<string, Team>> Games()
        {
            return new List<Dictionary<string, Team>> {
                new Dictionary<string, Team>
                {
                    {
                        "team1", new Team() { Name="Lions", Points=3 }
                    },
                    {
                        "team2", new Team() { Name="Snakes", Points=3 }
                    },
                },

                new Dictionary<string, Team>
                {
                    {
                        "team1", new Team() { Name="Tarantulas", Points=1 }
                    },
                    {
                        "team2", new Team() { Name="FC Awesome", Points=0 }

                    },
                },

                new Dictionary<string, Team>
                {
                    {
                        "team1", new Team() { Name="Lions", Points=1 }
                    },
                    {
                        "team2", new Team() { Name="FC Awesome", Points=1 }

                    },
                }
            };
        }

        public static List<Team> Stats()
        {
            return new List<Team>
            {
                new Team() { Name="Lions", Score=2 },
                new Team() { Name="Snakes", Score=1 },
                new Team() { Name="Tarantulas", Score=3 },
                new Team() { Name="FC Awesome", Score=1 },
            };
        }

        public static List<Team> Sorted()
        {
            return new List<Team>
            {
                new Team() { Name="Tarantulas", Score=3 },
                new Team() { Name="Lions", Score=2 },
                new Team() { Name="FC Awesome", Score=1 },
                new Team() { Name="Snakes", Score=1 },
            };
        }
    }
}
