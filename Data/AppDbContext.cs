using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Domain;
using System.IO;

namespace Sinemaci.BiletSistemi.Data;

/// <summary>
/// Uygulama veritabanı bağlam sınıfı - SQLite ile çalışır
/// </summary>
public class AppDbContext : DbContext
{
    public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
    public DbSet<Film> Filmler => Set<Film>();
    public DbSet<Salon> Salonlar => Set<Salon>();
    public DbSet<Seans> Seanslar => Set<Seans>();
    public DbSet<Bilet> Biletler => Set<Bilet>();

    /// <summary>
    /// Veritabanı bağlantı yapılandırması - SQLite LocalApplicationData klasöründe
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SQLite veritabanı dosyası - kullanıcının AppData klasöründe tutulur
        var appDataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Sinemaci"
        );

        // Klasör yoksa oluştur
        Directory.CreateDirectory(appDataPath);

        var dbPath = Path.Combine(appDataPath, "sinemaci.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    /// <summary>
    /// Model yapılandırması - Unique constraint'ler ve index'ler tanımlanır
    /// </summary>
    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Aynı seans için aynı koltuğun iki kere satılmasını engelle
        mb.Entity<Bilet>()
          .HasIndex(b => new { b.SeansId, b.KoltukNo })
          .IsUnique();

        // E-posta benzersiz olsun (kayıt ekranı için önemli)
        mb.Entity<Kullanici>()
          .HasIndex(k => k.Email)
          .IsUnique();

        // Yerel saat saklamak istersen (UTC kullanmıyoruz dersen) şu iki satırı aç:
        // mb.Entity<Seans>().Property(p => p.TarihSaat).HasColumnType("timestamp without time zone");
        // mb.Entity<Bilet>().Property(p => p.AlimZamani).HasColumnType("timestamp without time zone");
    }
}
