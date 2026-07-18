using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinderQuest
{
    public partial class FormDialogNewSave : Form
    {
        public FormDialogNewSave()
        {
            InitializeComponent();
            textBoxPlayerName.MaxLength = 12;
        }

        FormProfile profileForm;
        private void FormDialogNewSave_Load(object sender, EventArgs e)
        {
            profileForm = (FormProfile)this.Owner;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string playerName = textBoxPlayerName.Text.Trim();
            string saveFileName = textBoxSaveFile.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please enter a player name.");
                textBoxPlayerName.Focus();
                return;
            }

            foreach (char character in saveFileName)
            {
                if (!char.IsLetterOrDigit(character) && character != '-' && character != '_')
                {
                    MessageBox.Show("Save file name may only contain letters, numbers, hyphens (-), and underscores (_).");

                    textBoxSaveFile.Focus();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(saveFileName))
            {
                MessageBox.Show("Please enter a save file name.");
                textBoxSaveFile.Focus();
                return;
            }

            saveFileName += ".fqs";

            FormProfile profileForm = (FormProfile)this.Owner;
            string fullPath = Path.Combine(Application.StartupPath, "Saves", saveFileName);

            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Saves"));

            if (File.Exists(fullPath))
            {
                MessageBox.Show("A save file with that name already exists.");
                textBoxSaveFile.Focus();
                return;
            }

            profileForm.mainForm.account.PlayerName = playerName;
            profileForm.mainForm.account.SaveFileName = saveFileName;
            profileForm.mainForm.SaveAccount(saveFileName);

            MessageBox.Show("New save created successfully!");
            profileForm.Close();
            this.Close();
        }
    }
}
