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
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {
            mainForm = (FormMain)this.Owner;

            labelQuestion.Text = mainForm.game.ActivePerson.Question.TheQuestion;
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
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Evaluate the input string against the underlying data property
            int score = mainForm.game.ActivePerson.CheckAnswer(textBoxAnswer.Text);

            if (score != 0)
            {
                MessageBox.Show("Your answer is correct! you get " + score + " points.");

                mainForm.player.AddScore(score);
                mainForm.labelPlayer.Text = mainForm.player.DisplayData();
            }
            else
            {
                MessageBox.Show("Sorry, your answer is incorrect! ");
            }

            this.Close();
            mainForm.ExitTalkArea();
        }
    }
}