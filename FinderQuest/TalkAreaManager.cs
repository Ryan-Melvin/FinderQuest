using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace FinderQuest
{
    public class TalkAreaManager
    {
        #region methods
        public void GenerateTalkArea(FormMain form, Label labelTalkArea)
        {
            string roomName = form.game.GetTalkAreaName(form.game.CurrWalkArea.AreaNum);

            form.game.CurrTalkArea = new TalkArea(roomName, form.BackgroundImage, form.game.ActivePerson);

            labelTalkArea.Text = form.game.CurrTalkArea.DisplayData();
            labelTalkArea.Location = new Point(10, form.GetTalkAreaPanel().Height - labelTalkArea.Size.Height - 10);
        }

        public void EnterTalkArea(FormMain form, Label labelTalkArea)
        {
            GenerateTalkArea(form, labelTalkArea);
            form.sound.PlaySFX(form.game.ActivePerson.GreetingSound);
            form.SavePeronX(form.game.ActivePerson.X);
            form.SavePersonY(form.game.ActivePerson.Y);
            form.SavePersonSize(form.game.ActivePerson.Size);

            form.player.IsVisible = false;
            form.GetTalkAreaPanel().BringToFront();
            form.GetTalkAreaPanel().Visible = true;

            form.game.ActivePerson.Size = new Size(form.GetSize("medium") * 2, form.GetSize("medium") * 2);
            form.game.ActivePerson.X = form.GetTalkAreaPanel().ClientSize.Width / 2;
            form.game.ActivePerson.Y = form.GetTalkAreaPanel().Height - (form.GetSize("medium") * 2);

            form.SetEnterTalkArea(true);

            if (form.game.ActivePerson.Solved)
            {
                form. game.ActivePerson.Dialog = "Congrats, you solved my question!";
            }

            form.game.ActivePerson.DisplayDialog(form.GetTalkAreaPanel());
        }

        public void ExitTalkArea(FormMain form)
        {
            form.player.IsVisible = true;
            form.SetEnterTalkArea(false);

            form.GetTalkAreaPanel().Visible = false;
            if (form.game.ActivePerson != null)
            {
                form.game.ActivePerson.Size = form.GetPersonSize();
                form.game.ActivePerson.X = form.GetPersonX();
                form.game.ActivePerson.Y = form.GetPersonY();

                form.game.ActivePerson.RemoveDialog();
            }

            form.game.CurrTalkArea = null;

        }
        #endregion
    }
}