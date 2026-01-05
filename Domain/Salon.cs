namespace Sinemaci.BiletSistemi.Domain;

/// <summary>
/// Salon entity sınıfı - Sinema salonlarının bilgilerini tutar
/// </summary>
public class Salon
{
    public int Id { get; set; }
    public string Ad { get; set; } = "";
    public int KoltukSayisi { get; set; }

    // Navigation property - Salon'un tüm seansları
    public ICollection<Seans> Seanslar { get; set; } = new List<Seans>();
}
