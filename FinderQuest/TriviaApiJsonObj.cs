using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    public class TriviaApiJsonObj
    {
        private string category;
        private string correctAnswer;
        private TriviaApiQuestionText question;
        private string difficulty;

        public string Category { get => category; set => category = value; }
        public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        public TriviaApiQuestionText Question { get => question; set => question = value; }
        public string Difficulty { get => difficulty; set => difficulty = value; }
    }
}