using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    public class Boss : Person
    {
        #region fields
        private List<Question> questions;
        #endregion

        #region constructors
        public Boss(int num, string name, Image image, Size size, string dialog, int x, int y, string greet, string death, List<Question> questions) : base(num, name, image, size, dialog, x, y, greet, death, null)
        {
            this.Questions = questions;
        }

        public Boss(int num, string name, Image image, Size size, string dialog, int x, int y, string greet, string death) : base(num, name, image, size, dialog, x, y, greet, death)
        {
            this.Questions = null;
        }
        #endregion

        #region properties
        public List<Question> Questions { get => questions; set => questions = value; }
        #endregion

        #region methods
        public int CheckAnswer(int questionNum, string answer)
        {
            if (this.Questions == null || questionNum < 0 || questionNum >= this.Questions.Count)
            {
                return 0;
            }

            // Call the CheckAnswer method on the parent to get the score of the specific question
            int score = base.CheckAnswer(this.Questions[questionNum], answer);

            // Solved logic for boss (only solved if it's the final question)
            if (score > 0 && questionNum == this.Questions.Count - 1)
            {
                this.Solved = true;
            }

            return score;
        }

        #endregion
    }
}