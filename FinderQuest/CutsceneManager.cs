using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace FinderQuest
{
    public class CutsceneManager
    {
        #region methods
        public async Task PlayGoodEnding(FormMain form, ToolStripMenuItem pause, ToolStripMenuItem start, Label labelCutscene, Label labelSkip, CancellationToken skip)
        {
            form.SetAllowSkipCutscene(true);
            pause.Enabled = false;
            start.Enabled = false;
            try
            {
                form.SetInCutscene(true);
                form.sound.Fade = 8;
                form.BackgroundImage = Properties.Resources.BackgroundWin;
                form.game.CurrWalkArea.RemovePeople();
                form.game.CurrWalkArea = null;
                form.SetGameStarted(false);
                form.GetGamePanel().Visible = false;

                labelCutscene.Text = "";
                labelCutscene.Parent = form;
                labelCutscene.BringToFront();
                labelCutscene.Font = new Font("Garamond", 16, FontStyle.Bold);
                labelCutscene.ForeColor = Color.White;
                labelCutscene.BackColor = Color.FromArgb(180, 0, 0, 0);
                labelCutscene.TextAlign = ContentAlignment.MiddleCenter;
                labelCutscene.AutoSize = true;
                labelCutscene.MaximumSize = new Size(form.ClientSize.Width - 80, 0);

                await AnimateText(form, labelCutscene, "The Oracle's ancient gaze shattered into blinding fragments...", skip);
                await Task.Delay(2500, skip);

                labelSkip.Parent = form;
                labelSkip.Text = "Press Enter to Skip";
                labelSkip.BackColor = Color.FromArgb(120, 0, 0, 0);
                labelSkip.Font = new Font("Garamond", 12);
                labelSkip.ForeColor = Color.White;
                labelSkip.Location = new Point(form.ClientSize.Width / 2 - (labelSkip.Width / 2), form.ClientSize.Height - labelSkip.Height - 20);
                labelSkip.Visible = true;
                labelSkip.BringToFront();

                await AnimateText(form, labelCutscene, "Warm, long-forgotten light cascaded over the valleys of the realm.", skip);
                await Task.Delay(4000, skip);

                await AnimateText(form, labelCutscene, "A broken crown rests on the altar, its curse lifted forevermore.", skip);
                await Task.Delay(4000, skip);

            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                form.SetAllowSkipCutscene(false);
                labelSkip.Visible = false;
                labelCutscene.Text = "";
                form.BackgroundImage = Properties.Resources.WinTextGoIn;
                form.AnimateMainMenu();
                await Task.Delay(2400);
                form.BackgroundImage = Properties.Resources.WinEnterToReturn;
                form.AnimateMainMenu();
                form.SetAllowReturnMainMenu(true);
            }

        }

        public async Task PlayBadEnding(FormMain form, ToolStripMenuItem pause, ToolStripMenuItem start, Label labelCutscene, Label labelSkip, CancellationToken skip)
        {
            form.SetAllowSkipCutscene(true);
            pause.Enabled = false;
            start.Enabled = false;
            try
            {
                form.SetInCutscene(true);
                form.sound.Fade = 8;
                form.BackgroundImage = Properties.Resources.BackgroundLose;
                form.game.CurrWalkArea.RemovePeople();
                form.game.CurrWalkArea = null;
                form.SetGameStarted(false);
                form.GetGamePanel().Visible = false;

                labelCutscene.Text = "";
                labelCutscene.Parent = form;
                labelCutscene.BringToFront();
                labelCutscene.Font = new Font("Garamond", 16, FontStyle.Bold);
                labelCutscene.ForeColor = Color.White;
                labelCutscene.BackColor = Color.FromArgb(180, 0, 0, 0);
                labelCutscene.TextAlign = ContentAlignment.MiddleCenter;
                labelCutscene.AutoSize = true;
                labelCutscene.MaximumSize = new Size(form.ClientSize.Width - 80, 0);

                await AnimateText(form, labelCutscene, "The walls of the sanctuary crumbled...", skip);
                await Task.Delay(3500, skip);

                //allowSkipCutscene = true;
                labelSkip.Parent = form;
                labelSkip.Text = "Press Enter to Skip";
                labelSkip.BackColor = Color.FromArgb(120, 0, 0, 0);
                labelSkip.Font = new Font("Garamond", 12);
                labelSkip.ForeColor = Color.White;
                labelSkip.Location = new Point(form.ClientSize.Width / 2 - (labelSkip.Width / 2), form.ClientSize.Height - labelSkip.Height - 20);
                labelSkip.Visible = true;
                labelSkip.BringToFront();

                await AnimateText(form, labelCutscene, "The hero fell to their knees as darkness swallowed the throne room.", skip);
                await Task.Delay(4000, skip);
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                form.SetAllowSkipCutscene(false);
                labelCutscene.Text = "";
                labelSkip.Visible = false;
                form.BackgroundImage = Properties.Resources.GameOverTextGoIn;
                form.AnimateMainMenu();
                await Task.Delay(2400);
                form.BackgroundImage = Properties.Resources.GameOverEnterToReturn;
                form.AnimateMainMenu();

                form.SetAllowReturnMainMenu(true);
            }
        }

        public async Task PlayOpeningCutscene(FormMain form, ToolStripMenuItem start, Label labelCutscene, Label labelSkip, CancellationToken skip)
        {
            form.SetAllowSkipCutscene(true);
            start.Enabled = false;
            try
            {
                form.SetInCutscene(true); //blocks player input
                form.sound.Fade = 8;
                form.sound.PlaySound("opening");
                form.BackgroundImage = Properties.Resources.OnceUponATime;
                double scaleX = (double)form.ClientSize.Width / 800.0;

                labelCutscene.Text = "";
                labelCutscene.Parent = form;
                labelCutscene.BringToFront();
                labelCutscene.Font = new Font("Edwardian Script ITC", 16, FontStyle.Bold);
                labelCutscene.ForeColor = Color.White;
                labelCutscene.BackColor = Color.Transparent;
                labelCutscene.TextAlign = ContentAlignment.MiddleCenter;
                labelCutscene.AutoSize = true;
                labelCutscene.MaximumSize = new Size(form.ClientSize.Width - 80, 0);

                await AnimateText(form, labelCutscene,"Once Upon A Time..", skip);
                await Task.Delay(2480, skip);

                labelCutscene.BackColor = Color.FromArgb(180, 0, 0, 0);
                labelCutscene.Font = new Font("Garamond", 16, FontStyle.Bold);
                form.BackgroundImage = Properties.Resources.Opening;

                await AnimateText(form, labelCutscene, "There was a kingdom hidden away in the valleys.", skip);
                await Task.Delay(1000, skip);

                labelSkip.Parent = form;
                labelSkip.Text = "Press Enter to Skip";
                labelSkip.BackColor = Color.FromArgb(120, 0, 0, 0);
                labelSkip.Font = new Font("Garamond", 12);
                labelSkip.ForeColor = Color.White;
                labelSkip.Location = new Point(form.ClientSize.Width / 2 - (labelSkip.Width / 2), form.ClientSize.Height - labelSkip.Height - 20);
                labelSkip.Visible = true;
                labelSkip.BringToFront();

                await AnimateText(form, labelCutscene, "Where a golden crown held the realm's light in harmony.", skip);
                await Task.Delay(1000, skip);

                form.game.CurrWalkArea = form.game.CurrWalkArea = new WalkArea("The Oracle's Sanctum", Properties.Resources.throne_room, 8);
                form.game.CurrWalkArea.AddPerson(19, "The Oracle", Properties.Resources.DarkApprentice_Idle_Left, new Size(form.GetSize("boss"), form.GetSize("boss")), "", form.ClientSize.Width / 2 - (form.GetSize("boss") / 2), form.ClientSize.Height / 2 - (form.GetSize("boss") - form.GetPlayerSize().Height - 20), "", "");
        
                foreach (Person person in form.game.CurrWalkArea.People)
                {
                    form.AnimatePerson(person);
                }

                await AnimateText(form, labelCutscene, "But the Oracle betrayed the light.. ", skip, 40);
                await Task.Delay(1420, skip);

                labelSkip.Visible = false;

                await AnimateText(form, labelCutscene, "seizing the throne room and binding the golden crown in an eternal curse.", skip, 40);
                await Task.Delay(1420, skip);

                form.game.CurrWalkArea.RemovePeople();
                form.game.CurrWalkArea = new WalkArea("Reaper's Domain", Properties.Resources.ReaperHallway, 7);

                form.game.CurrWalkArea.AddPerson(17, "Grim", Properties.Resources.Reaper_Idle_Right, new Size(form.GetSize("medium"), form.GetSize("medium")), "", (int)(180 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") - form.GetPlayerSize().Height), "", "");
                form.game.CurrWalkArea.AddPerson(18, "Azrael", Properties.Resources.DeathReaper_Idle_Left, new Size(form.GetSize("medium"), form.GetSize("medium")), "", (int)(420 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("medium") -form.GetPlayerSize().Height), "", "");

                foreach (Person person in form.game.CurrWalkArea.People)
                {
                    form.AnimatePerson(person);
                }

                await AnimateText(form, labelCutscene, "With the crown corrupted, ancient gates shattered under waves of howling anomalies...", skip, 40);
                await Task.Delay(3000, skip);

                form.game.CurrWalkArea.RemovePeople();
                form.game.CurrWalkArea = new WalkArea("The Zombie Outpost", Properties.Resources.AbandonedVillage, 3);

                form.game.CurrWalkArea.AddPerson(6, "Zombie Stalker", Properties.Resources.Zombie_Idle_Right, new Size(form.GetSize("small"), form.GetSize("small")), "", (int)(140 * scaleX), form.ClientSize.Height / 2, "", "");
                form.game.CurrWalkArea.AddPerson(7, "Zombie Spitter", Properties.Resources.ZombieVillager_Idle_Right, new Size(form.GetSize("small"), form.GetSize("small")), "", (int)(400 * scaleX), form.ClientSize.Height / 2, "", "");
                form.game.CurrWalkArea.AddPerson(8, "Zombie Tank", Properties.Resources.Husk_Idle_Left, new Size(form.GetSize("big"), form.GetSize("big")), "", (int)(650 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "", "");

                foreach (Person person in form.game.CurrWalkArea.People)
                {
                    form.AnimatePerson(person);
                }

                await AnimateText(form, labelCutscene, "Spreading like a plague, monsters overran the peaceful valleys...", skip, 40);
                await Task.Delay(3000, skip);

                form.game.CurrWalkArea.RemovePeople();
                form.game.CurrWalkArea = new WalkArea("Titan's Ridge", Properties.Resources.GolemLands, 2);

                form.game.CurrWalkArea.AddPerson(4, "Rock Golem", Properties.Resources.RockGolem_Idle_Right, new Size(form.GetSize("big"), form.GetSize("big")), "", (int)(160 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "", "");
                form.game.CurrWalkArea.AddPerson(5, "Moss Golem", Properties.Resources.MossGolem_Idle_Left, new Size(form.GetSize("big"), form.GetSize("big")), "", (int)(650 * scaleX), form.ClientSize.Height / 2 - (form.GetSize("big") - form.GetPlayerSize().Height), "", "");

                foreach (Person person in form.game.CurrWalkArea.People)
                {
                    form.AnimatePerson(person);
                }

                await AnimateText(form, labelCutscene, "Leaving only ash, ruins, and a lone hero destined to break the curse.", skip, 40);
                await Task.Delay(4000, skip);

                form.game.CurrWalkArea.RemovePeople();
                form.game.CurrWalkArea = null;

                labelCutscene.Font = new Font("Edwardian Script ITC", 16, FontStyle.Bold);
                labelCutscene.ForeColor = Color.White;
                labelCutscene.BackColor = Color.Transparent;
                form.BackgroundImage = Properties.Resources.OnceUponATime;
                await AnimateText(form, labelCutscene, "Be That Hero.", skip);
                await Task.Delay(2480, skip);
            }
            catch (OperationCanceledException)
            {
                //leave empty
            }
            finally
            {
                start.Enabled = true;
                labelCutscene.Text = "";
                form.SetAllowSkipCutscene(false);
                form.SetInCutscene(false);
                form.sound.Fade = 4;
            }
            labelSkip.Visible = false;
        }

        private async Task AnimateText(FormMain form, Label labelCutscene, string text, CancellationToken skip, int height = 0)
        {
            labelCutscene.Text = "";

            try
            {
                foreach (char c in text)
                {
                    labelCutscene.Text += c;
                    if (height == 0)
                    {
                        labelCutscene.Location = new Point(form.ClientSize.Width / 2 - (labelCutscene.Width / 2), form.ClientSize.Height / 2 - (labelCutscene.Height / 2) + 15);
                    }
                    else
                    {
                        labelCutscene.Location = new Point(form.ClientSize.Width / 2 - (labelCutscene.Width / 2), height);
                    }
                    await Task.Delay(40, skip);
                }

            }
            catch (OperationCanceledException)
            {

            }
        }

        private void AnimationTimer_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}