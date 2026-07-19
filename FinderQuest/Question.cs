using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    public class Question
    {
        #region fields
        private string theQuestion;
        private string answer;
        private int score;
        #endregion

        #region constructors
        public Question(string question, string answer, int score)
        {
            this.TheQuestion = question;
            this.Answer = answer;
            this.Score = score;
        }
        #endregion

        #region properties
        public string TheQuestion 
        { 
            get => this.theQuestion;
            set
            {
                if(value == "")
                {
                    throw new Exception("Question cannot be empty.");
                }
                else
                {
                    this.theQuestion = value;
                }
            }
        }
        public string Answer 
        { 
            get => this.answer;
            set
            {
                if (value == "")
                {
                    throw new Exception("Answer cannot be empty.");
                }
                else
                {
                    this.answer = value;
                }
            }
        }
        public int Score 
        { 
            get => this.score;
            set
            {
                if(value < 0)
                {
                    this.score = 0;
                }
                else
                {
                    this.score = value;
                }
            }
        }
        #endregion
    }
}