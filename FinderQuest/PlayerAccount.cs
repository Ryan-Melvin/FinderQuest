using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    [Serializable]
    public class PlayerAccount
    {
        private string playerName;
        private int goldBalance;
        private List<PlayReport> gameHistory;
        private List<string> ownedSkins;
        private string equippedSkin;
        private string saveFileName;

        public PlayerAccount(string playerName, string saveFileName)
        {
            this.PlayerName = playerName;
            this.GoldBalance = 0;
            this.GameHistory = new List<PlayReport>();
            this.OwnedSkins = new List<string>() { "ForestRanger" }; // default skin
            this.EquippedSkin = "ForestRanger";
            this.SaveFileName = saveFileName;
        }

        public string PlayerName { get => playerName; set => playerName = value; }
        public int GoldBalance { get => goldBalance; set => goldBalance = value; }
        public List<PlayReport> GameHistory { get => gameHistory; private set => gameHistory = value; }
        public List<string> OwnedSkins { get => ownedSkins; private set => ownedSkins = value; }
        public string EquippedSkin { get => equippedSkin; set => equippedSkin = value; }
        public string SaveFileName { get => saveFileName; set => saveFileName = value; }

        public void AddGameHistory(PlayReport report)
        {
            this.GameHistory.Add(report);
        }

        public void AddOwnedSkins(string skin)
        {
            this.OwnedSkins.Add(skin);
        }

        public int DetermineHighScore()
        {
            int max = 0;
            foreach (PlayReport report in this.GameHistory)
            {
                if (report.Score > max)
                {
                    max = report.Score;
                }
            }
            return max;
        }

        public int CalculateTotalGold()
        {
            int total = 0;
            foreach (PlayReport report in this.GameHistory)
            {
                total += report.GoldEarned;
            }
            return total;
        }
    }
}