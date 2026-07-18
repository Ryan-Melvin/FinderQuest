using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinderQuest
{
    public partial class FormQuestion : Form
    {
        // Reference to our main game window canvas frame interface
        private FormMain mainForm;

        private void GenerateQuestion()
        {
            if (mainForm.game.ActivePerson is Boss boss)
            {
                labelQuestion.Text = boss.Questions[mainForm.game.BossQuestionNum].TheQuestion;
                int questionScore = boss.Questions[mainForm.game.BossQuestionNum].Score;
                UpdateQuestionScoreLabel(questionScore);
            }
            else
            {
                labelQuestion.Text = mainForm.game.ActivePerson.Question.TheQuestion;
                int questionScore = mainForm.game.ActivePerson.Question.Score;
                UpdateQuestionScoreLabel(questionScore);
            }

            labelQuestion.AutoSize = true;
            labelQuestion.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
            labelQuestion.Location = new Point((this.ClientSize.Width - labelQuestion.Width) / 2, 50);

            textBoxAnswer.Focus();
        }

        private void SpawnFloatingTimeIndicator(string text, Color displayColor)
        {
            Label indicator = new Label();
            indicator.Text = text;
            indicator.Font = new Font("Plus Jakarta Sans", 14, FontStyle.Bold);
            indicator.ForeColor = displayColor;
            indicator.BackColor = Color.FromArgb(80, 0, 0, 0);
            indicator.AutoSize = true;

            indicator.Location = new Point(
                labelTimerQuestion.Left + (labelTimerQuestion.Width / 2) - 25,
                labelTimerQuestion.Top - 30
            );

            this.Controls.Add(indicator);
            indicator.BringToFront();

            mainForm.game.RegisterFloatingLabel(indicator);
        }

        private void UpdateQuestionScoreLabel(int questionScore)
        {
            labelQuestionScore.Text = "Score: " + questionScore;

            if (questionScore == 100)
            {
                labelQuestionScore.ForeColor = Color.LimeGreen;
            }
            else if (questionScore == 200)
            {
                labelQuestionScore.ForeColor = Color.AntiqueWhite;
            }
            else if (questionScore == 300)
            {
                labelQuestionScore.ForeColor = Color.Salmon;
            }
        }

        public FormQuestion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            mainForm = (FormMain)this.Owner;

            this.BackgroundImage = mainForm.BackgroundImage;
            labelAnswer.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelAnswer.ForeColor = Color.White;

            labelQuestion.BackColor = Color.FromArgb(180, 0, 0, 0);
            labelQuestion.ForeColor = Color.White;
            buttonSubmit.BackColor = Color.FromArgb(120, 0, 0, 0);
            buttonSubmit.ForeColor = Color.White;

            labelQuestion.BorderStyle = BorderStyle.FixedSingle;
            labelQuestion.Padding = new Padding(10, 10, 10, 10);
            labelQuestion.Font = new Font("Plus Jakarta Sans", 16, FontStyle.Bold);

            labelTimerQuestion.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelQuestionScore.BackColor = Color.FromArgb(120, 0, 0, 0);

            GenerateQuestion();
            if (mainForm.game.ActivePerson is Boss)
            {
                mainForm.sound.PlaySound("area8-Battle");
            }
            labelTimerQuestion.Text = mainForm.time.DisplayData();
            timerDisplayChange.Start();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int score = 0;
            if (mainForm.game.ActivePerson is Boss boss)
            {
                score = boss.CheckAnswer(mainForm.game.BossQuestionNum, textBoxAnswer.Text);
            }
            else
            {
                score = mainForm.game.ActivePerson.CheckAnswer(textBoxAnswer.Text);
            }

            if (score > 0)
            {
                mainForm.time.AddWithSecond(30);
                SpawnFloatingTimeIndicator("+30s", Color.LawnGreen);
                MessageBox.Show("Your answer is correct! you get " + score + " points.");
                mainForm.player.AddScore(score);
                if (!(mainForm.game.ActivePerson is Boss))
                {
                    mainForm.sound.PlaySFX(mainForm.game.ActivePerson.DeathSound);
                }
                else if (mainForm.game.BossQuestionNum == 6)
                {
                    mainForm.sound.PlaySFX(mainForm.game.ActivePerson.DeathSound);
                }
            }
            else
            {
                if (mainForm.game.ActivePerson is Boss)
                {
                    mainForm.time.AddWithSecond(-30);
                    SpawnFloatingTimeIndicator("-30s", Color.Red);
                }
                MessageBox.Show("Sorry, your answer is incorrect! ");
            }

            if (mainForm.game.ActivePerson is Boss x && mainForm.game.BossQuestionNum < x.Questions.Count - 1)
            {
                if (score > 0)
                {
                    mainForm.game.BossQuestionNum += 1;
                }
                this.textBoxAnswer.Text = "";
                GenerateQuestion();
            }
            else
            {
                textBoxAnswer.Text = "";
                this.Close();
                mainForm.talkArea.ExitTalkArea(mainForm);
            }     
        }

        private void FormQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSubmit_Click(sender, e);
            }
        }

        private void FormQuestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainForm.game.ActivePerson is Boss)
            {
                mainForm.sound.PlaySound("area8-Ambient");
            }
        }

        private void timerDisplayChange_Tick(object sender, EventArgs e)
        {
            labelTimerQuestion.Text = mainForm.time.DisplayData();
        }
    }
}