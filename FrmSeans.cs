using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Domain;
using Sinemaci.BiletSistemi.Helper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Seans Yönetimi Formu - DevExpress XtraForm
    /// LookUpEdit, DateEdit, SpinEdit, GridControl kullanımı
    /// </summary>
    public partial class FrmSeans : XtraForm
    {
        public FrmSeans()
        {
            InitializeComponent();
            this.Text = "Seans Yönetimi - Sinemacı";
        }

        private async void FrmSeans_Load(object sender, EventArgs e)
        {
            // Grid ayarları
            ConfigureGrid();

            // Hover efektleri
            DevExpressUIHelper.AddHoverEffect(btnSeansEkle, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnSeansSil, DevExpressTheme.Danger, Color.FromArgb(192, 57, 43));
            DevExpressUIHelper.AddHoverEffect(btnKapat, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));

            // DateEdit ayarları
            dtSeans.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            dtSeans.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm";
            dtSeans.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm";

            // SpinEdit ayarları
            numFiyat.Properties.MinValue = 1;
            numFiyat.Properties.MaxValue = 10000;
            numFiyat.Properties.DisplayFormat.FormatString = "C2";
            numFiyat.Properties.EditFormat.FormatString = "C2";
            numFiyat.EditValue = 50m;

            await DoldurCombolarAsync();
            await YenileSeanslarAsync();
        }

        private void ConfigureGrid()
        {
            var gridView = gridSeans.MainView as GridView;
            if (gridView == null) return;

            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.MultiSelect = false;

            // Alternating row colors
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(240, 244, 247);
        }

        private async Task DoldurCombolarAsync()
        {
            try
            {
                using var db = new AppDbContext();

                // Film LookUpEdit
                var filmler = await db.Filmler.OrderBy(f => f.Ad).Select(f => new { f.Id, f.Ad }).ToListAsync();
                cmbFilm.Properties.DataSource = filmler;
                cmbFilm.Properties.DisplayMember = "Ad";
                cmbFilm.Properties.ValueMember = "Id";
                cmbFilm.Properties.Columns.Clear();
                cmbFilm.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Film Adı"));

                // Salon LookUpEdit
                var salonlar = await db.Salonlar.OrderBy(s => s.Ad).Select(s => new { s.Id, s.Ad }).ToListAsync();
                cmbSalon.Properties.DataSource = salonlar;
                cmbSalon.Properties.DisplayMember = "Ad";
                cmbSalon.Properties.ValueMember = "Id";
                cmbSalon.Properties.Columns.Clear();
                cmbSalon.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Salon Adı"));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Film ve salon listeleri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task YenileSeanslarAsync()
        {
            try
            {
                using var db = new AppDbContext();
                var seanslar = await db.Seanslar
                  .Include(s => s.Film)
                  .Include(s => s.Salon)
                  .Select(s => new
                  {
                      s.Id,
                      Film = s.Film!.Ad,
                      Salon = s.Salon!.Ad,
                      TarihSaat = s.TarihSaat,
                      Fiyat = s.Fiyat
                  })
                  .OrderBy(s => s.TarihSaat)
                  .ToListAsync();

                gridSeans.DataSource = seanslar;

                // Grid kolonlarını yapılandır
                ConfigureColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Seans listesi yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            var gridView = gridSeans.MainView as GridView;
            if (gridView == null) return;

            // Gizli kolon
            if (gridView.Columns["Id"] != null)
                gridView.Columns["Id"].Visible = false;

            // Film kolonu
            if (gridView.Columns["Film"] != null)
            {
                gridView.Columns["Film"].Caption = "Film Adı";
                gridView.Columns["Film"].Width = 250;
                gridView.Columns["Film"].AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            }

            // Salon kolonu
            if (gridView.Columns["Salon"] != null)
            {
                gridView.Columns["Salon"].Caption = "Salon";
                gridView.Columns["Salon"].Width = 150;
            }

            // TarihSaat kolonu
            if (gridView.Columns["TarihSaat"] != null)
            {
                gridView.Columns["TarihSaat"].Caption = "Tarih/Saat";
                gridView.Columns["TarihSaat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView.Columns["TarihSaat"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
                gridView.Columns["TarihSaat"].Width = 180;
            }

            // Fiyat kolonu
            if (gridView.Columns["Fiyat"] != null)
            {
                gridView.Columns["Fiyat"].Caption = "Fiyat";
                gridView.Columns["Fiyat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView.Columns["Fiyat"].DisplayFormat.FormatString = "c2";
                gridView.Columns["Fiyat"].Width = 120;
                gridView.Columns["Fiyat"].AppearanceCell.ForeColor = DevExpressTheme.Success;
                gridView.Columns["Fiyat"].AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            }

            gridView.BestFitColumns();
        }

        private async void btnSeansEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (cmbFilm.EditValue == null || cmbSalon.EditValue == null)
                {
                    XtraMessageBox.Show("Film ve Salon seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filmId = (int)cmbFilm.EditValue;
                var salonId = (int)cmbSalon.EditValue;

                // DateEdit'ten tarih al
                if (dtSeans.EditValue == null)
                {
                    XtraMessageBox.Show("Tarih/Saat seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var secilenTarih = (DateTime)dtSeans.EditValue;

                // Yerel saati UTC'ye çevir (timestamptz uyumu)
                var utcTarih = DateTime.SpecifyKind(secilenTarih, DateTimeKind.Local).ToUniversalTime();

                // Geçmiş tarih kontrolü
                if (utcTarih < DateTime.UtcNow)
                {
                    XtraMessageBox.Show("Geçmiş tarih için seans eklenemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var fiyat = (decimal)numFiyat.Value;
                if (fiyat < 1 || fiyat > 10000)
                {
                    XtraMessageBox.Show("Fiyat 1-10000 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var db = new AppDbContext();
                bool cakisma = await db.Seanslar.AnyAsync(s => s.SalonId == salonId && s.TarihSaat == utcTarih);
                if (cakisma)
                {
                    XtraMessageBox.Show("Bu salonda aynı tarih-saatte seans var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Seanslar.Add(new Seans { FilmId = filmId, SalonId = salonId, TarihSaat = utcTarih, Fiyat = fiyat });
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Seans başarıyla eklendi!", AlertType.Success);
                await YenileSeanslarAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Seans eklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSeansSil_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridSeans.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lütfen silmek için bir seans seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = (int)gridView.GetFocusedRowCellValue("Id");

                var result = XtraMessageBox.Show("Seçili seansı silmek istediğinize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using var db = new AppDbContext();
                var seans = await db.Seanslar.FindAsync(id);
                if (seans == null) return;

                bool biletVar = await db.Biletler.AnyAsync(b => b.SeansId == id);
                if (biletVar)
                {
                    XtraMessageBox.Show("Seansa ait satılmış bilet var. Silinemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Seanslar.Remove(seans);
                await db.SaveChangesAsync();

                DevExpressUIHelper.ShowToast(this, "Seans başarıyla silindi!", AlertType.Success);
                await YenileSeanslarAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Seans silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
