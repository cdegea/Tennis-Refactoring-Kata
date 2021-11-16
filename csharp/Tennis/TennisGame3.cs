using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Points;
        private int player1Points;
        private readonly string player1Name;
        private readonly string player2Name;
        private readonly string[] pointNames;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            pointNames = new[] { "Love", "Fifteen", "Thirty", "Forty" };
        }

        public string GetScoreResult()
        {
            if (IsTheSame())
                return GetScoreForTheSame();
            
            if (player1Points == player2Points)
                return "Deuce";

            return IsAdvantage() ? "Advantage " + GetAdvantagedPlayerName() : "Win for " + GetAdvantagedPlayerName();
        }

        private string GetAdvantagedPlayerName()
        {
            return player1Points > player2Points ? player1Name : player2Name;
        }

        private string GetScoreForTheSame()
        {
            var s = GetPointName(player1Points);
            return (player1Points == player2Points) ? s + "-All" : s + "-" + pointNames[player2Points];
        }

        private bool IsTheSame()
        {
            return (player1Points < 4 && player2Points < 4) && (player1Points + player2Points < 6);
        }

        private bool IsAdvantage()
        {
            return Math.Abs(player1Points - player2Points) == 1;
        }

        private string GetPointName(int point)
        {
            return pointNames[point];
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Points += 1;
            else
                player2Points += 1;
        }

    }
}

