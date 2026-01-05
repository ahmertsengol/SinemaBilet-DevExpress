using Microsoft.EntityFrameworkCore;
using Sinemaci.BiletSistemi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinemaci.BiletSistemi.Service
{
    /// <summary>
    /// Koltuk işlemleri için servis katmanı
    /// </summary>
    public class SKoltuk
    {
        private readonly AppDbContext _db;

        public SKoltuk(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Belirtilen seansa ait dolu koltuk numaralarını getirir
        /// </summary>
        public async Task<List<int>> GetDoluKoltuklarAsync(int seansId)
        {
            return await _db.Biletler
                .Where(b => b.SeansId == seansId)
                .Select(b => b.KoltukNo)
                .OrderBy(k => k)
                .ToListAsync();
        }

        /// <summary>
        /// Belirtilen koltuk dolu mu kontrol eder
        /// </summary>
        public async Task<bool> IsKoltukDoluAsync(int seansId, int koltukNo)
        {
            return await _db.Biletler.AnyAsync(b => b.SeansId == seansId && b.KoltukNo == koltukNo);
        }

        /// <summary>
        /// Belirtilen seanstaki boş koltuk sayısını getirir
        /// </summary>
        public async Task<int> GetBosKoltukSayisiAsync(int seansId)
        {
            var seans = await _db.Seanslar
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(s => s.Id == seansId);

            if (seans == null || seans.Salon == null) return 0;

            var doluKoltukSayisi = await _db.Biletler
                .Where(b => b.SeansId == seansId)
                .CountAsync();

            return seans.Salon.KoltukSayisi - doluKoltukSayisi;
        }

        /// <summary>
        /// Belirtilen seanstaki dolu koltuk sayısını getirir
        /// </summary>
        public async Task<int> GetDoluKoltukSayisiAsync(int seansId)
        {
            return await _db.Biletler
                .Where(b => b.SeansId == seansId)
                .CountAsync();
        }
    }
}
