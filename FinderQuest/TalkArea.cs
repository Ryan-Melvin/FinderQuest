using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    public class TalkArea : Area
    {
        #region fields
        private Person person;
        #endregion

        #region constructors
        public TalkArea(string name, Image background, Person person): base(name, background)
        {
            this.Person = person;
        }
        #endregion

        #region properties
        public Person Person { get => person; set => person = value; }
        #endregion

        #region methods
        public override string DisplayData()
        {
            return this.Person.Name + "'s Talk Area \n" + base.DisplayData();
        }


        #endregion

    }
}