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

        public FormQuestion()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {
            mainForm = (FormMain)this.Owner;
            GenerateQuestion();
            if(mainForm.game.ActivePerson is Boss)
            {
                mainForm.game.PlaySound("area8-Battle");
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Evaluate the input string against the underlying data property
            int score = 0;
            if(mainForm.game.ActivePerson is Boss boss)
            {
                score = boss.CheckAnswer(mainForm.game.BossQuestionNum, textBoxAnswer.Text);
            }
            else
            {
                score = mainForm.game.ActivePerson.CheckAnswer(textBoxAnswer.Text);
            }
            

            if (score != 0)
            {
                MessageBox.Show("Your answer is correct! you get " + score + " points.");

                mainForm.player.AddScore(score);
                mainForm.labelPlayer.Text = mainForm.player.DisplayData();
                mainForm.time.AddWithSecond(30);
            }
            else
            {
                MessageBox.Show("Sorry, your answer is incorrect! ");
            }
            if(mainForm.game.ActivePerson is Boss x && mainForm.game.BossQuestionNum < x.Questions.Count - 1)
            {
                if(score != 0)
                {
                    mainForm.game.BossQuestionNum++;
                }
                GenerateQuestion();
            }
            else
            {
                this.Close();
                mainForm.ExitTalkArea();
            }     
        }

        private void GenerateQuestion()
        {
            if (mainForm.game.ActivePerson is Boss boss)
            {
                labelQuestion.Text = boss.Questions[mainForm.game.BossQuestionNum].TheQuestion;
            }
            else
            {
                labelQuestion.Text = mainForm.game.ActivePerson.Question.TheQuestion;
            }

            labelQuestion.AutoSize = true;
            labelQuestion.MaximumSize = new Size(this.ClientSize.Width - 40, 0);

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
            labelQuestion.Location = new Point((this.ClientSize.Width - labelQuestion.Width) / 2, 50);
            textBoxAnswer.Focus();
        }

        private void FormQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonSubmit_Click(sender, e);
            }
        }

        private void FormQuestion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(mainForm.game.ActivePerson is Boss)
            {
                mainForm.game.PlaySound("area8-Ambient");
            }
        }
    }
}