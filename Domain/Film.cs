namespace Sinemaci.BiletSistemi.Domain;

/// <summary>
/// Film entity sınıfı - Vizyondaki film bilgilerini tutar
/// </summary>
public class Film
{
    public int Id { get; set; }
    public string Ad { get; set; } = "";
    public int SureDakika { get; set; }
    public string? Tur { get; set; }
    public DateTime? VizyonaGiris { get; set; }

    // Navigation property - Film'in tüm seansları
    public ICollection<Seans> Seanslar { get; set; } = new List<Seans>();
}
