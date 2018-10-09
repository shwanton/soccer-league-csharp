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

        public IEnumerable<Dictionary<string, string>> Parse()
        {
            return _data
                .Split("\n")
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    string pattern = @"^([\w ]+) (\d+), ([\w ]+) (\d+)";
                    Match m = Regex.Match(line, pattern, RegexOptions.Singleline);
                    GroupCollection groups = m.Groups;

                    return new Dictionary<string, string>
                    {
                        { groups[1].Value, groups[2].Value },
                        { groups[3].Value, groups[4].Value },
                    };
                })
                .ToList();
        }
    }
}
