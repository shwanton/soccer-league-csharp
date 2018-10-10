using System;
using System.Collections.Generic;
using League;

namespace Tests
{
    public class Fixtures
    {
        public static string Input()
        {
            return "Lions 3, Snakes 3\nTarantulas 1, FC Awesome 0\nLions 1, FC Awesome 1\nTarantulas 3, Snakes 1\nLions 4, Grouches 0\n";
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
                },
                new Dictionary<string, Team>
                {
                    {
                        "team1", new Team() { Name="Tarantulas", Points=3 }
                    },
                    {
                        "team2", new Team() { Name="Snakes", Points=1 }

                    },
                },
                new Dictionary<string, Team>
                {
                    {
                        "team1", new Team() { Name="Lions", Points=4 }
                    },
                    {
                        "team2", new Team() { Name="Grouches", Points=0 }

                    },
                }
            };
        }

        public static List<Team> Stats()
        {
            return new List<Team>
            {
                new Team() { Name="Lions", Score=5 },
                new Team() { Name="Snakes", Score=1 },
                new Team() { Name="Tarantulas", Score=6 },
                new Team() { Name="FC Awesome", Score=1 },
                new Team() { Name="Grouches", Score=0 },
            };
        }

        public static List<Team> Sorted()
        {
            return new List<Team>
            {
                new Team() { Name="Tarantulas", Score=6 },
                new Team() { Name="Lions", Score=5 },
                new Team() { Name="FC Awesome", Score=1 },
                new Team() { Name="Snakes", Score=1 },
                new Team() { Name="Grouches", Score=0 },
            };
        }

        public static List<Team> Ranked()
        {
            return new List<Team>
            {
                new Team() { Name="Tarantulas", Score=6, Rank=1 },
                new Team() { Name="Lions", Score=5, Rank=2 },
                new Team() { Name="FC Awesome", Score=1, Rank=3 },
                new Team() { Name="Snakes", Score=1, Rank=3 },
                new Team() { Name="Grouches", Score=0, Rank=5 },
            };
        }

        public static string Output()
        {
            return "1. Tarantulas, 6 pts\n2. Lions, 5 pts\n3. FC Awesome, 1 pt\n3. Snakes, 1 pt\n5. Grouches, 0 pts\n";
        }
    }
}
