namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";

        public TennisGame2()
        {
            p1point = 0;
        }

        public string GetScoreResult()
        {
            var score = GetScoreWord(p1point) + "-" + GetScoreWord(p2point);
            if (p1point == p2point && p1point < 3)
            {
                score = GetScoreForSame(score);
            }
            if (p1point == p2point && p1point > 2)
                score = "Deuce";

            if (p1point > p2point && p1point < 4)
            {
                switch (p1point)
                {
                    case 2:
                        p1res = "Thirty";
                        break;
                    case 3:
                        p1res = "Forty";
                        break;
                }

                switch (p2point)
                {
                    case 1:
                        p2res = "Fifteen";
                        break;
                    case 2:
                        p2res = "Thirty";
                        break;
                }

                score = p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                switch (p2point)
                {
                    case 2:
                        p2res = "Thirty";
                        break;
                    case 3:
                        p2res = "Forty";
                        break;
                }

                switch (p1point)
                {
                    case 1:
                        p1res = "Fifteen";
                        break;
                    case 2:
                        p1res = "Thirty";
                        break;
                }

                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
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

        private string GetScoreForSame(string score)
        {
            switch (p1point)
            {
                case 0:
                    score = "Love";
                    break;
                case 1:
                    score = "Fifteen";
                    break;
                case 2:
                    score = "Thirty";
                    break;
            }

            score += "-All";
            return score;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                p1point++;
            else
                p2point++;
        }
    }
}

