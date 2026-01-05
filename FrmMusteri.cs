using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Helper;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Müşteri Paneli - DevExpress XtraGrid ile
    /// Premium features: Filtering, Grouping, Summary, Conditional formatting
    /// </summary>
    public partial class FrmMusteri : XtraForm
    {
        private readonly int _kullaniciId;

        public FrmMusteri(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            this.Text = "Müşteri Paneli - Sinemacı";
        }

        private async void FrmMusteri_Load(object sender, EventArgs e)
        {
            // DevExpress grid ayarları
            ConfigureGrid();

            // Hover efektleri
            DevExpressUIHelper.AddHoverEffect(btnKoltukSec, DevExpressTheme.Primary, DevExpressTheme.Info);
            DevExpressUIHelper.AddHoverEffect(btnYenile, DevExpressTheme.Success, DevExpressTheme.SuccessHover);
            DevExpressUIHelper.AddHoverEffect(btnBiletlerim, DevExpressTheme.Accent, Color.FromArgb(211, 84, 0));

            await YukleAsync();
        }

        private void ConfigureGrid()
        {
            var gridView = gridSeanslar.MainView as GridView;
            if (gridView == null) return;

            // Grid görünüm ayarları
            gridView.OptionsView.ShowAutoFilterRow = true; // Auto-filter row (DevExpress premium)
            gridView.OptionsView.ShowGroupPanel = true;    // Drag-drop grouping panel
            gridView.OptionsView.ShowFooter = true;        // Summary footer
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.MultiSelect = false;

            // Alternating row colors
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(240, 244, 247);

            // Row double-click event
            gridView.DoubleClick += GridView_DoubleClick;
        }

        private async Task YukleAsync()
        {
            try
            {
                using var db = new AppDbContext();

                var k = await db.Kullanicilar.FindAsync(_kullaniciId);
                if (k == null)
                {
                    XtraMessageBox.Show("Kullanıcı bulunamadı.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Bakiye güncelleme
                lblBakiye.Text = $"Bakiye: {k.Bakiye:C2}";
                lblKullanici.Text = $"Hoş geldiniz, {k.AdSoyad}";

                // Seansları yükle
                var list = await db.Seanslar
                  .Include(s => s.Film)
                  .Include(s => s.Salon)
                  .Select(s => new
                  {
                      s.Id,
                      s.SalonId,
                      Film = s.Film!.Ad,
                      Salon = s.Salon!.Ad,
                      KoltukSayisi = s.Salon!.KoltukSayisi,
                      Tarih = s.TarihSaat.Date,
                      Saat = s.TarihSaat.TimeOfDay,
                      TarihSaat = s.TarihSaat,
                      Fiyat = s.Fiyat
                  })
                  .OrderBy(s => s.TarihSaat)
                  .ToListAsync();

                gridSeanslar.DataSource = list;

                // Grid kolonlarını yapılandır
                ConfigureColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Veri yükleme sırasında hata oluştu:\n\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            var gridView = gridSeanslar.MainView as GridView;
            if (gridView == null) return;

            // Gizli kolonlar
            if (gridView.Columns["Id"] != null) gridView.Columns["Id"].Visible = false;
            if (gridView.Columns["SalonId"] != null) gridView.Columns["SalonId"].Visible = false;
            if (gridView.Columns["KoltukSayisi"] != null) gridView.Columns["KoltukSayisi"].Visible = false;
            if (gridView.Columns["TarihSaat"] != null) gridView.Columns["TarihSaat"].Visible = false;

            // Kolon başlıkları ve genişlikler
            if (gridView.Columns["Film"] != null)
            {
                gridView.Columns["Film"].Caption = "Film Adı";
                gridView.Columns["Film"].Width = 200;
                gridView.Columns["Film"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (gridView.Columns["Salon"] != null)
            {
                gridView.Columns["Salon"].Caption = "Salon";
                gridView.Columns["Salon"].Width = 120;
            }

            if (gridView.Columns["Tarih"] != null)
            {
                gridView.Columns["Tarih"].Caption = "Tarih";
                gridView.Columns["Tarih"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView.Columns["Tarih"].DisplayFormat.FormatString = "dd.MM.yyyy";
                gridView.Columns["Tarih"].Width = 100;
            }

            if (gridView.Columns["Saat"] != null)
            {
                gridView.Columns["Saat"].Caption = "Saat";
                gridView.Columns["Saat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                gridView.Columns["Saat"].DisplayFormat.FormatString = @"hh\:mm";
                gridView.Columns["Saat"].Width = 80;
            }

            if (gridView.Columns["Fiyat"] != null)
            {
                gridView.Columns["Fiyat"].Caption = "Fiyat";
                gridView.Columns["Fiyat"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView.Columns["Fiyat"].DisplayFormat.FormatString = "c2";
                gridView.Columns["Fiyat"].Width = 100;
                gridView.Columns["Fiyat"].AppearanceCell.ForeColor = DevExpressTheme.Success;
                gridView.Columns["Fiyat"].AppearanceCell.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                // Summary - Toplam fiyat (DevExpress premium feature)
                gridView.Columns["Fiyat"].Summary.Add(DevExpress.Data.SummaryItemType.Average, "Fiyat", "Ort: {0:C2}");
            }

            gridView.BestFitColumns();
        }

        private void GridView_DoubleClick(object? sender, EventArgs e)
        {
            // Double-click ile koltuk seçimi
            btnKoltukSec_Click(sender, e);
        }

        private async void btnKoltukSec_Click(object sender, EventArgs e)
        {
            try
            {
                var gridView = gridSeanslar.MainView as GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Lütfen bir seans seçin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var seansIdValue = gridView.GetFocusedRowCellValue("Id");
                if (seansIdValue == null)
                {
                    XtraMessageBox.Show("Seans bilgisi alınamadı. Lütfen tekrar deneyin.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var seansId = (int)seansIdValue;

                using var frmKoltuk = new FrmKoltukSecimi(_kullaniciId, seansId);
                if (frmKoltuk.ShowDialog() == DialogResult.OK)
                {
                    await YukleAsync();
                    DevExpressUIHelper.ShowToast(this, "Bilet başarıyla alındı!", AlertType.Success);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu:\n\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await YukleAsync();
            DevExpressUIHelper.ShowToast(this, "Seans listesi güncellendi.", AlertType.Info);
        }

        private async void btnBiletlerim_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new AppDbContext();

                var biletler = await db.Biletler
                    .Include(b => b.Seans)
                        .ThenInclude(s => s.Film)
                    .Include(b => b.Seans)
                        .ThenInclude(s => s.Salon)
                    .Where(b => b.KullaniciId == _kullaniciId)
                    .Select(b => new
                    {
                        Film = b.Seans.Film.Ad,
                        Salon = b.Seans.Salon.Ad,
                        Tarih = b.Seans.TarihSaat,
                        Koltuk = b.KoltukNo,
                        Tutar = b.Tutar,
                        AlimZamani = b.AlimZamani
                    })
                    .OrderByDescending(b => b.AlimZamani)
                    .ToListAsync();

                if (biletler.Count == 0)
                {
                    XtraMessageBox.Show("Henüz bilet satın almadınız.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Biletleri grid'de göster
                gridSeanslar.DataSource = biletler;

                var gridView = gridSeanslar.MainView as GridView;
                if (gridView != null)
                {
                    gridView.BestFitColumns();
                    DevExpressUIHelper.ShowToast(this, $"{biletler.Count} biletiniz listelendi.", AlertType.Success);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Biletler yüklenirken hata oluştu:\n\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
