using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
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
    /// Personel Paneli - DevExpress XtraForm
    /// Modern Tab-based UI: Film Yönetimi + Salon Yönetimi
    /// </summary>
    public partial class FrmPersonel : XtraForm
    {
        private readonly int _kullaniciId;

        public FrmPersonel(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            this.Text = "Personel Paneli - Sinemacı";
        }

        private async void FrmPersonel_Load(object sender, EventArgs e)
        {
            // Grid ayarları
            ConfigureFilmGrid();
            ConfigureSalonGrid();

            // Toolbar hover efektleri
            DevExpressUIHelper.AddHoverEffect(btnSeansYonet, DevExpressTheme.Info, Color.FromArgb(41, 128, 185));
            DevExpressUIHelper.AddHoverEffect(btnRaporOlustur, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnCikis, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));

            // Film butonları hover
            DevExpressUIHelper.AddHoverEffect(btnFilmEkle, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnFilmSil, DevExpressTheme.Danger, Color.FromArgb(192, 57, 43));

            // Salon butonları hover
            DevExpressUIHelper.AddHoverEffect(btnSalonEkle, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnSalonSil, DevExpressTheme.Danger, Color.FromArgb(192, 57, 43));

            // SpinEdit ayarları - Film
            numSure.Properties.MinValue = 1;
            numSure.Properties.MaxValue = 400;
            numSure.EditValue = 120;

            // SpinEdit ayarları - Salon
            numKoltukSayisi.Properties.MinValue = 1;
            numKoltukSayisi.Properties.MaxValue = 300;
            numKoltukSayisi.EditValue = 50;

            // Tab stil ayarları
            tabControl.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            tabControl.Appearance.ForeColor = DevExpressTheme.Primary;
            tabControl.Appearance.Options.UseFont = true;
            tabControl.Appearance.Options.UseForeColor = true;

            // İlk yükleme
            await YenileFilmlerAsync();
            await YenileSalonlarAsync();
        }

        #region Film Yönetimi

        private void ConfigureFilmGrid()
        {
            var gridView = gridFilm.MainView as GridView;
            if (gridView == null) return;

            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsSelection.MultiSelect = false;

            // Alternating row colors
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
                XtraMessageBox.Show($"Film listesi yüklenirken hata oluştu: {ex.Message}", "Hata",
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
                gridView.Columns["Ad"].Caption = "Film Adı";
                gridView.Columns["Ad"].Width = 250;
                gridView.Columns["Ad"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (gridView.Columns["SureDakika"] != null)
            {
                gridView.Columns["SureDakika"].Caption = "Süre (Dk)";
                gridView.Columns["SureDakika"].Width = 100;
            }

            if (gridView.Columns["Tur"] != null)
            {
                gridView.Columns["Tur"].Caption = "Tür";
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
                    XtraMessageBox.Show("Film adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFilmAd.Focus();
                    return;
                }

                if (ad.Length > 200)
                {
                    XtraMessageBox.Show("Film adı maksimum 200 karakter olabilir.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sure = (int)numSure.Value;
                if (sure < 1 || sure > 400)
                {
                    XtraMessageBox.Show("Film süresi 1-400 dakika arasında olmalıdır.", "Uyarı",
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

                DevExpressUIHelper.ShowToast(this, "Film başarıyla eklendi!", AlertType.Success);
                await YenileFilmlerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Film eklenirken hata oluştu: {ex.Message}", "Hata",
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
                    XtraMessageBox.Show("Lütfen silmek için bir film seçin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var filmAd = gridView.GetFocusedRowCellValue("Ad")?.ToString();

                var result = XtraMessageBox.Show($"'{filmAd}' filmini silmek istediğinize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var film = await db.Filmler.FindAsync(id);
                if (film == null) return;

                // Bağımlılık kontrolü
                var bagliSeansVar = await db.Seanslar.AnyAsync(s => s.FilmId == id);
                if (bagliSeansVar)
                {
                    XtraMessageBox.Show("Bu film için tanımlı seanslar var. Önce seansları silin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Filmler.Remove(film);
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Film başarıyla silindi!", AlertType.Success);
                await YenileFilmlerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Film silinirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Salon Yönetimi

        private void ConfigureSalonGrid()
        {
            var gridView = gridSalon.MainView as GridView;
            if (gridView == null) return;

            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsSelection.MultiSelect = false;

            // Alternating row colors
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
                XtraMessageBox.Show($"Salon listesi yüklenirken hata oluştu: {ex.Message}", "Hata",
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
                gridView.Columns["Ad"].Caption = "Salon Adı";
                gridView.Columns["Ad"].Width = 250;
                gridView.Columns["Ad"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (gridView.Columns["KoltukSayisi"] != null)
            {
                gridView.Columns["KoltukSayisi"].Caption = "Koltuk Sayısı";
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
                    XtraMessageBox.Show("Salon adı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalonAd.Focus();
                    return;
                }

                if (ad.Length > 100)
                {
                    XtraMessageBox.Show("Salon adı maksimum 100 karakter olabilir.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var koltukSayisi = (int)numKoltukSayisi.Value;
                if (koltukSayisi < 1 || koltukSayisi > 300)
                {
                    XtraMessageBox.Show("Koltuk sayısı 1-300 arasında olmalıdır.", "Uyarı",
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

                DevExpressUIHelper.ShowToast(this, "Salon başarıyla eklendi!", AlertType.Success);
                await YenileSalonlarAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Salon eklenirken hata oluştu: {ex.Message}", "Hata",
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
                    XtraMessageBox.Show("Lütfen silmek için bir salon seçin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");
                var salonAd = gridView.GetFocusedRowCellValue("Ad")?.ToString();

                var result = XtraMessageBox.Show($"'{salonAd}' salonunu silmek istediğinize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var salon = await db.Salonlar.FindAsync(id);
                if (salon == null) return;

                // Bağımlılık kontrolü
                var bagliSeansVar = await db.Seanslar.AnyAsync(s => s.SalonId == id);
                if (bagliSeansVar)
                {
                    XtraMessageBox.Show("Bu salon için tanımlı seanslar var. Önce seansları silin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Salonlar.Remove(salon);
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Salon başarıyla silindi!", AlertType.Success);
                await YenileSalonlarAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Salon silinirken hata oluştu: {ex.Message}", "Hata",
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
