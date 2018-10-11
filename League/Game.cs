using System;
namespace League
{
    public enum GameOutcome
    {
        Team1Win,
        Team2Win,
        Tie
    }

    public struct Game
    {
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public int Team1Points { get; set; }
        public int Team2Points { get; set; }

        private bool Tie => Team1Points == Team2Points;
        private bool Team1Win => Team1Points > Team2Points;
        private bool Team2Win => Team2Points > Team1Points;

        public GameOutcome Outcome()
        {
            if (Team1Win) return GameOutcome.Team1Win;
            else if (Team2Win) return GameOutcome.Team2Win;
            else if (Tie) return GameOutcome.Tie;
            else throw new Exception("Game outcome was invalid");
        }
    }
}
