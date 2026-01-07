using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Domain;
using Sinemaci.BiletSistemi.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinemaci.BiletSistemi.Forms
{
    /// <summary>
    /// Biletlerim Sayfası - Modern Kart Tasarımı
    /// </summary>
    public partial class FrmBiletlerim : XtraForm
    {
        private readonly int _kullaniciId;
        private List<Bilet> _biletler = new List<Bilet>();

        public FrmBiletlerim(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            this.Text = "Biletlerim - Sinemacı";
        }

        private async void FrmBiletlerim_Load(object sender, EventArgs e)
        {
            await BiletleriYukleAsync();
        }

        private async Task BiletleriYukleAsync()
        {
            try
            {
                using var db = new AppDbContext();

                _biletler = await db.Biletler
                    .Include(b => b.Seans)
                        .ThenInclude(s => s.Film)
                    .Include(b => b.Seans)
                        .ThenInclude(s => s.Salon)
                    .Where(b => b.KullaniciId == _kullaniciId)
                    .OrderByDescending(b => b.AlimZamani)
                    .ToListAsync();

                if (_biletler.Count == 0)
                {
                    lblBos.Visible = true;
                    flowBiletler.Visible = false;
                    return;
                }

                lblBos.Visible = false;
                flowBiletler.Visible = true;

                BiletKartlariOlustur();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Biletler yüklenirken hata oluştu:\n\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BiletKartlariOlustur()
        {
            flowBiletler.Controls.Clear();

            foreach (var bilet in _biletler)
            {
                var kart = BiletKartiOlustur(bilet);
                flowBiletler.Controls.Add(kart);
            }
        }

        private Panel BiletKartiOlustur(Bilet bilet)
        {
            var panel = new Panel
            {
                Size = new Size(350, 240),
                Margin = new Padding(15),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = bilet // Bilet nesnesini Tag'e koy
            };

            // Film adı (büyük, ortalanmış)
            var lblFilm = new Label
            {
                Text = bilet.Seans?.Film?.Ad ?? "Bilinmiyor",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                Location = new Point(5, 15),
                Size = new Size(340, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Salon
            var lblSalon = new Label
            {
                Text = $"🏛️  {bilet.Seans?.Salon?.Ad ?? "-"}",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(5, 70),
                Size = new Size(340, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Tarih
            var lblTarih = new Label
            {
                Text = $"📅  {bilet.Seans?.TarihSaat.ToLocalTime():dd MMMM yyyy}",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(5, 107),
                Size = new Size(340, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Saat
            var lblSaat = new Label
            {
                Text = $"🕐  {bilet.Seans?.TarihSaat.ToLocalTime():HH:mm}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                Location = new Point(5, 142),
                Size = new Size(340, 55),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Koltuk
            var lblKoltuk = new Label
            {
                Text = $"💺  Koltuk: {bilet.KoltukNo}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(5, 182),
                Size = new Size(340, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Hover efekti - Daha belirgin
            panel.MouseEnter += (s, e) =>
            {
                panel.BackColor = Color.FromArgb(230, 240, 255);
                panel.BorderStyle = BorderStyle.FixedSingle;
            };

            panel.MouseLeave += (s, e) =>
            {
                panel.BackColor = Color.White;
                panel.BorderStyle = BorderStyle.FixedSingle;
            };

            // Tıklama eventi
            panel.Click += BiletKart_Click;
            lblFilm.Click += BiletKart_Click;
            lblSalon.Click += BiletKart_Click;
            lblTarih.Click += BiletKart_Click;
            lblSaat.Click += BiletKart_Click;
            lblKoltuk.Click += BiletKart_Click;

            panel.Controls.Add(lblFilm);
            panel.Controls.Add(lblSalon);
            panel.Controls.Add(lblTarih);
            panel.Controls.Add(lblSaat);
            panel.Controls.Add(lblKoltuk);

            return panel;
        }

        private void BiletKart_Click(object sender, EventArgs e)
        {
            // Tıklanan kontrolün parent'ını (Panel) bul
            Control control = sender as Control;
            while (control != null && !(control is Panel))
            {
                control = control.Parent;
            }

            if (control?.Tag is Bilet bilet)
            {
                // QR kod detay sayfasını aç
                using var frmDetay = new FrmBiletDetay(bilet);
                frmDetay.ShowDialog(this);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
