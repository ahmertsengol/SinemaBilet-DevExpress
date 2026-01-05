using DevExpress.XtraEditors;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmGiris
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
            pnlHeader = new PanelControl();
            lblBaslik = new LabelControl();
            lblAltBaslik = new LabelControl();
            pnlMain = new PanelControl();
            lblEmail = new LabelControl();
            txtEmail = new TextEdit();
            lblSifre = new LabelControl();
            txtSifre = new TextEdit();
            btnGiris = new SimpleButton();
            btnKaydol = new SimpleButton();
            lnkSifreUnuttum = new HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSifre.Properties).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Appearance.BackColor2 = Color.FromArgb(52, 73, 94);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblBaslik);
            pnlHeader.Controls.Add(lblAltBaslik);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(6, 6, 6, 6);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(848, 200);
            pnlHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBaslik.Appearance.ForeColor = Color.White;
            lblBaslik.Appearance.Options.UseFont = true;
            lblBaslik.Appearance.Options.UseForeColor = true;
            lblBaslik.Appearance.Options.UseTextOptions = true;
            lblBaslik.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            lblBaslik.AutoSizeMode = LabelAutoSizeMode.None;
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Margin = new Padding(6, 6, 6, 6);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(848, 100);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "🎬 SİNEMACI";
            // 
            // lblAltBaslik
            // 
            lblAltBaslik.Appearance.Font = new Font("Segoe UI", 11F);
            lblAltBaslik.Appearance.ForeColor = Color.White;
            lblAltBaslik.Appearance.Options.UseFont = true;
            lblAltBaslik.Appearance.Options.UseForeColor = true;
            lblAltBaslik.Appearance.Options.UseTextOptions = true;
            lblAltBaslik.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            lblAltBaslik.AutoSizeMode = LabelAutoSizeMode.None;
            lblAltBaslik.Dock = DockStyle.Bottom;
            lblAltBaslik.Location = new Point(0, 120);
            lblAltBaslik.Margin = new Padding(6, 6, 6, 6);
            lblAltBaslik.Name = "lblAltBaslik";
            lblAltBaslik.Size = new Size(848, 80);
            lblAltBaslik.TabIndex = 1;
            lblAltBaslik.Text = "Sinema Bilet Sistemi - Giriş";
            // 
            // pnlMain
            // 
            pnlMain.Appearance.BackColor = Color.White;
            pnlMain.Appearance.Options.UseBackColor = true;
            pnlMain.BorderStyle = BorderStyles.NoBorder;
            pnlMain.Controls.Add(lblEmail);
            pnlMain.Controls.Add(txtEmail);
            pnlMain.Controls.Add(lblSifre);
            pnlMain.Controls.Add(txtSifre);
            pnlMain.Controls.Add(btnGiris);
            pnlMain.Controls.Add(btnKaydol);
            pnlMain.Controls.Add(lnkSifreUnuttum);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 200);
            pnlMain.Margin = new Padding(6, 6, 6, 6);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(848, 684);
            pnlMain.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Appearance.ForeColor = Color.FromArgb(44, 62, 80);
            lblEmail.Appearance.Options.UseFont = true;
            lblEmail.Appearance.Options.UseForeColor = true;
            lblEmail.Location = new Point(100, 60);
            lblEmail.Margin = new Padding(6, 6, 6, 6);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(186, 37);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "E-posta Adresi";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 110);
            txtEmail.Margin = new Padding(6, 6, 6, 6);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtEmail.Properties.Appearance.Options.UseFont = true;
            txtEmail.Properties.AutoHeight = false;
            txtEmail.Properties.NullValuePrompt = "ornek@email.com";
            txtEmail.Size = new Size(600, 64);
            txtEmail.TabIndex = 0;
            // 
            // lblSifre
            // 
            lblSifre.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSifre.Appearance.ForeColor = Color.FromArgb(44, 62, 80);
            lblSifre.Appearance.Options.UseFont = true;
            lblSifre.Appearance.Options.UseForeColor = true;
            lblSifre.Location = new Point(100, 200);
            lblSifre.Margin = new Padding(6, 6, 6, 6);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(59, 37);
            lblSifre.TabIndex = 1;
            lblSifre.Text = "Şifre";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(100, 250);
            txtSifre.Margin = new Padding(6, 6, 6, 6);
            txtSifre.Name = "txtSifre";
            txtSifre.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtSifre.Properties.Appearance.Options.UseFont = true;
            txtSifre.Properties.AutoHeight = false;
            txtSifre.Properties.PasswordChar = '●';
            txtSifre.Size = new Size(600, 64);
            txtSifre.TabIndex = 1;
            // 
            // btnGiris
            // 
            btnGiris.Appearance.BackColor = Color.FromArgb(46, 204, 113);
            btnGiris.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGiris.Appearance.ForeColor = Color.White;
            btnGiris.Appearance.Options.UseBackColor = true;
            btnGiris.Appearance.Options.UseFont = true;
            btnGiris.Appearance.Options.UseForeColor = true;
            btnGiris.Cursor = Cursors.Hand;
            btnGiris.Location = new Point(100, 350);
            btnGiris.Margin = new Padding(6, 6, 6, 6);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(600, 80);
            btnGiris.TabIndex = 2;
            btnGiris.Text = "Giriş Yap";
            btnGiris.Click += btnGiris_Click;
            // 
            // btnKaydol
            // 
            btnKaydol.Appearance.BackColor = Color.FromArgb(41, 128, 185);
            btnKaydol.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKaydol.Appearance.ForeColor = Color.White;
            btnKaydol.Appearance.Options.UseBackColor = true;
            btnKaydol.Appearance.Options.UseFont = true;
            btnKaydol.Appearance.Options.UseForeColor = true;
            btnKaydol.Cursor = Cursors.Hand;
            btnKaydol.Location = new Point(100, 450);
            btnKaydol.Margin = new Padding(6, 6, 6, 6);
            btnKaydol.Name = "btnKaydol";
            btnKaydol.Size = new Size(600, 80);
            btnKaydol.TabIndex = 3;
            btnKaydol.Text = "Yeni Hesap Oluştur";
            btnKaydol.Click += btnKaydol_Click;
            // 
            // lnkSifreUnuttum
            // 
            lnkSifreUnuttum.Appearance.Font = new Font("Segoe UI", 9F);
            lnkSifreUnuttum.Appearance.Options.UseFont = true;
            lnkSifreUnuttum.Appearance.Options.UseTextOptions = true;
            lnkSifreUnuttum.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            lnkSifreUnuttum.AutoSizeMode = LabelAutoSizeMode.None;
            lnkSifreUnuttum.Cursor = Cursors.Hand;
            lnkSifreUnuttum.Location = new Point(100, 560);
            lnkSifreUnuttum.Margin = new Padding(6, 6, 6, 6);
            lnkSifreUnuttum.Name = "lnkSifreUnuttum";
            lnkSifreUnuttum.Size = new Size(600, 100);
            lnkSifreUnuttum.TabIndex = 4;
            lnkSifreUnuttum.Text = "Şifremi Unuttum";
            lnkSifreUnuttum.Click += lnkSifreUnuttum_Click;
            // 
            // FrmGiris
            // 
            AcceptButton = btnGiris;
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(848, 884);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.ShowIcon = false;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            Name = "FrmGiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giriş - Sinemacı";
            Load += FrmGiris_Load;
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSifre.Properties).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private global::DevExpress.XtraEditors.PanelControl pnlHeader;
        private global::DevExpress.XtraEditors.LabelControl lblBaslik;
        private global::DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private global::DevExpress.XtraEditors.PanelControl pnlMain;
        private global::DevExpress.XtraEditors.LabelControl lblEmail;
        private global::DevExpress.XtraEditors.TextEdit txtEmail;
        private global::DevExpress.XtraEditors.LabelControl lblSifre;
        private global::DevExpress.XtraEditors.TextEdit txtSifre;
        private global::DevExpress.XtraEditors.SimpleButton btnGiris;
        private global::DevExpress.XtraEditors.SimpleButton btnKaydol;
        private global::DevExpress.XtraEditors.HyperlinkLabelControl lnkSifreUnuttum;
    }
}
