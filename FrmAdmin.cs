using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Domain;
using Sinemaci.BiletSistemi.Helper;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Admin Paneli - DevExpress XtraForm
    /// Modern Tab-based UI: Film + Salon + Musteri + Personel Yonetimi
    /// </summary>
    public partial class FrmAdmin : XtraForm
    {
        private readonly int _kullaniciId;

        public FrmAdmin(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            this.Text = "Admin Paneli - Sinemaci";
        }

        private async void FrmAdmin_Load(object sender, EventArgs e)
        {
            // Grid ayarlari
            ConfigureFilmGrid();
            ConfigureSalonGrid();
            ConfigureMusteriGrid();
            ConfigurePersonelGrid();

            // Toolbar hover efektleri
            DevExpressUIHelper.AddHoverEffect(btnSeansYonet, DevExpressTheme.Info, Color.FromArgb(41, 128, 185));
            DevExpressUIHelper.AddHoverEffect(btnRaporOlustur, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnCikis, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));

            // Film butonlari hover
            DevExpressUIHelper.AddHoverEffect(btnFilmEkle, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnFilmSil, DevExpressTheme.Danger, Color.FromArgb(192, 57, 43));

            // Salon butonlari hover
            DevExpressUIHelper.AddHoverEffect(btnSalonEkle, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnSalonSil, DevExpressTheme.Danger, Color.FromArgb(192, 57, 43));

            // Musteri butonlari hover
            DevExpressUIHelper.AddHoverEffect(btnMusteriBakiyeGuncelle, DevExpressTheme.Info, Color.FromArgb(41, 128, 185));
            DevExpressUIHelper.AddHoverEffect(btnMusteriSil, DevExpressTheme.Danger, Color.FromArgb(192, 57, 43));

            // Personel butonlari hover
            DevExpressUIHelper.AddHoverEffect(btnPersonelEkle, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnPersonelGuncelle, DevExpressTheme.Info, Color.FromArgb(41, 128, 185));
            DevExpressUIHelper.AddHoverEffect(btnPersonelSil, DevExpressTheme.Danger, Color.FromArgb(192, 57, 43));

            // SpinEdit ayarlari - Film
            numSure.Properties.MinValue = 1;
            numSure.Properties.MaxValue = 400;
            numSure.EditValue = 120;

            // SpinEdit ayarlari - Salon
            numKoltukSayisi.Properties.MinValue = 1;
            numKoltukSayisi.Properties.MaxValue = 300;
            numKoltukSayisi.EditValue = 50;

            // SpinEdit ayarlari - Musteri
            numMusteriBakiye.Properties.MinValue = 0;
            numMusteriBakiye.Properties.MaxValue = 100000;
            numMusteriBakiye.EditValue = 0;
            numMusteriBakiye.Properties.DisplayFormat.FormatString = "c2"; // Currency format
            numMusteriBakiye.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            // ComboBox ayarlari - Personel Rol
            cmbPersonelRol.Properties.Items.Clear();
            cmbPersonelRol.Properties.Items.Add("Personel");
            cmbPersonelRol.Properties.Items.Add("Admin");
            cmbPersonelRol.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbPersonelRol.EditValue = "Personel";

            // Sifre gizleme
            txtPersonelSifre.Properties.PasswordChar = '●';

            // Tab stil ayarlari
            tabControl.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            tabControl.Appearance.ForeColor = DevExpressTheme.Primary;
            tabControl.Appearance.Options.UseFont = true;
            tabControl.Appearance.Options.UseForeColor = true;

            // Ilk yukleme
            await YenileFilmlerAsync();
            await YenileSalonlarAsync();
            await YenileMusterilerAsync();
            await YenilePersonelAsync();
        }

        #region Film Yonetimi

        private void ConfigureFilmGrid()
        {
            var gridView = gridFilm.MainView as GridView;
            if (gridView == null) return;

            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsSelection.MultiSelect = false;

            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(240, 244, 247);
        }

        private async Task YenileFilmlerAsync()
        {
            try
            {
                using var db = new AppDbContext();
                var filmler = await db.Filmler
                    .Select(f => new { f.Id, f.Ad, f.SureDakika, f.Tur })
                    .OrderBy(f => f.Ad)
                    .ToListAsync();

                gridFilm.DataSource = filmler;
                ConfigureFilmColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Film listesi yuklenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureFilmColumns()
        {
            var gridView = gridFilm.MainView as GridView;
            if (gridView == null) return;

            if (gridView.Columns["Id"] != null)
                gridView.Columns["Id"].Visible = false;

            if (gridView.Columns["Ad"] != null)
            {
                gridView.Columns["Ad"].Caption = "Film Adi";
                gridView.Columns["Ad"].Width = 250;
                gridView.Columns["Ad"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (gridView.Columns["SureDakika"] != null)
            {
                gridView.Columns["SureDakika"].Caption = "Sure (Dk)";
                gridView.Columns["SureDakika"].Width = 100;
            }

            if (gridView.Columns["Tur"] != null)
            {
                gridView.Columns["Tur"].Caption = "Tur";
                gridView.Columns["Tur"].Width = 150;
            }

            gridView.BestFitColumns();
        }

        private async void btnFilmEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ad = txtFilmAd.Text?.Trim();
                if (string.IsNullOrWhiteSpace(ad))
                {
                    XtraMessageBox.Show("Film adi bos olamaz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFilmAd.Focus();
                    return;
                }

                if (ad.Length > 200)
                {
                    XtraMessageBox.Show("Film adi maksimum 200 karakter olabilir.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sure = (int)numSure.Value;
                if (sure < 1 || sure > 400)
                {
                    XtraMessageBox.Show("Film suresi 1-400 dakika arasinda olmalidir.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var db = new AppDbContext();
                db.Filmler.Add(new Film
                {
                    Ad = ad,
                    SureDakika = sure,
                    Tur = txtTur.Text?.Trim()
                });
                await db.SaveChangesAsync();

                txtFilmAd.EditValue = "";
                txtTur.EditValue = "";
                numSure.EditValue = 120;

                DevExpressUIHelper.ShowToast(this, "Film basariyla eklendi!", AlertType.Success);
                await YenileFilmlerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Film eklenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFilmSil_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridFilm.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lutfen silmek icin bir film secin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var filmAd = gridView.GetFocusedRowCellValue("Ad")?.ToString();

                var result = XtraMessageBox.Show($"'{filmAd}' filmini silmek istediginize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var film = await db.Filmler.FindAsync(id);
                if (film == null) return;

                var bagliSeansVar = await db.Seanslar.AnyAsync(s => s.FilmId == id);
                if (bagliSeansVar)
                {
                    XtraMessageBox.Show("Bu film icin tanimli seanslar var. Once seanslari silin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Filmler.Remove(film);
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Film basariyla silindi!", AlertType.Success);
                await YenileFilmlerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Film silinirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Salon Yonetimi

        private void ConfigureSalonGrid()
        {
            var gridView = gridSalon.MainView as GridView;
            if (gridView == null) return;

            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsSelection.MultiSelect = false;

            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(240, 244, 247);
        }

        private async Task YenileSalonlarAsync()
        {
            try
            {
                using var db = new AppDbContext();
                var salonlar = await db.Salonlar
                    .Select(s => new { s.Id, s.Ad, s.KoltukSayisi })
                    .OrderBy(s => s.Ad)
                    .ToListAsync();

                gridSalon.DataSource = salonlar;
                ConfigureSalonColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Salon listesi yuklenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureSalonColumns()
        {
            var gridView = gridSalon.MainView as GridView;
            if (gridView == null) return;

            if (gridView.Columns["Id"] != null)
                gridView.Columns["Id"].Visible = false;

            if (gridView.Columns["Ad"] != null)
            {
                gridView.Columns["Ad"].Caption = "Salon Adi";
                gridView.Columns["Ad"].Width = 250;
                gridView.Columns["Ad"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (gridView.Columns["KoltukSayisi"] != null)
            {
                gridView.Columns["KoltukSayisi"].Caption = "Koltuk Sayisi";
                gridView.Columns["KoltukSayisi"].Width = 150;
                gridView.Columns["KoltukSayisi"].AppearanceCell.ForeColor = DevExpressTheme.Success;
                gridView.Columns["KoltukSayisi"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            gridView.BestFitColumns();
        }

        private async void btnSalonEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ad = txtSalonAd.Text?.Trim();
                if (string.IsNullOrWhiteSpace(ad))
                {
                    XtraMessageBox.Show("Salon adi bos olamaz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalonAd.Focus();
                    return;
                }

                if (ad.Length > 100)
                {
                    XtraMessageBox.Show("Salon adi maksimum 100 karakter olabilir.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var koltukSayisi = (int)numKoltukSayisi.Value;
                if (koltukSayisi < 1 || koltukSayisi > 300)
                {
                    XtraMessageBox.Show("Koltuk sayisi 1-300 arasinda olmalidir.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var db = new AppDbContext();
                db.Salonlar.Add(new Salon
                {
                    Ad = ad,
                    KoltukSayisi = koltukSayisi
                });
                await db.SaveChangesAsync();

                txtSalonAd.EditValue = "";
                numKoltukSayisi.EditValue = 50;

                DevExpressUIHelper.ShowToast(this, "Salon basariyla eklendi!", AlertType.Success);
                await YenileSalonlarAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Salon eklenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSalonSil_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridSalon.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lutfen silmek icin bir salon secin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var salonAd = gridView.GetFocusedRowCellValue("Ad")?.ToString();

                var result = XtraMessageBox.Show($"'{salonAd}' salonunu silmek istediginize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var salon = await db.Salonlar.FindAsync(id);
                if (salon == null) return;

                var bagliSeansVar = await db.Seanslar.AnyAsync(s => s.SalonId == id);
                if (bagliSeansVar)
                {
                    XtraMessageBox.Show("Bu salon icin tanimli seanslar var. Once seanslari silin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Salonlar.Remove(salon);
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Salon basariyla silindi!", AlertType.Success);
                await YenileSalonlarAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Salon silinirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Musteri Yonetimi

        private void ConfigureMusteriGrid()
        {
            var gridView = gridMusteri.MainView as GridView;
            if (gridView == null) return;

            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = true;
            gridView.OptionsSelection.MultiSelect = false;

            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(240, 244, 247);

            // Row click event
            gridView.FocusedRowChanged += GridViewMusteri_FocusedRowChanged;
        }

        private void GridViewMusteri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView == null || gridView.FocusedRowHandle < 0) return;

            try
            {
                txtMusteriAd.Text = gridView.GetFocusedRowCellValue("AdSoyad")?.ToString();
                txtMusteriEmail.Text = gridView.GetFocusedRowCellValue("Email")?.ToString();
                numMusteriBakiye.EditValue = gridView.GetFocusedRowCellValue("Bakiye");
            }
            catch { }
        }

        private async Task YenileMusterilerAsync()
        {
            try
            {
                using var db = new AppDbContext();
                var musteriler = await db.Kullanicilar
                    .Where(k => k.Rol == "Musteri")
                    .Select(k => new { k.Id, k.AdSoyad, k.Email, k.Bakiye })
                    .OrderBy(k => k.AdSoyad)
                    .ToListAsync();

                gridMusteri.DataSource = musteriler;
                ConfigureMusteriColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Musteri listesi yuklenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureMusteriColumns()
        {
            var gridView = gridMusteri.MainView as GridView;
            if (gridView == null) return;

            if (gridView.Columns["Id"] != null)
                gridView.Columns["Id"].Visible = false;

            if (gridView.Columns["AdSoyad"] != null)
            {
                gridView.Columns["AdSoyad"].Caption = "Ad Soyad";
                gridView.Columns["AdSoyad"].Width = 200;
                gridView.Columns["AdSoyad"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (gridView.Columns["Email"] != null)
            {
                gridView.Columns["Email"].Caption = "E-posta";
                gridView.Columns["Email"].Width = 250;
            }

            if (gridView.Columns["Bakiye"] != null)
            {
                gridView.Columns["Bakiye"].Caption = "Bakiye";
                gridView.Columns["Bakiye"].Width = 120;
                gridView.Columns["Bakiye"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView.Columns["Bakiye"].DisplayFormat.FormatString = "c2";
                gridView.Columns["Bakiye"].AppearanceCell.ForeColor = DevExpressTheme.Success;
                gridView.Columns["Bakiye"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                // Summary
                gridView.Columns["Bakiye"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Bakiye", "Toplam: {0:c2}");
            }

            gridView.BestFitColumns();
        }

        private async void btnMusteriBakiyeGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridMusteri.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lutfen bir musteri secin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var yeniBakiye = numMusteriBakiye.Value;

                if (yeniBakiye < 0)
                {
                    XtraMessageBox.Show("Bakiye negatif olamaz.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = XtraMessageBox.Show($"Bakiyeyi {yeniBakiye:c2} olarak guncellemek istiyor musunuz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var kullanici = await db.Kullanicilar.FindAsync(id);
                if (kullanici == null) return;

                kullanici.Bakiye = yeniBakiye;
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Bakiye basariyla guncellendi!", AlertType.Success);
                await YenileMusterilerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bakiye guncellenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMusteriSil_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridMusteri.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lutfen silmek icin bir musteri secin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var ad = gridView.GetFocusedRowCellValue("AdSoyad")?.ToString();

                var result = XtraMessageBox.Show($"'{ad}' kullanicisini silmek istediginize emin misiniz?\n\nBu islem geri alinamaz!", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var kullanici = await db.Kullanicilar.Include(k => k.Biletler).FirstOrDefaultAsync(k => k.Id == id);
                if (kullanici == null) return;

                // Biletleri de sil
                if (kullanici.Biletler.Any())
                {
                    db.Biletler.RemoveRange(kullanici.Biletler);
                }

                db.Kullanicilar.Remove(kullanici);
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Musteri basariyla silindi!", AlertType.Success);
                await YenileMusterilerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Musteri silinirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Personel Yonetimi

        private void ConfigurePersonelGrid()
        {
            var gridView = gridPersonel.MainView as GridView;
            if (gridView == null) return;

            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsSelection.MultiSelect = false;

            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(240, 244, 247);

            // Row click event
            gridView.FocusedRowChanged += GridViewPersonel_FocusedRowChanged;
        }

        private void GridViewPersonel_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView == null || gridView.FocusedRowHandle < 0) return;

            try
            {
                txtPersonelAd.Text = gridView.GetFocusedRowCellValue("AdSoyad")?.ToString();
                txtPersonelEmail.Text = gridView.GetFocusedRowCellValue("Email")?.ToString();
                txtPersonelSifre.Text = ""; // Guvenlik icin sifre gosterme
                cmbPersonelRol.EditValue = gridView.GetFocusedRowCellValue("Rol")?.ToString();
            }
            catch { }
        }

        private async Task YenilePersonelAsync()
        {
            try
            {
                using var db = new AppDbContext();
                var personeller = await db.Kullanicilar
                    .Where(k => k.Rol == "Personel" || k.Rol == "Admin")
                    .Select(k => new { k.Id, k.AdSoyad, k.Email, k.Rol })
                    .OrderBy(k => k.Rol).ThenBy(k => k.AdSoyad)
                    .ToListAsync();

                gridPersonel.DataSource = personeller;
                ConfigurePersonelColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Personel listesi yuklenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurePersonelColumns()
        {
            var gridView = gridPersonel.MainView as GridView;
            if (gridView == null) return;

            if (gridView.Columns["Id"] != null)
                gridView.Columns["Id"].Visible = false;

            if (gridView.Columns["AdSoyad"] != null)
            {
                gridView.Columns["AdSoyad"].Caption = "Ad Soyad";
                gridView.Columns["AdSoyad"].Width = 200;
                gridView.Columns["AdSoyad"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (gridView.Columns["Email"] != null)
            {
                gridView.Columns["Email"].Caption = "E-posta";
                gridView.Columns["Email"].Width = 250;
            }

            if (gridView.Columns["Rol"] != null)
            {
                gridView.Columns["Rol"].Caption = "Rol";
                gridView.Columns["Rol"].Width = 120;
                gridView.Columns["Rol"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            gridView.BestFitColumns();
        }

        private async void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var ad = txtPersonelAd.Text?.Trim();
                if (string.IsNullOrWhiteSpace(ad))
                {
                    XtraMessageBox.Show("Ad Soyad bos olamaz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPersonelAd.Focus();
                    return;
                }

                if (ad.Length < 3)
                {
                    XtraMessageBox.Show("Ad Soyad en az 3 karakter olmalidir.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var email = txtPersonelEmail.Text?.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    XtraMessageBox.Show("E-posta bos olamaz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPersonelEmail.Focus();
                    return;
                }

                if (!email.Contains("@") || !email.Contains("."))
                {
                    XtraMessageBox.Show("Gecerli bir e-posta adresi girin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sifre = txtPersonelSifre.Text;
                if (string.IsNullOrWhiteSpace(sifre))
                {
                    XtraMessageBox.Show("Sifre bos olamaz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPersonelSifre.Focus();
                    return;
                }

                if (sifre.Length < 6)
                {
                    XtraMessageBox.Show("Sifre en az 6 karakter olmalidir.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var rol = cmbPersonelRol.EditValue?.ToString();
                if (string.IsNullOrWhiteSpace(rol))
                {
                    XtraMessageBox.Show("Rol secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email kontrolu
                using (var db = new AppDbContext())
                {
                    var mevcutKullanici = await db.Kullanicilar.FirstOrDefaultAsync(k => k.Email == email);
                    if (mevcutKullanici != null)
                    {
                        XtraMessageBox.Show("Bu e-posta adresi zaten kayitli.", "Uyari",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (var db = new AppDbContext())
                {
                    db.Kullanicilar.Add(new Kullanici
                    {
                        AdSoyad = ad,
                        Email = email,
                        SifreHash = sifre,  // TODO: Hash'lenmeli
                        Bakiye = 0,
                        Rol = rol
                    });
                    await db.SaveChangesAsync();
                }

                txtPersonelAd.EditValue = "";
                txtPersonelEmail.EditValue = "";
                txtPersonelSifre.EditValue = "";
                cmbPersonelRol.EditValue = "Personel";

                DevExpressUIHelper.ShowToast(this, $"{rol} basariyla eklendi!", AlertType.Success);
                await YenilePersonelAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Personel eklenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridPersonel.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lutfen guncellemek icin bir personel secin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var ad = txtPersonelAd.Text?.Trim();
                var email = txtPersonelEmail.Text?.Trim();
                var sifre = txtPersonelSifre.Text;
                var rol = cmbPersonelRol.EditValue?.ToString();

                // Validasyon
                if (string.IsNullOrWhiteSpace(ad) || ad.Length < 3)
                {
                    XtraMessageBox.Show("Ad Soyad en az 3 karakter olmalidir.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPersonelAd.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                {
                    XtraMessageBox.Show("Gecerli bir e-posta adresi girin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPersonelEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(rol))
                {
                    XtraMessageBox.Show("Rol secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email kontrolu (baska kullanici aynı emaili kullaniyor mu?)
                using (var db = new AppDbContext())
                {
                    var mevcutKullanici = await db.Kullanicilar
                        .FirstOrDefaultAsync(k => k.Email == email && k.Id != id);
                    if (mevcutKullanici != null)
                    {
                        XtraMessageBox.Show("Bu e-posta adresi baska bir kullanici tarafindan kullaniliyor.", "Uyari",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = XtraMessageBox.Show($"'{ad}' kullanicisini guncellemek istediginize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using (var db = new AppDbContext())
                {
                    var kullanici = await db.Kullanicilar.FindAsync(id);
                    if (kullanici == null)
                    {
                        XtraMessageBox.Show("Kullanici bulunamadi.", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    kullanici.AdSoyad = ad;
                    kullanici.Email = email;
                    kullanici.Rol = rol;

                    // Sifre guncellemesi (sadece doldurulduysa)
                    if (!string.IsNullOrWhiteSpace(sifre))
                    {
                        if (sifre.Length < 6)
                        {
                            XtraMessageBox.Show("Sifre en az 6 karakter olmalidir.", "Uyari",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        kullanici.SifreHash = sifre; // TODO: Hash'lenmeli
                    }

                    await db.SaveChangesAsync();
                }

                DevExpressUIHelper.ShowToast(this, $"{rol} basariyla guncellendi!", AlertType.Success);
                await YenilePersonelAsync();

                // Formu temizle
                txtPersonelAd.EditValue = "";
                txtPersonelEmail.EditValue = "";
                txtPersonelSifre.EditValue = "";
                cmbPersonelRol.EditValue = "Personel";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Personel guncellenirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnPersonelSil_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridPersonel.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lutfen silmek icin bir personel secin.", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var ad = gridView.GetFocusedRowCellValue("AdSoyad")?.ToString();
                var rol = gridView.GetFocusedRowCellValue("Rol")?.ToString();

                // Kendi hesabini silmeyi engelle
                if (id == _kullaniciId)
                {
                    XtraMessageBox.Show("Kendi hesabinizi silemezsiniz!", "Uyari",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = XtraMessageBox.Show($"'{ad}' ({rol}) kullanicisini silmek istediginize emin misiniz?\n\nBu islem geri alinamaz!", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var kullanici = await db.Kullanicilar.FindAsync(id);
                if (kullanici == null) return;

                db.Kullanicilar.Remove(kullanici);
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, $"{rol} basariyla silindi!", AlertType.Success);
                await YenilePersonelAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Personel silinirken hata olustu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Toolbar Actions

        private void btnSeansYonet_Click(object sender, EventArgs e)
        {
            using var frm = new FrmSeans();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
        }

        private void btnRaporOlustur_Click(object sender, EventArgs e)
        {
            using var frmRapor = new FrmRaporOlustur();
            frmRapor.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
