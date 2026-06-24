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


        #endregion

        #region properties
        public List<Question> Questions { get => questions; set => questions = value; }
        #endregion

        #region methods
        public int CheckAnswer(int questionNum, string answer)
        {
            if (this.Questions[questionNum].Answer.ToLower().Contains(answer))
            {
                if(questionNum == 6)
                {
                    this.Solved = true;
                }
                return this.Questions[questionNum].Score;
            }
            return 0;
        }
        #endregion
    }
}