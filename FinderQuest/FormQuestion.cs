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
    public partial class FormQuestion : Form
    {
        public FormQuestion()
        {
            InitializeComponent();
        }


        FormMain game;
        private void FormQuestion_Load(object sender, EventArgs e)
        {
            game = (FormMain)this.Owner;
            labelQuestion.Text = game.activePerson.Question.TheQuestion;
            this.BackgroundImage = game.BackgroundImage;
            labelAnswer.BackColor = Color.FromArgb(120, 0, 0, 0);
            labelAnswer.ForeColor = Color.White;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int score = game.activePerson.CheckAnswer(textBoxAnswer.Text);
            if (score != 0)
            {
                MessageBox.Show("Your Answer is correct! you get " + score + " points.");
                game.player.AddScore(score);
                game.labelPlayer.Text = game.player.DisplayData();
            }
            else
            {
                MessageBox.Show("Sorry, your answer is incorrect! ");
            }
            this.Close();
            game.ExitTalkArea();
        }
    }
}
