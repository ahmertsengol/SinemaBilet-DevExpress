using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTab;

namespace Sinemaci.BiletSistemi.Forms
{
    partial class FrmPersonel
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
            pnlHeader = new PanelControl();
            lblBaslik = new LabelControl();
            pnlToolbar = new PanelControl();
            btnSeansYonet = new SimpleButton();
            btnRaporOlustur = new SimpleButton();
            btnCikis = new SimpleButton();
            tabControl = new XtraTabControl();
            tabFilm = new XtraTabPage();
            splitFilm = new SplitContainerControl();
            grpFilmGiris = new GroupControl();
            lblFilmAd = new LabelControl();
            txtFilmAd = new TextEdit();
            lblTur = new LabelControl();
            txtTur = new TextEdit();
            lblSure = new LabelControl();
            numSure = new SpinEdit();
            btnFilmEkle = new SimpleButton();
            btnFilmSil = new SimpleButton();
            grpFilmListe = new GroupControl();
            gridFilm = new GridControl();
            gridViewFilm = new GridView();
            tabSalon = new XtraTabPage();
            tabMusteri = new XtraTabPage();
            splitMusteri = new SplitContainerControl();
            grpMusteriGiris = new GroupControl();
            lblMusteriAd = new LabelControl();
            txtMusteriAd = new TextEdit();
            lblMusteriEmail = new LabelControl();
            txtMusteriEmail = new TextEdit();
            lblMusteriBakiye = new LabelControl();
            numMusteriBakiye = new SpinEdit();
            btnMusteriBakiyeGuncelle = new SimpleButton();
            grpMusteriListe = new GroupControl();
            gridMusteri = new GridControl();
            gridViewMusteri = new GridView();
            splitSalon = new SplitContainerControl();
            grpSalonGiris = new GroupControl();
            lblSalonAd = new LabelControl();
            txtSalonAd = new TextEdit();
            lblKoltukSayisi = new LabelControl();
            numKoltukSayisi = new SpinEdit();
            btnSalonEkle = new SimpleButton();
            btnSalonSil = new SimpleButton();
            grpSalonListe = new GroupControl();
            gridSalon = new GridControl();
            gridViewSalon = new GridView();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlToolbar).BeginInit();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabControl).BeginInit();
            tabControl.SuspendLayout();
            tabFilm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitFilm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitFilm.Panel1).BeginInit();
            splitFilm.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitFilm.Panel2).BeginInit();
            splitFilm.Panel2.SuspendLayout();
            splitFilm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpFilmGiris).BeginInit();
            grpFilmGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFilmAd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTur.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSure.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpFilmListe).BeginInit();
            grpFilmListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFilm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewFilm).BeginInit();
            tabSalon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitSalon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitSalon.Panel1).BeginInit();
            splitSalon.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitSalon.Panel2).BeginInit();
            splitSalon.Panel2.SuspendLayout();
            splitSalon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpSalonGiris).BeginInit();
            grpSalonGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSalonAd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKoltukSayisi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpSalonListe).BeginInit();
            grpSalonListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSalon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSalon).BeginInit();
            tabMusteri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMusteri).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitMusteri.Panel1).BeginInit();
            splitMusteri.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMusteri.Panel2).BeginInit();
            splitMusteri.Panel2.SuspendLayout();
            splitMusteri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpMusteriGiris).BeginInit();
            grpMusteriGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMusteriAd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMusteriEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMusteriBakiye.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpMusteriListe).BeginInit();
            grpMusteriListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridMusteri).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMusteri).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Appearance.BackColor2 = Color.FromArgb(52, 73, 94);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblBaslik);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(770, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.Appearance.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBaslik.Appearance.ForeColor = Color.White;
            lblBaslik.Appearance.Options.UseFont = true;
            lblBaslik.Appearance.Options.UseForeColor = true;
            lblBaslik.Location = new Point(20, 15);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(280, 37);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "🎬 Personel Paneli";
            // 
            // pnlToolbar
            // 
            pnlToolbar.BorderStyle = BorderStyles.NoBorder;
            pnlToolbar.Controls.Add(btnSeansYonet);
            pnlToolbar.Controls.Add(btnRaporOlustur);
            pnlToolbar.Controls.Add(btnCikis);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 80);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(15, 10, 15, 10);
            pnlToolbar.Size = new Size(770, 60);
            pnlToolbar.TabIndex = 1;
            // 
            // btnSeansYonet
            // 
            btnSeansYonet.Appearance.BackColor = Color.FromArgb(52, 152, 219);
            btnSeansYonet.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSeansYonet.Appearance.ForeColor = Color.White;
            btnSeansYonet.Appearance.Options.UseBackColor = true;
            btnSeansYonet.Appearance.Options.UseFont = true;
            btnSeansYonet.Appearance.Options.UseForeColor = true;
            btnSeansYonet.Cursor = Cursors.Hand;
            btnSeansYonet.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            btnSeansYonet.Location = new Point(20, 10);
            btnSeansYonet.Name = "btnSeansYonet";
            btnSeansYonet.Size = new Size(180, 40);
            btnSeansYonet.TabIndex = 0;
            btnSeansYonet.Text = "📅 Seans Yönet";
            btnSeansYonet.Click += btnSeansYonet_Click;
            // 
            // btnRaporOlustur
            // 
            btnRaporOlustur.Appearance.BackColor = Color.FromArgb(46, 204, 113);
            btnRaporOlustur.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRaporOlustur.Appearance.ForeColor = Color.White;
            btnRaporOlustur.Appearance.Options.UseBackColor = true;
            btnRaporOlustur.Appearance.Options.UseFont = true;
            btnRaporOlustur.Appearance.Options.UseForeColor = true;
            btnRaporOlustur.Cursor = Cursors.Hand;
            btnRaporOlustur.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            btnRaporOlustur.Location = new Point(210, 10);
            btnRaporOlustur.Name = "btnRaporOlustur";
            btnRaporOlustur.Size = new Size(180, 40);
            btnRaporOlustur.TabIndex = 1;
            btnRaporOlustur.Text = "📊 Rapor Oluştur";
            btnRaporOlustur.Click += btnRaporOlustur_Click;
            // 
            // btnCikis
            // 
            btnCikis.Appearance.BackColor = Color.FromArgb(149, 165, 166);
            btnCikis.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCikis.Appearance.ForeColor = Color.White;
            btnCikis.Appearance.Options.UseBackColor = true;
            btnCikis.Appearance.Options.UseFont = true;
            btnCikis.Appearance.Options.UseForeColor = true;
            btnCikis.Cursor = Cursors.Hand;
            btnCikis.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            btnCikis.Location = new Point(400, 10);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(150, 40);
            btnCikis.TabIndex = 2;
            btnCikis.Text = "🚪 Çıkış";
            btnCikis.Click += btnCikis_Click;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 140);
            tabControl.Name = "tabControl";
            tabControl.SelectedTabPage = tabFilm;
            tabControl.Size = new Size(770, 560);
            tabControl.TabIndex = 2;
            tabControl.TabPages.AddRange(new XtraTabPage[] { tabFilm, tabSalon, tabMusteri });
            // 
            // tabFilm
            //
            tabFilm.Controls.Add(splitFilm);
            tabFilm.Name = "tabFilm";
            tabFilm.Size = new Size(766, 511);
            tabFilm.Text = "🎬 Film Yönetimi";
            // 
            // splitFilm
            // 
            splitFilm.Dock = DockStyle.Fill;
            splitFilm.Location = new Point(0, 0);
            splitFilm.Name = "splitFilm";
            // 
            // splitFilm.Panel1
            // 
            splitFilm.Panel1.Controls.Add(grpFilmGiris);
            splitFilm.Panel1.Padding = new Padding(10);
            splitFilm.Panel1.Text = "Panel1";
            // 
            // splitFilm.Panel2
            // 
            splitFilm.Panel2.Controls.Add(grpFilmListe);
            splitFilm.Panel2.Padding = new Padding(10);
            splitFilm.Panel2.Text = "Panel2";
            splitFilm.Size = new Size(766, 511);
            splitFilm.SplitterPosition = 400;
            splitFilm.TabIndex = 0;
            // 
            // grpFilmGiris
            // 
            grpFilmGiris.Controls.Add(lblFilmAd);
            grpFilmGiris.Controls.Add(txtFilmAd);
            grpFilmGiris.Controls.Add(lblTur);
            grpFilmGiris.Controls.Add(txtTur);
            grpFilmGiris.Controls.Add(lblSure);
            grpFilmGiris.Controls.Add(numSure);
            grpFilmGiris.Controls.Add(btnFilmEkle);
            grpFilmGiris.Controls.Add(btnFilmSil);
            grpFilmGiris.Dock = DockStyle.Fill;
            grpFilmGiris.Location = new Point(10, 10);
            grpFilmGiris.Name = "grpFilmGiris";
            grpFilmGiris.Size = new Size(380, 491);
            grpFilmGiris.TabIndex = 0;
            grpFilmGiris.Text = "Yeni Film Ekle";
            // 
            // lblFilmAd
            // 
            lblFilmAd.Appearance.Font = new Font("Segoe UI", 14F);
            lblFilmAd.Appearance.Options.UseFont = true;
            lblFilmAd.Location = new Point(20, 40);
            lblFilmAd.Name = "lblFilmAd";
            lblFilmAd.Size = new Size(103, 37);
            lblFilmAd.TabIndex = 0;
            lblFilmAd.Text = "Film Adı:";
            // 
            // txtFilmAd
            // 
            txtFilmAd.Location = new Point(20, 65);
            txtFilmAd.Name = "txtFilmAd";
            txtFilmAd.Properties.Appearance.Font = new Font("Segoe UI", 14F);
            txtFilmAd.Properties.Appearance.Options.UseFont = true;
            txtFilmAd.Size = new Size(340, 35);
            txtFilmAd.TabIndex = 1;
            // 
            // lblTur
            // 
            lblTur.Appearance.Font = new Font("Segoe UI", 14F);
            lblTur.Appearance.Options.UseFont = true;
            lblTur.Location = new Point(20, 110);
            lblTur.Name = "lblTur";
            lblTur.Size = new Size(44, 37);
            lblTur.TabIndex = 2;
            lblTur.Text = "Tür:";
            // 
            // txtTur
            // 
            txtTur.Location = new Point(20, 135);
            txtTur.Name = "txtTur";
            txtTur.Properties.Appearance.Font = new Font("Segoe UI", 14F);
            txtTur.Properties.Appearance.Options.UseFont = true;
            txtTur.Size = new Size(340, 35);
            txtTur.TabIndex = 3;
            // 
            // lblSure
            // 
            lblSure.Appearance.Font = new Font("Segoe UI", 14F);
            lblSure.Appearance.Options.UseFont = true;
            lblSure.Location = new Point(20, 180);
            lblSure.Name = "lblSure";
            lblSure.Size = new Size(161, 37);
            lblSure.TabIndex = 4;
            lblSure.Text = "Süre (Dakika):";
            // 
            // numSure
            // 
            numSure.EditValue = new decimal(new int[] { 120, 0, 0, 0 });
            numSure.Location = new Point(20, 205);
            numSure.Name = "numSure";
            numSure.Properties.Appearance.Font = new Font("Segoe UI", 14F);
            numSure.Properties.Appearance.Options.UseFont = true;
            numSure.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            numSure.Properties.MaxValue = new decimal(new int[] { 400, 0, 0, 0 });
            numSure.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            numSure.Size = new Size(340, 35);
            numSure.TabIndex = 5;
            // 
            // btnFilmEkle
            // 
            btnFilmEkle.Appearance.BackColor = Color.FromArgb(46, 204, 113);
            btnFilmEkle.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilmEkle.Appearance.ForeColor = Color.White;
            btnFilmEkle.Appearance.Options.UseBackColor = true;
            btnFilmEkle.Appearance.Options.UseFont = true;
            btnFilmEkle.Appearance.Options.UseForeColor = true;
            btnFilmEkle.Cursor = Cursors.Hand;
            btnFilmEkle.Location = new Point(20, 260);
            btnFilmEkle.Name = "btnFilmEkle";
            btnFilmEkle.Size = new Size(340, 45);
            btnFilmEkle.TabIndex = 6;
            btnFilmEkle.Text = "✅ Film Ekle";
            btnFilmEkle.Click += btnFilmEkle_Click;
            // 
            // btnFilmSil
            // 
            btnFilmSil.Appearance.BackColor = Color.FromArgb(231, 76, 60);
            btnFilmSil.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilmSil.Appearance.ForeColor = Color.White;
            btnFilmSil.Appearance.Options.UseBackColor = true;
            btnFilmSil.Appearance.Options.UseFont = true;
            btnFilmSil.Appearance.Options.UseForeColor = true;
            btnFilmSil.Cursor = Cursors.Hand;
            btnFilmSil.Location = new Point(20, 320);
            btnFilmSil.Name = "btnFilmSil";
            btnFilmSil.Size = new Size(340, 45);
            btnFilmSil.TabIndex = 7;
            btnFilmSil.Text = "🗑️ Seçili Filmi Sil";
            btnFilmSil.Click += btnFilmSil_Click;
            // 
            // grpFilmListe
            // 
            grpFilmListe.Controls.Add(gridFilm);
            grpFilmListe.Dock = DockStyle.Fill;
            grpFilmListe.Location = new Point(10, 10);
            grpFilmListe.Name = "grpFilmListe";
            grpFilmListe.Size = new Size(326, 491);
            grpFilmListe.TabIndex = 0;
            grpFilmListe.Text = "Film Listesi";
            // 
            // gridFilm
            // 
            gridFilm.Dock = DockStyle.Fill;
            gridFilm.Location = new Point(3, 45);
            gridFilm.MainView = gridViewFilm;
            gridFilm.Name = "gridFilm";
            gridFilm.Size = new Size(566, 595);
            gridFilm.TabIndex = 0;
            gridFilm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewFilm });
            // 
            // gridViewFilm
            // 
            gridViewFilm.Appearance.Row.Font = new Font("Segoe UI", 15F);
            gridViewFilm.Appearance.Row.Options.UseFont = true;
            gridViewFilm.GridControl = gridFilm;
            gridViewFilm.Name = "gridViewFilm";
            gridViewFilm.OptionsBehavior.Editable = false;
            gridViewFilm.OptionsView.ShowGroupPanel = false;
            // 
            // tabSalon
            // 
            tabSalon.Controls.Add(splitSalon);
            tabSalon.Name = "tabSalon";
            tabSalon.Size = new Size(766, 511);
            tabSalon.Text = "🏛️ Salon Yönetimi";
            // 
            // splitSalon
            // 
            splitSalon.Dock = DockStyle.Fill;
            splitSalon.Location = new Point(0, 0);
            splitSalon.Name = "splitSalon";
            // 
            // splitSalon.Panel1
            // 
            splitSalon.Panel1.Controls.Add(grpSalonGiris);
            splitSalon.Panel1.Padding = new Padding(10);
            splitSalon.Panel1.Text = "Panel1";
            // 
            // splitSalon.Panel2
            // 
            splitSalon.Panel2.Controls.Add(grpSalonListe);
            splitSalon.Panel2.Padding = new Padding(10);
            splitSalon.Panel2.Text = "Panel2";
            splitSalon.Size = new Size(766, 511);
            splitSalon.SplitterPosition = 400;
            splitSalon.TabIndex = 0;
            // 
            // grpSalonGiris
            // 
            grpSalonGiris.Controls.Add(lblSalonAd);
            grpSalonGiris.Controls.Add(txtSalonAd);
            grpSalonGiris.Controls.Add(lblKoltukSayisi);
            grpSalonGiris.Controls.Add(numKoltukSayisi);
            grpSalonGiris.Controls.Add(btnSalonEkle);
            grpSalonGiris.Controls.Add(btnSalonSil);
            grpSalonGiris.Dock = DockStyle.Fill;
            grpSalonGiris.Location = new Point(10, 10);
            grpSalonGiris.Name = "grpSalonGiris";
            grpSalonGiris.Size = new Size(380, 491);
            grpSalonGiris.TabIndex = 0;
            grpSalonGiris.Text = "Yeni Salon Ekle";
            // 
            // lblSalonAd
            // 
            lblSalonAd.Appearance.Font = new Font("Segoe UI", 14F);
            lblSalonAd.Appearance.Options.UseFont = true;
            lblSalonAd.Location = new Point(20, 40);
            lblSalonAd.Name = "lblSalonAd";
            lblSalonAd.Size = new Size(119, 37);
            lblSalonAd.TabIndex = 0;
            lblSalonAd.Text = "Salon Adı:";
            // 
            // txtSalonAd
            // 
            txtSalonAd.Location = new Point(20, 65);
            txtSalonAd.Name = "txtSalonAd";
            txtSalonAd.Properties.Appearance.Font = new Font("Segoe UI", 14F);
            txtSalonAd.Properties.Appearance.Options.UseFont = true;
            txtSalonAd.Size = new Size(340, 35);
            txtSalonAd.TabIndex = 1;
            // 
            // lblKoltukSayisi
            // 
            lblKoltukSayisi.Appearance.Font = new Font("Segoe UI", 14F);
            lblKoltukSayisi.Appearance.Options.UseFont = true;
            lblKoltukSayisi.Location = new Point(20, 110);
            lblKoltukSayisi.Name = "lblKoltukSayisi";
            lblKoltukSayisi.Size = new Size(155, 37);
            lblKoltukSayisi.TabIndex = 2;
            lblKoltukSayisi.Text = "Koltuk Sayısı:";
            // 
            // numKoltukSayisi
            // 
            numKoltukSayisi.EditValue = new decimal(new int[] { 50, 0, 0, 0 });
            numKoltukSayisi.Location = new Point(20, 135);
            numKoltukSayisi.Name = "numKoltukSayisi";
            numKoltukSayisi.Properties.Appearance.Font = new Font("Segoe UI", 14F);
            numKoltukSayisi.Properties.Appearance.Options.UseFont = true;
            numKoltukSayisi.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            numKoltukSayisi.Properties.MaxValue = new decimal(new int[] { 300, 0, 0, 0 });
            numKoltukSayisi.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            numKoltukSayisi.Size = new Size(340, 35);
            numKoltukSayisi.TabIndex = 3;
            // 
            // btnSalonEkle
            // 
            btnSalonEkle.Appearance.BackColor = Color.FromArgb(46, 204, 113);
            btnSalonEkle.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalonEkle.Appearance.ForeColor = Color.White;
            btnSalonEkle.Appearance.Options.UseBackColor = true;
            btnSalonEkle.Appearance.Options.UseFont = true;
            btnSalonEkle.Appearance.Options.UseForeColor = true;
            btnSalonEkle.Cursor = Cursors.Hand;
            btnSalonEkle.Location = new Point(20, 190);
            btnSalonEkle.Name = "btnSalonEkle";
            btnSalonEkle.Size = new Size(340, 45);
            btnSalonEkle.TabIndex = 4;
            btnSalonEkle.Text = "✅ Salon Ekle";
            btnSalonEkle.Click += btnSalonEkle_Click;
            // 
            // btnSalonSil
            // 
            btnSalonSil.Appearance.BackColor = Color.FromArgb(231, 76, 60);
            btnSalonSil.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalonSil.Appearance.ForeColor = Color.White;
            btnSalonSil.Appearance.Options.UseBackColor = true;
            btnSalonSil.Appearance.Options.UseFont = true;
            btnSalonSil.Appearance.Options.UseForeColor = true;
            btnSalonSil.Cursor = Cursors.Hand;
            btnSalonSil.Location = new Point(20, 250);
            btnSalonSil.Name = "btnSalonSil";
            btnSalonSil.Size = new Size(340, 45);
            btnSalonSil.TabIndex = 5;
            btnSalonSil.Text = "🗑️ Seçili Salonu Sil";
            btnSalonSil.Click += btnSalonSil_Click;
            // 
            // grpSalonListe
            // 
            grpSalonListe.Controls.Add(gridSalon);
            grpSalonListe.Dock = DockStyle.Fill;
            grpSalonListe.Location = new Point(10, 10);
            grpSalonListe.Name = "grpSalonListe";
            grpSalonListe.Size = new Size(326, 491);
            grpSalonListe.TabIndex = 0;
            grpSalonListe.Text = "Salon Listesi";
            // 
            // gridSalon
            // 
            gridSalon.Dock = DockStyle.Fill;
            gridSalon.Location = new Point(3, 45);
            gridSalon.MainView = gridViewSalon;
            gridSalon.Name = "gridSalon";
            gridSalon.Size = new Size(320, 443);
            gridSalon.TabIndex = 0;
            gridSalon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewSalon });
            // 
            // gridViewSalon
            // 
            gridViewSalon.Appearance.Row.Font = new Font("Segoe UI", 15F);
            gridViewSalon.Appearance.Row.Options.UseFont = true;
            gridViewSalon.GridControl = gridSalon;
            gridViewSalon.Name = "gridViewSalon";
            gridViewSalon.OptionsBehavior.Editable = false;
            gridViewSalon.OptionsView.ShowGroupPanel = false;

            // === TAB MUSTERI ===
            tabMusteri.Name = "tabMusteri";
            tabMusteri.Size = new Size(766, 511);
            tabMusteri.Text = "👥 Musteri Yonetimi";
            tabMusteri.Controls.Add(splitMusteri);

            splitMusteri.Dock = DockStyle.Fill;
            splitMusteri.Location = new Point(0, 0);
            splitMusteri.Name = "splitMusteri";
            splitMusteri.Panel1.Controls.Add(grpMusteriGiris);
            splitMusteri.Panel2.Controls.Add(grpMusteriListe);
            splitMusteri.Size = new Size(766, 511);
            splitMusteri.SplitterPosition = 350;
            splitMusteri.TabIndex = 0;

            grpMusteriGiris.Controls.Add(lblMusteriAd);
            grpMusteriGiris.Controls.Add(txtMusteriAd);
            grpMusteriGiris.Controls.Add(lblMusteriEmail);
            grpMusteriGiris.Controls.Add(txtMusteriEmail);
            grpMusteriGiris.Controls.Add(lblMusteriBakiye);
            grpMusteriGiris.Controls.Add(numMusteriBakiye);
            grpMusteriGiris.Controls.Add(btnMusteriBakiyeGuncelle);
            grpMusteriGiris.Dock = DockStyle.Fill;
            grpMusteriGiris.Location = new Point(0, 0);
            grpMusteriGiris.Name = "grpMusteriGiris";
            grpMusteriGiris.Size = new Size(350, 511);
            grpMusteriGiris.TabIndex = 0;
            grpMusteriGiris.Text = "Musteri Bilgileri";

            lblMusteriAd.Appearance.Font = new Font("Segoe UI", 11F);
            lblMusteriAd.Location = new Point(20, 40);
            lblMusteriAd.Name = "lblMusteriAd";
            lblMusteriAd.Size = new Size(70, 20);
            lblMusteriAd.Text = "Ad Soyad:";

            txtMusteriAd.Location = new Point(20, 65);
            txtMusteriAd.Name = "txtMusteriAd";
            txtMusteriAd.Properties.ReadOnly = true;
            txtMusteriAd.Size = new Size(300, 26);

            lblMusteriEmail.Appearance.Font = new Font("Segoe UI", 11F);
            lblMusteriEmail.Location = new Point(20, 110);
            lblMusteriEmail.Name = "lblMusteriEmail";
            lblMusteriEmail.Size = new Size(60, 20);
            lblMusteriEmail.Text = "E-posta:";

            txtMusteriEmail.Location = new Point(20, 135);
            txtMusteriEmail.Name = "txtMusteriEmail";
            txtMusteriEmail.Properties.ReadOnly = true;
            txtMusteriEmail.Size = new Size(300, 26);

            lblMusteriBakiye.Appearance.Font = new Font("Segoe UI", 11F);
            lblMusteriBakiye.Location = new Point(20, 180);
            lblMusteriBakiye.Name = "lblMusteriBakiye";
            lblMusteriBakiye.Size = new Size(50, 20);
            lblMusteriBakiye.Text = "Bakiye:";

            numMusteriBakiye.Location = new Point(20, 205);
            numMusteriBakiye.Name = "numMusteriBakiye";
            numMusteriBakiye.Size = new Size(200, 26);

            btnMusteriBakiyeGuncelle.Appearance.BackColor = Color.FromArgb(52, 152, 219);
            btnMusteriBakiyeGuncelle.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMusteriBakiyeGuncelle.Appearance.ForeColor = Color.White;
            btnMusteriBakiyeGuncelle.Appearance.Options.UseBackColor = true;
            btnMusteriBakiyeGuncelle.Appearance.Options.UseFont = true;
            btnMusteriBakiyeGuncelle.Appearance.Options.UseForeColor = true;
            btnMusteriBakiyeGuncelle.Cursor = Cursors.Hand;
            btnMusteriBakiyeGuncelle.Location = new Point(20, 260);
            btnMusteriBakiyeGuncelle.Name = "btnMusteriBakiyeGuncelle";
            btnMusteriBakiyeGuncelle.Size = new Size(200, 40);
            btnMusteriBakiyeGuncelle.TabIndex = 6;
            btnMusteriBakiyeGuncelle.Text = "💰 Bakiye Guncelle";
            btnMusteriBakiyeGuncelle.Click += btnMusteriBakiyeGuncelle_Click;

            grpMusteriListe.Controls.Add(gridMusteri);
            grpMusteriListe.Dock = DockStyle.Fill;
            grpMusteriListe.Location = new Point(0, 0);
            grpMusteriListe.Name = "grpMusteriListe";
            grpMusteriListe.Size = new Size(411, 511);
            grpMusteriListe.TabIndex = 0;
            grpMusteriListe.Text = "Musteri Listesi";

            gridMusteri.Dock = DockStyle.Fill;
            gridMusteri.Location = new Point(2, 28);
            gridMusteri.MainView = gridViewMusteri;
            gridMusteri.Name = "gridMusteri";
            gridMusteri.Size = new Size(407, 481);
            gridMusteri.TabIndex = 0;
            gridMusteri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewMusteri });

            gridViewMusteri.Appearance.HeaderPanel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            gridViewMusteri.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewMusteri.Appearance.Row.Font = new Font("Segoe UI", 15F);
            gridViewMusteri.Appearance.Row.Options.UseFont = true;
            gridViewMusteri.GridControl = gridMusteri;
            gridViewMusteri.Name = "gridViewMusteri";
            gridViewMusteri.OptionsBehavior.Editable = false;
            gridViewMusteri.OptionsView.ShowGroupPanel = false;
            //
            // FrmPersonel
            //
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            ClientSize = new Size(1000, 700);
            Controls.Add(tabControl);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Tahoma", 8.25F);
            IconOptions.ShowIcon = false;
            Name = "FrmPersonel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personel Paneli - Sinemacı";
            WindowState = FormWindowState.Maximized;
            Load += FrmPersonel_Load;
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlToolbar).EndInit();
            pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabControl).EndInit();
            tabControl.ResumeLayout(false);
            tabFilm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitFilm.Panel1).EndInit();
            splitFilm.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitFilm.Panel2).EndInit();
            splitFilm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitFilm).EndInit();
            splitFilm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpFilmGiris).EndInit();
            grpFilmGiris.ResumeLayout(false);
            grpFilmGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFilmAd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTur.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSure.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpFilmListe).EndInit();
            grpFilmListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFilm).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewFilm).EndInit();
            tabSalon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitSalon.Panel1).EndInit();
            splitSalon.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitSalon.Panel2).EndInit();
            splitSalon.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitSalon).EndInit();
            splitSalon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpSalonGiris).EndInit();
            grpSalonGiris.ResumeLayout(false);
            grpSalonGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtSalonAd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKoltukSayisi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpSalonListe).EndInit();
            grpSalonListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSalon).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSalon).EndInit();
            tabMusteri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMusteri.Panel1).EndInit();
            splitMusteri.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMusteri.Panel2).EndInit();
            splitMusteri.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMusteri).EndInit();
            splitMusteri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpMusteriGiris).EndInit();
            grpMusteriGiris.ResumeLayout(false);
            grpMusteriGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMusteriAd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMusteriEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMusteriBakiye.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpMusteriListe).EndInit();
            grpMusteriListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridMusteri).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMusteri).EndInit();
            ResumeLayout(false);

        }

        private global::DevExpress.XtraEditors.PanelControl pnlHeader;
        private global::DevExpress.XtraEditors.LabelControl lblBaslik;
        private global::DevExpress.XtraEditors.PanelControl pnlToolbar;
        private global::DevExpress.XtraEditors.SimpleButton btnSeansYonet;
        private global::DevExpress.XtraEditors.SimpleButton btnRaporOlustur;
        private global::DevExpress.XtraEditors.SimpleButton btnCikis;
        private global::DevExpress.XtraTab.XtraTabControl tabControl;
        private global::DevExpress.XtraTab.XtraTabPage tabFilm;
        private global::DevExpress.XtraEditors.SplitContainerControl splitFilm;
        private global::DevExpress.XtraEditors.GroupControl grpFilmGiris;
        private global::DevExpress.XtraEditors.LabelControl lblFilmAd;
        private global::DevExpress.XtraEditors.TextEdit txtFilmAd;
        private global::DevExpress.XtraEditors.LabelControl lblTur;
        private global::DevExpress.XtraEditors.TextEdit txtTur;
        private global::DevExpress.XtraEditors.LabelControl lblSure;
        private global::DevExpress.XtraEditors.SpinEdit numSure;
        private global::DevExpress.XtraEditors.SimpleButton btnFilmEkle;
        private global::DevExpress.XtraEditors.SimpleButton btnFilmSil;
        private global::DevExpress.XtraEditors.GroupControl grpFilmListe;
        private global::DevExpress.XtraGrid.GridControl gridFilm;
        private global::DevExpress.XtraGrid.Views.Grid.GridView gridViewFilm;
        private global::DevExpress.XtraTab.XtraTabPage tabSalon;
        private global::DevExpress.XtraEditors.SplitContainerControl splitSalon;
        private global::DevExpress.XtraEditors.GroupControl grpSalonGiris;
        private global::DevExpress.XtraEditors.LabelControl lblSalonAd;
        private global::DevExpress.XtraEditors.TextEdit txtSalonAd;
        private global::DevExpress.XtraEditors.LabelControl lblKoltukSayisi;
        private global::DevExpress.XtraEditors.SpinEdit numKoltukSayisi;
        private global::DevExpress.XtraEditors.SimpleButton btnSalonEkle;
        private global::DevExpress.XtraEditors.SimpleButton btnSalonSil;
        private global::DevExpress.XtraEditors.GroupControl grpSalonListe;
        private global::DevExpress.XtraGrid.GridControl gridSalon;
        private global::DevExpress.XtraGrid.Views.Grid.GridView gridViewSalon;
        private global::DevExpress.XtraTab.XtraTabPage tabMusteri;
        private global::DevExpress.XtraEditors.SplitContainerControl splitMusteri;
        private global::DevExpress.XtraEditors.GroupControl grpMusteriGiris;
        private global::DevExpress.XtraEditors.LabelControl lblMusteriAd;
        private global::DevExpress.XtraEditors.TextEdit txtMusteriAd;
        private global::DevExpress.XtraEditors.LabelControl lblMusteriEmail;
        private global::DevExpress.XtraEditors.TextEdit txtMusteriEmail;
        private global::DevExpress.XtraEditors.LabelControl lblMusteriBakiye;
        private global::DevExpress.XtraEditors.SpinEdit numMusteriBakiye;
        private global::DevExpress.XtraEditors.SimpleButton btnMusteriBakiyeGuncelle;
        private global::DevExpress.XtraEditors.GroupControl grpMusteriListe;
        private global::DevExpress.XtraGrid.GridControl gridMusteri;
        private global::DevExpress.XtraGrid.Views.Grid.GridView gridViewMusteri;
    }
}
