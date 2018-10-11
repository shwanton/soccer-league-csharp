using System;
namespace League
{
    public struct Game
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public bool Tie => Team1.Points == Team2.Points;

        public bool Team1Win => Team1.Points > Team2.Points;

        public bool Team2Win => Team2.Points > Team1.Points;
    }
}
