using DevExpress.XtraEditors;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmSifreUnuttum
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlEmailGonder = new DevExpress.XtraEditors.PanelControl();
            this.lblEmailBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblEmailAciklama = new DevExpress.XtraEditors.LabelControl();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.btnKodGonder = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmailIptal = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSifreDegistir = new DevExpress.XtraEditors.PanelControl();
            this.lblSifreBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblSifreAciklama = new DevExpress.XtraEditors.LabelControl();
            this.lblDogrulamaKodu = new DevExpress.XtraEditors.LabelControl();
            this.txtDogrulamaKodu = new DevExpress.XtraEditors.TextEdit();
            this.lblYeniSifre = new DevExpress.XtraEditors.LabelControl();
            this.txtYeniSifre = new DevExpress.XtraEditors.TextEdit();
            this.lblYeniSifreTekrar = new DevExpress.XtraEditors.LabelControl();
            this.txtYeniSifreTekrar = new DevExpress.XtraEditors.TextEdit();
            this.btnSifreDegistir = new DevExpress.XtraEditors.SimpleButton();
            this.btnGeri = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenidenGonder = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailGonder)).BeginInit();
            this.pnlEmailGonder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSifreDegistir)).BeginInit();
            this.pnlSifreDegistir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogrulamaKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // pnlEmailGonder
            //
            this.pnlEmailGonder.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlEmailGonder.Appearance.Options.UseBackColor = true;
            this.pnlEmailGonder.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlEmailGonder.Controls.Add(this.lblEmailBaslik);
            this.pnlEmailGonder.Controls.Add(this.lblEmailAciklama);
            this.pnlEmailGonder.Controls.Add(this.lblEmail);
            this.pnlEmailGonder.Controls.Add(this.txtEmail);
            this.pnlEmailGonder.Controls.Add(this.btnKodGonder);
            this.pnlEmailGonder.Controls.Add(this.btnEmailIptal);
            this.pnlEmailGonder.Location = new System.Drawing.Point(0, 0);
            this.pnlEmailGonder.Name = "pnlEmailGonder";
            this.pnlEmailGonder.Size = new System.Drawing.Size(700, 500);
            this.pnlEmailGonder.TabIndex = 0;
            //
            // lblEmailBaslik
            //
            this.lblEmailBaslik.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblEmailBaslik.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblEmailBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblEmailBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblEmailBaslik.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblEmailBaslik.Appearance.Options.UseBackColor = true;
            this.lblEmailBaslik.Appearance.Options.UseFont = true;
            this.lblEmailBaslik.Appearance.Options.UseForeColor = true;
            this.lblEmailBaslik.Appearance.Options.UseTextOptions = true;
            this.lblEmailBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEmailBaslik.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblEmailBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEmailBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblEmailBaslik.Name = "lblEmailBaslik";
            this.lblEmailBaslik.Size = new System.Drawing.Size(700, 80);
            this.lblEmailBaslik.TabIndex = 0;
            this.lblEmailBaslik.Text = "🔐 Şifremi Unuttum";
            //
            // lblEmailAciklama
            //
            this.lblEmailAciklama.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblEmailAciklama.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblEmailAciklama.Appearance.Options.UseFont = true;
            this.lblEmailAciklama.Appearance.Options.UseForeColor = true;
            this.lblEmailAciklama.Appearance.Options.UseTextOptions = true;
            this.lblEmailAciklama.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEmailAciklama.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblEmailAciklama.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEmailAciklama.Location = new System.Drawing.Point(50, 110);
            this.lblEmailAciklama.Name = "lblEmailAciklama";
            this.lblEmailAciklama.Size = new System.Drawing.Size(600, 60);
            this.lblEmailAciklama.TabIndex = 1;
            this.lblEmailAciklama.Text = "Kayıtlı e-posta adresinizi girin. Size şifre sıfırlama kodu göndereceğiz.";
            //
            // lblEmail
            //
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Appearance.Options.UseForeColor = true;
            this.lblEmail.Location = new System.Drawing.Point(100, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(116, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "E-Posta Adresi";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(100, 220);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.NullValuePrompt = "ornek@email.com";
            this.txtEmail.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmail.Size = new System.Drawing.Size(500, 28);
            this.txtEmail.TabIndex = 3;
            //
            // btnKodGonder
            //
            this.btnKodGonder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnKodGonder.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnKodGonder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKodGonder.Appearance.Options.UseBackColor = true;
            this.btnKodGonder.Appearance.Options.UseFont = true;
            this.btnKodGonder.Appearance.Options.UseForeColor = true;
            this.btnKodGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKodGonder.Location = new System.Drawing.Point(100, 310);
            this.btnKodGonder.Name = "btnKodGonder";
            this.btnKodGonder.Size = new System.Drawing.Size(240, 55);
            this.btnKodGonder.TabIndex = 4;
            this.btnKodGonder.Text = "📧 Kod Gönder";
            this.btnKodGonder.Click += new System.EventHandler(this.btnKodGonder_Click);
            //
            // btnEmailIptal
            //
            this.btnEmailIptal.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnEmailIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnEmailIptal.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEmailIptal.Appearance.Options.UseBackColor = true;
            this.btnEmailIptal.Appearance.Options.UseFont = true;
            this.btnEmailIptal.Appearance.Options.UseForeColor = true;
            this.btnEmailIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmailIptal.Location = new System.Drawing.Point(360, 310);
            this.btnEmailIptal.Name = "btnEmailIptal";
            this.btnEmailIptal.Size = new System.Drawing.Size(240, 55);
            this.btnEmailIptal.TabIndex = 5;
            this.btnEmailIptal.Text = "✗ İptal";
            this.btnEmailIptal.Click += new System.EventHandler(this.btnEmailIptal_Click);
            //
            // pnlSifreDegistir
            //
            this.pnlSifreDegistir.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlSifreDegistir.Appearance.Options.UseBackColor = true;
            this.pnlSifreDegistir.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSifreDegistir.Controls.Add(this.lblSifreBaslik);
            this.pnlSifreDegistir.Controls.Add(this.lblSifreAciklama);
            this.pnlSifreDegistir.Controls.Add(this.lblDogrulamaKodu);
            this.pnlSifreDegistir.Controls.Add(this.txtDogrulamaKodu);
            this.pnlSifreDegistir.Controls.Add(this.lblYeniSifre);
            this.pnlSifreDegistir.Controls.Add(this.txtYeniSifre);
            this.pnlSifreDegistir.Controls.Add(this.lblYeniSifreTekrar);
            this.pnlSifreDegistir.Controls.Add(this.txtYeniSifreTekrar);
            this.pnlSifreDegistir.Controls.Add(this.btnSifreDegistir);
            this.pnlSifreDegistir.Controls.Add(this.btnGeri);
            this.pnlSifreDegistir.Controls.Add(this.btnYenidenGonder);
            this.pnlSifreDegistir.Location = new System.Drawing.Point(0, 0);
            this.pnlSifreDegistir.Name = "pnlSifreDegistir";
            this.pnlSifreDegistir.Size = new System.Drawing.Size(700, 650);
            this.pnlSifreDegistir.TabIndex = 1;
            this.pnlSifreDegistir.Visible = false;
            //
            // lblSifreBaslik
            //
            this.lblSifreBaslik.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblSifreBaslik.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblSifreBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSifreBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblSifreBaslik.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblSifreBaslik.Appearance.Options.UseBackColor = true;
            this.lblSifreBaslik.Appearance.Options.UseFont = true;
            this.lblSifreBaslik.Appearance.Options.UseForeColor = true;
            this.lblSifreBaslik.Appearance.Options.UseTextOptions = true;
            this.lblSifreBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblSifreBaslik.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSifreBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSifreBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblSifreBaslik.Name = "lblSifreBaslik";
            this.lblSifreBaslik.Size = new System.Drawing.Size(700, 80);
            this.lblSifreBaslik.TabIndex = 0;
            this.lblSifreBaslik.Text = "🔑 Yeni Şifre Belirle";
            //
            // lblSifreAciklama
            //
            this.lblSifreAciklama.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSifreAciklama.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSifreAciklama.Appearance.Options.UseFont = true;
            this.lblSifreAciklama.Appearance.Options.UseForeColor = true;
            this.lblSifreAciklama.Appearance.Options.UseTextOptions = true;
            this.lblSifreAciklama.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblSifreAciklama.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSifreAciklama.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSifreAciklama.Location = new System.Drawing.Point(50, 110);
            this.lblSifreAciklama.Name = "lblSifreAciklama";
            this.lblSifreAciklama.Size = new System.Drawing.Size(600, 60);
            this.lblSifreAciklama.TabIndex = 1;
            this.lblSifreAciklama.Text = "E-postanıza gönderilen 6 haneli kodu girin ve yeni şifrenizi belirleyin.";
            //
            // lblDogrulamaKodu
            //
            this.lblDogrulamaKodu.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDogrulamaKodu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDogrulamaKodu.Appearance.Options.UseFont = true;
            this.lblDogrulamaKodu.Appearance.Options.UseForeColor = true;
            this.lblDogrulamaKodu.Location = new System.Drawing.Point(100, 190);
            this.lblDogrulamaKodu.Name = "lblDogrulamaKodu";
            this.lblDogrulamaKodu.Size = new System.Drawing.Size(178, 20);
            this.lblDogrulamaKodu.TabIndex = 2;
            this.lblDogrulamaKodu.Text = "Doğrulama Kodu (6 hane)";
            //
            // txtDogrulamaKodu
            //
            this.txtDogrulamaKodu.Location = new System.Drawing.Point(100, 220);
            this.txtDogrulamaKodu.Name = "txtDogrulamaKodu";
            this.txtDogrulamaKodu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtDogrulamaKodu.Properties.Appearance.Options.UseFont = true;
            this.txtDogrulamaKodu.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDogrulamaKodu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDogrulamaKodu.Properties.MaxLength = 6;
            this.txtDogrulamaKodu.Properties.NullValuePrompt = "123456";
            this.txtDogrulamaKodu.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDogrulamaKodu.Size = new System.Drawing.Size(500, 28);
            this.txtDogrulamaKodu.TabIndex = 3;
            //
            // lblYeniSifre
            //
            this.lblYeniSifre.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblYeniSifre.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblYeniSifre.Appearance.Options.UseFont = true;
            this.lblYeniSifre.Appearance.Options.UseForeColor = true;
            this.lblYeniSifre.Location = new System.Drawing.Point(100, 290);
            this.lblYeniSifre.Name = "lblYeniSifre";
            this.lblYeniSifre.Size = new System.Drawing.Size(72, 20);
            this.lblYeniSifre.TabIndex = 4;
            this.lblYeniSifre.Text = "Yeni Şifre";
            //
            // txtYeniSifre
            //
            this.txtYeniSifre.Location = new System.Drawing.Point(100, 320);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtYeniSifre.Properties.Appearance.Options.UseFont = true;
            this.txtYeniSifre.Properties.NullValuePrompt = "En az 6 karakter";
            this.txtYeniSifre.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtYeniSifre.Properties.PasswordChar = '●';
            this.txtYeniSifre.Properties.UseSystemPasswordChar = false;
            this.txtYeniSifre.Size = new System.Drawing.Size(500, 28);
            this.txtYeniSifre.TabIndex = 5;
            //
            // lblYeniSifreTekrar
            //
            this.lblYeniSifreTekrar.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblYeniSifreTekrar.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblYeniSifreTekrar.Appearance.Options.UseFont = true;
            this.lblYeniSifreTekrar.Appearance.Options.UseForeColor = true;
            this.lblYeniSifreTekrar.Location = new System.Drawing.Point(100, 390);
            this.lblYeniSifreTekrar.Name = "lblYeniSifreTekrar";
            this.lblYeniSifreTekrar.Size = new System.Drawing.Size(134, 20);
            this.lblYeniSifreTekrar.TabIndex = 6;
            this.lblYeniSifreTekrar.Text = "Yeni Şifre (Tekrar)";
            //
            // txtYeniSifreTekrar
            //
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(100, 420);
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtYeniSifreTekrar.Properties.Appearance.Options.UseFont = true;
            this.txtYeniSifreTekrar.Properties.NullValuePrompt = "Şifrenizi tekrar girin";
            this.txtYeniSifreTekrar.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtYeniSifreTekrar.Properties.PasswordChar = '●';
            this.txtYeniSifreTekrar.Properties.UseSystemPasswordChar = false;
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(500, 28);
            this.txtYeniSifreTekrar.TabIndex = 7;
            //
            // btnSifreDegistir
            //
            this.btnSifreDegistir.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSifreDegistir.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSifreDegistir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSifreDegistir.Appearance.Options.UseBackColor = true;
            this.btnSifreDegistir.Appearance.Options.UseFont = true;
            this.btnSifreDegistir.Appearance.Options.UseForeColor = true;
            this.btnSifreDegistir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSifreDegistir.Location = new System.Drawing.Point(100, 510);
            this.btnSifreDegistir.Name = "btnSifreDegistir";
            this.btnSifreDegistir.Size = new System.Drawing.Size(190, 55);
            this.btnSifreDegistir.TabIndex = 8;
            this.btnSifreDegistir.Text = "✓ Şifreyi Değiştir";
            this.btnSifreDegistir.Click += new System.EventHandler(this.btnSifreDegistir_Click);
            //
            // btnGeri
            //
            this.btnGeri.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnGeri.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnGeri.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGeri.Appearance.Options.UseBackColor = true;
            this.btnGeri.Appearance.Options.UseFont = true;
            this.btnGeri.Appearance.Options.UseForeColor = true;
            this.btnGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeri.Location = new System.Drawing.Point(500, 510);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(100, 55);
            this.btnGeri.TabIndex = 9;
            this.btnGeri.Text = "← Geri";
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            //
            // btnYenidenGonder
            //
            this.btnYenidenGonder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnYenidenGonder.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnYenidenGonder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenidenGonder.Appearance.Options.UseBackColor = true;
            this.btnYenidenGonder.Appearance.Options.UseFont = true;
            this.btnYenidenGonder.Appearance.Options.UseForeColor = true;
            this.btnYenidenGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYenidenGonder.Location = new System.Drawing.Point(310, 510);
            this.btnYenidenGonder.Name = "btnYenidenGonder";
            this.btnYenidenGonder.Size = new System.Drawing.Size(170, 55);
            this.btnYenidenGonder.TabIndex = 10;
            this.btnYenidenGonder.Text = "🔄 Yeniden Gönder";
            this.btnYenidenGonder.Click += new System.EventHandler(this.btnYenidenGonder_Click);
            //
            // FrmSifreUnuttum
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(700, 650);
            this.Controls.Add(this.pnlSifreDegistir);
            this.Controls.Add(this.pnlEmailGonder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSifreUnuttum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifremi Unuttum - Sinemacı";
            this.Load += new System.EventHandler(this.FrmSifreUnuttum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailGonder)).EndInit();
            this.pnlEmailGonder.ResumeLayout(false);
            this.pnlEmailGonder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSifreDegistir)).EndInit();
            this.pnlSifreDegistir.ResumeLayout(false);
            this.pnlSifreDegistir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogrulamaKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private global::DevExpress.XtraEditors.PanelControl pnlEmailGonder;
        private global::DevExpress.XtraEditors.LabelControl lblEmailBaslik;
        private global::DevExpress.XtraEditors.LabelControl lblEmailAciklama;
        private global::DevExpress.XtraEditors.LabelControl lblEmail;
        private global::DevExpress.XtraEditors.TextEdit txtEmail;
        private global::DevExpress.XtraEditors.SimpleButton btnKodGonder;
        private global::DevExpress.XtraEditors.SimpleButton btnEmailIptal;
        private global::DevExpress.XtraEditors.PanelControl pnlSifreDegistir;
        private global::DevExpress.XtraEditors.LabelControl lblSifreBaslik;
        private global::DevExpress.XtraEditors.LabelControl lblSifreAciklama;
        private global::DevExpress.XtraEditors.LabelControl lblDogrulamaKodu;
        private global::DevExpress.XtraEditors.TextEdit txtDogrulamaKodu;
        private global::DevExpress.XtraEditors.LabelControl lblYeniSifre;
        private global::DevExpress.XtraEditors.TextEdit txtYeniSifre;
        private global::DevExpress.XtraEditors.LabelControl lblYeniSifreTekrar;
        private global::DevExpress.XtraEditors.TextEdit txtYeniSifreTekrar;
        private global::DevExpress.XtraEditors.SimpleButton btnSifreDegistir;
        private global::DevExpress.XtraEditors.SimpleButton btnGeri;
        private global::DevExpress.XtraEditors.SimpleButton btnYenidenGonder;
    }
}
