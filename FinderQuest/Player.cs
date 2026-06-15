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
        private PictureBox picture;
        private int score;
        private Time time;
        #endregion

        #region constructors
        public Player(string name, Image picture, Size size, Point location, Time playTime)
        {
            this.Name = name;
            this.Score = 0;
            this.Time = playTime;
            this.Picture = new PictureBox();
            this.Picture.Image = picture;
            this.Picture.Size = size;
            this.Picture.Location = location;
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
        public PictureBox Picture { get => this.picture; set => this.picture = value; }
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
            this.Picture.Parent = container;
            this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture.BackColor = Color.Transparent;
            this.Picture.BringToFront();
        }

        public void AddScore(int amount)
        {
            this.Score += amount;
        }

        public void MoveRight(int distance)
        {
            this.Picture.Location = new Point(this.Picture.Location.X + distance, this.Picture.Location.Y);
            this.Picture.Image = Properties.Resources.player_right;
        }

        public void MoveLeft(int distance)
        {           
            this.Picture.Location = new Point(this.Picture.Location.X - distance, this.Picture.Location.Y);
            this.Picture.Image = Properties.Resources.player_left;
        }
        #endregion

    }
}