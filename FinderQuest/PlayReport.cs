using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeApplication;

namespace FinderQuest
{
    [Serializable]
    public class PlayReport
    {
        #region fields
        private DateTime playDateTime;
        private int score;
        private Time timePlayed;
        private int finalScore;
        private int goldEarned;

        public PlayReport(DateTime playDateTime, int score, int hour, int minute, int second)
        {
            this.PlayDateTime = playDateTime;
            this.Score = score;
            this.timePlayed = new Time(hour, minute, second);

            int totalSeconds = this.timePlayed.ConvertToSecond();

            double timeBonus = Math.Max(0, (300.0 - totalSeconds) / 300.0);

            int tempFinalScore = (int)(score * (1.0 + timeBonus));
            this.FinalScore = (tempFinalScore / 100) * 100; // round score to the lower hundred

            this.GoldEarned = (int)(this.FinalScore * 0.25);
        }

        public DateTime PlayDateTime { get => playDateTime; set => playDateTime = value; }
        public int Score { get => score; set => score = value; }
        public Time TimePlayed { get => timePlayed; set => timePlayed = value; }
        public int FinalScore { get => finalScore; set => finalScore = value; }
        public int GoldEarned { get => goldEarned; set => goldEarned = value; }
        #endregion

        public string DisplayData()
        {
            string display = "Run Completed: " + this.PlayDateTime.ToString("g") + "\n"
                + "Score: " + this.Score + "pts\n"
                + "Time Played: " + this.timePlayed.DisplayData() + "\n"
                + "Final Score: " + this.FinalScore + "pts\n"
                + "Gold Earned: " + this.GoldEarned + "G";
            return display;
        }

    }
}