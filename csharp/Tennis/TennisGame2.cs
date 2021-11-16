using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Points;
        private int player2Points;
        private string player1Name;
        private string player2Name;

        public TennisGame2()
        {
            player1Points = 0;
            player1Name = "player1";
            player2Name = "player2";
        }

        public string GetScoreResult()
        {
            var score = GetScoreWord(player1Points) + "-" + GetScoreWord(player2Points);
            if (AreEquals())
            {
                score = GetScoreWord(player1Points) + "-All";
            }
            if (player1Points == player2Points && player1Points > 2)
                score = "Deuce";

            if (IsInAdvantage())
            {
                score = $"Advantage {GetPlayerNameInAdvantage()}";
            }

            if (WeHaveWinner())
            {
                score = $"Win for {GetPlayerNameInAdvantage()}";
            }
            
            return score;
        }

        private bool AreEquals()
        {
            return player1Points == player2Points && player1Points < 3;
        }

        private bool WeHaveWinner()
        {
            return (player2Points >= 4 && player1Points >= 0 || player1Points >= 4 && player2Points >= 0) && Math.Abs(player1Points - player2Points) >= 2;
        }

        private bool IsInAdvantage()
        {
            return player1Points > player2Points && player2Points >= 3 ||
                   player2Points > player1Points && player1Points >= 3;
        }

        private string GetScoreWord(int points)
        {
            switch (points)
            {
                case 0:
                    return "Love";
                case 1:   
                    return "Fifteen";
                case 2:
                    return "Thirty";
                default:
                   return "Forty";
            }
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                player1Points++;
            else
                player2Points++;
        }

        public string GetPlayerNameInAdvantage()
        {
            return player1Points > player2Points ? "player1" : "player2";
        }
    }
}

