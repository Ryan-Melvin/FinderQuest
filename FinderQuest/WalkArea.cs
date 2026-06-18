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
            return "No. Area : " + this.AreaNum + " - " + base.DisplayData();
        }

        public void AddPerson(int num, string name, Image sprite, Size size, Point location, string dialog)
        {
            Person person = new Person(num, name, sprite, size, location, dialog);
            this.People.Add(person);
        }

        public void DisplayPeople(Control container)
        {
            foreach(Person person in this.People)
            {
                person.DisplayPicture(container);
            }
        }

        public void RemovePeople()
        {
            foreach (Person person in this.People)
            {
                person.Sprite.Dispose();
            }
            this.People.Clear();
        }

        public bool CheckTouchPerson(Player player, out Person touchPerson)
        {
            foreach(Person person in this.People)
            {
                if (player.Sprite.Bounds.IntersectsWith(person.Sprite.Bounds))
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