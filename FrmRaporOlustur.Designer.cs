using DevExpress.XtraEditors;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmRaporOlustur
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
            this.grpRaporTuru = new DevExpress.XtraEditors.GroupControl();
            this.radioGroupRaporTuru = new DevExpress.XtraEditors.RadioGroup();
            this.grpTarihSecimi = new DevExpress.XtraEditors.GroupControl();
            this.pnlOzelTarih = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslangic = new DevExpress.XtraEditors.LabelControl();
            this.dtpBaslangic = new DevExpress.XtraEditors.DateEdit();
            this.lblBitis = new DevExpress.XtraEditors.LabelControl();
            this.dtpBitis = new DevExpress.XtraEditors.DateEdit();
            this.lblTarihSecim = new DevExpress.XtraEditors.LabelControl();
            this.cmbTarihSecim = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grpFormat = new DevExpress.XtraEditors.GroupControl();
            this.chkPdf = new DevExpress.XtraEditors.CheckEdit();
            this.chkExcel = new DevExpress.XtraEditors.CheckEdit();
            this.btnOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRaporTuru)).BeginInit();
            this.grpRaporTuru.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupRaporTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTarihSecimi)).BeginInit();
            this.grpTarihSecimi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOzelTarih)).BeginInit();
            this.pnlOzelTarih.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBaslangic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBaslangic.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBitis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBitis.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTarihSecim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFormat)).BeginInit();
            this.grpFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPdf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcel.Properties)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(650, 80);
            this.pnlHeader.TabIndex = 0;
            //
            // lblBaslik
            //
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Location = new System.Drawing.Point(25, 24);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(213, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "📊 Rapor Oluştur";
            //
            // grpRaporTuru
            //
            this.grpRaporTuru.Controls.Add(this.radioGroupRaporTuru);
            this.grpRaporTuru.Location = new System.Drawing.Point(30, 100);
            this.grpRaporTuru.Name = "grpRaporTuru";
            this.grpRaporTuru.Size = new System.Drawing.Size(590, 90);
            this.grpRaporTuru.TabIndex = 1;
            this.grpRaporTuru.Text = "Rapor Türü";
            //
            // radioGroupRaporTuru
            //
            this.radioGroupRaporTuru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupRaporTuru.Location = new System.Drawing.Point(2, 23);
            this.radioGroupRaporTuru.Name = "radioGroupRaporTuru";
            this.radioGroupRaporTuru.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioGroupRaporTuru.Properties.Appearance.Options.UseFont = true;
            this.radioGroupRaporTuru.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Film Bazlı (Film satışları)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Müşteri Bazlı (Müşteri detayları)")});
            this.radioGroupRaporTuru.Size = new System.Drawing.Size(586, 65);
            this.radioGroupRaporTuru.TabIndex = 0;
            //
            // grpTarihSecimi
            //
            this.grpTarihSecimi.Controls.Add(this.pnlOzelTarih);
            this.grpTarihSecimi.Controls.Add(this.lblTarihSecim);
            this.grpTarihSecimi.Controls.Add(this.cmbTarihSecim);
            this.grpTarihSecimi.Location = new System.Drawing.Point(30, 205);
            this.grpTarihSecimi.Name = "grpTarihSecimi";
            this.grpTarihSecimi.Size = new System.Drawing.Size(590, 210);
            this.grpTarihSecimi.TabIndex = 2;
            this.grpTarihSecimi.Text = "Tarih Aralığı";
            //
            // pnlOzelTarih
            //
            this.pnlOzelTarih.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlOzelTarih.Controls.Add(this.lblBaslangic);
            this.pnlOzelTarih.Controls.Add(this.dtpBaslangic);
            this.pnlOzelTarih.Controls.Add(this.lblBitis);
            this.pnlOzelTarih.Controls.Add(this.dtpBitis);
            this.pnlOzelTarih.Location = new System.Drawing.Point(20, 110);
            this.pnlOzelTarih.Name = "pnlOzelTarih";
            this.pnlOzelTarih.Size = new System.Drawing.Size(550, 85);
            this.pnlOzelTarih.TabIndex = 3;
            this.pnlOzelTarih.Visible = false;
            //
            // lblBaslangic
            //
            this.lblBaslangic.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblBaslangic.Appearance.Options.UseFont = true;
            this.lblBaslangic.Location = new System.Drawing.Point(15, 10);
            this.lblBaslangic.Name = "lblBaslangic";
            this.lblBaslangic.Size = new System.Drawing.Size(86, 15);
            this.lblBaslangic.TabIndex = 0;
            this.lblBaslangic.Text = "Başlangıç Tarihi:";
            //
            // dtpBaslangic
            //
            this.dtpBaslangic.EditValue = null;
            this.dtpBaslangic.Location = new System.Drawing.Point(15, 35);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dtpBaslangic.Properties.Appearance.Options.UseFont = true;
            this.dtpBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBaslangic.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBaslangic.Size = new System.Drawing.Size(180, 26);
            this.dtpBaslangic.TabIndex = 1;
            //
            // lblBitis
            //
            this.lblBitis.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblBitis.Appearance.Options.UseFont = true;
            this.lblBitis.Location = new System.Drawing.Point(285, 10);
            this.lblBitis.Name = "lblBitis";
            this.lblBitis.Size = new System.Drawing.Size(59, 15);
            this.lblBitis.TabIndex = 2;
            this.lblBitis.Text = "Bitiş Tarihi:";
            //
            // dtpBitis
            //
            this.dtpBitis.EditValue = null;
            this.dtpBitis.Location = new System.Drawing.Point(285, 35);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dtpBitis.Properties.Appearance.Options.UseFont = true;
            this.dtpBitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBitis.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBitis.Size = new System.Drawing.Size(180, 26);
            this.dtpBitis.TabIndex = 3;
            //
            // lblTarihSecim
            //
            this.lblTarihSecim.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTarihSecim.Appearance.Options.UseFont = true;
            this.lblTarihSecim.Location = new System.Drawing.Point(20, 40);
            this.lblTarihSecim.Name = "lblTarihSecim";
            this.lblTarihSecim.Size = new System.Drawing.Size(97, 15);
            this.lblTarihSecim.TabIndex = 1;
            this.lblTarihSecim.Text = "Hızlı Tarih Seçimi:";
            //
            // cmbTarihSecim
            //
            this.cmbTarihSecim.Location = new System.Drawing.Point(20, 65);
            this.cmbTarihSecim.Name = "cmbTarihSecim";
            this.cmbTarihSecim.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbTarihSecim.Properties.Appearance.Options.UseFont = true;
            this.cmbTarihSecim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTarihSecim.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTarihSecim.Size = new System.Drawing.Size(220, 26);
            this.cmbTarihSecim.TabIndex = 2;
            this.cmbTarihSecim.SelectedIndexChanged += new System.EventHandler(this.cmbTarihSecim_SelectedIndexChanged);
            //
            // grpFormat
            //
            this.grpFormat.Controls.Add(this.chkPdf);
            this.grpFormat.Controls.Add(this.chkExcel);
            this.grpFormat.Location = new System.Drawing.Point(30, 430);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(590, 90);
            this.grpFormat.TabIndex = 3;
            this.grpFormat.Text = "Rapor Formatı";
            //
            // chkPdf
            //
            this.chkPdf.Location = new System.Drawing.Point(20, 40);
            this.chkPdf.Name = "chkPdf";
            this.chkPdf.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.chkPdf.Properties.Appearance.Options.UseFont = true;
            this.chkPdf.Properties.Caption = "PDF (.pdf) - QuestPDF";
            this.chkPdf.Size = new System.Drawing.Size(240, 23);
            this.chkPdf.TabIndex = 0;
            //
            // chkExcel
            //
            this.chkExcel.Location = new System.Drawing.Point(310, 40);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.chkExcel.Properties.Appearance.Options.UseFont = true;
            this.chkExcel.Properties.Caption = "Excel (.xlsx) - EPPlus";
            this.chkExcel.Size = new System.Drawing.Size(240, 23);
            this.chkExcel.TabIndex = 1;
            //
            // btnOlustur
            //
            this.btnOlustur.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOlustur.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnOlustur.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOlustur.Appearance.Options.UseBackColor = true;
            this.btnOlustur.Appearance.Options.UseFont = true;
            this.btnOlustur.Appearance.Options.UseForeColor = true;
            this.btnOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOlustur.Location = new System.Drawing.Point(30, 540);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(280, 45);
            this.btnOlustur.TabIndex = 4;
            this.btnOlustur.Text = "✓ Rapor Oluştur";
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            //
            // btnIptal
            //
            this.btnIptal.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnIptal.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Appearance.Options.UseBackColor = true;
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.Appearance.Options.UseForeColor = true;
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.Location = new System.Drawing.Point(340, 540);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(280, 45);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "✕ İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            //
            // FrmRaporOlustur
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(650, 600);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnOlustur);
            this.Controls.Add(this.grpFormat);
            this.Controls.Add(this.grpTarihSecimi);
            this.Controls.Add(this.grpRaporTuru);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRaporOlustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor Oluştur - Sinemacı";
            this.Load += new System.EventHandler(this.FrmRaporOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRaporTuru)).EndInit();
            this.grpRaporTuru.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupRaporTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTarihSecimi)).EndInit();
            this.grpTarihSecimi.ResumeLayout(false);
            this.grpTarihSecimi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOzelTarih)).EndInit();
            this.pnlOzelTarih.ResumeLayout(false);
            this.pnlOzelTarih.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBaslangic.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBaslangic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBitis.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBitis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTarihSecim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFormat)).EndInit();
            this.grpFormat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPdf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private global::DevExpress.XtraEditors.PanelControl pnlHeader;
        private global::DevExpress.XtraEditors.LabelControl lblBaslik;
        private global::DevExpress.XtraEditors.GroupControl grpRaporTuru;
        private global::DevExpress.XtraEditors.RadioGroup radioGroupRaporTuru;
        private global::DevExpress.XtraEditors.GroupControl grpTarihSecimi;
        private global::DevExpress.XtraEditors.LabelControl lblTarihSecim;
        private global::DevExpress.XtraEditors.ComboBoxEdit cmbTarihSecim;
        private global::DevExpress.XtraEditors.PanelControl pnlOzelTarih;
        private global::DevExpress.XtraEditors.LabelControl lblBaslangic;
        private global::DevExpress.XtraEditors.DateEdit dtpBaslangic;
        private global::DevExpress.XtraEditors.LabelControl lblBitis;
        private global::DevExpress.XtraEditors.DateEdit dtpBitis;
        private global::DevExpress.XtraEditors.GroupControl grpFormat;
        private global::DevExpress.XtraEditors.CheckEdit chkPdf;
        private global::DevExpress.XtraEditors.CheckEdit chkExcel;
        private global::DevExpress.XtraEditors.SimpleButton btnOlustur;
        private global::DevExpress.XtraEditors.SimpleButton btnIptal;
    }
}
