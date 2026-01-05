namespace Sinemaci.BiletSistemi.Domain;

/// <summary>
/// Bilet entity sınıfı - Satın alınan bilet bilgilerini tutar
/// </summary>
public class Bilet
{
    public int Id { get; set; }
    public int SeansId { get; set; }
    public int KullaniciId { get; set; }
    public int KoltukNo { get; set; }
    public decimal Tutar { get; set; }
    public DateTime AlimZamani { get; set; } = DateTime.UtcNow;

    public Seans? Seans { get; set; }
    public Kullanici? Kullanici { get; set; }
}
