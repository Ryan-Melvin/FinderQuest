using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeApplication;

namespace FinderQuest
{
    public class Player
    {
        #region fields
        private string name;
        private PictureBox sprite;
        private int score;
        private Time time;
        #endregion

        #region constructors
        public Player(string name, Image picture, Size size, Point location, Time playTime)
        {
            this.Name = name;
            this.Score = 0;
            this.Time = playTime;
            this.Sprite = new PictureBox();
            this.Sprite.Image = picture;
            this.Sprite.Size = size;
            this.Sprite.Location = location;
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
        public PictureBox Sprite { get => this.sprite; set => this.sprite = value; }
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
        #endregion

        #region methods
        public string DisplayData()
        {
            return "Name : " + this.Name + "\nScore: " + this.Score + "\nPlay Time : " + this.Time.DisplayData();
        }

        public void DisplayPicture(Control container)
        {
            this.Sprite.Parent = container;
            this.Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Sprite.BackColor = Color.Transparent;
            this.Sprite.BringToFront();
        }

        public void AddScore(int amount)
        {
            this.Score += amount;
        }

        public void MoveRight(int distance)
        {
            this.Sprite.Location = new Point(this.Sprite.Location.X + distance, this.Sprite.Location.Y);
            this.Sprite.Image = Properties.Resources.player_right;
        }

        public void MoveLeft(int distance)
        {           
            this.Sprite.Location = new Point(this.Sprite.Location.X - distance, this.Sprite.Location.Y);
            this.Sprite.Image = Properties.Resources.player_left;
        }
        #endregion

    }
}