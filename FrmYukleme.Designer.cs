using DevExpress.XtraEditors;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmYukleme
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
            this.pnlAna = new DevExpress.XtraEditors.PanelControl();
            this.lblEmoji = new DevExpress.XtraEditors.LabelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.progressBarYukleme = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblYuklemeMetni = new DevExpress.XtraEditors.LabelControl();
            this.lblAltMetin = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAna)).BeginInit();
            this.pnlAna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarYukleme.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // pnlAna
            //
            this.pnlAna.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlAna.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlAna.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlAna.Appearance.Options.UseBackColor = true;
            this.pnlAna.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlAna.Controls.Add(this.lblAltMetin);
            this.pnlAna.Controls.Add(this.lblYuklemeMetni);
            this.pnlAna.Controls.Add(this.progressBarYukleme);
            this.pnlAna.Controls.Add(this.lblBaslik);
            this.pnlAna.Controls.Add(this.lblEmoji);
            this.pnlAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAna.Location = new System.Drawing.Point(0, 0);
            this.pnlAna.Name = "pnlAna";
            this.pnlAna.Size = new System.Drawing.Size(600, 400);
            this.pnlAna.TabIndex = 0;
            //
            // lblEmoji
            //
            this.lblEmoji.Appearance.Font = new System.Drawing.Font("Segoe UI", 72F);
            this.lblEmoji.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblEmoji.Appearance.Options.UseFont = true;
            this.lblEmoji.Appearance.Options.UseForeColor = true;
            this.lblEmoji.Appearance.Options.UseTextOptions = true;
            this.lblEmoji.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEmoji.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEmoji.Location = new System.Drawing.Point(200, 60);
            this.lblEmoji.Name = "lblEmoji";
            this.lblEmoji.Size = new System.Drawing.Size(200, 120);
            this.lblEmoji.TabIndex = 0;
            this.lblEmoji.Text = "🎬";
            //
            // lblBaslik
            //
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new System.Drawing.Point(50, 190);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(500, 60);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "SİNEMACI";
            //
            // progressBarYukleme
            //
            this.progressBarYukleme.EditValue = 0;
            this.progressBarYukleme.Location = new System.Drawing.Point(100, 280);
            this.progressBarYukleme.Name = "progressBarYukleme";
            this.progressBarYukleme.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(50)))));
            this.progressBarYukleme.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            this.progressBarYukleme.Properties.Appearance.Options.UseBackColor = true;
            this.progressBarYukleme.Properties.Appearance.Options.UseBorderColor = true;
            this.progressBarYukleme.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.progressBarYukleme.Properties.EndColor = System.Drawing.Color.White;
            this.progressBarYukleme.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.progressBarYukleme.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBarYukleme.Properties.Maximum = 100;
            this.progressBarYukleme.Properties.PercentView = true;
            this.progressBarYukleme.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.progressBarYukleme.Properties.ShowTitle = true;
            this.progressBarYukleme.Properties.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.progressBarYukleme.Properties.Step = 1;
            this.progressBarYukleme.Size = new System.Drawing.Size(400, 30);
            this.progressBarYukleme.TabIndex = 2;
            //
            // lblYuklemeMetni
            //
            this.lblYuklemeMetni.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblYuklemeMetni.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblYuklemeMetni.Appearance.Options.UseFont = true;
            this.lblYuklemeMetni.Appearance.Options.UseForeColor = true;
            this.lblYuklemeMetni.Appearance.Options.UseTextOptions = true;
            this.lblYuklemeMetni.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblYuklemeMetni.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblYuklemeMetni.Location = new System.Drawing.Point(100, 320);
            this.lblYuklemeMetni.Name = "lblYuklemeMetni";
            this.lblYuklemeMetni.Size = new System.Drawing.Size(400, 25);
            this.lblYuklemeMetni.TabIndex = 3;
            this.lblYuklemeMetni.Text = "Sistem başlatılıyor...";
            //
            // lblAltMetin
            //
            this.lblAltMetin.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAltMetin.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            this.lblAltMetin.Appearance.Options.UseFont = true;
            this.lblAltMetin.Appearance.Options.UseForeColor = true;
            this.lblAltMetin.Appearance.Options.UseTextOptions = true;
            this.lblAltMetin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblAltMetin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAltMetin.Location = new System.Drawing.Point(100, 360);
            this.lblAltMetin.Name = "lblAltMetin";
            this.lblAltMetin.Size = new System.Drawing.Size(400, 20);
            this.lblAltMetin.TabIndex = 4;
            this.lblAltMetin.Text = "Sinema Bilet Sistemi v1.0";
            //
            // FrmYukleme
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.pnlAna);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmYukleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yükleniyor...";
            this.Load += new System.EventHandler(this.FrmYukleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAna)).EndInit();
            this.pnlAna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarYukleme.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private global::DevExpress.XtraEditors.PanelControl pnlAna;
        private global::DevExpress.XtraEditors.LabelControl lblEmoji;
        private global::DevExpress.XtraEditors.LabelControl lblBaslik;
        private global::DevExpress.XtraEditors.ProgressBarControl progressBarYukleme;
        private global::DevExpress.XtraEditors.LabelControl lblYuklemeMetni;
        private global::DevExpress.XtraEditors.LabelControl lblAltMetin;
    }
}
