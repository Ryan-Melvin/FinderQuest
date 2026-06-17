using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public class Person
    {
        private int personNum;
        private string name;
        private PictureBox sprite;
        private string dialog;
        private Question question;
        private bool solved;

        public Person(int personNum, string name, Image image, Size size, Point location, string dialog, bool solved)
        {
            this.PersonNum = personNum;
            this.Name = name;
            this.Sprite = new PictureBox();
            this.Sprite.Image = image;
            this.Sprite.Size = size;
            this.Sprite.Location = location;
            this.Dialog = dialog;
            this.Solved = false;
        }

        public int PersonNum 
        { 
            get => personNum;
            set
            {
                if(value < 0)
                {
                    throw new Exception("Person number cannot be negative");
                }
                else
                {
                    this.personNum = value;
                }
            }
        }
        public string Name 
        { 
            get => name;
            set
            {
                if(value == "")
                {
                    throw new Exception("Person name cannot be empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public PictureBox Sprite { get => sprite; set => sprite = value; }
        public string Dialog { get => dialog; set => dialog = value; }
        public Question Question { get => question; set => question = value; }
        public bool Solved { get => solved; set => solved = value; }
    }
}