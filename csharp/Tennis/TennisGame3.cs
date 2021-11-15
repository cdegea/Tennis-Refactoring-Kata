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
            string s;
            if ((player1Points < 4 && player2Points < 4) && (player1Points + player2Points < 6))
            {
                s = pointNames[player1Points];
                return (player1Points == player2Points) ? s + "-All" : s + "-" + pointNames[player2Points];
            }

            if (player1Points == player2Points)
                return "Deuce";
            s = player1Points > player2Points ? player1Name : player2Name;
            return ((player1Points - player2Points) * (player1Points - player2Points) == 1) ? "Advantage " + s : "Win for " + s;
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

