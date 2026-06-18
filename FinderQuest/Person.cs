using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public class Person
    {
        #region fields
        private int personNum;
        private string name;
        private PictureBox sprite;
        private string dialog;
        private Question question;
        private bool solved;
        private Label labelDialog;
        #endregion

        #region constructors
        public Person(int personNum, string name, Image image, Size size, Point location, string dialog)
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
        #endregion

        #region properties
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
        public bool Solved { get => solved; private set => solved = value; }
        public Label LabelDialog { get => labelDialog; set => labelDialog = value; }
        #endregion

        #region methods
        public string DisplayData()
        {
            return "Hi.. I'm " + this.Name + ".\n" + this.Dialog + "Press 'y' to continue";
        }

        public void DisplayPicture(Control container)
        {
            this.Sprite.Parent = container;
            this.Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Sprite.BackColor = Color.Transparent;
            this.Sprite.BringToFront();
        }

        public void DisplayDialog(Control container)
        {

            labelDialog = new Label();
            labelDialog.AutoSize = true;
            labelDialog.Parent = container;
            labelDialog.MaximumSize = new Size(container.Width - 40, 0);
           
            labelDialog.Font = new Font("Arial", 18);
            labelDialog.TextAlign = ContentAlignment.TopCenter;
            labelDialog.Padding = new Padding(10, 10, 10, 10);
            labelDialog.BackColor = Color.LightYellow;
            labelDialog.BorderStyle = BorderStyle.FixedSingle;

            labelDialog.Text = this.DisplayData();
            labelDialog.Location = new Point((container.Width - labelDialog.Width) / 2, 10);
            labelDialog.Visible = true;
            labelDialog.BringToFront();
        }

        public void RemoveDialog()
        {
            labelDialog.Dispose();
        }

        public void AddQuestion(string question, string answer, int score)
        {
            this.Question = new Question(question, answer, score);
        }

        public int CheckAnswer(string answer)
        {
            if(answer.ToUpper() == this.Question.Answer.ToUpper())
            {
                this.Solved = true;
                return this.Question.Score;
            }
            return 0;
        }
        #endregion
    }
}