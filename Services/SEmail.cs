using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Sinemaci.BiletSistemi.Service
{
    /// <summary>
    /// E-posta gönderim işlemlerini yöneten servis sınıfı - Gmail SMTP kullanır
    /// </summary>
    public class SEmail
    {
        // SMTP ayarları - Gerçek uygulamada bu bilgiler appsettings.json'dan okunmalı
        private const string SMTP_HOST = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const bool ENABLE_SSL = true;

        // Admin email bilgileri
        // UYARI: Gerçek uygulamada bu bilgiler güvenli bir yerde saklanmalı
        private string _adminEmail = "ahmertsengol@gmail.com";
        private string _adminPassword = "gtpczlvmvehmivvh"; // Gmail App Password

        /// <summary>
        /// Kullanıcı kaydı için doğrulama kodu e-postası gönderir
        /// </summary>
        /// <param name="aliciEmail">Alıcının e-posta adresi</param>
        /// <param name="dogrulamaKodu">6 haneli doğrulama kodu</param>
        /// <param name="kullaniciAdi">Kullanıcının adı</param>
        /// <returns>Başarılıysa true, hata varsa false</returns>
        public async Task<bool> DogrulamaKoduGonderAsync(string aliciEmail, string dogrulamaKodu, string kullaniciAdi)
        {
            try
            {
                using (var smtpClient = new SmtpClient(SMTP_HOST, SMTP_PORT))
                {
                    smtpClient.EnableSsl = ENABLE_SSL;
                    smtpClient.Credentials = new NetworkCredential(_adminEmail, _adminPassword);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_adminEmail, "SinemaBilet"),
                        Subject = "SinemaBilet - E-posta Doğrulama Kodu",
                        Body = OlusturEmailIcerigi(kullaniciAdi, dogrulamaKodu),
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(aliciEmail);

                    await smtpClient.SendMailAsync(mailMessage);
                }

                Console.WriteLine($"Email başarıyla gönderildi: {aliciEmail}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email gönderme hatası: {ex.Message}");
                Console.WriteLine($"Detaylı hata: {ex.ToString()}");
                System.Windows.Forms.MessageBox.Show(
                    $"Email gönderme hatası:\n\n{ex.Message}\n\nDetay:\n{ex.InnerException?.Message}",
                    "Email Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        private string OlusturEmailIcerigi(string kullaniciAdi, string dogrulamaKodu)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }}
        .container {{ background-color: white; padding: 30px; border-radius: 10px; max-width: 600px; margin: 0 auto; }}
        .header {{ background-color: #2980b9; color: white; padding: 20px; text-align: center; border-radius: 10px 10px 0 0; }}
        .code {{ font-size: 32px; font-weight: bold; color: #2980b9; text-align: center; padding: 20px; background-color: #ecf0f1; border-radius: 5px; margin: 20px 0; letter-spacing: 5px; }}
        .footer {{ text-align: center; color: #7f8c8d; font-size: 12px; margin-top: 20px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎬 SinemaBilet</h1>
            <p>E-posta Doğrulama</p>
        </div>
        <div style='padding: 20px;'>
            <p>Merhaba <strong>{kullaniciAdi}</strong>,</p>
            <p>SinemaBilet'e hoş geldiniz! Kaydınızı tamamlamak için aşağıdaki doğrulama kodunu kullanın:</p>
            <div class='code'>{dogrulamaKodu}</div>
            <p>Bu kod 10 dakika boyunca geçerlidir.</p>
            <p>Eğer bu kaydı siz yapmadıysanız, bu emaili görmezden gelebilirsiniz.</p>
        </div>
        <div class='footer'>
            <p>© 2024 SinemaBilet - Tüm hakları saklıdır</p>
        </div>
    </div>
</body>
</html>";
        }

        /// <summary>
        /// Şifre sıfırlama işlemi için doğrulama kodu e-postası gönderir
        /// </summary>
        /// <param name="aliciEmail">Alıcının e-posta adresi</param>
        /// <param name="dogrulamaKodu">6 haneli doğrulama kodu</param>
        /// <returns>Başarılıysa true, hata varsa false</returns>
        public async Task<bool> SifreResetKoduGonderAsync(string aliciEmail, string dogrulamaKodu)
        {
            try
            {
                using (var smtpClient = new SmtpClient(SMTP_HOST, SMTP_PORT))
                {
                    smtpClient.EnableSsl = ENABLE_SSL;
                    smtpClient.Credentials = new NetworkCredential(_adminEmail, _adminPassword);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_adminEmail, "SinemaBilet"),
                        Subject = "SinemaBilet - Şifre Sıfırlama Kodu",
                        Body = OlusturSifreResetEmailIcerigi(dogrulamaKodu),
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(aliciEmail);

                    await smtpClient.SendMailAsync(mailMessage);
                }

                Console.WriteLine($"Şifre sıfırlama emaili başarıyla gönderildi: {aliciEmail}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Şifre sıfırlama emaili gönderme hatası: {ex.Message}");
                Console.WriteLine($"Detaylı hata: {ex.ToString()}");
                System.Windows.Forms.MessageBox.Show(
                    $"Email gönderme hatası:\n\n{ex.Message}\n\nDetay:\n{ex.InnerException?.Message}",
                    "Email Hatası",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        private string OlusturSifreResetEmailIcerigi(string dogrulamaKodu)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }}
        .container {{ background-color: white; padding: 30px; border-radius: 10px; max-width: 600px; margin: 0 auto; }}
        .header {{ background-color: #e74c3c; color: white; padding: 20px; text-align: center; border-radius: 10px 10px 0 0; }}
        .code {{ font-size: 32px; font-weight: bold; color: #e74c3c; text-align: center; padding: 20px; background-color: #ecf0f1; border-radius: 5px; margin: 20px 0; letter-spacing: 5px; }}
        .warning {{ background-color: #fff3cd; border-left: 4px solid #f39c12; padding: 15px; margin: 20px 0; }}
        .footer {{ text-align: center; color: #7f8c8d; font-size: 12px; margin-top: 20px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🔐 SinemaBilet</h1>
            <p>Şifre Sıfırlama</p>
        </div>
        <div style='padding: 20px;'>
            <p>Merhaba,</p>
            <p>Şifre sıfırlama talebiniz alındı. Yeni şifrenizi belirlemek için aşağıdaki 6 haneli kodu kullanın:</p>
            <div class='code'>{dogrulamaKodu}</div>
            <div class='warning'>
                <strong>⚠️ Güvenlik Uyarısı:</strong><br/>
                Bu kodu kimseyle paylaşmayın. Bu talebi siz yapmadıysanız, lütfen derhal hesabınızın güvenliğini kontrol edin.
            </div>
            <p>Kod 15 dakika boyunca geçerlidir.</p>
        </div>
        <div class='footer'>
            <p>© 2024 SinemaBilet - Tüm hakları saklıdır</p>
        </div>
    </div>
</body>
</html>";
        }

        /// <summary>
        /// E-posta gönderimi için kullanılacak hesap bilgilerini günceller
        /// </summary>
        /// <param name="adminEmail">Gönderici e-posta adresi</param>
        /// <param name="adminPassword">E-posta şifresi veya app password</param>
        public void SetEmailCredentials(string adminEmail, string adminPassword)
        {
            _adminEmail = adminEmail;
            _adminPassword = adminPassword;
        }
    }
}
