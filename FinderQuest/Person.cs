using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    [Serializable]
    public class Person
    {
        #region fields
        private int personNum;
        private string name;
        //private PictureBox sprite;
        private string dialog;
        private Question question;
        private bool solved;
        private Label labelDialog;
        private int x;
        private int y;
        private Image sprite;
        private Size size;
        private string greetingSound;
        private string deathSound;
        private Rectangle npcHitbox;
        #endregion

        #region constructors
        public Person(int personNum, string name, Image image, Size size, string dialog, int x, int y, string greeting, string death, Question question)
        {
            this.PersonNum = personNum;
            this.Name = name;
            this.Sprite = image;
            this.Size = size;
            this.X = x;
            this.Y = y;
            this.Dialog = dialog;
            this.Solved = false;
            this.Question = question;
            this.GreetingSound = greeting;
            this.DeathSound = death;
            this.NpcHitbox = new Rectangle(this.X, this.Y, this.Size.Width - 60, this.Size.Height - 60);
        }

        public Person(int personNum, string name, Image image, Size size, string dialog, int x, int y, string greeting, string death)
        {
            this.PersonNum = personNum;
            this.Name = name;
            this.Sprite = image;
            this.Size = size;
            this.X = x;
            this.Y = y;
            this.Dialog = dialog;
            this.Solved = false;
            this.Question = null;
            this.GreetingSound = greeting;
            this.DeathSound = death;
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
        public string Dialog { get => dialog; set => dialog = value; }
        public Question Question { get => question; set => question = value; }
        public bool Solved { get => solved; protected set => solved = value; }
        public Label LabelDialog { get => labelDialog; set => labelDialog = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Image Sprite { get => sprite; set => sprite = value; }
        public Size Size { get => size; set => size = value; }
        public string GreetingSound { get => greetingSound; set => greetingSound = value; }
        public string DeathSound { get => deathSound; set => deathSound = value; }
        public Rectangle NpcHitbox { get => npcHitbox; private set => npcHitbox = value; }
        #endregion

        #region methods
        public string DisplayData()
        {
            return "Hello.. I'm " + this.Name + ".\n" + this.Dialog + "Press 'y' to continue";
        }

        public void DisplayDialog(Control container)
        {

            labelDialog = new Label();
            labelDialog.AutoSize = true;
            labelDialog.Parent = container;
            labelDialog.MaximumSize = new Size(container.Width - 40, 0);
           
            labelDialog.Font = new Font("Plus Jakarta Sans", 18);
            labelDialog.TextAlign = ContentAlignment.TopCenter;
            labelDialog.Padding = new Padding(10, 10, 10, 10);
            labelDialog.BackColor = Color.FromArgb(180, 0, 0, 0);
            labelDialog.ForeColor = Color.White;
            labelDialog.BorderStyle = BorderStyle.FixedSingle;

            labelDialog.Text = this.DisplayData();
            labelDialog.Location = new Point((container.Width - labelDialog.Width) / 2, 10);
            labelDialog.Visible = true;
            labelDialog.BringToFront();
        }

        public void RemoveDialog()
        {
            if(labelDialog != null)
            {
                labelDialog.Dispose();
            }     
        }

        public void AddQuestion(string question, string answer, int score)
        {
            this.Question = new Question(question, answer, score);
        }

        // Sanitize text helper function for CheckAnswer
        private string SanitizeText(string text)
        {
            string sanitized = text.Trim().ToLower();

            string[] punctuation = new string[] { ".", ",", "!", "?", "'", "\"", "-", "&" };

            foreach (string p in punctuation)
            {
                sanitized = sanitized.Replace(p, "");
            }

            if (sanitized.StartsWith("the ")) sanitized = sanitized.Substring(4);
            if (sanitized.StartsWith("an ")) sanitized = sanitized.Substring(3);
            if (sanitized.StartsWith("a ")) sanitized = sanitized.Substring(2);
            if (sanitized.EndsWith("s")) sanitized = sanitized.Substring(0, sanitized.Length - 1);

            return sanitized.Trim();
        }

        public int CheckAnswer(Question questionToCheck, string answer) // Put question as parameter to enable CheckAnswer() from boss (avoid repeating code)
            // The core CheckAnswer method now only returns the score due to differences in handling this.Solved for normal single-question NPC and Boss
        {
            // Check if data is broken or input is completely empty
            if (questionToCheck == null || string.IsNullOrWhiteSpace(answer))
            {
                return 0;
            }

            // Sanitize both player answer and the correct answer
            string sanitizedPlayerAnswer = SanitizeText(answer);
            string sanitizedCorrectAnswer = SanitizeText(questionToCheck.Answer);

            // DEMONSTRATION PURPOSES: "oop" as extra answer key
            if (sanitizedPlayerAnswer == "oop")
            {
                return questionToCheck.Score;
            }

            // 1. Return score if they're exactly the same
            if (sanitizedPlayerAnswer == sanitizedCorrectAnswer)
            {
                return questionToCheck.Score;
            }

            // 2. Return score answer is numeric and has the same numeric value (anticipating unit like "cm" in player answer or answer key
            if (sanitizedPlayerAnswer.Length > 0 && char.IsDigit(sanitizedPlayerAnswer[0]) && sanitizedCorrectAnswer.StartsWith(sanitizedPlayerAnswer))
            {
                return questionToCheck.Score;
            }

            // 3. Return score if  player typed a significant portion of a multi-word or long answer
            bool isSubstantialAnswer = sanitizedPlayerAnswer.Contains(" ") || sanitizedPlayerAnswer.Length > 5;

            if (isSubstantialAnswer && sanitizedCorrectAnswer.Contains(sanitizedPlayerAnswer))
            {
                return questionToCheck.Score;
            }

            // Else the answer is completely wrong
            return 0;
        }

        public int CheckAnswer(string answer) // method overloading 
        {
            // Call the core CheckAnswer method
            int score = CheckAnswer(this.Question, answer);

            // Solved logic for normal NPC (only one queestion)
            if (score > 0)
            {
                this.Solved = true;
            }

            return score;
        }
        #endregion
    }
}