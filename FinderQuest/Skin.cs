using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public class Skin
    {
        #region fields
        private string name;
        private string displayName;
        private Image sprite;
        private int price;
        private string rarity;
        #endregion

        #region constructor
        public Skin(string name, string displayName, int price, string rarity)
        {
            var resourceManager = Properties.Resources.ResourceManager;
            this.Name = name;
            this.DisplayName = displayName;
            this.Sprite = (Image)resourceManager.GetObject(this.Name + "_Idle_Right");
            this.Price = price;
            this.Rarity = rarity;
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
        public Image Sprite { get => sprite; set => sprite = value; } 
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
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Rarity { get => rarity; set => rarity = value; }
        #endregion

        #region methods

        #endregion
    }
}