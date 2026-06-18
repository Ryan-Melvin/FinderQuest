using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public abstract class Area
    {
        #region fields;
        private string name;
        private Image background;
        #endregion

        #region constructors
        public Area(string name, Image background)
        {
            this.Name = name;
            this.Background = background;
        }
        #endregion

        #region properties
        public string Name 
        { 
            get => this.name;
            set
            {
                if(value == "")
                {
                    throw new Exception("Level name cannot be empty.");
                }
                else
                {
                    this.name = value;
                }
            } 
        }
        public Image Background { get => background; set => background = value; }
        #endregion

        #region methods
        public virtual string DisplayData()
        {
            return this.Name;
        }

        public void DisplayPicture(Control container)
        {
            container.BackgroundImage = this.Background;
        }
        #endregion
    }
}