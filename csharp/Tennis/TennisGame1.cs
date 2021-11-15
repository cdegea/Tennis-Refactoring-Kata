namespace Tennis
{
    internal class Player
    {
        public string PlayerName { get; }

        public Player(string playerName)
        {
            PlayerName = playerName;
        }
    }
    internal class Score
    {
        public int ScoreLeft { get; private set; }
        public int ScoreRight { get; private set; }

        public Score()
        {
            ScoreLeft = 0;
            ScoreRight = 0;
        }

        public void AddScore(bool isLeft)
        {
            if (isLeft)
                ScoreLeft++;
            else
                ScoreRight++;
        }

        public bool IsTheSame() => ScoreLeft == ScoreRight;

        public bool IsInAdvantage()
        {
            return this.ScoreLeft >= 4 || this.ScoreRight >= 4;
        }

        private static string GetNameByScoreValue(int score)
        {
            switch (score)
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

        public string GetNaturalScore()
        {
            return $"{GetNameByScoreValue(ScoreLeft)}-{GetNameByScoreValue(ScoreRight)}";
        }

        public string GetScoreForAdvantage()
        {
            var minusResult = ScoreLeft - ScoreRight;
            switch (minusResult)
            {
                case 1:
                    return "Advantage player1";
                case -1:
                    return "Advantage player2";
                case >= 2:
                    return "Win for player1";
                default:
                    return "Win for player2";
            }
        }

        public string GetScoreForSame()
        {
            switch (ScoreLeft)
            {
                case 0:
                    return "Love-All";                    
                case 1:
                    return "Fifteen-All";                    
                case 2:
                    return "Thirty-All";                    
                default:
                    return "Deuce";                    
            }
        }

        public string GetScore()
        {
            if (IsTheSame())
                return GetScoreForSame();
            if (IsInAdvantage())
                return GetScoreForAdvantage();
            return GetNaturalScore();
        }
    }
    internal class TennisGame1 : ITennisGame
    {
        private readonly Player winnerOfPoint;
        private readonly Score score;

        public TennisGame1(string winnerName)
        {
            winnerOfPoint = new Player(winnerName);
            score = new Score();
        }

        public void WonPoint(string playerName)
        {
            score.AddScore(playerName == winnerOfPoint.PlayerName);
        }

        public string GetScoreResult()
        {
            return score.GetScore();
        }
    }
}

