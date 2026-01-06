using DevExpress.XtraEditors;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmKoltukSecimi
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
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblFilmAd = new DevExpress.XtraEditors.LabelControl();
            this.lblSeansDetay = new DevExpress.XtraEditors.LabelControl();
            this.lblFiyat = new DevExpress.XtraEditors.LabelControl();
            this.pnlEkran = new DevExpress.XtraEditors.PanelControl();
            this.lblEkran = new DevExpress.XtraEditors.LabelControl();
            this.flpKoltuk = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
            this.lblSecim = new DevExpress.XtraEditors.LabelControl();
            this.btnSatinAl = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEkran)).BeginInit();
            this.pnlEkran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblFilmAd);
            this.pnlHeader.Controls.Add(this.lblSeansDetay);
            this.pnlHeader.Controls.Add(this.lblFiyat);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 100);
            this.pnlHeader.TabIndex = 0;
            //
            // lblFilmAd
            //
            this.lblFilmAd.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblFilmAd.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblFilmAd.Appearance.Options.UseFont = true;
            this.lblFilmAd.Appearance.Options.UseForeColor = true;
            this.lblFilmAd.Location = new System.Drawing.Point(20, 15);
            this.lblFilmAd.Name = "lblFilmAd";
            this.lblFilmAd.Size = new System.Drawing.Size(154, 32);
            this.lblFilmAd.TabIndex = 0;
            this.lblFilmAd.Text = "🎬 Film Adı";
            //
            // lblSeansDetay
            //
            this.lblSeansDetay.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSeansDetay.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblSeansDetay.Appearance.Options.UseFont = true;
            this.lblSeansDetay.Appearance.Options.UseForeColor = true;
            this.lblSeansDetay.Location = new System.Drawing.Point(20, 55);
            this.lblSeansDetay.Name = "lblSeansDetay";
            this.lblSeansDetay.Size = new System.Drawing.Size(93, 20);
            this.lblSeansDetay.TabIndex = 1;
            this.lblSeansDetay.Text = "Seans Detayı";
            //
            // lblFiyat
            //
            this.lblFiyat.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblFiyat.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblFiyat.Appearance.Options.UseFont = true;
            this.lblFiyat.Appearance.Options.UseForeColor = true;
            this.lblFiyat.Appearance.Options.UseTextOptions = true;
            this.lblFiyat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblFiyat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFiyat.Location = new System.Drawing.Point(800, 30);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(180, 40);
            this.lblFiyat.TabIndex = 2;
            this.lblFiyat.Text = "0,00 ₺";
            //
            // pnlEkran
            //
            this.pnlEkran.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlEkran.Appearance.Options.UseBackColor = true;
            this.pnlEkran.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlEkran.Controls.Add(this.lblEkran);
            this.pnlEkran.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEkran.Location = new System.Drawing.Point(0, 100);
            this.pnlEkran.Name = "pnlEkran";
            this.pnlEkran.Size = new System.Drawing.Size(1000, 50);
            this.pnlEkran.TabIndex = 1;
            //
            // lblEkran
            //
            this.lblEkran.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEkran.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblEkran.Appearance.Options.UseFont = true;
            this.lblEkran.Appearance.Options.UseForeColor = true;
            this.lblEkran.Appearance.Options.UseTextOptions = true;
            this.lblEkran.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEkran.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEkran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEkran.Location = new System.Drawing.Point(0, 0);
            this.lblEkran.Name = "lblEkran";
            this.lblEkran.Size = new System.Drawing.Size(1000, 50);
            this.lblEkran.TabIndex = 0;
            this.lblEkran.Text = "▬▬▬▬▬▬▬▬ EKRAN ▬▬▬▬▬▬▬▬";
            //
            // flpKoltuk
            //
            this.flpKoltuk.AutoScroll = true;
            this.flpKoltuk.BackColor = System.Drawing.Color.White;
            this.flpKoltuk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpKoltuk.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpKoltuk.Location = new System.Drawing.Point(0, 150);
            this.flpKoltuk.Name = "flpKoltuk";
            this.flpKoltuk.Padding = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.flpKoltuk.Size = new System.Drawing.Size(1000, 520);
            this.flpKoltuk.TabIndex = 2;
            //
            // pnlFooter
            //
            this.pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFooter.Controls.Add(this.lblSecim);
            this.pnlFooter.Controls.Add(this.btnSatinAl);
            this.pnlFooter.Controls.Add(this.btnIptal);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 670);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlFooter.Size = new System.Drawing.Size(1000, 80);
            this.pnlFooter.TabIndex = 3;
            //
            // lblSecim
            //
            this.lblSecim.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSecim.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSecim.Appearance.Options.UseFont = true;
            this.lblSecim.Appearance.Options.UseForeColor = true;
            this.lblSecim.Location = new System.Drawing.Point(30, 30);
            this.lblSecim.Name = "lblSecim";
            this.lblSecim.Size = new System.Drawing.Size(127, 21);
            this.lblSecim.TabIndex = 0;
            this.lblSecim.Text = "Koltuk seçiniz...";
            //
            // btnSatinAl
            //
            this.btnSatinAl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSatinAl.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSatinAl.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSatinAl.Appearance.Options.UseBackColor = true;
            this.btnSatinAl.Appearance.Options.UseFont = true;
            this.btnSatinAl.Appearance.Options.UseForeColor = true;
            this.btnSatinAl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSatinAl.Enabled = false;
            this.btnSatinAl.Location = new System.Drawing.Point(700, 15);
            this.btnSatinAl.Name = "btnSatinAl";
            this.btnSatinAl.Size = new System.Drawing.Size(180, 50);
            this.btnSatinAl.TabIndex = 1;
            this.btnSatinAl.Text = "💳 Satın Al";
            this.btnSatinAl.Click += new System.EventHandler(this.btnSatinAl_Click);
            //
            // btnIptal
            //
            this.btnIptal.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnIptal.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Appearance.Options.UseBackColor = true;
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.Appearance.Options.UseForeColor = true;
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.Location = new System.Drawing.Point(890, 15);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(90, 50);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            //
            // FrmKoltukSecimi
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Controls.Add(this.flpKoltuk);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlEkran);
            this.Controls.Add(this.pnlHeader);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKoltukSecimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Koltuk Seçimi - Sinemacı";
            this.Load += new System.EventHandler(this.FrmKoltukSecimi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEkran)).EndInit();
            this.pnlEkran.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private global::DevExpress.XtraEditors.PanelControl pnlHeader;
        private global::DevExpress.XtraEditors.LabelControl lblFilmAd;
        private global::DevExpress.XtraEditors.LabelControl lblSeansDetay;
        private global::DevExpress.XtraEditors.LabelControl lblFiyat;
        private global::DevExpress.XtraEditors.PanelControl pnlEkran;
        private global::DevExpress.XtraEditors.LabelControl lblEkran;
        private System.Windows.Forms.FlowLayoutPanel flpKoltuk;
        private global::DevExpress.XtraEditors.PanelControl pnlFooter;
        private global::DevExpress.XtraEditors.LabelControl lblSecim;
        private global::DevExpress.XtraEditors.SimpleButton btnSatinAl;
        private global::DevExpress.XtraEditors.SimpleButton btnIptal;
    }
}
