using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using TimeApplication;

namespace FinderQuest
{
    [Serializable]
    public class Player
    {
        #region fields
        private string name;
        //private PictureBox sprite;
        private int score;
        private Time time;
        private string currState;
        private int x;
        private int y;
        private Image sprite;
        private Size size;
        bool isVisible;
        private string skin;
        #endregion

        #region constructors
        public Player(string name, Size size, Time playTime, int x, int y, string skin)
        {
            this.Name = name;
            this.Score = 0;
            this.X = x;
            this.Y = y;
            this.Time = playTime;
            this.SetSkin(skin);
            this.CurrState = "";
            this.SetState("idle-right");
            this.IsVisible = true;
            this.Size = size;

        }
        #endregion

        #region property
        public string Name 
        { 
            get => this.name;
            set
            {
                if(value == "")
                {
                    throw new Exception("Name cannot be empty.");
                }
                else
                {
                    this.name = value;
                }
            } 
        }
        public int Score 
        { 
            get => this.score;
            set
            {
                if(this.score < 0)
                {
                    this.score = 0;
                }
                else
                {
                    this.score = value;
                }
            } 
        }
        public Time Time { get => this.time; set => this.time = value; }
        public string CurrState { get => currState; private set => currState = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Image Sprite { get => sprite; set => sprite = value; }
        public Size Size { get => size; set => size = value; }
        public bool IsVisible { get => isVisible; set => isVisible = value; }
        public string Skin { get => skin; private set => skin = value; }
        #endregion

        #region methods
        public string DisplayData()
        {
            return "Name : " + this.Name + "\nScore: " + this.Score + "\nPlay Time : " + this.Time.DisplayData();
        }

        public void AddScore(int amount)
        {
            this.Score += amount;
        }

        public void MoveRight(int distance)
        {
            
            this.X += distance;
            
        }

        public void MoveLeft(int distance)
        {           
           
            this.X -= distance;
            
        }

        public void SetState(string newState)
        {
            if(newState == this.CurrState)
            {
                return;
            }
            this.CurrState = newState;
            var resourceManager = Properties.Resources.ResourceManager;

            if(this.CurrState == "idle-right")
            {
                this.Sprite = (Image)resourceManager.GetObject($"{this.Skin}_Idle_Right");
            }
            else if(this.CurrState == "walk-right")
            {
                this.Sprite = (Image)resourceManager.GetObject($"{this.Skin}_Walking_Right");
            }
            else if (this.CurrState == "walk-left")
            {
                this.Sprite = (Image)resourceManager.GetObject($"{this.Skin}_Walking_Left");
            }
            else if (this.CurrState == "idle-left")
            {
                this.Sprite = (Image)resourceManager.GetObject($"{this.Skin}_Idle_Left");
            }
        }

        public void SetSkin(string newSkin)
        {
            this.Skin = newSkin;
        }
        #endregion

    }
}