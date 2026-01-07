using DevExpress.XtraEditors;
using QRCoder;
using Sinemaci.BiletSistemi.Domain;
using Sinemaci.BiletSistemi.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Bilet Detay Formu - QR Kod ve Bilet Bilgilerini Gösterir
    /// </summary>
    public partial class FrmBiletDetay : XtraForm
    {
        private readonly Bilet _bilet;

        public FrmBiletDetay(Bilet bilet)
        {
            InitializeComponent();
            _bilet = bilet;
            this.Text = "Bilet Detayı - Sinemacı";
        }

        private void FrmBiletDetay_Load(object sender, EventArgs e)
        {
            try
            {
                // QR Kod Oluştur
                GenerateQRCode();

                // Bilet Bilgilerini Göster
                lblFilmAd.Text = _bilet.Seans?.Film?.Ad ?? "Bilinmiyor";
                lblSalonAd.Text = _bilet.Seans?.Salon?.Ad ?? "Bilinmiyor";
                lblTarih.Text = _bilet.Seans?.TarihSaat.ToLocalTime().ToString("dd MMMM yyyy, dddd") ?? "-";
                lblSaat.Text = _bilet.Seans?.TarihSaat.ToLocalTime().ToString("HH:mm") ?? "-";
                lblKoltuk.Text = $"Koltuk: {_bilet.KoltukNo}";
                lblSure.Text = $"{_bilet.Seans?.Film?.SureDakika ?? 0} dakika";
                lblFiyat.Text = $"{_bilet.Tutar:C2}";
                lblBiletNo.Text = $"Bilet No: {_bilet.BenzersizKod}";
                lblAlimZamani.Text = $"Alım: {_bilet.AlimZamani.ToLocalTime():dd.MM.yyyy HH:mm}";

                // Tur bilgisi varsa göster
                if (!string.IsNullOrEmpty(_bilet.Seans?.Film?.Tur))
                {
                    lblTur.Text = $"Tür: {_bilet.Seans.Film.Tur}";
                }
                else
                {
                    lblTur.Visible = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bilet bilgileri yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateQRCode()
        {
            try
            {
                // QR kod için veri hazırla
                string qrData = $"SINEMA-BILET:{_bilet.BenzersizKod}|FILM:{_bilet.Seans?.Film?.Ad}|SALON:{_bilet.Seans?.Salon?.Ad}|TARIH:{_bilet.Seans?.TarihSaat:dd.MM.yyyy HH:mm}|KOLTUK:{_bilet.KoltukNo}";

                // QR kod oluştur
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);
                        picQRCode.Image = qrCodeImage;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"QR kod oluşturulurken hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
