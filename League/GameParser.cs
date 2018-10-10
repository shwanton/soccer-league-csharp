using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace League
{
    public class GameParser
    {
        private string _data;

        public GameParser(string data)
        {
            _data = data;
        }

        public List<Dictionary<string, Team>> Parse()
        {
            return _data
                .Split("\n")
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    string pattern = @"^([\w ]+) (\d+), ([\w ]+) (\d+)";
                    Match m = Regex.Match(line, pattern, RegexOptions.Singleline);
                    GroupCollection groups = m.Groups;

                    var team1Name = groups[1].Value;
                    var team1Points = Convert.ToInt32(groups[2].Value);

                    var team2Name = groups[3].Value;
                    var team2Points = Convert.ToInt32(groups[4].Value);

                    return new Dictionary<string, Team>
                    {
                        { "team1", new Team() { Name=team1Name, Points=team1Points } },
                        { "team2", new Team() { Name=team2Name, Points=team2Points } },
                    };
                })
                .ToList();
        }
    }
}
