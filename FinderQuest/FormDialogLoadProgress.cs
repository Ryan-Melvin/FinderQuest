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
    public partial class FormDialogLoadProgress : Form
    {
        public FormDialogLoadProgress()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        FormProfile profileForm;
        private void FormDialogLoadProgress_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            profileForm = (FormProfile)this.Owner;
            string saveFolder = Path.Combine(Application.StartupPath, "Saves");

            comboBoxAccount.Items.Clear();

            if (!Directory.Exists(saveFolder))
            {
                MessageBox.Show("No save files found. Try creating a new save!");
                buttonLoad.Enabled = false;
                this.Close();
                return;
            }

            string[] saveFiles = Directory.GetFiles(saveFolder, "*.fqs");

            foreach (string fullPath in saveFiles)
            {
                comboBoxAccount.Items.Add(Path.GetFileName(fullPath));
            }

            if (comboBoxAccount.Items.Count > 0)
            {
                comboBoxAccount.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No save files found. Try creating a new save!");
                buttonLoad.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (comboBoxAccount.SelectedItem == null)
            {
                MessageBox.Show("Please select a save file.");
                return;
            }

            string selectedFileName = comboBoxAccount.SelectedItem.ToString();

            FormProfile profileForm = (FormProfile)this.Owner;
            profileForm.mainForm.LoadAccount(selectedFileName);

            MessageBox.Show("Save file loaded successfully!");

            profileForm.Close();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
