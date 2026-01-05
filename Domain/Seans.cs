namespace Sinemaci.BiletSistemi.Domain;

/// <summary>
/// Seans entity sınıfı - Film gösterim zamanlarını tutar
/// </summary>
public class Seans
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public int SalonId { get; set; }
    public DateTime TarihSaat { get; set; }
    public decimal Fiyat { get; set; }

    public Film? Film { get; set; }
    public Salon? Salon { get; set; }
    public ICollection<Bilet> Biletler { get; set; } = new List<Bilet>();
}
