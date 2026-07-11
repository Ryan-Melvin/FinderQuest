namespace FinderQuest
{
    partial class FormSkins
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panelSkin = new System.Windows.Forms.Panel();
            this.labelSkinPrice = new System.Windows.Forms.Label();
            this.labelSkinName = new System.Windows.Forms.Label();
            this.panelShowSkin = new System.Windows.Forms.Panel();
            this.labelPrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.buttonEquip = new System.Windows.Forms.Button();
            this.labelEquippedSkin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(511, 0);
            this.vScrollBar1.Maximum = 500;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(23, 460);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // panelSkin
            // 
            this.panelSkin.AutoScroll = true;
            this.panelSkin.AutoScrollMinSize = new System.Drawing.Size(5, 5);
            this.panelSkin.BackColor = System.Drawing.Color.White;
            this.panelSkin.Location = new System.Drawing.Point(-1, 0);
            this.panelSkin.Name = "panelSkin";
            this.panelSkin.Size = new System.Drawing.Size(510, 980);
            this.panelSkin.TabIndex = 1;
            this.panelSkin.Click += new System.EventHandler(this.panelSkin_Click);
            this.panelSkin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSkin_Paint);
            // 
            // labelSkinPrice
            // 
            this.labelSkinPrice.AutoSize = true;
            this.labelSkinPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelSkinPrice.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSkinPrice.Location = new System.Drawing.Point(229, 312);
            this.labelSkinPrice.Name = "labelSkinPrice";
            this.labelSkinPrice.Size = new System.Drawing.Size(93, 28);
            this.labelSkinPrice.TabIndex = 2;
            this.labelSkinPrice.Text = "SkinPrice";
            // 
            // labelSkinName
            // 
            this.labelSkinName.AutoSize = true;
            this.labelSkinName.BackColor = System.Drawing.Color.Transparent;
            this.labelSkinName.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSkinName.Location = new System.Drawing.Point(15, 312);
            this.labelSkinName.Name = "labelSkinName";
            this.labelSkinName.Size = new System.Drawing.Size(101, 28);
            this.labelSkinName.TabIndex = 1;
            this.labelSkinName.Text = "SkinName";
            // 
            // panelShowSkin
            // 
            this.panelShowSkin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelShowSkin.Location = new System.Drawing.Point(23, 24);
            this.panelShowSkin.Name = "panelShowSkin";
            this.panelShowSkin.Size = new System.Drawing.Size(280, 280);
            this.panelShowSkin.TabIndex = 3;
            this.panelShowSkin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelShowSkin_Paint);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelPrice.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(167, 312);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(65, 28);
            this.labelPrice.TabIndex = 3;
            this.labelPrice.Text = "Price: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.panelShowSkin);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.labelSkinPrice);
            this.panel1.Controls.Add(this.labelSkinName);
            this.panel1.Location = new System.Drawing.Point(551, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 349);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(546, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Coin: ";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrency.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.Location = new System.Drawing.Point(599, 9);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(86, 28);
            this.labelCurrency.TabIndex = 5;
            this.labelCurrency.Text = "Currency";
            // 
            // buttonBuy
            // 
            this.buttonBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuy.Location = new System.Drawing.Point(723, 413);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(153, 36);
            this.buttonBuy.TabIndex = 4;
            this.buttonBuy.Text = "Buy Skin";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // buttonEquip
            // 
            this.buttonEquip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEquip.Location = new System.Drawing.Point(551, 413);
            this.buttonEquip.Name = "buttonEquip";
            this.buttonEquip.Size = new System.Drawing.Size(153, 35);
            this.buttonEquip.TabIndex = 6;
            this.buttonEquip.Text = "Equip Skin";
            this.buttonEquip.UseVisualStyleBackColor = true;
            this.buttonEquip.Click += new System.EventHandler(this.buttonEquip_Click);
            // 
            // labelEquippedSkin
            // 
            this.labelEquippedSkin.AutoSize = true;
            this.labelEquippedSkin.BackColor = System.Drawing.Color.Transparent;
            this.labelEquippedSkin.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEquippedSkin.Location = new System.Drawing.Point(732, 9);
            this.labelEquippedSkin.Name = "labelEquippedSkin";
            this.labelEquippedSkin.Size = new System.Drawing.Size(51, 28);
            this.labelEquippedSkin.TabIndex = 7;
            this.labelEquippedSkin.Text = "Skin";
            // 
            // FormSkins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(892, 461);
            this.Controls.Add(this.labelEquippedSkin);
            this.Controls.Add(this.buttonEquip);
            this.Controls.Add(this.buttonBuy);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.panelSkin);
            this.Controls.Add(this.panel1);
            this.Name = "FormSkins";
            this.Text = "Skins";
            this.Load += new System.EventHandler(this.FormSkins_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panelSkin;
        private System.Windows.Forms.Label labelSkinName;
        private System.Windows.Forms.Label labelSkinPrice;
        private System.Windows.Forms.Panel panelShowSkin;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button buttonEquip;
        private System.Windows.Forms.Label labelEquippedSkin;
    }
}