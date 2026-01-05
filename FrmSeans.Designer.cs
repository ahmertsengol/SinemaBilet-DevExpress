using DevExpress.XtraEditors;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmSeans
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
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlForm = new DevExpress.XtraEditors.PanelControl();
            this.lblSeansFilm = new DevExpress.XtraEditors.LabelControl();
            this.cmbFilm = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSeansSalon = new DevExpress.XtraEditors.LabelControl();
            this.cmbSalon = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSeansTarihSaat = new DevExpress.XtraEditors.LabelControl();
            this.dtSeans = new DevExpress.XtraEditors.DateEdit();
            this.lblSeansFiyat = new DevExpress.XtraEditors.LabelControl();
            this.numFiyat = new DevExpress.XtraEditors.SpinEdit();
            this.btnSeansEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeansSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.gridSeans = new DevExpress.XtraGrid.GridControl();
            this.gridViewSeans = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlForm)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSalon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSeans.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSeans.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSeans)).BeginInit();
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
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(770, 80);
            this.pnlHeader.TabIndex = 0;
            //
            // lblBaslik
            //
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(30, 25);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(229, 37);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "SEANS YÖNETİMİ";
            //
            // pnlMain
            //
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.gridSeans);
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(770, 620);
            this.pnlMain.TabIndex = 1;
            //
            // pnlForm
            //
            this.pnlForm.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlForm.Appearance.Options.UseBackColor = true;
            this.pnlForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlForm.Controls.Add(this.lblSeansFilm);
            this.pnlForm.Controls.Add(this.cmbFilm);
            this.pnlForm.Controls.Add(this.lblSeansSalon);
            this.pnlForm.Controls.Add(this.cmbSalon);
            this.pnlForm.Controls.Add(this.lblSeansTarihSaat);
            this.pnlForm.Controls.Add(this.dtSeans);
            this.pnlForm.Controls.Add(this.lblSeansFiyat);
            this.pnlForm.Controls.Add(this.numFiyat);
            this.pnlForm.Controls.Add(this.btnSeansEkle);
            this.pnlForm.Controls.Add(this.btnSeansSil);
            this.pnlForm.Controls.Add(this.btnKapat);
            this.pnlForm.Location = new System.Drawing.Point(20, 20);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20);
            this.pnlForm.Size = new System.Drawing.Size(380, 580);
            this.pnlForm.TabIndex = 0;
            //
            // lblSeansFilm
            //
            this.lblSeansFilm.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSeansFilm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSeansFilm.Appearance.Options.UseFont = true;
            this.lblSeansFilm.Appearance.Options.UseForeColor = true;
            this.lblSeansFilm.Location = new System.Drawing.Point(30, 20);
            this.lblSeansFilm.Name = "lblSeansFilm";
            this.lblSeansFilm.Size = new System.Drawing.Size(36, 20);
            this.lblSeansFilm.TabIndex = 0;
            this.lblSeansFilm.Text = "Film:";
            //
            // cmbFilm
            //
            this.cmbFilm.Location = new System.Drawing.Point(30, 50);
            this.cmbFilm.Name = "cmbFilm";
            this.cmbFilm.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbFilm.Properties.Appearance.Options.UseFont = true;
            this.cmbFilm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFilm.Properties.NullText = "Film seçin...";
            this.cmbFilm.Size = new System.Drawing.Size(320, 26);
            this.cmbFilm.TabIndex = 1;
            //
            // lblSeansSalon
            //
            this.lblSeansSalon.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSeansSalon.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSeansSalon.Appearance.Options.UseFont = true;
            this.lblSeansSalon.Appearance.Options.UseForeColor = true;
            this.lblSeansSalon.Location = new System.Drawing.Point(30, 100);
            this.lblSeansSalon.Name = "lblSeansSalon";
            this.lblSeansSalon.Size = new System.Drawing.Size(44, 20);
            this.lblSeansSalon.TabIndex = 2;
            this.lblSeansSalon.Text = "Salon:";
            //
            // cmbSalon
            //
            this.cmbSalon.Location = new System.Drawing.Point(30, 130);
            this.cmbSalon.Name = "cmbSalon";
            this.cmbSalon.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbSalon.Properties.Appearance.Options.UseFont = true;
            this.cmbSalon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSalon.Properties.NullText = "Salon seçin...";
            this.cmbSalon.Size = new System.Drawing.Size(320, 26);
            this.cmbSalon.TabIndex = 3;
            //
            // lblSeansTarihSaat
            //
            this.lblSeansTarihSaat.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSeansTarihSaat.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSeansTarihSaat.Appearance.Options.UseFont = true;
            this.lblSeansTarihSaat.Appearance.Options.UseForeColor = true;
            this.lblSeansTarihSaat.Location = new System.Drawing.Point(30, 180);
            this.lblSeansTarihSaat.Name = "lblSeansTarihSaat";
            this.lblSeansTarihSaat.Size = new System.Drawing.Size(77, 20);
            this.lblSeansTarihSaat.TabIndex = 4;
            this.lblSeansTarihSaat.Text = "Tarih/Saat:";
            //
            // dtSeans
            //
            this.dtSeans.EditValue = null;
            this.dtSeans.Location = new System.Drawing.Point(30, 210);
            this.dtSeans.Name = "dtSeans";
            this.dtSeans.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dtSeans.Properties.Appearance.Options.UseFont = true;
            this.dtSeans.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSeans.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSeans.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            this.dtSeans.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtSeans.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm";
            this.dtSeans.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtSeans.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm";
            this.dtSeans.Size = new System.Drawing.Size(320, 26);
            this.dtSeans.TabIndex = 5;
            //
            // lblSeansFiyat
            //
            this.lblSeansFiyat.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSeansFiyat.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSeansFiyat.Appearance.Options.UseFont = true;
            this.lblSeansFiyat.Appearance.Options.UseForeColor = true;
            this.lblSeansFiyat.Location = new System.Drawing.Point(30, 260);
            this.lblSeansFiyat.Name = "lblSeansFiyat";
            this.lblSeansFiyat.Size = new System.Drawing.Size(39, 20);
            this.lblSeansFiyat.TabIndex = 6;
            this.lblSeansFiyat.Text = "Fiyat:";
            //
            // numFiyat
            //
            this.numFiyat.EditValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numFiyat.Location = new System.Drawing.Point(30, 290);
            this.numFiyat.Name = "numFiyat";
            this.numFiyat.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numFiyat.Properties.Appearance.Options.UseFont = true;
            this.numFiyat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numFiyat.Properties.DisplayFormat.FormatString = "C2";
            this.numFiyat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.numFiyat.Properties.EditFormat.FormatString = "C2";
            this.numFiyat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.numFiyat.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numFiyat.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFiyat.Size = new System.Drawing.Size(200, 35);
            this.numFiyat.TabIndex = 7;
            //
            // btnSeansEkle
            //
            this.btnSeansEkle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSeansEkle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSeansEkle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSeansEkle.Appearance.Options.UseBackColor = true;
            this.btnSeansEkle.Appearance.Options.UseFont = true;
            this.btnSeansEkle.Appearance.Options.UseForeColor = true;
            this.btnSeansEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeansEkle.Location = new System.Drawing.Point(30, 360);
            this.btnSeansEkle.Name = "btnSeansEkle";
            this.btnSeansEkle.Size = new System.Drawing.Size(150, 45);
            this.btnSeansEkle.TabIndex = 8;
            this.btnSeansEkle.Text = "✓ Seans Ekle";
            this.btnSeansEkle.Click += new System.EventHandler(this.btnSeansEkle_Click);
            //
            // btnSeansSil
            //
            this.btnSeansSil.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSeansSil.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSeansSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSeansSil.Appearance.Options.UseBackColor = true;
            this.btnSeansSil.Appearance.Options.UseFont = true;
            this.btnSeansSil.Appearance.Options.UseForeColor = true;
            this.btnSeansSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeansSil.Location = new System.Drawing.Point(200, 360);
            this.btnSeansSil.Name = "btnSeansSil";
            this.btnSeansSil.Size = new System.Drawing.Size(150, 45);
            this.btnSeansSil.TabIndex = 9;
            this.btnSeansSil.Text = "✗ Seans Sil";
            this.btnSeansSil.Click += new System.EventHandler(this.btnSeansSil_Click);
            //
            // btnKapat
            //
            this.btnKapat.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnKapat.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Appearance.Options.UseBackColor = true;
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.Appearance.Options.UseForeColor = true;
            this.btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKapat.Location = new System.Drawing.Point(30, 520);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(150, 45);
            this.btnKapat.TabIndex = 10;
            this.btnKapat.Text = "← Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            //
            // gridSeans
            //
            this.gridSeans.Location = new System.Drawing.Point(420, 20);
            this.gridSeans.MainView = this.gridViewSeans;
            this.gridSeans.Name = "gridSeans";
            this.gridSeans.Size = new System.Drawing.Size(760, 580);
            this.gridSeans.TabIndex = 1;
            this.gridSeans.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSeans});
            //
            // gridViewSeans
            //
            this.gridViewSeans.GridControl = this.gridSeans;
            this.gridViewSeans.Name = "gridViewSeans";
            this.gridViewSeans.OptionsView.ShowGroupPanel = false;
            //
            // FrmSeans
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmSeans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seans Yönetimi - Sinemacı";
            this.Load += new System.EventHandler(this.FrmSeans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlForm)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSalon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSeans.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSeans.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSeans)).EndInit();
            this.ResumeLayout(false);
        }

        private global::DevExpress.XtraEditors.PanelControl pnlHeader;
        private global::DevExpress.XtraEditors.LabelControl lblBaslik;
        private global::DevExpress.XtraEditors.PanelControl pnlMain;
        private global::DevExpress.XtraEditors.PanelControl pnlForm;
        private global::DevExpress.XtraEditors.LabelControl lblSeansFilm;
        private global::DevExpress.XtraEditors.LookUpEdit cmbFilm;
        private global::DevExpress.XtraEditors.LabelControl lblSeansSalon;
        private global::DevExpress.XtraEditors.LookUpEdit cmbSalon;
        private global::DevExpress.XtraEditors.LabelControl lblSeansTarihSaat;
        private global::DevExpress.XtraEditors.DateEdit dtSeans;
        private global::DevExpress.XtraEditors.LabelControl lblSeansFiyat;
        private global::DevExpress.XtraEditors.SpinEdit numFiyat;
        private global::DevExpress.XtraEditors.SimpleButton btnSeansEkle;
        private global::DevExpress.XtraEditors.SimpleButton btnSeansSil;
        private global::DevExpress.XtraEditors.SimpleButton btnKapat;
        private global::DevExpress.XtraGrid.GridControl gridSeans;
        private global::DevExpress.XtraGrid.Views.Grid.GridView gridViewSeans;
    }
}
