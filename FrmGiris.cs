using DevExpress.XtraEditors;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Helper;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Giriş Formu - DevExpress XtraForm
    /// Login screen with DevExpress modern controls
    /// </summary>
    public partial class FrmGiris : XtraForm
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            // DevExpress tema uygula
            DevExpressTheme.ApplyDefaultSkin();

            // Hover efektleri (DevExpress SimpleButton için)
            DevExpressUIHelper.AddHoverEffect(btnGiris, DevExpressTheme.Success, DevExpressTheme.SuccessHover);
            DevExpressUIHelper.AddHoverEffect(btnKaydol, DevExpressTheme.Primary, DevExpressTheme.Info);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                var email = txtEmail.Text?.Trim();
                var sifre = txtSifre.Text;

                if (string.IsNullOrWhiteSpace(email))
                {
                    XtraMessageBox.Show("E-posta adresi boş olamaz.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!email.Contains("@") || !email.Contains("."))
                {
                    XtraMessageBox.Show("Geçerli bir e-posta adresi girin.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(sifre))
                {
                    XtraMessageBox.Show("Şifre boş olamaz.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSifre.Focus();
                    return;
                }

                using var db = new AppDbContext();
                var u = db.Kullanicilar.FirstOrDefault(x => x.Email == email && x.SifreHash == sifre);

                if (u is null)
                {
                    XtraMessageBox.Show("Geçersiz e-posta veya şifre.", "Giriş Başarısız",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSifre.Text = "";
                    txtEmail.Focus();
                    return;
                }

                // Başarılı giriş - Toast notification göster
                DevExpressUIHelper.ShowToast(this, $"Hoş geldiniz, {u.AdSoyad}!", AlertType.Success);

                // Yeni formu aç ve bu formu kapat
                XtraForm yeniForm = u.Rol == "Personel"
                    ? new FrmPersonel(u.Id)
                    : new FrmMusteri(u.Id);

                yeniForm.FormClosed += (s, args) => Application.Exit();
                yeniForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Giriş sırasında hata oluştu:\n\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            try
            {
                var kaydolForm = new FrmKaydol();
                var sonuc = kaydolForm.ShowDialog();

                if (sonuc == DialogResult.OK)
                {
                    DevExpressUIHelper.ShowToast(this, "Kayıt başarılı! Giriş yapabilirsiniz.", AlertType.Success);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu:\n\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkSifreUnuttum_Click(object sender, EventArgs e)
        {
            try
            {
                var sifreUnuttumForm = new FrmSifreUnuttum();
                var sonuc = sifreUnuttumForm.ShowDialog();

                if (sonuc == DialogResult.OK)
                {
                    DevExpressUIHelper.ShowToast(this, "Şifreniz başarıyla değiştirildi!", AlertType.Success);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu:\n\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
