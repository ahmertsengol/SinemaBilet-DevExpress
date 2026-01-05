using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Domain;
using Sinemaci.BiletSistemi.Helper;
using Sinemaci.BiletSistemi.Forms;
using System.Collections.Generic;

namespace Sinemaci.BiletSistemi;

/// <summary>
/// Uygulama başlangıç noktası - DevExpress tema ayarları ve veritabanı seeding
/// </summary>
internal static class Program
{
    [STAThread]
    static void Main()
    {
        // === DPI AWARENESS AYARLARI ===
        // Windows 10 1703+ için Per-Monitor V2 DPI desteği
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

        // DevExpress DPI desteğini aktif et
        DevExpress.XtraEditors.WindowsFormsSettings.SetPerMonitorDpiAware();
        DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Segoe UI", 9F);
        // DevExpress.Utils.Svg.SvgImageSize.SizeMode = DevExpress.Utils.Svg.SvgImageSizeMode.Zoom; // Bu özellik mevcut DevExpress sürümünde yok
        DevExpress.XtraEditors.WindowsFormsSettings.AllowDpiScale = true;

        // DevExpress tema ayarı
        DevExpressTheme.ApplyDefaultSkin();

        ApplicationConfiguration.Initialize();

        // === SPLASH SCREEN ===
        // Yükleme ekranını göster
        using (var frmYukleme = new FrmYukleme())
        {
            frmYukleme.ShowDialog();
        }

        // Veritabanı işlemleri
        try
        {
            using (var db = new AppDbContext())
            {
                // Veritabanı oluştur (SQLite)
                db.Database.EnsureCreated();

                // Demo verileri sadece veritabanı boşsa ekle
                if (!db.Kullanicilar.Any())
                {
                    SeedDemoData(db);
                }
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(
                $"Veritabanı başlatılırken hata oluştu:\n\n{ex.Message}\n\nDetay:\n{ex.InnerException?.Message}",
                "Veritabanı Hatası",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error
            );
            return;
        }

        // Giriş ekranını başlat
        Application.Run(new FrmGiris());
    }

    /// <summary>
    /// Demo verileri database'e ekler
    /// </summary>
    private static void SeedDemoData(AppDbContext db)
    {
        // === KULLANICILAR ===
        db.Kullanicilar.AddRange(
          new Kullanici { AdSoyad = "Ali Müşteri", Email = "musteri@demo.com", SifreHash = "123", Bakiye = 500, Rol = "Musteri" },
          new Kullanici { AdSoyad = "Ayşe Personel", Email = "personel@demo.com", SifreHash = "123", Bakiye = 0, Rol = "Personel" },
          new Kullanici { AdSoyad = "Mehmet Yılmaz", Email = "mehmet@demo.com", SifreHash = "123", Bakiye = 350, Rol = "Musteri" },
          new Kullanici { AdSoyad = "Zeynep Kaya", Email = "zeynep@demo.com", SifreHash = "123", Bakiye = 600, Rol = "Musteri" }
        );
        db.SaveChanges();

        // === FİLMLER ===
        var filmler = new List<Film>
        {
            new Film { Ad = "Oppenheimer", SureDakika = 180, Tur = "Biyografi/Drama" },
            new Film { Ad = "Inception", SureDakika = 148, Tur = "Bilim Kurgu" },
            new Film { Ad = "Interstellar", SureDakika = 169, Tur = "Bilim Kurgu" },
            new Film { Ad = "The Dark Knight", SureDakika = 152, Tur = "Aksiyon/Suç" },
            new Film { Ad = "Parasite", SureDakika = 132, Tur = "Gerilim/Drama" },
            new Film { Ad = "Dune: Part Two", SureDakika = 166, Tur = "Bilim Kurgu" },
            new Film { Ad = "The Godfather", SureDakika = 175, Tur = "Suç/Drama" },
            new Film { Ad = "Pulp Fiction", SureDakika = 154, Tur = "Suç/Drama" },
            new Film { Ad = "Forrest Gump", SureDakika = 142, Tur = "Drama/Romantik" },
            new Film { Ad = "The Matrix", SureDakika = 136, Tur = "Bilim Kurgu/Aksiyon" },
            new Film { Ad = "Gladiator", SureDakika = 155, Tur = "Aksiyon/Drama" },
            new Film { Ad = "Avatar", SureDakika = 162, Tur = "Bilim Kurgu/Fantastik" }
        };
        db.Filmler.AddRange(filmler);
        db.SaveChanges();

        // === SALONLAR ===
        var salonlar = new List<Salon>
        {
            new Salon { Ad = "Salon 1 - VIP", KoltukSayisi = 48 },
            new Salon { Ad = "Salon 2 - Premium", KoltukSayisi = 72 },
            new Salon { Ad = "Salon 3 - Standart", KoltukSayisi = 90 },
            new Salon { Ad = "Salon 4 - IMAX", KoltukSayisi = 120 }
        };
        db.Salonlar.AddRange(salonlar);
        db.SaveChanges();

        // === SEANSLAR ===
        var seanslar = new List<Seans>();
        var bugun = DateTime.UtcNow;
        var random = new Random();

        // Her film için 5 seans oluştur
        foreach (var film in filmler)
        {
            var randomSalon1 = salonlar[random.Next(salonlar.Count)];
            var randomSalon2 = salonlar[random.Next(salonlar.Count)];
            var randomSalon3 = salonlar[random.Next(salonlar.Count)];

            // Farklı fiyatlar
            decimal fiyat1 = randomSalon1.Ad.Contains("VIP") ? 200 : randomSalon1.Ad.Contains("IMAX") ? 180 : randomSalon1.Ad.Contains("Premium") ? 150 : 120;
            decimal fiyat2 = randomSalon2.Ad.Contains("VIP") ? 200 : randomSalon2.Ad.Contains("IMAX") ? 180 : randomSalon2.Ad.Contains("Premium") ? 150 : 120;
            decimal fiyat3 = randomSalon3.Ad.Contains("VIP") ? 200 : randomSalon3.Ad.Contains("IMAX") ? 180 : randomSalon3.Ad.Contains("Premium") ? 150 : 120;

            // Bugün - 3 farklı saat
            seanslar.Add(new Seans { FilmId = film.Id, SalonId = randomSalon1.Id, TarihSaat = bugun.Date.AddHours(14), Fiyat = fiyat1 }); // 14:00
            seanslar.Add(new Seans { FilmId = film.Id, SalonId = randomSalon2.Id, TarihSaat = bugun.Date.AddHours(17).AddMinutes(30), Fiyat = fiyat2 }); // 17:30
            seanslar.Add(new Seans { FilmId = film.Id, SalonId = randomSalon3.Id, TarihSaat = bugun.Date.AddHours(21), Fiyat = fiyat3 }); // 21:00

            // Yarın - 2 seans
            var yarin = bugun.AddDays(1);
            seanslar.Add(new Seans { FilmId = film.Id, SalonId = randomSalon1.Id, TarihSaat = yarin.Date.AddHours(15).AddMinutes(30), Fiyat = fiyat1 }); // 15:30
            seanslar.Add(new Seans { FilmId = film.Id, SalonId = randomSalon2.Id, TarihSaat = yarin.Date.AddHours(19).AddMinutes(45), Fiyat = fiyat2 }); // 19:45
        }

        db.Seanslar.AddRange(seanslar);
        db.SaveChanges();

        System.Diagnostics.Debug.WriteLine("Demo veriler başarıyla yüklendi:");
        System.Diagnostics.Debug.WriteLine($"- {db.Kullanicilar.Count()} kullanıcı");
        System.Diagnostics.Debug.WriteLine($"- {db.Filmler.Count()} film");
        System.Diagnostics.Debug.WriteLine($"- {db.Salonlar.Count()} salon");
        System.Diagnostics.Debug.WriteLine($"- {db.Seanslar.Count()} seans");
    }
}