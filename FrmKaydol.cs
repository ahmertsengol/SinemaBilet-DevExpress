using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Domain;
using Sinemaci.BiletSistemi.Helper;
using Sinemaci.BiletSistemi.Service;
using System;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Kayıt Ol Formu - DevExpress XtraForm
    /// İki panelli tasarım: Bilgi girişi + Email doğrulama
    /// </summary>
    public partial class FrmKaydol : XtraForm
    {
        private string _dogrulamaKodu = "";
        private string _email = "";

        public FrmKaydol()
        {
            InitializeComponent();
            this.Text = "Kayıt Ol - Sinemacı";
        }

        private void FrmKaydol_Load(object sender, EventArgs e)
        {
            // Panel görünürlüğü
            pnlBilgiler.Visible = true;
            pnlDogrulama.Visible = false;

            // Şifre karakterlerini gizle
            txtSifre.Properties.PasswordChar = '●';
            txtSifreTekrar.Properties.PasswordChar = '●';

            // Hover efektleri
            DevExpressUIHelper.AddHoverEffect(btnDevam, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnIptal, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));
            DevExpressUIHelper.AddHoverEffect(btnKayitTamamla, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnGeri, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));
            DevExpressUIHelper.AddHoverEffect(btnYenidenGonder, DevExpressTheme.Primary, DevExpressTheme.Info);
        }

        // === BİLGİ GİRİŞİ - DEVAM BUTONU ===
        private async void btnDevam_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasyon
                var adSoyad = txtAdSoyad.Text?.Trim();
                if (string.IsNullOrWhiteSpace(adSoyad))
                {
                    XtraMessageBox.Show("Ad Soyad boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdSoyad.Focus();
                    return;
                }

                if (adSoyad.Length < 3)
                {
                    XtraMessageBox.Show("Ad Soyad en az 3 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdSoyad.Focus();
                    return;
                }

                _email = txtEmail.Text?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(_email))
                {
                    XtraMessageBox.Show("E-posta adresi boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!_email.Contains("@") || !_email.Contains("."))
                {
                    XtraMessageBox.Show("Geçerli bir e-posta adresi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Email zaten var mı kontrol et
                using (var db = new AppDbContext())
                {
                    var mevcutKullanici = await db.Kullanicilar.FirstOrDefaultAsync(k => k.Email == _email);
                    if (mevcutKullanici != null)
                    {
                        XtraMessageBox.Show("Bu e-posta adresi zaten kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return;
                    }
                }

                var sifre = txtSifre.Text;
                if (string.IsNullOrWhiteSpace(sifre))
                {
                    XtraMessageBox.Show("Şifre boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSifre.Focus();
                    return;
                }

                if (sifre.Length < 6)
                {
                    XtraMessageBox.Show("Şifre en az 6 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSifre.Focus();
                    return;
                }

                if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    XtraMessageBox.Show("Şifreler eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSifreTekrar.Focus();
                    return;
                }

                var bakiye = numBakiye.Value;
                if (bakiye < 0)
                {
                    XtraMessageBox.Show("Bakiye negatif olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Doğrulama kodu oluştur (6 haneli)
                Random rnd = new Random();
                _dogrulamaKodu = rnd.Next(100000, 999999).ToString();

                // Email gönder
                var emailService = new SEmail();
                bool emailGonderildi = await emailService.DogrulamaKoduGonderAsync(_email, _dogrulamaKodu, adSoyad);

                if (!emailGonderildi)
                {
                    XtraMessageBox.Show("Doğrulama kodu gönderilemedi. Lütfen email ayarlarınızı kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Doğrulama paneline geç
                pnlBilgiler.Visible = false;
                pnlDogrulama.Visible = true;
                txtDogrulamaKodu.Focus();

                XtraMessageBox.Show($"Doğrulama kodu {_email} adresine gönderildi.\n\nLütfen e-posta gelen kutunuzu kontrol edin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === DOĞRULAMA - KAYIT TAMAMLA ===
        private async void btnKayitTamamla_Click(object sender, EventArgs e)
        {
            try
            {
                var girilenKod = txtDogrulamaKodu.Text?.Trim();

                if (string.IsNullOrWhiteSpace(girilenKod))
                {
                    XtraMessageBox.Show("Doğrulama kodunu girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (girilenKod != _dogrulamaKodu)
                {
                    XtraMessageBox.Show("Doğrulama kodu hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDogrulamaKodu.EditValue = "";
                    txtDogrulamaKodu.Focus();
                    return;
                }

                // Kayıt işlemi
                using (var db = new AppDbContext())
                {
                    var yeniKullanici = new Kullanici
                    {
                        AdSoyad = txtAdSoyad.Text.Trim(),
                        Email = _email,
                        SifreHash = txtSifre.Text, // TODO: Gerçek uygulamada hash'lenmeli
                        Bakiye = numBakiye.Value,
                        Rol = "Musteri"
                    };

                    db.Kullanicilar.Add(yeniKullanici);
                    await db.SaveChangesAsync();
                }

                XtraMessageBox.Show("Kayıt başarıyla tamamlandı!\n\nGiriş ekranına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kayıt tamamlanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === GERİ DÖNÜŞ BUTONLARI ===
        private void btnGeri_Click(object sender, EventArgs e)
        {
            pnlDogrulama.Visible = false;
            pnlBilgiler.Visible = true;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // === YENİDEN GÖNDERİM ===
        private async void btnYenidenGonder_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni kod oluştur
                Random rnd = new Random();
                _dogrulamaKodu = rnd.Next(100000, 999999).ToString();

                // Email gönder
                var emailService = new SEmail();
                bool emailGonderildi = await emailService.DogrulamaKoduGonderAsync(_email, _dogrulamaKodu, txtAdSoyad.Text.Trim());

                if (emailGonderildi)
                {
                    XtraMessageBox.Show($"Yeni doğrulama kodu {_email} adresine gönderildi.\n\nLütfen e-posta gelen kutunuzu kontrol edin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Kod gönderilemedi. Lütfen internet bağlantınızı ve email ayarlarınızı kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
