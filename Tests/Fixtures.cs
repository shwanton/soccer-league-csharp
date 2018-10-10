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

        public static List<KeyValuePair<string, int>> Stats()
        {
            return new List<KeyValuePair<string, int>>
            {
                KeyValuePair.Create<string, int>("Lions", 2),
                KeyValuePair.Create<string, int>("Snakes", 1),
                KeyValuePair.Create<string, int>("Tarantulas", 3),
                KeyValuePair.Create<string, int>("FC Awesome", 1),
            };
        }

        public static List<KeyValuePair<string, int>> Sorted()
        {
            return new List<KeyValuePair<string, int>>
            {
                KeyValuePair.Create<string, int>("Tarantulas", 3),
                KeyValuePair.Create<string, int>("Lions", 2),
                KeyValuePair.Create<string, int>("FC Awesome", 1),
                KeyValuePair.Create<string, int>("Snakes", 1),
            };
        }
    }
}
