using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class StatsCalulator
    {
        private List<Dictionary<string, string>> _games;

        public StatsCalulator(List<Dictionary<string, string>> games)
        {
            _games = games;
        }

        public List<KeyValuePair<string, int>> Calculate()
        {
            return _games
                .Aggregate(new Dictionary<string, int>(), (acc, game) =>
                {
                    foreach (var team in game)
                    {
                        var name = team.Key;
                        var score = Convert.ToInt32(team.Value);

                        if (!acc.ContainsKey(name))
                            acc.Add(name, score);
                        else
                            acc[name] = acc[name] += score;
                    }

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
