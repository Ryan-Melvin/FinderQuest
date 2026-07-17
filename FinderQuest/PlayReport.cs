using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeApplication;

namespace FinderQuest
{
    public class PlayReport
    {
        #region fields
        private int score;
        private Time timePlayed;
        private int finalScore;
        private int goldEarned;

        public PlayReport(int score, Time timePlayed)
        {
            this.Score = score;
            this.timePlayed = timePlayed;

            int totalSeconds = this.timePlayed.ConvertToSecond();

            double timeBonus = Math.Max(0, (300.0 - totalSeconds) / 300.0);

            int tempFinalScore = (int)(score * (1.0 + timeBonus));
            this.FinalScore = (tempFinalScore / 100) * 100; // round score to the lower hundred

            this.GoldEarned = (int)(this.FinalScore * 0.25);
        }

        public int Score { get => score; set => score = value; }
        public Time TimePlayed { get => timePlayed; set => timePlayed = value; }
        public int FinalScore { get => finalScore; set => finalScore = value; }
        public int GoldEarned { get => goldEarned; set => goldEarned = value; }
        #endregion

    }
}