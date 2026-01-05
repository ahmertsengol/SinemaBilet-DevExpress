using DevExpress.XtraEditors;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Helper;
using Sinemaci.BiletSistemi.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Rapor Oluşturma Formu - DevExpress XtraForm
    /// PDF ve Excel rapor oluşturma: Film bazlı ve Müşteri bazlı
    /// </summary>
    public partial class FrmRaporOlustur : XtraForm
    {
        private readonly AppDbContext _context;

        public FrmRaporOlustur()
        {
            InitializeComponent();
            _context = new AppDbContext();
            this.Text = "Rapor Oluştur - Sinemacı";
        }

        private void FrmRaporOlustur_Load(object sender, EventArgs e)
        {
            // Hover efektleri
            DevExpressUIHelper.AddHoverEffect(btnOlustur, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnIptal, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));

            // RadioGroup varsayılan seçimi
            radioGroupRaporTuru.SelectedIndex = 0; // Film Bazlı

            // Tarih seçimi ComboBox dolduruluyor
            cmbTarihSecim.Properties.Items.Clear();
            cmbTarihSecim.Properties.Items.AddRange(new string[]
            {
                "Bugün",
                "Dün",
                "Bu Hafta",
                "Bu Ay",
                "Geçen Ay",
                "Özel Aralık"
            });
            cmbTarihSecim.SelectedIndex = 0; // Bugün

            // Varsayılan format seçimleri
            chkPdf.Checked = true;
            chkExcel.Checked = false;

            // Özel tarih panelini başlangıçta gizle
            pnlOzelTarih.Visible = false;

            // DateEdit varsayılan değerleri
            dtpBaslangic.EditValue = DateTime.Now.Date;
            dtpBitis.EditValue = DateTime.Now.Date;
        }

        private void cmbTarihSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            var secim = cmbTarihSecim.EditValue?.ToString();

            if (secim == "Özel Aralık")
            {
                pnlOzelTarih.Visible = true;
            }
            else
            {
                pnlOzelTarih.Visible = false;

                // Hızlı tarih seçimlerini ayarla
                DateTime baslangic = DateTime.Now.Date;
                DateTime bitis = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                switch (secim)
                {
                    case "Bugün":
                        // Varsayılan değerler zaten bugün
                        break;
                    case "Dün":
                        baslangic = DateTime.Now.Date.AddDays(-1);
                        bitis = DateTime.Now.Date.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                        break;
                    case "Bu Hafta":
                        var gun = (int)DateTime.Now.DayOfWeek;
                        var pazartesi = gun == 0 ? -6 : -(gun - 1); // Pazartesi'yi bul
                        baslangic = DateTime.Now.Date.AddDays(pazartesi);
                        break;
                    case "Bu Ay":
                        baslangic = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        break;
                    case "Geçen Ay":
                        var gecenAy = DateTime.Now.AddMonths(-1);
                        baslangic = new DateTime(gecenAy.Year, gecenAy.Month, 1);
                        bitis = new DateTime(gecenAy.Year, gecenAy.Month, DateTime.DaysInMonth(gecenAy.Year, gecenAy.Month))
                            .AddHours(23).AddMinutes(59).AddSeconds(59);
                        break;
                }

                dtpBaslangic.EditValue = baslangic;
                dtpBitis.EditValue = bitis;
            }
        }

        private async void btnOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                // Tarih kontrolü
                if (dtpBaslangic.EditValue == null || dtpBitis.EditValue == null)
                {
                    XtraMessageBox.Show("Lütfen başlangıç ve bitiş tarihlerini seçin.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime baslangic = ((DateTime)dtpBaslangic.EditValue).Date;
                DateTime bitis = ((DateTime)dtpBitis.EditValue).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                if (baslangic > bitis)
                {
                    XtraMessageBox.Show("Başlangıç tarihi, bitiş tarihinden büyük olamaz.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // UTC'ye çevir
                baslangic = DateTime.SpecifyKind(baslangic, DateTimeKind.Local).ToUniversalTime();
                bitis = DateTime.SpecifyKind(bitis, DateTimeKind.Local).ToUniversalTime();

                // Rapor türünü belirle
                var raporTuru = radioGroupRaporTuru.SelectedIndex == 0 ? RaporTuru.FilmBazli : RaporTuru.MusteriBazli;

                // Buton devre dışı
                btnOlustur.Enabled = false;
                btnOlustur.Text = "Oluşturuluyor...";
                Cursor = Cursors.WaitCursor;

                var raporService = new SRapor(_context);

                // Masaüstü konumu
                var masaustu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Dosya adı: Tarih formatında (yyyy-MM-dd.txt)
                var tarihFormatli = DateTime.Now.ToString("yyyy-MM-dd");
                var txtYol = Path.Combine(masaustu, $"{tarihFormatli}.txt");

                // TXT rapor oluştur
                if (raporTuru == RaporTuru.FilmBazli)
                {
                    await raporService.FilmBazliTxtOlusturAsync(baslangic, bitis, txtYol);
                }
                else
                {
                    await raporService.MusteriBazliTxtOlusturAsync(baslangic, bitis, txtYol);
                }

                Cursor = Cursors.Default;
                btnOlustur.Enabled = true;
                btnOlustur.Text = "✓ Rapor Oluştur";

                // Başarı mesajı
                var mesaj = $"Rapor başarıyla oluşturuldu!\n\nKonum: {txtYol}\n\nDosyayı açmak ister misiniz?";
                var sonuc = XtraMessageBox.Show(mesaj, "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (sonuc == DialogResult.Yes)
                {
                    // Dosyayı aç
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = txtYol,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }

                // Formu kapat
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnOlustur.Enabled = true;
                btnOlustur.Text = "✓ Rapor Oluştur";

                XtraMessageBox.Show($"Rapor oluşturulurken hata oluştu:\n{ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context?.Dispose();
        }
    }
}
