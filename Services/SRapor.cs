using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Sinemaci.BiletSistemi.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace Sinemaci.BiletSistemi.Service
{
    /// <summary>
    /// Rapor türü enum - Film bazlı veya Müşteri bazlı
    /// </summary>
    public enum RaporTuru
    {
        FilmBazli,
        MusteriBazli
    }

    /// <summary>
    /// Rapor oluşturma işlemlerini yöneten servis sınıfı - PDF, Excel ve TXT formatlarını destekler
    /// </summary>
    public class SRapor
    {
        private readonly AppDbContext _context;

        public SRapor(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Film bazlı rapor verilerini getirir
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi (UTC)</param>
        /// <param name="bitis">Bitiş tarihi (UTC)</param>
        /// <returns>Film detay listesi</returns>
        public async Task<List<FilmRaporDetay>> FilmBazliRaporVerileriGetirAsync(DateTime baslangic, DateTime bitis)
        {
            var biletler = await _context.Biletler
                .Include(b => b.Seans)
                    .ThenInclude(s => s.Film)
                .Include(b => b.Seans)
                    .ThenInclude(s => s.Salon)
                .Include(b => b.Kullanici)
                .Where(b => b.AlimZamani >= baslangic && b.AlimZamani <= bitis)
                .ToListAsync();

            var filmGrubu = biletler
                .GroupBy(b => new { b.Seans.Film!.Id, b.Seans.Film.Ad })
                .Select(g => new FilmRaporDetay
                {
                    FilmAdi = g.Key.Ad,
                    ToplamBiletSayisi = g.Count(),
                    ToplamGelir = g.Sum(b => b.Tutar),
                    SeansSayisi = g.Select(b => b.SeansId).Distinct().Count(),
                    OrtalamaBiletFiyati = g.Average(b => b.Tutar),
                    EnCokSatanSalon = g.GroupBy(b => b.Seans.Salon!.Ad)
                        .OrderByDescending(sg => sg.Count())
                        .Select(sg => sg.Key)
                        .FirstOrDefault() ?? "N/A"
                })
                .OrderByDescending(f => f.ToplamGelir)
                .ToList();

            return filmGrubu;
        }

        /// <summary>
        /// Müşteri bazlı rapor verilerini getirir
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi (UTC)</param>
        /// <param name="bitis">Bitiş tarihi (UTC)</param>
        /// <returns>Müşteri detay listesi</returns>
        public async Task<List<MusteriRaporDetay>> MusteriBazliRaporVerileriGetirAsync(DateTime baslangic, DateTime bitis)
        {
            var biletler = await _context.Biletler
                .Include(b => b.Seans)
                    .ThenInclude(s => s.Film)
                .Include(b => b.Kullanici)
                .Where(b => b.AlimZamani >= baslangic && b.AlimZamani <= bitis)
                .ToListAsync();

            var musteriGrubu = biletler
                .GroupBy(b => new { b.Kullanici!.Id, b.Kullanici.AdSoyad, b.Kullanici.Email })
                .Select(g => new MusteriRaporDetay
                {
                    MusteriAdi = g.Key.AdSoyad,
                    Email = g.Key.Email,
                    ToplamBiletSayisi = g.Count(),
                    ToplamHarcama = g.Sum(b => b.Tutar),
                    IzlenenFilmSayisi = g.Select(b => b.Seans.FilmId).Distinct().Count(),
                    SonAlimTarihi = g.Max(b => b.AlimZamani),
                    EnCokIzledigiFilm = g.GroupBy(b => b.Seans.Film!.Ad)
                        .OrderByDescending(fg => fg.Count())
                        .Select(fg => fg.Key)
                        .FirstOrDefault() ?? "N/A"
                })
                .OrderByDescending(m => m.ToplamHarcama)
                .ToList();

            return musteriGrubu;
        }

        /// <summary>
        /// Film bazlı TXT formatında rapor oluşturur
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi</param>
        /// <param name="bitis">Bitiş tarihi</param>
        /// <param name="kayitYolu">Dosya kayıt yolu</param>
        /// <returns>Oluşturulan dosya yolu</returns>
        public async Task<string> FilmBazliTxtOlusturAsync(DateTime baslangic, DateTime bitis, string kayitYolu)
        {
            var veriler = await FilmBazliRaporVerileriGetirAsync(baslangic, bitis);
            var toplamGelir = veriler.Sum(v => v.ToplamGelir);
            var toplamBilet = veriler.Sum(v => v.ToplamBiletSayisi);

            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine("          SİNEMACI - FİLM BAZLI SATIŞ RAPORU");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine();
            sb.AppendLine($"Tarih Aralığı: {baslangic:dd.MM.yyyy} - {bitis:dd.MM.yyyy}");
            sb.AppendLine($"Rapor Oluşturma Zamanı: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine();
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine("ÖZET BİLGİLER");
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine($"Toplam Film Sayısı      : {veriler.Count}");
            sb.AppendLine($"Toplam Bilet Satışı     : {toplamBilet}");
            sb.AppendLine($"Toplam Gelir            : {toplamGelir:N2} ₺");
            sb.AppendLine($"Ortalama Bilet Fiyatı   : {(toplamBilet > 0 ? toplamGelir / toplamBilet : 0):N2} ₺");
            sb.AppendLine();
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine("FİLM DETAYLARI");
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine();

            foreach (var veri in veriler)
            {
                sb.AppendLine($"Film: {veri.FilmAdi}");
                sb.AppendLine($"  • Bilet Sayısı          : {veri.ToplamBiletSayisi}");
                sb.AppendLine($"  • Seans Sayısı          : {veri.SeansSayisi}");
                sb.AppendLine($"  • Toplam Gelir          : {veri.ToplamGelir:N2} ₺");
                sb.AppendLine($"  • Ortalama Bilet Fiyatı : {veri.OrtalamaBiletFiyati:N2} ₺");
                sb.AppendLine($"  • En Çok Satan Salon    : {veri.EnCokSatanSalon}");
                sb.AppendLine();
            }

            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine("            RAPOR SONU");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");

            File.WriteAllText(kayitYolu, sb.ToString(), Encoding.UTF8);
            return kayitYolu;
        }

        /// <summary>
        /// Müşteri bazlı TXT formatında rapor oluşturur
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi</param>
        /// <param name="bitis">Bitiş tarihi</param>
        /// <param name="kayitYolu">Dosya kayıt yolu</param>
        /// <returns>Oluşturulan dosya yolu</returns>
        public async Task<string> MusteriBazliTxtOlusturAsync(DateTime baslangic, DateTime bitis, string kayitYolu)
        {
            var veriler = await MusteriBazliRaporVerileriGetirAsync(baslangic, bitis);
            var toplamGelir = veriler.Sum(v => v.ToplamHarcama);
            var toplamBilet = veriler.Sum(v => v.ToplamBiletSayisi);

            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine("          SİNEMACI - MÜŞTERİ BAZLI SATIŞ RAPORU");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine();
            sb.AppendLine($"Tarih Aralığı: {baslangic:dd.MM.yyyy} - {bitis:dd.MM.yyyy}");
            sb.AppendLine($"Rapor Oluşturma Zamanı: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine();
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine("ÖZET BİLGİLER");
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine($"Toplam Müşteri Sayısı     : {veriler.Count}");
            sb.AppendLine($"Toplam Bilet Satışı       : {toplamBilet}");
            sb.AppendLine($"Toplam Gelir              : {toplamGelir:N2} ₺");
            sb.AppendLine($"Müşteri Başı Ort. Harcama : {(veriler.Count > 0 ? toplamGelir / veriler.Count : 0):N2} ₺");
            sb.AppendLine();
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine("MÜŞTERİ DETAYLARI");
            sb.AppendLine("───────────────────────────────────────────────────────────────────");
            sb.AppendLine();

            foreach (var veri in veriler)
            {
                sb.AppendLine($"Müşteri: {veri.MusteriAdi}");
                sb.AppendLine($"  • Email                : {veri.Email}");
                sb.AppendLine($"  • Bilet Sayısı         : {veri.ToplamBiletSayisi}");
                sb.AppendLine($"  • Toplam Harcama       : {veri.ToplamHarcama:N2} ₺");
                sb.AppendLine($"  • İzlenen Film Sayısı  : {veri.IzlenenFilmSayisi}");
                sb.AppendLine($"  • En Çok İzlediği Film : {veri.EnCokIzledigiFilm}");
                sb.AppendLine($"  • Son Alım Tarihi      : {veri.SonAlimTarihi:dd.MM.yyyy HH:mm}");
                sb.AppendLine();
            }

            sb.AppendLine("═══════════════════════════════════════════════════════════════════");
            sb.AppendLine("            RAPOR SONU");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════");

            File.WriteAllText(kayitYolu, sb.ToString(), Encoding.UTF8);
            return kayitYolu;
        }

        /// <summary>
        /// Film bazlı PDF formatında rapor oluşturur (QuestPDF kütüphanesi kullanır)
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi</param>
        /// <param name="bitis">Bitiş tarihi</param>
        /// <param name="kayitYolu">Dosya kayıt yolu</param>
        /// <returns>Oluşturulan dosya yolu</returns>
        public async Task<string> FilmBazliPdfOlusturAsync(DateTime baslangic, DateTime bitis, string kayitYolu)
        {
            var veriler = await FilmBazliRaporVerileriGetirAsync(baslangic, bitis);
            var toplamGelir = veriler.Sum(v => v.ToplamGelir);
            var toplamBilet = veriler.Sum(v => v.ToplamBiletSayisi);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    // Header
                    page.Header()
                        .Height(80)
                        .Background(Colors.Blue.Darken2)
                        .Padding(20)
                        .Column(column =>
                        {
                            column.Item().Text("SİNEMACI - Film Bazlı Satış Raporu")
                                .FontSize(20)
                                .Bold()
                                .FontColor(Colors.White);
                            column.Item().PaddingTop(5).Text($"Tarih Aralığı: {baslangic:dd.MM.yyyy} - {bitis:dd.MM.yyyy}")
                                .FontSize(12)
                                .FontColor(Colors.White);
                        });

                    // Content
                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            // Özet Bilgiler
                            column.Item().Background(Colors.Grey.Lighten3).Padding(15).Column(col =>
                            {
                                col.Item().Text("ÖZET BİLGİLER").FontSize(14).Bold();
                                col.Item().PaddingTop(10).Row(row =>
                                {
                                    row.RelativeItem().Text($"Toplam Film Sayısı: {veriler.Count}").FontSize(11);
                                    row.RelativeItem().Text($"Toplam Bilet Satışı: {toplamBilet}").FontSize(11);
                                });
                                col.Item().PaddingTop(5).Text($"Toplam Gelir: {toplamGelir:N2} ₺").FontSize(12).Bold().FontColor(Colors.Green.Darken2);
                                col.Item().PaddingTop(5).Text($"Ortalama Bilet Başı Gelir: {(toplamBilet > 0 ? toplamGelir / toplamBilet : 0):N2} ₺").FontSize(11);
                            });

                            column.Item().PaddingTop(20).Text("FİLM DETAYLARI").FontSize(14).Bold();

                            // Tablo
                            column.Item().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3); // Film Adı
                                    columns.RelativeColumn(1); // Bilet Sayısı
                                    columns.RelativeColumn(1); // Seans Sayısı
                                    columns.RelativeColumn(1); // Gelir
                                    columns.RelativeColumn(2); // En Çok Satan Salon
                                });

                                // Header
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Blue.Darken1).Padding(5).Text("Film Adı").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Blue.Darken1).Padding(5).Text("Bilet").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Blue.Darken1).Padding(5).Text("Seans").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Blue.Darken1).Padding(5).Text("Gelir (₺)").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Blue.Darken1).Padding(5).Text("En Çok Satan Salon").FontColor(Colors.White).Bold();
                                });

                                // Rows
                                foreach (var veri in veriler)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.FilmAdi);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.ToplamBiletSayisi.ToString());
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.SeansSayisi.ToString());
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.ToplamGelir.ToString("N2"));
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.EnCokSatanSalon);
                                }
                            });
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ").FontSize(9);
                            x.CurrentPageNumber().FontSize(9);
                            x.Span(" / ").FontSize(9);
                            x.TotalPages().FontSize(9);
                            x.Span($" - Oluşturulma: {DateTime.Now:dd.MM.yyyy HH:mm}").FontSize(9);
                        });
                });
            });

            document.GeneratePdf(kayitYolu);
            return kayitYolu;
        }

        /// <summary>
        /// Müşteri bazlı PDF formatında rapor oluşturur (QuestPDF kütüphanesi kullanır)
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi</param>
        /// <param name="bitis">Bitiş tarihi</param>
        /// <param name="kayitYolu">Dosya kayıt yolu</param>
        /// <returns>Oluşturulan dosya yolu</returns>
        public async Task<string> MusteriBazliPdfOlusturAsync(DateTime baslangic, DateTime bitis, string kayitYolu)
        {
            var veriler = await MusteriBazliRaporVerileriGetirAsync(baslangic, bitis);
            var toplamGelir = veriler.Sum(v => v.ToplamHarcama);
            var toplamBilet = veriler.Sum(v => v.ToplamBiletSayisi);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                    // Header
                    page.Header()
                        .Height(80)
                        .Background(Colors.Green.Darken2)
                        .Padding(20)
                        .Column(column =>
                        {
                            column.Item().Text("SİNEMACI - Müşteri Bazlı Satış Raporu")
                                .FontSize(20)
                                .Bold()
                                .FontColor(Colors.White);
                            column.Item().PaddingTop(5).Text($"Tarih Aralığı: {baslangic:dd.MM.yyyy} - {bitis:dd.MM.yyyy}")
                                .FontSize(12)
                                .FontColor(Colors.White);
                        });

                    // Content
                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            // Özet Bilgiler
                            column.Item().Background(Colors.Grey.Lighten3).Padding(15).Column(col =>
                            {
                                col.Item().Text("ÖZET BİLGİLER").FontSize(14).Bold();
                                col.Item().PaddingTop(10).Row(row =>
                                {
                                    row.RelativeItem().Text($"Toplam Müşteri Sayısı: {veriler.Count}").FontSize(11);
                                    row.RelativeItem().Text($"Toplam Bilet Satışı: {toplamBilet}").FontSize(11);
                                });
                                col.Item().PaddingTop(5).Text($"Toplam Gelir: {toplamGelir:N2} ₺").FontSize(12).Bold().FontColor(Colors.Green.Darken2);
                                col.Item().PaddingTop(5).Text($"Müşteri Başı Ortalama Harcama: {(veriler.Count > 0 ? toplamGelir / veriler.Count : 0):N2} ₺").FontSize(11);
                            });

                            column.Item().PaddingTop(20).Text("MÜŞTERİ DETAYLARI").FontSize(14).Bold();

                            // Tablo
                            column.Item().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2); // Müşteri Adı
                                    columns.RelativeColumn(2); // Email
                                    columns.RelativeColumn(1); // Bilet Sayısı
                                    columns.RelativeColumn(1); // Harcama
                                    columns.RelativeColumn(2); // En Çok İzlediği Film
                                });

                                // Header
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Green.Darken1).Padding(5).Text("Müşteri Adı").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Green.Darken1).Padding(5).Text("Email").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Green.Darken1).Padding(5).Text("Bilet").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Green.Darken1).Padding(5).Text("Harcama (₺)").FontColor(Colors.White).Bold();
                                    header.Cell().Background(Colors.Green.Darken1).Padding(5).Text("En Çok İzlediği").FontColor(Colors.White).Bold();
                                });

                                // Rows
                                foreach (var veri in veriler)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.MusteriAdi);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.Email);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.ToplamBiletSayisi.ToString());
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.ToplamHarcama.ToString("N2"));
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(veri.EnCokIzledigiFilm);
                                }
                            });
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ").FontSize(9);
                            x.CurrentPageNumber().FontSize(9);
                            x.Span(" / ").FontSize(9);
                            x.TotalPages().FontSize(9);
                            x.Span($" - Oluşturulma: {DateTime.Now:dd.MM.yyyy HH:mm}").FontSize(9);
                        });
                });
            });

            document.GeneratePdf(kayitYolu);
            return kayitYolu;
        }

        /// <summary>
        /// Film bazlı Excel formatında rapor oluşturur (EPPlus kütüphanesi kullanır)
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi</param>
        /// <param name="bitis">Bitiş tarihi</param>
        /// <param name="kayitYolu">Dosya kayıt yolu</param>
        /// <returns>Oluşturulan dosya yolu</returns>
        public async Task<string> FilmBazliExcelOlusturAsync(DateTime baslangic, DateTime bitis, string kayitYolu)
        {
            var veriler = await FilmBazliRaporVerileriGetirAsync(baslangic, bitis);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Film Bazlı Rapor");

                // Başlık
                worksheet.Cells["A1:F1"].Merge = true;
                worksheet.Cells["A1"].Value = "SİNEMACI - Film Bazlı Satış Raporu";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(41, 128, 185));
                worksheet.Cells["A1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                // Tarih Aralığı
                worksheet.Cells["A2:F2"].Merge = true;
                worksheet.Cells["A2"].Value = $"Tarih Aralığı: {baslangic:dd.MM.yyyy} - {bitis:dd.MM.yyyy}";
                worksheet.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Özet Bilgiler
                var toplamGelir = veriler.Sum(v => v.ToplamGelir);
                var toplamBilet = veriler.Sum(v => v.ToplamBiletSayisi);

                worksheet.Cells["A4"].Value = "Toplam Film Sayısı:";
                worksheet.Cells["B4"].Value = veriler.Count;
                worksheet.Cells["A5"].Value = "Toplam Bilet Satışı:";
                worksheet.Cells["B5"].Value = toplamBilet;
                worksheet.Cells["A6"].Value = "Toplam Gelir:";
                worksheet.Cells["B6"].Value = toplamGelir;
                worksheet.Cells["B6"].Style.Numberformat.Format = "#,##0.00 ₺";
                worksheet.Cells["A6:B6"].Style.Font.Bold = true;

                // Tablo başlıkları
                var headerRow = 8;
                worksheet.Cells[headerRow, 1].Value = "Film Adı";
                worksheet.Cells[headerRow, 2].Value = "Bilet Sayısı";
                worksheet.Cells[headerRow, 3].Value = "Seans Sayısı";
                worksheet.Cells[headerRow, 4].Value = "Toplam Gelir (₺)";
                worksheet.Cells[headerRow, 5].Value = "Ort. Bilet Fiyatı (₺)";
                worksheet.Cells[headerRow, 6].Value = "En Çok Satan Salon";

                // Header style
                using (var range = worksheet.Cells[headerRow, 1, headerRow, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(52, 152, 219));
                    range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }

                // Veriler
                int row = headerRow + 1;
                foreach (var veri in veriler)
                {
                    worksheet.Cells[row, 1].Value = veri.FilmAdi;
                    worksheet.Cells[row, 2].Value = veri.ToplamBiletSayisi;
                    worksheet.Cells[row, 3].Value = veri.SeansSayisi;
                    worksheet.Cells[row, 4].Value = veri.ToplamGelir;
                    worksheet.Cells[row, 4].Style.Numberformat.Format = "#,##0.00";
                    worksheet.Cells[row, 5].Value = veri.OrtalamaBiletFiyati;
                    worksheet.Cells[row, 5].Style.Numberformat.Format = "#,##0.00";
                    worksheet.Cells[row, 6].Value = veri.EnCokSatanSalon;
                    row++;
                }

                // Kolon genişlikleri
                worksheet.Column(1).Width = 30;
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 18;
                worksheet.Column(5).Width = 20;
                worksheet.Column(6).Width = 25;

                // Border
                var dataRange = worksheet.Cells[headerRow, 1, row - 1, 6];
                dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Dosyayı kaydet
                var file = new FileInfo(kayitYolu);
                package.SaveAs(file);
            }

            return kayitYolu;
        }

        /// <summary>
        /// Müşteri bazlı Excel formatında rapor oluşturur (EPPlus kütüphanesi kullanır)
        /// </summary>
        /// <param name="baslangic">Başlangıç tarihi</param>
        /// <param name="bitis">Bitiş tarihi</param>
        /// <param name="kayitYolu">Dosya kayıt yolu</param>
        /// <returns>Oluşturulan dosya yolu</returns>
        public async Task<string> MusteriBazliExcelOlusturAsync(DateTime baslangic, DateTime bitis, string kayitYolu)
        {
            var veriler = await MusteriBazliRaporVerileriGetirAsync(baslangic, bitis);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Müşteri Bazlı Rapor");

                // Başlık
                worksheet.Cells["A1:F1"].Merge = true;
                worksheet.Cells["A1"].Value = "SİNEMACI - Müşteri Bazlı Satış Raporu";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(46, 204, 113));
                worksheet.Cells["A1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                // Tarih Aralığı
                worksheet.Cells["A2:F2"].Merge = true;
                worksheet.Cells["A2"].Value = $"Tarih Aralığı: {baslangic:dd.MM.yyyy} - {bitis:dd.MM.yyyy}";
                worksheet.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Özet Bilgiler
                var toplamGelir = veriler.Sum(v => v.ToplamHarcama);
                var toplamBilet = veriler.Sum(v => v.ToplamBiletSayisi);

                worksheet.Cells["A4"].Value = "Toplam Müşteri Sayısı:";
                worksheet.Cells["B4"].Value = veriler.Count;
                worksheet.Cells["A5"].Value = "Toplam Bilet Satışı:";
                worksheet.Cells["B5"].Value = toplamBilet;
                worksheet.Cells["A6"].Value = "Toplam Gelir:";
                worksheet.Cells["B6"].Value = toplamGelir;
                worksheet.Cells["B6"].Style.Numberformat.Format = "#,##0.00 ₺";
                worksheet.Cells["A6:B6"].Style.Font.Bold = true;

                // Tablo başlıkları
                var headerRow = 8;
                worksheet.Cells[headerRow, 1].Value = "Müşteri Adı";
                worksheet.Cells[headerRow, 2].Value = "Email";
                worksheet.Cells[headerRow, 3].Value = "Bilet Sayısı";
                worksheet.Cells[headerRow, 4].Value = "Toplam Harcama (₺)";
                worksheet.Cells[headerRow, 5].Value = "İzlenen Film Sayısı";
                worksheet.Cells[headerRow, 6].Value = "En Çok İzlediği Film";

                // Header style
                using (var range = worksheet.Cells[headerRow, 1, headerRow, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(39, 174, 96));
                    range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }

                // Veriler
                int row = headerRow + 1;
                foreach (var veri in veriler)
                {
                    worksheet.Cells[row, 1].Value = veri.MusteriAdi;
                    worksheet.Cells[row, 2].Value = veri.Email;
                    worksheet.Cells[row, 3].Value = veri.ToplamBiletSayisi;
                    worksheet.Cells[row, 4].Value = veri.ToplamHarcama;
                    worksheet.Cells[row, 4].Style.Numberformat.Format = "#,##0.00";
                    worksheet.Cells[row, 5].Value = veri.IzlenenFilmSayisi;
                    worksheet.Cells[row, 6].Value = veri.EnCokIzledigiFilm;
                    row++;
                }

                // Kolon genişlikleri
                worksheet.Column(1).Width = 25;
                worksheet.Column(2).Width = 30;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 20;
                worksheet.Column(5).Width = 20;
                worksheet.Column(6).Width = 25;

                // Border
                var dataRange = worksheet.Cells[headerRow, 1, row - 1, 6];
                dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Dosyayı kaydet
                var file = new FileInfo(kayitYolu);
                package.SaveAs(file);
            }

            return kayitYolu;
        }
    }

    /// <summary>
    /// Film bazlı rapor detay bilgilerini tutan model sınıfı
    /// </summary>
    public class FilmRaporDetay
    {
        public string FilmAdi { get; set; } = string.Empty;
        public int ToplamBiletSayisi { get; set; }
        public decimal ToplamGelir { get; set; }
        public int SeansSayisi { get; set; }
        public decimal OrtalamaBiletFiyati { get; set; }
        public string EnCokSatanSalon { get; set; } = string.Empty;
    }

    /// <summary>
    /// Müşteri bazlı rapor detay bilgilerini tutan model sınıfı
    /// </summary>
    public class MusteriRaporDetay
    {
        public string MusteriAdi { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ToplamBiletSayisi { get; set; }
        public decimal ToplamHarcama { get; set; }
        public int IzlenenFilmSayisi { get; set; }
        public DateTime SonAlimTarihi { get; set; }
        public string EnCokIzledigiFilm { get; set; } = string.Empty;
    }
}
