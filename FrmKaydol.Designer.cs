using DevExpress.XtraEditors;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmKaydol
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
            this.pnlBilgiler = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblAdSoyad = new DevExpress.XtraEditors.LabelControl();
            this.txtAdSoyad = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblSifre = new DevExpress.XtraEditors.LabelControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.lblSifreTekrar = new DevExpress.XtraEditors.LabelControl();
            this.txtSifreTekrar = new DevExpress.XtraEditors.TextEdit();
            this.lblBakiye = new DevExpress.XtraEditors.LabelControl();
            this.numBakiye = new DevExpress.XtraEditors.SpinEdit();
            this.btnDevam = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.pnlDogrulama = new DevExpress.XtraEditors.PanelControl();
            this.lblDogrulamaBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblDogrulamaAciklama = new DevExpress.XtraEditors.LabelControl();
            this.lblDogrulamaKodu = new DevExpress.XtraEditors.LabelControl();
            this.txtDogrulamaKodu = new DevExpress.XtraEditors.TextEdit();
            this.btnKayitTamamla = new DevExpress.XtraEditors.SimpleButton();
            this.btnGeri = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenidenGonder = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBilgiler)).BeginInit();
            this.pnlBilgiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreTekrar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBakiye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDogrulama)).BeginInit();
            this.pnlDogrulama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogrulamaKodu.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // pnlBilgiler
            //
            this.pnlBilgiler.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBilgiler.Appearance.Options.UseBackColor = true;
            this.pnlBilgiler.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBilgiler.Controls.Add(this.lblBaslik);
            this.pnlBilgiler.Controls.Add(this.lblAdSoyad);
            this.pnlBilgiler.Controls.Add(this.txtAdSoyad);
            this.pnlBilgiler.Controls.Add(this.lblEmail);
            this.pnlBilgiler.Controls.Add(this.txtEmail);
            this.pnlBilgiler.Controls.Add(this.lblSifre);
            this.pnlBilgiler.Controls.Add(this.txtSifre);
            this.pnlBilgiler.Controls.Add(this.lblSifreTekrar);
            this.pnlBilgiler.Controls.Add(this.txtSifreTekrar);
            this.pnlBilgiler.Controls.Add(this.lblBakiye);
            this.pnlBilgiler.Controls.Add(this.numBakiye);
            this.pnlBilgiler.Controls.Add(this.btnDevam);
            this.pnlBilgiler.Controls.Add(this.btnIptal);
            this.pnlBilgiler.Location = new System.Drawing.Point(0, 0);
            this.pnlBilgiler.Name = "pnlBilgiler";
            this.pnlBilgiler.Size = new System.Drawing.Size(600, 700);
            this.pnlBilgiler.TabIndex = 0;
            //
            // lblBaslik
            //
            this.lblBaslik.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblBaslik.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblBaslik.Appearance.Options.UseBackColor = true;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(600, 100);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🎬 Kayıt Ol";
            //
            // lblAdSoyad
            //
            this.lblAdSoyad.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAdSoyad.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAdSoyad.Appearance.Options.UseFont = true;
            this.lblAdSoyad.Appearance.Options.UseForeColor = true;
            this.lblAdSoyad.Location = new System.Drawing.Point(80, 140);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(73, 20);
            this.lblAdSoyad.TabIndex = 1;
            this.lblAdSoyad.Text = "Ad Soyad:";
            //
            // txtAdSoyad
            //
            this.txtAdSoyad.Location = new System.Drawing.Point(80, 170);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtAdSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtAdSoyad.Properties.NullValuePrompt = "Adınız ve soyadınız";
            this.txtAdSoyad.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAdSoyad.Size = new System.Drawing.Size(440, 35);
            this.txtAdSoyad.TabIndex = 2;
            //
            // lblEmail
            //
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Appearance.Options.UseForeColor = true;
            this.lblEmail.Location = new System.Drawing.Point(80, 230);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 20);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "E-posta:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(80, 260);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.NullValuePrompt = "ornek@email.com";
            this.txtEmail.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmail.Size = new System.Drawing.Size(440, 35);
            this.txtEmail.TabIndex = 4;
            //
            // lblSifre
            //
            this.lblSifre.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSifre.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Appearance.Options.UseForeColor = true;
            this.lblSifre.Location = new System.Drawing.Point(80, 320);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(37, 20);
            this.lblSifre.TabIndex = 5;
            this.lblSifre.Text = "Şifre:";
            //
            // txtSifre
            //
            this.txtSifre.Location = new System.Drawing.Point(80, 350);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.NullValuePrompt = "En az 6 karakter";
            this.txtSifre.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Properties.UseSystemPasswordChar = false;
            this.txtSifre.Size = new System.Drawing.Size(440, 35);
            this.txtSifre.TabIndex = 6;
            //
            // lblSifreTekrar
            //
            this.lblSifreTekrar.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSifreTekrar.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSifreTekrar.Appearance.Options.UseFont = true;
            this.lblSifreTekrar.Appearance.Options.UseForeColor = true;
            this.lblSifreTekrar.Location = new System.Drawing.Point(80, 410);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new System.Drawing.Size(88, 20);
            this.lblSifreTekrar.TabIndex = 7;
            this.lblSifreTekrar.Text = "Şifre Tekrar:";
            //
            // txtSifreTekrar
            //
            this.txtSifreTekrar.Location = new System.Drawing.Point(80, 440);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtSifreTekrar.Properties.Appearance.Options.UseFont = true;
            this.txtSifreTekrar.Properties.NullValuePrompt = "Şifrenizi tekrar girin";
            this.txtSifreTekrar.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSifreTekrar.Properties.PasswordChar = '●';
            this.txtSifreTekrar.Properties.UseSystemPasswordChar = false;
            this.txtSifreTekrar.Size = new System.Drawing.Size(440, 35);
            this.txtSifreTekrar.TabIndex = 8;
            //
            // lblBakiye
            //
            this.lblBakiye.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBakiye.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBakiye.Appearance.Options.UseFont = true;
            this.lblBakiye.Appearance.Options.UseForeColor = true;
            this.lblBakiye.Location = new System.Drawing.Point(80, 500);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(125, 20);
            this.lblBakiye.TabIndex = 9;
            this.lblBakiye.Text = "Başlangıç Bakiye:";
            //
            // numBakiye
            //
            this.numBakiye.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBakiye.Location = new System.Drawing.Point(80, 530);
            this.numBakiye.Name = "numBakiye";
            this.numBakiye.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numBakiye.Properties.Appearance.Options.UseFont = true;
            this.numBakiye.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numBakiye.Properties.DisplayFormat.FormatString = "C2";
            this.numBakiye.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.numBakiye.Properties.EditFormat.FormatString = "C2";
            this.numBakiye.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.numBakiye.Properties.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBakiye.Properties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numBakiye.Size = new System.Drawing.Size(200, 35);
            this.numBakiye.TabIndex = 10;
            //
            // btnDevam
            //
            this.btnDevam.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDevam.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnDevam.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDevam.Appearance.Options.UseBackColor = true;
            this.btnDevam.Appearance.Options.UseFont = true;
            this.btnDevam.Appearance.Options.UseForeColor = true;
            this.btnDevam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevam.Location = new System.Drawing.Point(320, 600);
            this.btnDevam.Name = "btnDevam";
            this.btnDevam.Size = new System.Drawing.Size(200, 50);
            this.btnDevam.TabIndex = 11;
            this.btnDevam.Text = "Devam →";
            this.btnDevam.Click += new System.EventHandler(this.btnDevam_Click);
            //
            // btnIptal
            //
            this.btnIptal.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnIptal.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Appearance.Options.UseBackColor = true;
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.Appearance.Options.UseForeColor = true;
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.Location = new System.Drawing.Point(80, 600);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(200, 50);
            this.btnIptal.TabIndex = 12;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            //
            // pnlDogrulama
            //
            this.pnlDogrulama.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlDogrulama.Appearance.Options.UseBackColor = true;
            this.pnlDogrulama.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDogrulama.Controls.Add(this.lblDogrulamaBaslik);
            this.pnlDogrulama.Controls.Add(this.lblDogrulamaAciklama);
            this.pnlDogrulama.Controls.Add(this.lblDogrulamaKodu);
            this.pnlDogrulama.Controls.Add(this.txtDogrulamaKodu);
            this.pnlDogrulama.Controls.Add(this.btnKayitTamamla);
            this.pnlDogrulama.Controls.Add(this.btnGeri);
            this.pnlDogrulama.Controls.Add(this.btnYenidenGonder);
            this.pnlDogrulama.Location = new System.Drawing.Point(0, 0);
            this.pnlDogrulama.Name = "pnlDogrulama";
            this.pnlDogrulama.Size = new System.Drawing.Size(600, 700);
            this.pnlDogrulama.TabIndex = 1;
            this.pnlDogrulama.Visible = false;
            //
            // lblDogrulamaBaslik
            //
            this.lblDogrulamaBaslik.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblDogrulamaBaslik.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblDogrulamaBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblDogrulamaBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDogrulamaBaslik.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lblDogrulamaBaslik.Appearance.Options.UseBackColor = true;
            this.lblDogrulamaBaslik.Appearance.Options.UseFont = true;
            this.lblDogrulamaBaslik.Appearance.Options.UseForeColor = true;
            this.lblDogrulamaBaslik.Appearance.Options.UseTextOptions = true;
            this.lblDogrulamaBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDogrulamaBaslik.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDogrulamaBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDogrulamaBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblDogrulamaBaslik.Name = "lblDogrulamaBaslik";
            this.lblDogrulamaBaslik.Size = new System.Drawing.Size(600, 100);
            this.lblDogrulamaBaslik.TabIndex = 0;
            this.lblDogrulamaBaslik.Text = "✉️ E-posta Doğrulama";
            //
            // lblDogrulamaAciklama
            //
            this.lblDogrulamaAciklama.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblDogrulamaAciklama.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDogrulamaAciklama.Appearance.Options.UseFont = true;
            this.lblDogrulamaAciklama.Appearance.Options.UseForeColor = true;
            this.lblDogrulamaAciklama.Appearance.Options.UseTextOptions = true;
            this.lblDogrulamaAciklama.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDogrulamaAciklama.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDogrulamaAciklama.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDogrulamaAciklama.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDogrulamaAciklama.Location = new System.Drawing.Point(50, 150);
            this.lblDogrulamaAciklama.Name = "lblDogrulamaAciklama";
            this.lblDogrulamaAciklama.Size = new System.Drawing.Size(500, 100);
            this.lblDogrulamaAciklama.TabIndex = 1;
            this.lblDogrulamaAciklama.Text = "E-posta adresinize 6 haneli bir doğrulama kodu gönderdik.\r\n\r\nLütfen kodunuzu aşa" +
    "ğıdaki alana girin.";
            //
            // lblDogrulamaKodu
            //
            this.lblDogrulamaKodu.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDogrulamaKodu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDogrulamaKodu.Appearance.Options.UseFont = true;
            this.lblDogrulamaKodu.Appearance.Options.UseForeColor = true;
            this.lblDogrulamaKodu.Location = new System.Drawing.Point(220, 280);
            this.lblDogrulamaKodu.Name = "lblDogrulamaKodu";
            this.lblDogrulamaKodu.Size = new System.Drawing.Size(136, 21);
            this.lblDogrulamaKodu.TabIndex = 2;
            this.lblDogrulamaKodu.Text = "Doğrulama Kodu:";
            //
            // txtDogrulamaKodu
            //
            this.txtDogrulamaKodu.Location = new System.Drawing.Point(180, 320);
            this.txtDogrulamaKodu.Name = "txtDogrulamaKodu";
            this.txtDogrulamaKodu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.txtDogrulamaKodu.Properties.Appearance.Options.UseFont = true;
            this.txtDogrulamaKodu.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDogrulamaKodu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDogrulamaKodu.Properties.MaxLength = 6;
            this.txtDogrulamaKodu.Properties.NullValuePrompt = "000000";
            this.txtDogrulamaKodu.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDogrulamaKodu.Size = new System.Drawing.Size(240, 36);
            this.txtDogrulamaKodu.TabIndex = 3;
            //
            // btnKayitTamamla
            //
            this.btnKayitTamamla.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnKayitTamamla.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnKayitTamamla.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKayitTamamla.Appearance.Options.UseBackColor = true;
            this.btnKayitTamamla.Appearance.Options.UseFont = true;
            this.btnKayitTamamla.Appearance.Options.UseForeColor = true;
            this.btnKayitTamamla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitTamamla.Location = new System.Drawing.Point(180, 420);
            this.btnKayitTamamla.Name = "btnKayitTamamla";
            this.btnKayitTamamla.Size = new System.Drawing.Size(240, 50);
            this.btnKayitTamamla.TabIndex = 4;
            this.btnKayitTamamla.Text = "✓ Kaydı Tamamla";
            this.btnKayitTamamla.Click += new System.EventHandler(this.btnKayitTamamla_Click);
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
            this.btnGeri.Location = new System.Drawing.Point(180, 540);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(240, 45);
            this.btnGeri.TabIndex = 5;
            this.btnGeri.Text = "← Geri Dön";
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            //
            // btnYenidenGonder
            //
            this.btnYenidenGonder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnYenidenGonder.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnYenidenGonder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenidenGonder.Appearance.Options.UseBackColor = true;
            this.btnYenidenGonder.Appearance.Options.UseFont = true;
            this.btnYenidenGonder.Appearance.Options.UseForeColor = true;
            this.btnYenidenGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYenidenGonder.Location = new System.Drawing.Point(180, 600);
            this.btnYenidenGonder.Name = "btnYenidenGonder";
            this.btnYenidenGonder.Size = new System.Drawing.Size(240, 40);
            this.btnYenidenGonder.TabIndex = 6;
            this.btnYenidenGonder.Text = "↻ Yeniden Gönder";
            this.btnYenidenGonder.Click += new System.EventHandler(this.btnYenidenGonder_Click);
            //
            // FrmKaydol
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.pnlDogrulama);
            this.Controls.Add(this.pnlBilgiler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKaydol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıt Ol - Sinemacı";
            this.Load += new System.EventHandler(this.FrmKaydol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBilgiler)).EndInit();
            this.pnlBilgiler.ResumeLayout(false);
            this.pnlBilgiler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifreTekrar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBakiye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDogrulama)).EndInit();
            this.pnlDogrulama.ResumeLayout(false);
            this.pnlDogrulama.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogrulamaKodu.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private global::DevExpress.XtraEditors.PanelControl pnlBilgiler;
        private global::DevExpress.XtraEditors.LabelControl lblBaslik;
        private global::DevExpress.XtraEditors.LabelControl lblAdSoyad;
        private global::DevExpress.XtraEditors.TextEdit txtAdSoyad;
        private global::DevExpress.XtraEditors.LabelControl lblEmail;
        private global::DevExpress.XtraEditors.TextEdit txtEmail;
        private global::DevExpress.XtraEditors.LabelControl lblSifre;
        private global::DevExpress.XtraEditors.TextEdit txtSifre;
        private global::DevExpress.XtraEditors.LabelControl lblSifreTekrar;
        private global::DevExpress.XtraEditors.TextEdit txtSifreTekrar;
        private global::DevExpress.XtraEditors.LabelControl lblBakiye;
        private global::DevExpress.XtraEditors.SpinEdit numBakiye;
        private global::DevExpress.XtraEditors.SimpleButton btnDevam;
        private global::DevExpress.XtraEditors.SimpleButton btnIptal;
        private global::DevExpress.XtraEditors.PanelControl pnlDogrulama;
        private global::DevExpress.XtraEditors.LabelControl lblDogrulamaBaslik;
        private global::DevExpress.XtraEditors.LabelControl lblDogrulamaAciklama;
        private global::DevExpress.XtraEditors.LabelControl lblDogrulamaKodu;
        private global::DevExpress.XtraEditors.TextEdit txtDogrulamaKodu;
        private global::DevExpress.XtraEditors.SimpleButton btnKayitTamamla;
        private global::DevExpress.XtraEditors.SimpleButton btnGeri;
        private global::DevExpress.XtraEditors.SimpleButton btnYenidenGonder;
    }
}
