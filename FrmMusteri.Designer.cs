using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmMusteri
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
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblKullanici = new DevExpress.XtraEditors.LabelControl();
            this.lblBakiye = new DevExpress.XtraEditors.LabelControl();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnKoltukSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnBiletlerim = new DevExpress.XtraEditors.SimpleButton();
            this.gridSeanslar = new DevExpress.XtraGrid.GridControl();
            this.gridViewSeanslar = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeanslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSeanslar)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Controls.Add(this.lblKullanici);
            this.pnlHeader.Controls.Add(this.lblBakiye);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(770, 100);
            this.pnlHeader.TabIndex = 0;
            //
            // lblBaslik
            //
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(266, 37);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🎬 Müşteri Paneli";
            //
            // lblKullanici
            //
            this.lblKullanici.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKullanici.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblKullanici.Appearance.Options.UseFont = true;
            this.lblKullanici.Appearance.Options.UseForeColor = true;
            this.lblKullanici.Location = new System.Drawing.Point(20, 60);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(105, 20);
            this.lblKullanici.TabIndex = 1;
            this.lblKullanici.Text = "Hoş geldiniz, ...";
            //
            // lblBakiye
            //
            this.lblBakiye.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBakiye.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblBakiye.Appearance.Options.UseFont = true;
            this.lblBakiye.Appearance.Options.UseForeColor = true;
            this.lblBakiye.Appearance.Options.UseTextOptions = true;
            this.lblBakiye.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBakiye.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBakiye.Location = new System.Drawing.Point(750, 30);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(230, 40);
            this.lblBakiye.TabIndex = 2;
            this.lblBakiye.Text = "Bakiye: 0,00 ₺";
            //
            // pnlButtons
            //
            this.pnlButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlButtons.Controls.Add(this.btnKoltukSec);
            this.pnlButtons.Controls.Add(this.btnYenile);
            this.pnlButtons.Controls.Add(this.btnBiletlerim);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 550);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlButtons.Size = new System.Drawing.Size(770, 80);
            this.pnlButtons.TabIndex = 1;
            //
            // btnKoltukSec
            //
            this.btnKoltukSec.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnKoltukSec.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKoltukSec.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKoltukSec.Appearance.Options.UseBackColor = true;
            this.btnKoltukSec.Appearance.Options.UseFont = true;
            this.btnKoltukSec.Appearance.Options.UseForeColor = true;
            this.btnKoltukSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKoltukSec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnKoltukSec.Location = new System.Drawing.Point(20, 10);
            this.btnKoltukSec.Name = "btnKoltukSec";
            this.btnKoltukSec.Size = new System.Drawing.Size(250, 60);
            this.btnKoltukSec.TabIndex = 0;
            this.btnKoltukSec.Text = "🎫 Koltuk Seç ve Bilet Al";
            this.btnKoltukSec.Click += new System.EventHandler(this.btnKoltukSec_Click);
            //
            // btnBiletlerim
            //
            this.btnBiletlerim.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnBiletlerim.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBiletlerim.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnBiletlerim.Appearance.Options.UseBackColor = true;
            this.btnBiletlerim.Appearance.Options.UseFont = true;
            this.btnBiletlerim.Appearance.Options.UseForeColor = true;
            this.btnBiletlerim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBiletlerim.Location = new System.Drawing.Point(290, 10);
            this.btnBiletlerim.Name = "btnBiletlerim";
            this.btnBiletlerim.Size = new System.Drawing.Size(200, 60);
            this.btnBiletlerim.TabIndex = 1;
            this.btnBiletlerim.Text = "📋 Biletlerim";
            this.btnBiletlerim.Click += new System.EventHandler(this.btnBiletlerim_Click);
            //
            // btnYenile
            //
            this.btnYenile.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYenile.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Appearance.Options.UseBackColor = true;
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.Appearance.Options.UseForeColor = true;
            this.btnYenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYenile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnYenile.Location = new System.Drawing.Point(800, 10);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(180, 60);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            //
            // gridSeanslar
            //
            this.gridSeanslar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSeanslar.Location = new System.Drawing.Point(0, 100);
            this.gridSeanslar.MainView = this.gridViewSeanslar;
            this.gridSeanslar.Name = "gridSeanslar";
            this.gridSeanslar.Size = new System.Drawing.Size(770, 450);
            this.gridSeanslar.TabIndex = 2;
            this.gridSeanslar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSeanslar});
            //
            // gridViewSeanslar
            //
            this.gridViewSeanslar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gridViewSeanslar.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewSeanslar.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gridViewSeanslar.Appearance.Row.Options.UseFont = true;
            this.gridViewSeanslar.GridControl = this.gridSeanslar;
            this.gridViewSeanslar.Name = "gridViewSeanslar";
            this.gridViewSeanslar.OptionsBehavior.Editable = false;
            this.gridViewSeanslar.OptionsBehavior.ReadOnly = true;
            this.gridViewSeanslar.OptionsView.ShowGroupPanel = true;
            this.gridViewSeanslar.OptionsView.ShowFooter = true;
            //
            // FrmMusteri
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Controls.Add(this.gridSeanslar);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmMusteri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Paneli - Sinemacı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMusteri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSeanslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSeanslar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private global::DevExpress.XtraEditors.PanelControl pnlHeader;
        private global::DevExpress.XtraEditors.LabelControl lblBaslik;
        private global::DevExpress.XtraEditors.LabelControl lblKullanici;
        private global::DevExpress.XtraEditors.LabelControl lblBakiye;
        private global::DevExpress.XtraEditors.PanelControl pnlButtons;
        private global::DevExpress.XtraEditors.SimpleButton btnKoltukSec;
        private global::DevExpress.XtraEditors.SimpleButton btnYenile;
        private global::DevExpress.XtraEditors.SimpleButton btnBiletlerim;
        private global::DevExpress.XtraGrid.GridControl gridSeanslar;
        private global::DevExpress.XtraGrid.Views.Grid.GridView gridViewSeanslar;
    }
}
