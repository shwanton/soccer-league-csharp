using System;
namespace League
{
    public struct Team
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
        public int GoalDiff { get; set; }

        public static Team Season(string name)
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
