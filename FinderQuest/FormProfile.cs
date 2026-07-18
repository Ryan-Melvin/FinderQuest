using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinderQuest
{
    public partial class FormProfile : Form
    {

        public FormMain mainForm;
        Image equippedSkinSprite;

        private void AnimateEquippedSkin()
        {
            if (equippedSkinSprite == null)
            {
                return;
            }

            if (ImageAnimator.CanAnimate(equippedSkinSprite))
            {
                ImageAnimator.Animate(
                    equippedSkinSprite,
                    (sender, e) =>
                    {
                        panelProfileSkin.Invalidate();
                    }
                );
            }
        }

        public FormProfile()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelProfileSkin, new object[] { true });
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            mainForm = (FormMain)this.Owner;
            mainForm.sound.PlaySound("profile");

            equippedSkinSprite = (Image)Properties.Resources.ResourceManager.GetObject( mainForm.account.EquippedSkin + "_Idle_Right");

            labelName.Text = mainForm.account.PlayerName;
            labelGamesCompleted.Text = "Games Completed: " + mainForm.account.GameHistory.Count;
            labelSkinsCollected.Text = "Skins Collected: " + mainForm.account.OwnedSkins.Count + " / 17";
            labelHighScore.Text = mainForm.account.DetermineHighScore() + "pts";
            labelGoldBalance.Text = mainForm.account.GoldBalance + "G";
            labelTotalGold.Text = "Total Gold Earned: " + mainForm.account.CalculateTotalGold() + "G";

            AnimateEquippedSkin();

            panelProfileSkin.Invalidate();
        }

        private void panelProfileSkin_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.FromArgb(195, 199, 205);
            int borderWidth = 4;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen,
                    borderWidth / 2,
                    borderWidth / 2,
                    panelProfileSkin.Width - (int)(borderWidth * 1.5),
                    panelProfileSkin.Height - (int)(borderWidth * 1.5));
            }

            if (equippedSkinSprite == null)
            {
                return;
            }

            ImageAnimator.UpdateFrames(equippedSkinSprite);

            int drawSize = 280;

            int x = (panelProfileSkin.Width - drawSize) / 2;
            int y = (panelProfileSkin.Height - drawSize) / 2;

            e.Graphics.DrawImage(equippedSkinSprite, x, y, drawSize, drawSize);
        }

        private void buttonViewHistory_Click(object sender, EventArgs e)
        {
            FormGameHistory form = new FormGameHistory();
            form.Owner = this;
            form.ShowDialog();
        }

        private void buttonNewSave_Click(object sender, EventArgs e)
        {
            FormDialogNewSave form = new FormDialogNewSave();
            form.Owner = this;
            form.ShowDialog();
        }

        private void buttonSaveProgress_Click(object sender, EventArgs e)
        {
            if (mainForm.account.SaveFileName == null)
            {
                MessageBox.Show("No account is currently loaded (Guest).");
                return;
            }

            mainForm.SaveAccount(mainForm.account.SaveFileName);
            MessageBox.Show("Progress saved successfully.");
        }

        private void buttonLoadProgress_Click(object sender, EventArgs e)
        {
            FormDialogLoadProgress form = new FormDialogLoadProgress();
            form.Owner = this;
            form.ShowDialog();
        }
    }
}
