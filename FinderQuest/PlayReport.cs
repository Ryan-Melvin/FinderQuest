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

        public PlayReport(int score, Time timePlayed, int finalScore, int goldEarned)
        {
            this.Score = score;
            this.TimePlayed = timePlayed;
            this.FinalScore = finalScore;
            this.GoldEarned = goldEarned;
        }

        public int Score { get => score; set => score = value; }
        public Time TimePlayed { get => timePlayed; set => timePlayed = value; }
        public int FinalScore { get => finalScore; set => finalScore = value; }
        public int GoldEarned { get => goldEarned; set => goldEarned = value; }
        #endregion

    }
}