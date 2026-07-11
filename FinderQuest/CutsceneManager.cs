using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                form.game.Fade = 8;
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
                form.game.Fade = 8;
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
        #endregion
    }
}