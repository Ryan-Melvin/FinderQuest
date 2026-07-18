using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    public class WalkArea : Area
    {
        #region fields
        private int areaNum;
        private List<Person> people;
        #endregion

        #region constructors
        public WalkArea (string name, Image background, int num) : base(name, background)
        {
            this.AreaNum = num;
            this.People = new List<Person>();
        }
        #endregion

        #region properties
        public int AreaNum { get => areaNum; set => areaNum = value; }
        public List<Person> People { get => people; set => people = value; }
        #endregion

        #region methods
        public override string DisplayData()
        {
            return "Area " + this.AreaNum + "\n" + base.DisplayData();
        }

        public void AddPerson(int num, string name, Image sprite, Size size, string dialog, int x, int y, string greet, string death, Question question)
        {
            Person person = new Person(num, name, sprite, size, dialog, x, y, greet, death, question);
            this.People.Add(person);
        }

        public void AddPerson(int num, string name, Image sprite, Size size, string dialog, int x, int y, string greet, string death)
        {
            Person person = new Person(num, name, sprite, size, dialog, x, y, greet, death);
            this.People.Add(person);
        }

        public void AddPerson(int num, string name, Image sprite, Size size, string dialog, int x, int y, string greet, string death, List<Question> questions)
        {
            Person person = new Boss(num, name, sprite, size, dialog, x, y, greet, death, questions);
            this.People.Add(person);
        }

        public void RemovePeople(FormMain form)
        {
            foreach (Person person in People)
            {
                ImageAnimator.StopAnimate(person.Sprite, form.OnGameFrameChanged);
            }
            this.People.Clear();
        }

        public bool CheckTouchPerson(Player player, out Person touchPerson)
        {

            Rectangle playerHitbox = player.PlayerHitbox;

            foreach(Person person in this.People)
            {
                Rectangle personHitbox = person.NpcHitbox;
                if (playerHitbox.IntersectsWith(personHitbox))
                {
                    touchPerson = person;
                    return true;
                }
            }
            touchPerson = null;
            return false;
            
        }

        public bool FinishedAllQuestions()
        {
            int solvedCounter = 0;
            foreach(Person person in this.People)
            {
                if (person.Solved)
                {
                    solvedCounter ++;
                }
            }

            if(solvedCounter == this.People.Count)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}