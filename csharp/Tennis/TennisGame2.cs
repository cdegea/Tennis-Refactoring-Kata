namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Points;
        private int player2Points;

        public TennisGame2()
        {
            player1Points = 0;
        }

        public string GetScoreResult()
        {
            var score = GetScoreWord(player1Points) + "-" + GetScoreWord(player2Points);
            if (player1Points == player2Points && player1Points < 3)
            {
                score = GetScoreWord(player1Points) + "-All";
            }
            if (player1Points == player2Points && player1Points > 2)
                score = "Deuce";

            if (player1Points > player2Points && player2Points >= 3)
            {
                score = "Advantage player1";
            }

            if (player2Points > player1Points && player1Points >= 3)
            {
                score = "Advantage player2";
            }

            if (player1Points >= 4 && player2Points >= 0 && (player1Points - player2Points) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Points >= 4 && player1Points >= 0 && (player2Points - player1Points) >= 2)
            {
                score = "Win for player2";
            }
            return score;
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
    }
}

