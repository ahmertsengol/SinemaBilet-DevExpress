namespace Sinemaci.BiletSistemi.Domain;

/// <summary>
/// Kullanıcı entity sınıfı - Müşteri ve Personel bilgilerini tutar
/// </summary>
public class Kullanici
{
    public int Id { get; set; }
    public string AdSoyad { get; set; } = "";
    public string Email { get; set; } = "";
    public string SifreHash { get; set; } = "";
    public decimal Bakiye { get; set; }
    public string Rol { get; set; } = "Musteri"; // Musteri | Personel | Admin

    public ICollection<Bilet> Biletler { get; set; } = new List<Bilet>();
}
