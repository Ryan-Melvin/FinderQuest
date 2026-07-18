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
    public partial class FormGameHistory : Form
    {
        public FormGameHistory()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        FormProfile profileForm;
        private List<PlayReport> displayHistory;

        private void RefreshHistory()
        {
            // Create a separate list so the account's original
            displayHistory = new List<PlayReport>(profileForm.mainForm.account.GameHistory);

            SortHistory();
            DisplayHistory();
        }

        private void SortHistory()
        {
            string selectedSort = comboBoxSort.Text;

            if (selectedSort == "Play Date / Time")
            {
                displayHistory.Sort(
                    (firstReport, secondReport) =>
                        firstReport.PlayDateTime.CompareTo(secondReport.PlayDateTime));
            }
            else if (selectedSort == "Time Played")
            {
                displayHistory.Sort(
                    (firstReport, secondReport) =>
                        firstReport.TimePlayed.ConvertToSecond().CompareTo(
                        secondReport.TimePlayed.ConvertToSecond()));
            }
            else if (selectedSort == "Final Score")
            {
                displayHistory.Sort(
                    (firstReport, secondReport) =>
                        firstReport.FinalScore.CompareTo(secondReport.FinalScore));
            }

            if (radioButtonDescending.Checked)
            {
                displayHistory.Reverse();
            }
        }

        private void DisplayHistory()
        {
            listBoxDisplay.Items.Clear();

            if (displayHistory.Count == 0)
            {
                listBoxDisplay.Items.Add("No game history yet.");
                return;
            }

            foreach (PlayReport report in displayHistory)
            {
                listBoxDisplay.Items.AddRange(report.DisplayData().Split('\n'));
                listBoxDisplay.Items.Add("----------------------------------------");}
        }


        private void FormGameHistory_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            profileForm = (FormProfile)this.Owner;

            comboBoxSort.Items.Clear();
            comboBoxSort.Items.Add("Play Date / Time");
            comboBoxSort.Items.Add("Time Played");
            comboBoxSort.Items.Add("Final Score");

            comboBoxSort.SelectedIndex = 0;
            radioButtonDescending.Checked = true;

            RefreshHistory();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshHistory();
        }

        private void radioButtonAscending_CheckedChanged(object sender, EventArgs e)
        {
            RefreshHistory();
        }
    }
}
