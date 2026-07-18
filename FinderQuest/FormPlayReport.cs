using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinderQuest
{
    public partial class FormPlayReport : Form
    {
        public FormPlayReport()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        FormMain mainForm;
        PlayReport report;

        private void EvaluateStars()
        {
            labelStars.Font = new Font("Arial", 50, FontStyle.Bold);
            labelStars.ForeColor = Color.Gold;
            labelStars.TextAlign = ContentAlignment.MiddleCenter;

            if (report.FinalScore < 3500)
            {
                labelStars.Text = "★☆☆☆☆";
                
                labelFeedback.Text = "I mean, every success starts somewhere...";
                labelFeedback.ForeColor = Color.LightCoral;
            }
            else if (report.FinalScore >= 3500 && report.FinalScore < 4800)
            {
                labelStars.Text = "★★☆☆☆";

                labelFeedback.Text = "Well, practice makes perfect. Keep on!";
                labelFeedback.ForeColor = Color.SandyBrown;
            }
            else if (report.FinalScore >= 4800 && report.FinalScore < 6000)
            {
                labelStars.Text = "★★★☆☆";

                labelFeedback.Text = "Not bad! You have the potential.";
                labelFeedback.ForeColor = Color.Khaki;
            }
            else if (report.FinalScore >= 6000 && report.FinalScore < 7000)
            {
                labelStars.Text = "★★★★☆";

                labelFeedback.Text = "Exceptional! The Oracle is impressed.";
                labelFeedback.ForeColor = Color.LightGreen;
            }
            else // 7000 or Higher
            {
                labelStars.Text = "★★★★★";
 
                labelFeedback.Text = "Legendary! The true Trivia Master!";
                labelFeedback.ForeColor = Color.PaleGreen;
            }
        }

        private void FormPlayReport_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Mountain;
            this.panelBack.BackColor = Color.FromArgb(150, 0, 0, 0);

            labelTitle.Font = new Font("Plus Jakarta Sans", 18, FontStyle.Bold);
            labelFeedback.Font = new Font("Garamond", 17, FontStyle.Bold);
            //labelStats.Font = new Font("Unispace", 13, FontStyle.Bold);
            //labelScore.Font = new Font("Unispace", 18, FontStyle.Bold);
            //labelGold.Font = new Font("Unispace", 24, FontStyle.Bold);

            mainForm = (FormMain)this.Owner;
            report = new PlayReport(DateTime.Now, mainForm.player.Score, mainForm.timePlayed.Hour, mainForm.timePlayed.Minute, mainForm.timePlayed.Second);

            mainForm.account.GoldBalance += report.GoldEarned;
            mainForm.account.AddGameHistory(report);

            labelStats.Text = "Base Score : " + report.Score + "pts\n" +
                              "Time Played : " + report.TimePlayed.DisplayData();
            EvaluateStars();
            labelScore.Text = report.FinalScore + "pts";
            labelGold.Text = report.GoldEarned + "G";
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPlayReport_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void panelBack_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelGold_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxGold_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
