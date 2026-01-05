using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using Sinemaci.BiletSistemi.Domain;

namespace Sinemaci.BiletSistemi.Service
{
    /// <summary>
    /// Bilet satış işlemlerini yöneten servis sınıfı
    /// </summary>
    public class SBilet
    {
        private readonly AppDbContext _db;
        public SBilet(AppDbContext db) => _db = db;

        /// <summary>
        /// Kullanıcı için bilet satın alma işlemini gerçekleştirir
        /// </summary>
        /// <param name="kullaniciId">Kullanıcı ID</param>
        /// <param name="seansId">Seans ID</param>
        /// <param name="koltukNo">Koltuk numarası</param>
        /// <returns>Hata mesajı (varsa), başarılıysa başarı mesajı</returns>
        public async Task<string> BiletAlAsync(int kullaniciId, int seansId, int koltukNo)
        {
            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                var k = await _db.Kullanicilar.FindAsync(kullaniciId);
                var s = await _db.Seanslar.Include(x => x.Salon).FirstOrDefaultAsync(x => x.Id == seansId);
                if (k is null || s is null) return "Kullanıcı veya seans bulunamadı.";

                // Salon kapasitesi kontrolü (KRİTİK!)
                if (s.Salon == null) return "Seans salon bilgisi bulunamadı.";
                if (koltukNo < 1 || koltukNo > s.Salon.KoltukSayisi)
                {
                    return $"Geçersiz koltuk numarası. Bu salonda 1-{s.Salon.KoltukSayisi} arası koltuk seçebilirsiniz.";
                }

                // Koltuk dolu mu?
                bool dolu = await _db.Biletler.AnyAsync(b => b.SeansId == seansId && b.KoltukNo == koltukNo);
                if (dolu) return "Seçilen koltuk dolu.";

                // Bakiye yeterli mi?
                if (k.Bakiye < s.Fiyat) return "Yetersiz bakiye.";

                // Satın alma
                k.Bakiye -= s.Fiyat;
                _db.Biletler.Add(new Bilet { SeansId = seansId, KullaniciId = kullaniciId, KoltukNo = koltukNo, Tutar = s.Fiyat });
                await _db.SaveChangesAsync();
                await tx.CommitAsync();

                return "Bilet başarıyla alındı.";
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                return $"Bilet alımı sırasında hata oluştu: {ex.Message}";
            }
        }
    }
}
