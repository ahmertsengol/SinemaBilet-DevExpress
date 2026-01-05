using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Uygulama yükleme ekranı - DevExpress XtraForm
    /// Progress bar ile yükleme simülasyonu ve animasyonlar
    /// </summary>
    public partial class FrmYukleme : XtraForm
    {
        private int progressValue = 0;
        private readonly System.Windows.Forms.Timer timer;

        public FrmYukleme()
        {
            InitializeComponent();

            // Timer ayarları
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30; // 30ms aralıklarla güncelle (smooth animasyon)
            timer.Tick += Timer_Tick;
        }

        private void FrmYukleme_Load(object sender, EventArgs e)
        {
            // Timer'ı başlat
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Progress bar'ı artır
            progressValue += 2;

            if (progressValue <= 100)
            {
                progressBarYukleme.EditValue = progressValue;

                // Yükleme mesajlarını güncelle
                UpdateLoadingMessage(progressValue);
            }
            else
            {
                // Yükleme tamamlandı
                timer.Stop();

                // Kısa bir bekleme sonrası formu kapat
                System.Threading.Tasks.Task.Delay(300).ContinueWith(_ =>
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => this.DialogResult = DialogResult.OK));
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                });
            }
        }

        private void UpdateLoadingMessage(int progress)
        {
            string mesaj;

            if (progress < 30)
            {
                mesaj = "Sistem başlatılıyor...";
            }
            else if (progress < 60)
            {
                mesaj = "Veritabanı bağlantısı kuruluyor...";
            }
            else if (progress < 90)
            {
                mesaj = "Modüller yükleniyor...";
            }
            else
            {
                mesaj = "Hazır!";
            }

            lblYuklemeMetni.Text = mesaj;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer?.Stop();
            timer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
