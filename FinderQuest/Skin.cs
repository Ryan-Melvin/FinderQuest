using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public class Skin
    {
        #region fields
        private string name;
        private PictureBox sprite;
        private bool isUnlocked;
        private int price;
        #endregion

        #region constructor
        public Skin(string name, Image image, Point point, Size size, int price)
        {
            this.Name = name;
            this.Sprite = new PictureBox();
            this.Sprite.Size = size;
            this.Sprite.Location = point;
            this.IsUnlocked = false;
            this.Price = price;
        }
        #endregion

        #region properties
        public string Name 
        { 
            get => name;
            set
            {
                if(value == "")
                {
                    throw new Exception("Skin name cannot be empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public PictureBox Sprite { get => sprite; set => sprite = value; }
        public bool IsUnlocked { get => isUnlocked; private set => isUnlocked = value; }
        public int Price 
        { 
            get => price;
            set
            {
                if (value < 0)
                {
                    this.price = 0;
                }
                else
                {
                    this.price = value;
                }
            } 
        }
        #endregion

        #region methods
        public void BuySkin()
        {

        }
        #endregion
    }
}