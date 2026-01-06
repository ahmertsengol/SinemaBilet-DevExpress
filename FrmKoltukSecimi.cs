using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Domain;
using Sinemaci.BiletSistemi.Helper;
using Sinemaci.BiletSistemi.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Koltuk Seçimi Formu - DevExpress XtraForm
    /// </summary>
    public partial class FrmKoltukSecimi : XtraForm
    {
        private readonly int _kullaniciId;
        private readonly int _seansId;
        private int _secilenKoltuk = 0;
        private SimpleButton? _secilenButton = null;
        private Seans? _seans;
        private List<int> _doluKoltuklar = new List<int>();

        public FrmKoltukSecimi(int kullaniciId, int seansId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            _seansId = seansId;
            this.Text = "Koltuk Seçimi - Sinemacı";
        }

        private async void FrmKoltukSecimi_Load(object sender, EventArgs e)
        {
            try
            {
                // Seans bilgilerini yükle
                using var db = new AppDbContext();
                _seans = await db.Seanslar
                    .Include(s => s.Film)
                    .Include(s => s.Salon)
                    .FirstOrDefaultAsync(s => s.Id == _seansId);

                if (_seans == null || _seans.Film == null || _seans.Salon == null)
                {
                    XtraMessageBox.Show("Seans bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Header bilgilerini güncelle
                lblFilmAd.Text = "🎬 " + _seans.Film.Ad.ToUpper();
                lblSeansDetay.Text = $"{_seans.Salon.Ad} • {_seans.TarihSaat.ToLocalTime():HH:mm} • {_seans.TarihSaat.ToLocalTime():dd.MM.yyyy}";
                lblFiyat.Text = _seans.Fiyat.ToString("C");

                // Dolu koltukları al
                var koltukService = new SKoltuk(db);
                _doluKoltuklar = await koltukService.GetDoluKoltuklarAsync(_seansId);

                // Koltukları oluştur
                KoltuklariOlustur();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Yükleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KoltuklariOlustur()
        {
            if (_seans == null || _seans.Salon == null) return;

            flpKoltuk.Controls.Clear();
            int koltukSayisi = _seans.Salon.KoltukSayisi;
            int satirBasinaKoltuk = 10; // Standart sinema düzeni: 10 koltuk/satır

            int satirSayisi = (int)Math.Ceiling((double)koltukSayisi / satirBasinaKoltuk);
            int koltukIndex = 1;

            for (int satirNo = 0; satirNo < satirSayisi; satirNo++)
            {
                // Sıra harfi (A, B, C, D, ...)
                char satirHarfi = (char)('A' + satirNo);

                // Satır container oluştur
                Panel satirContainer = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(0),
                    Margin = new Padding(0, 5, 0, 5)
                };

                FlowLayoutPanel satirPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(0),
                    Margin = new Padding(0)
                };

                // Sıra etiketi (sol tarafta)
                LabelControl lblSira = new LabelControl
                {
                    Text = satirHarfi.ToString(),
                    AutoSizeMode = LabelAutoSizeMode.None,
                    Size = new Size(50, 70),
                    Appearance =
                    {
                        Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(44, 62, 80),
                        TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Center, VAlignment = DevExpress.Utils.VertAlignment.Center }
                    }
                };
                satirPanel.Controls.Add(lblSira);

                // Bu satırdaki koltuk sayısını hesapla
                int buSatirdakiKoltukSayisi = Math.Min(satirBasinaKoltuk, koltukSayisi - koltukIndex + 1);

                for (int koltukNoSatirda = 1; koltukNoSatirda <= buSatirdakiKoltukSayisi; koltukNoSatirda++)
                {
                    bool dolu = _doluKoltuklar.Contains(koltukIndex);
                    string koltukEtiketi = $"{satirHarfi}-{koltukNoSatirda}";
                    SimpleButton koltukBtn = KoltukButtonOlustur(koltukIndex, koltukEtiketi, dolu);
                    satirPanel.Controls.Add(koltukBtn);

                    // Her 5 koltukta bir koridor boşluğu (orta koridor)
                    if (koltukNoSatirda == 5 && buSatirdakiKoltukSayisi > 5)
                    {
                        Panel koridor = new Panel
                        {
                            Width = 30,
                            Height = 70,
                            BackColor = Color.Transparent,
                            Margin = new Padding(0)
                        };
                        satirPanel.Controls.Add(koridor);
                    }

                    koltukIndex++;
                    if (koltukIndex > koltukSayisi) break;
                }

                satirContainer.Controls.Add(satirPanel);
                flpKoltuk.Controls.Add(satirContainer);
            }
        }

        private SimpleButton KoltukButtonOlustur(int koltukNo, string koltukEtiketi, bool dolu)
        {
            SimpleButton btn = new SimpleButton
            {
                Size = new Size(70, 70),
                Text = koltukEtiketi,
                Tag = koltukNo, // Veritabanı için gerçek koltuk numarası
                Cursor = dolu ? Cursors.No : Cursors.Hand,
                Enabled = !dolu,
                Margin = new Padding(3)
            };

            // DevExpress Appearance ayarları
            btn.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn.Appearance.BackColor = dolu ? DevExpressTheme.KoltukDolu : DevExpressTheme.KoltukBos;
            btn.Appearance.ForeColor = Color.White;
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseFont = true;
            btn.Appearance.Options.UseForeColor = true;

            if (!dolu)
            {
                // Click event
                btn.Click += KoltukButton_Click;

                // Hover animasyon
                btn.MouseEnter += (s, e) =>
                {
                    if (btn.Tag != null && (int)btn.Tag != _secilenKoltuk)
                    {
                        btn.Appearance.BackColor = DevExpressTheme.KoltukHover;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn.Tag != null && (int)btn.Tag != _secilenKoltuk)
                    {
                        btn.Appearance.BackColor = DevExpressTheme.KoltukBos;
                    }
                };
            }

            return btn;
        }

        private void KoltukButton_Click(object? sender, EventArgs e)
        {
            if (sender is not SimpleButton btn) return;
            if (btn.Tag == null) return;

            // Önceki seçimi temizle
            if (_secilenButton != null)
            {
                _secilenButton.Appearance.BackColor = DevExpressTheme.KoltukBos;
            }

            // Yeni seçim
            _secilenKoltuk = (int)btn.Tag;
            _secilenButton = btn;
            btn.Appearance.BackColor = DevExpressTheme.KoltukSecili;

            // Footer güncelle - Koltuk etiketini göster (A-5 gibi)
            lblSecim.Text = $"Seçilen: {btn.Text}";
            btnSatinAl.Enabled = true;
        }

        private async void btnSatinAl_Click(object sender, EventArgs e)
        {
            if (_secilenKoltuk == 0)
            {
                XtraMessageBox.Show("Lütfen bir koltuk seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new AppDbContext();
                var service = new SBilet(db);
                var mesaj = await service.BiletAlAsync(_kullaniciId, _seansId, _secilenKoltuk);

                if (mesaj.Contains("başarıyla"))
                {
                    DevExpressUIHelper.ShowToast(this, "✓ " + mesaj, AlertType.Success);
                    await System.Threading.Tasks.Task.Delay(1500); // Toast'u görmek için bekle
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Koltuk durumunu yenile (başkası almış olabilir)
                    await YenileKoltuklar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Satın alma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task YenileKoltuklar()
        {
            try
            {
                using var db = new AppDbContext();
                var koltukService = new SKoltuk(db);
                _doluKoltuklar = await koltukService.GetDoluKoltuklarAsync(_seansId);
                KoltuklariOlustur();
                _secilenKoltuk = 0;
                _secilenButton = null;
                btnSatinAl.Enabled = false;
                lblSecim.Text = "Koltuk seçiniz...";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Yenileme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
