using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Helper;
using Sinemaci.BiletSistemi.Service;
using System;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Şifremi Unuttum Formu - DevExpress XtraForm
    /// İki panelli tasarım: Email doğrulama + Şifre değiştirme
    /// </summary>
    public partial class FrmSifreUnuttum : XtraForm
    {
        private string _dogrulamaKodu = "";
        private string _email = "";

        public FrmSifreUnuttum()
        {
            InitializeComponent();
            this.Text = "Şifremi Unuttum - Sinemacı";
        }

        private void FrmSifreUnuttum_Load(object sender, EventArgs e)
        {
            // Panel görünürlüğü
            pnlEmailGonder.Visible = true;
            pnlSifreDegistir.Visible = false;

            // Şifre karakterlerini gizle
            txtYeniSifre.Properties.PasswordChar = '●';
            txtYeniSifreTekrar.Properties.PasswordChar = '●';

            // Hover efektleri - Email Paneli
            DevExpressUIHelper.AddHoverEffect(btnKodGonder, DevExpressTheme.Info, Color.FromArgb(41, 128, 185));
            DevExpressUIHelper.AddHoverEffect(btnEmailIptal, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));

            // Hover efektleri - Şifre Paneli
            DevExpressUIHelper.AddHoverEffect(btnSifreDegistir, DevExpressTheme.Success, Color.FromArgb(39, 174, 96));
            DevExpressUIHelper.AddHoverEffect(btnGeri, Color.FromArgb(149, 165, 166), Color.FromArgb(127, 140, 141));
            DevExpressUIHelper.AddHoverEffect(btnYenidenGonder, DevExpressTheme.Warning, DevExpressTheme.Accent);
        }

        // === ADIM 1: EMAIL DOĞRULAMA KODU GÖNDER ===
        private async void btnKodGonder_Click(object sender, EventArgs e)
        {
            try
            {
                // Email validasyon
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

                // Email veritabanında var mı kontrol et
                using (var db = new AppDbContext())
                {
                    var kullanici = await db.Kullanicilar.FirstOrDefaultAsync(k => k.Email == _email);
                    if (kullanici == null)
                    {
                        XtraMessageBox.Show("Bu e-posta adresi sistemde kayıtlı değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return;
                    }
                }

                // Doğrulama kodu oluştur (6 haneli)
                Random rnd = new Random();
                _dogrulamaKodu = rnd.Next(100000, 999999).ToString();

                // Email gönder
                var emailService = new SEmail();
                bool emailGonderildi = await emailService.SifreResetKoduGonderAsync(_email, _dogrulamaKodu);

                if (!emailGonderildi)
                {
                    XtraMessageBox.Show("Doğrulama kodu gönderilemedi. Lütfen email ayarlarınızı kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Şifre değiştirme paneline geç
                pnlEmailGonder.Visible = false;
                pnlSifreDegistir.Visible = true;
                txtDogrulamaKodu.Focus();

                XtraMessageBox.Show($"Şifre sıfırlama kodu {_email} adresine gönderildi.\n\nLütfen e-posta gelen kutunuzu kontrol edin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === ADIM 2: KOD DOĞRULAMA VE ŞİFRE DEĞİŞTİRME ===
        private async void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                var girilenKod = txtDogrulamaKodu.Text?.Trim();

                if (string.IsNullOrWhiteSpace(girilenKod))
                {
                    XtraMessageBox.Show("Doğrulama kodunu girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDogrulamaKodu.Focus();
                    return;
                }

                if (girilenKod != _dogrulamaKodu)
                {
                    XtraMessageBox.Show("Doğrulama kodu hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDogrulamaKodu.EditValue = "";
                    txtDogrulamaKodu.Focus();
                    return;
                }

                // Yeni şifre validasyon
                var yeniSifre = txtYeniSifre.Text;
                if (string.IsNullOrWhiteSpace(yeniSifre))
                {
                    XtraMessageBox.Show("Yeni şifre boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtYeniSifre.Focus();
                    return;
                }

                if (yeniSifre.Length < 6)
                {
                    XtraMessageBox.Show("Şifre en az 6 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtYeniSifre.Focus();
                    return;
                }

                if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
                {
                    XtraMessageBox.Show("Şifreler eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtYeniSifreTekrar.Focus();
                    return;
                }

                // Şifre güncelleme
                using (var db = new AppDbContext())
                {
                    var kullanici = await db.Kullanicilar.FirstOrDefaultAsync(k => k.Email == _email);
                    if (kullanici == null)
                    {
                        XtraMessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // TODO: Gerçek uygulamada şifre hash'lenmeli
                    kullanici.SifreHash = yeniSifre;
                    await db.SaveChangesAsync();
                }

                XtraMessageBox.Show("Şifreniz başarıyla değiştirildi!\n\nYeni şifreniz ile giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Şifre değiştirilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === GERİ DÖNÜŞ VE İPTAL BUTONLARI ===
        private void btnGeri_Click(object sender, EventArgs e)
        {
            pnlSifreDegistir.Visible = false;
            pnlEmailGonder.Visible = true;
            txtEmail.Focus();
        }

        private void btnEmailIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // === YENİDEN KOD GÖNDER ===
        private async void btnYenidenGonder_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni kod oluştur
                Random rnd = new Random();
                _dogrulamaKodu = rnd.Next(100000, 999999).ToString();

                // Email gönder
                var emailService = new SEmail();
                bool emailGonderildi = await emailService.SifreResetKoduGonderAsync(_email, _dogrulamaKodu);

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
